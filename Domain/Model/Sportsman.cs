using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Sportsman : Entity
    {
        protected Sportsman() { }
        public Sportsman(string firstName, string lastName, DateTime birthDate, Country country, Sport sport)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Country = country;
            Sport = sport;
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj is Sportsman sportsman)
            {
                if (this.FirstName == sportsman.FirstName && this.LastName == sportsman.LastName &&
                    this.BirthDate == sportsman.BirthDate && this.Country == sportsman.Country &&
                    this.Sport == sportsman.Sport)
                    return true;
            }
            return false;
        }
        public static bool operator ==(Sportsman a, Sportsman b)
        {
            if (object.ReferenceEquals(a, null))
            {
                return object.ReferenceEquals(b, null);
            }
            return a.Equals(b);
        }
        public static bool operator !=(Sportsman a, Sportsman b)
        {
            return !(a == b);
        }

        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public DateTime BirthDate { get; protected set; }
        public virtual Country Country { get; protected set; }
        public virtual Sport Sport { get; protected set; }
    }
}
