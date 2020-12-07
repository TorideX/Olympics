using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public enum MedalType
    {
        Bronze,
        Silver,
        Gold
    }
    public class Medal : Entity
    {
        public int ParticipantId { get; set; }
        public Participant Participant { get; set; }
        public virtual OlympicSportsman Sportsman { get; set; }
        public MedalType MedalType { get; set; }
    }
}
