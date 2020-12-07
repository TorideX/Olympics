using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public enum MedalType
    {
        Bronze = 1,
        Silver,
        Gold
    }
    public class MedalSportsman : Entity
    {
        protected MedalSportsman() { }
        public MedalSportsman(Sportsman sportsman, MedalType medalType)
        {
            Sportsman = sportsman;
            MedalType = medalType;
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if(obj is MedalSportsman medal)
            {
                if (this.Sportsman == medal.Sportsman && this.MedalType == medal.MedalType)
                    return true;
            }
            return false;
        }
        public static bool operator ==(MedalSportsman a, MedalSportsman b)
        {
            if (object.ReferenceEquals(a, null))
            {
                return object.ReferenceEquals(b, null);
            }
            return a.Equals(b);
        }
        public static bool operator !=(MedalSportsman a, MedalSportsman b)
        {
            return !(a == b);
        }

        public virtual Sportsman Sportsman { get; protected set; }
        public MedalType MedalType { get; protected set; }

        public void ChangeMedalType(MedalType medalType)
        {
            MedalType = medalType;
        }
    }
}
