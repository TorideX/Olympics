using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Participant : Entity
    {
        protected Participant() { }
        public Participant(Country country)
        {
            Country = country;
            Sportsmen = new List<Sportsman>();
            Medals = new List<MedalSportsman>();
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj is Participant participant)
            {
                if (this.Country == participant.Country)
                    return true;
            }
            return false;
        }
        public static bool operator ==(Participant a, Participant b)
        {
            if (object.ReferenceEquals(a, null))
            {
                return object.ReferenceEquals(b, null);
            }
            return a.Equals(b);
        }
        public static bool operator !=(Participant a, Participant b)
        {
            return !(a == b);
        }
        public override string ToString()
        {
            return $"{Country}";
        }

        public  Country Country { get; protected set; }
        public virtual ICollection<Sportsman> Sportsmen { get; protected set; }
        public virtual ICollection<MedalSportsman> Medals { get; protected set; }
        public virtual Event Event { get; set; }

        public bool RegisterSportsman(Sportsman sportsman)
        {
            if(Sportsmen.Contains(sportsman))
            {
                return false;
            }
            Sportsmen.Add(sportsman);
            return true;
        }
        public bool RemoveSportsman(Sportsman sportsman)
        {
            if(Sportsmen.Contains(sportsman))
            {
                if (Medals.Any(m => m.Sportsman == sportsman))
                    throw new Exception($"{sportsman} can not be removed because he/she has involved in a competition");
                else
                {
                    Sportsmen.Remove(sportsman);
                    return true;
                }
            }
            return false;
        }
        public bool AddMedalToSportsman(Sportsman sportsman, MedalType medalType)
        {
            var newMedal = new MedalSportsman(sportsman, medalType);
            if(Medals.Contains(newMedal))
            {
                return false;
            }
            Medals.Add(newMedal);
            return true;
        }
        public void RemoveMedalToSportsman(Sportsman sportsman)
        {
            Medals.Remove(Medals.FirstOrDefault(m => m.Sportsman == sportsman));
        }
        public void ChangeSportsmanMedal(Sportsman sportsman, MedalType medalType)
        {
            Medals.FirstOrDefault(m => m.Sportsman == sportsman).ChangeMedalType(medalType);
        }
    }
}
