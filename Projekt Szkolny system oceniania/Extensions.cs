using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Szkolny_system_oceniania
{
    public class Extensions
    {

        public int ExtensionID { get; set; }
        public string ExtensionProfile { get; set; }
        public List<string> ExtendedSubjects { get; set;}
        public Extensions(int extensionID, string extensionProfile, List<string> extendedSubjects)
        {
            ExtensionID = extensionID;
            ExtensionProfile = extensionProfile;
            ExtendedSubjects = extendedSubjects;
        }
    }
}
