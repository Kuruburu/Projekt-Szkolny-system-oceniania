using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Szkolny_system_oceniania
{
    public class Teacher : Person
    {
        public int TeacherID { get; set; }
        public string TeacherName { get; set; }
        public string TeacherSurname { get; set; }
        public string TeachingSubject { get; set; }
        public DateTime HireDate { get; set; }
        public string ContactNumber { get; set; }
        public string TeacherLogin { get; set; }
        public string TeacherPassword { get; set; }


        // Konstruktor
        public Teacher(int teacherID, string personName, string personSurName, string teachingSubject,
                       DateTime hireDate, string contactNumber, string teacherLogin, string teacherPassword) : base(personName, personSurName)
        {
            TeacherID = teacherID;
            TeacherName = personName;
            TeacherSurname = personSurName;
            TeachingSubject = teachingSubject;
            HireDate = hireDate;
            ContactNumber = contactNumber;
            TeacherLogin = teacherLogin;
            TeacherPassword = teacherPassword;
        }
        public static void TeachersMenu()
        {
            const string ConnectionString = @"Data Source=LaptopFilip\SQLEXPRESS;Initial Catalog=ESchool_Grading_System;Integrated Security=True;";
            Console.WriteLine("What is your login?");
            Console.WriteLine("to exit, type 'exit'");
            string response = "";
            while (response != "exit")
            {
                response = Console.ReadLine();
                if (response == "exit")
                {
                    Program.Menu();
                }
                else
                {
                    DatabaseManager dbManager = new DatabaseManager();
                    List<Teacher> teachers = dbManager.RetrieveTeachers();
                    foreach (var teacher in teachers)
                    {
                        if (teacher.TeacherLogin == response)
                        {
                            Console.WriteLine("enter password");
                            string password = "";
                            while (password != "exit")
                            {
                                password = Console.ReadLine();
                                if (password == "exit")
                                {
                                    Program.Menu();
                                }
                                else if (password == teacher.TeacherPassword)
                                {
                                    var teacherid = teacher.TeacherID;
                                    Console.WriteLine("Congrats!");
                                    Console.WriteLine("to exit, type 'exit'");
                                    Console.WriteLine("Choose 1 to place Grade");
                                    Console.WriteLine("Choose 2 to remove student");
                                    Console.WriteLine("Choose 3 to update grade");
                                    while (response != "exit")
                                    {
                                        response = Console.ReadLine();
                                        switch (response.ToLower())
                                        {
                                            case "exit":
                                                Program.Menu();
                                                break;
                                            case "1":
                                                List<Grade> grades = dbManager.RetrieveGrades();
                                                List<Classes> classes = dbManager.RetrieveClasses();
                                                List<SupervisingTeacher> supervisingTeachers = dbManager.RetrieveSupervisingTeachers();
                                                List<Students> students = dbManager.RetrieveStudents();
                                                //List<Grade> grades = dbManager.RetrieveGrades();
                                                List<Subject> subjects = dbManager.RetrieveSubjects();
                                                List<Presence> presence = dbManager.RetrievePresence();
                                                Console.WriteLine("Which student would you like to put grade to(Write ID of the student)?");
                                                string putGrade = Console.ReadLine();
                                                while (putGrade != "exit")
                                                {
                                                    int intPutGrade = Int32.Parse(putGrade);
                                                    if (intPutGrade <= students.Count())
                                                    {
                                                        int studentGradeId = intPutGrade;
                                                        Console.WriteLine("what is subjectID?");
                                                        var subjectId = Console.ReadLine();
                                                        int intSubjectId = Int32.Parse(subjectId);
                                                        if (intSubjectId <= subjects.Count())
                                                        {
                                                            int subjectGradeId = intSubjectId;
                                                            Console.WriteLine("what grade would you like to put?");
                                                            var grade = Console.ReadLine();
                                                            int intgrade = Int32.Parse(grade);
                                                            if (intgrade > 0 & intgrade < 6)
                                                            {
                                                                int finalGrade = intgrade;
                                                                //ConnectionString = @"Data Source=LaptopFilip\SQLEXPRESS;Initial Catalog=ESchool_Grading_System;Integrated Security=True;";
                                                                using (SqlConnection connection = new SqlConnection(ConnectionString))
                                                                {
                                                                    connection.Open();
                                                                    string query = "INSERT INTO Grades (StudentID, TeacherID, SubjectID, Grade, GradeDate) values (@studentGradeId, @teacherid, @subjectGradeId, @finalGrade, CURRENT_TIMESTAMP)";
                                                                    using (SqlCommand command = new SqlCommand(query, connection))
                                                                    {
                                                                        command.Parameters.AddWithValue("@studentGradeId", studentGradeId);
                                                                        command.Parameters.AddWithValue("@teacherid", teacherid);
                                                                        command.Parameters.AddWithValue("@subjectGradeId", subjectGradeId);
                                                                        command.Parameters.AddWithValue("@finalGrade", finalGrade);

                                                                        command.ExecuteNonQuery();
                                                                    }
                                                                    putGrade = "exit";
                                                                }
                                                            }
                                                            else { Console.WriteLine("Incorrect grade"); }
                                                        }
                                                        else { Console.WriteLine("incorrect subjectID"); }
                                                    }
                                                    else { Console.WriteLine("icnorrect id"); }
                                                }
                                                break;
                                            case "2":
                                                List<Students> studentss = dbManager.RetrieveStudents();
                                                bool validInput = false;
                                                while(!validInput)
                                                {
                                                    Console.WriteLine("Which student would you like to remove (ID)?");
                                                    string removeStudentInput = Console.ReadLine();

                                                    if (int.TryParse(removeStudentInput, out int studentId))
                                                    {
                                                        if(studentId <= studentss.Count() && studentId > 0)
                                                        {
                                                            Console.WriteLine($"Removing student with ID {studentId}.");
                                                            using (SqlConnection connection = new SqlConnection(ConnectionString))
                                                            {
                                                                connection.Open();
                                                                string query = "DELETE FROM Grades WHERE StudentID = @StudentID\r\n DELETE FROM Presence where StudentID = @StudentID\r\n\r\nDELETE FROM STUDENTS where StudentID = @StudentID";
                                                                using (SqlCommand command = new SqlCommand(query, connection))
                                                                {
                                                                    command.Parameters.AddWithValue("@StudentID", studentId);

                                                                    command.ExecuteNonQuery();
                                                                }
                                                            }
                                                            validInput = true;
                                                        }
                                                        else { Console.WriteLine("Incorrect ID"); }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Incorrect ID, please enter a valid integer.");
                                                    }
                                                }

                                                

                                                break;
                                            case "3":
                                                List<Grade> gradess = dbManager.RetrieveGrades();
                                                List<Students> studentsss = dbManager.RetrieveStudents();
                                                List<Subject> subjectss = dbManager.RetrieveSubjects();
                                                Console.WriteLine("What is the ID of grade?");
                                                string gradeID = Console.ReadLine();
                                                while (gradeID != "exit")
                                                {
                                                    int GradeID = Convert.ToInt32(gradeID);
                                                    Console.WriteLine("what grade would you like to put");
                                                    string grade = Console.ReadLine();
                                                    int Grade = Convert.ToInt32(grade);

                                                    using (SqlConnection connection = new SqlConnection(ConnectionString))
                                                    {
                                                        connection.Open();
                                                        string query = "UPDATE Grades SET TeacherID = @teacherid, Grade = @NewGrade ,GradeDate = GETDATE() WHERE GradeID = @GradeID";
                                                        using (SqlCommand command = new SqlCommand(query, connection))
                                                        {
                                                            command.Parameters.AddWithValue("@NewGrade", Grade);
                                                            command.Parameters.AddWithValue("@teacherid", teacherid);
                                                            command.Parameters.AddWithValue("@GradeID", GradeID);

                                                            command.ExecuteNonQuery();
                                                        }
                                                        putGrade = "exit";
                                                    }
                                                    Console.WriteLine("grade updated");
                                                    gradeID = "exit";
                                                    response = "exit";
                                                }
                                                break;
                                        }
                                    }

                                }
                                else { Console.WriteLine("Wrong Password"); }
                            }
                        }
                        Console.WriteLine();
                    }
                }

            }
        }
    }
}
