using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Szkolny_system_oceniania
{
    public class Presence
    {
        public int PresenceID { get; set; }
        public int StudentID { get; set; }
        public DateTime PresenceDate { get; set; }
        public string PresenceStatus { get; set; }

        public Presence(int presenceID, int studentID, DateTime presenceDate, string presenceStatus)
        {
            PresenceID = presenceID;
            StudentID = studentID;
            PresenceDate = presenceDate;
            PresenceStatus = presenceStatus;
        }
    }
}
