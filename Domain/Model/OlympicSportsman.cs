using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class OlympicSportsman : Entity
    {
        public string FistName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public virtual Country Country { get; set; }
        public string PicturePath { get; set; }
        public virtual ICollection<Sport> Sports { get; set; }
        public int ParticipantId { get; set; }
        public Participant Participant { get; set; }
    }
}
