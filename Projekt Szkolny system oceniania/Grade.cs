using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Szkolny_system_oceniania
{
    public class Grade
    {
        public int GradeID { get; set; }
        public int StudentID { get; set; }
        public int TeacherID { get; set; }
        public int SubjectID { get; set; }
        public int GradeValue { get; set; }
        public DateTime GradeDate { get; set; }

        public Grade(int gradeID, int studentID, int teacherID, int subjectID, int gradeValue, DateTime gradeDate)
        {
            GradeID = gradeID;
            StudentID = studentID;
            TeacherID = teacherID;
            SubjectID = subjectID;
            GradeValue = gradeValue;
            GradeDate = gradeDate;
        }
    }
}
