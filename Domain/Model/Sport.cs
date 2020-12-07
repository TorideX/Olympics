using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Sport : Entity
    {
        protected Sport() { }
        public Sport(string name, Season season, string description = null, string imagePath = null)
        {
            Name = name;
            Season = season;
            Description = description;
            ImagePath = imagePath;
        }

        public override string ToString()
        {
            return $"{Name}({Season.ToString()[0]})";
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if(obj is Sport sport)
            {
                if (string.Equals(this.Name, sport.Name))
                    return true;
            }
            return false;
        }
        public static bool operator==(Sport a, Sport b)
        {
            if (object.ReferenceEquals(a, null))
            {
                return object.ReferenceEquals(b, null);
            }
            return a.Equals(b);
        }
        public static bool operator !=(Sport a, Sport b)
        {
            return !(a == b);
        }

        public string Name { get; protected set; }
        public Season Season { get; set; }
        public string Description { get; protected set; }
        public string ImagePath { get; set; }

    }
}
