using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Szkolny_system_oceniania
{
    public class SupervisingTeacher
    {
        public int SupervisingTeacherID { get; set; }
        public int TeacherID { get; set; }
        public int ClassID { get; set; }

        public SupervisingTeacher(int supervisingTeacherID, int teacherID, int classID)
        {
            SupervisingTeacherID = supervisingTeacherID;
            TeacherID = teacherID;
            ClassID = classID;
        }
    }
}
