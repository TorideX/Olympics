using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Event : Entity
    {
        protected Event() { }
        public Event(Sport sport)
        {
            Sport = sport;
            Participants = new List<Participant>();
        }

        public override string ToString()
        {
            return $"{Sport}, {Olympiad}";
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj is Event evnt)
            {
                if (this.Sport == evnt.Sport)
                    return true;
            }
            return false;
        }
        public static bool operator ==(Event a, Event b)
        {
            if (object.ReferenceEquals(a, null))
            {
                return object.ReferenceEquals(b, null);
            }
            return a.Equals(b);
        }
        public static bool operator !=(Event a, Event b)
        {
            return !(a == b);
        }

        public Sport Sport { get; protected set; }
        public virtual ICollection<Participant> Participants { get; protected set; }
        public virtual Olympiad Olympiad { get; set; }

        public void ChangeSport(Sport sport)
        {
            
            Sport = sport;
        }
        public bool RegisterParticipant(Participant participant)
        {
            if(Participants.Contains(participant))
            {
                return false;
            }
            Participants.Add(participant);
            return true;
        }
        public bool RemoveParticipant(Participant participant)
        {
            if(Participants.Contains(participant))
            {
                Participants.Remove(participant);
                return true;
            }
            return false;
        }
    }
}
