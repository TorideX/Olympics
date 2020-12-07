using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public enum Season
    {
        Summer = 1,
        Winter = 2
    }
    public class Olympiad : Entity
    {
        protected Olympiad() { }
        public Olympiad(int year, Season season, Country host, string city, string imagePath)
        {
            if (ChangeYear(year) == false) throw new ArgumentException("Year is not valid");
            if (ChangeCity(city) == false) throw new ArgumentNullException("City is null or empty");
            Season = season;
            Host = host;
            ImagePath = imagePath;

            Events = new List<Event>();
        }

        public override string ToString()
        {
            return $"{Season.ToString()} {City} {Year}, {Host}";
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj is Olympiad olymp)
            {
                if (this.Id == olymp.Id)
                    return true;
            }
            return false;
        }

        public int Year { get; protected set; }
        public Season Season { get; protected set; }
        public virtual Country Host { get; protected set; }
        public string City { get; protected set; }
        public string ImagePath { get; protected set; }
        public virtual ICollection<Event> Events { get; protected set; }

        public static bool IsValidYear(int year)
        {
            if (year >= 1896 && year < 3000)
                return true;
            return false;
        }

        public bool ChangeCity(string city)
        {
            if (string.IsNullOrEmpty(city))
                return false;
            City = city;
            return true;
        }
        public bool ChangeYear(int year)
        {
            if (year >= 1896 && year < 3000)
            {
                Year = year;
                return true;
            }
            return false;
        }
        public bool RegisterEvent(Event _event)
        {
            if(!Events.Contains(_event))
            {
                Events.Add(_event);
                return true;
            }
            return false;
        }
    }
}
