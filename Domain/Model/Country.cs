using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Country : Entity
    {
        protected Country() { }
        public Country(string name, string imagePath = null)
        {
            Name = name;
            ImagePath = imagePath;
        }
        public override string ToString()
        {
            return $"{Name}";
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj is Country country)
            {
                if (this.Name == country.Name)
                    return true;
            }
            return false;
        }
        public static bool operator ==(Country a, Country b)
        {
            if (object.ReferenceEquals(a, null))
            {
                return object.ReferenceEquals(b, null);
            }
            return a.Equals(b);
        }
        public static bool operator !=(Country a, Country b)
        {
            return !(a == b);
        }

        public string Name { get; protected set; }
        public string ImagePath { get; set; }
    }
}
