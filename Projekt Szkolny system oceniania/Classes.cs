using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Szkolny_system_oceniania
{
    public class Classes
    {

        public int ClassID { get; set; }
        public string ClassName { get; set; }
        public int ClassExtensionID { get; set; }

        public Classes(int classID, string className, int classExtensionID)
        {
            ClassID = classID;
            ClassName = className;
            ClassExtensionID = classExtensionID;
        }

    }
}
