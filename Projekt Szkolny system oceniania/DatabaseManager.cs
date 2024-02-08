using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Szkolny_system_oceniania
{
    public class DatabaseManager
    {
        public const string ConnectionString = @"Data Source=LaptopFilip\SQLEXPRESS;Initial Catalog=ESchool_Grading_System;Integrated Security=True;";


        
        public List<Extensions> RetrieveExtensions()
        {
            List<Extensions> extensions = new List<Extensions>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                // Specify your SQL query to retrieve data from the "Extensions" table
                string query = "SELECT ExtensionID, ExtensionProfile, ExtendedSubjects FROM Extensions";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int extensionID = Convert.ToInt32(reader["ExtensionID"]);
                            string extensionProfile = reader["ExtensionProfile"].ToString();

                            // Parse the comma-separated list of subjects into a List<string>
                            List<string> extendedSubjects = reader["ExtendedSubjects"].ToString().Split(',').ToList();

                            // Create Extension object and add to the list
                            Extensions extension = new Extensions(extensionID, extensionProfile, extendedSubjects);
                            extensions.Add(extension);
                        }
                    }
                }
            }

            return extensions;
        }
        public List<Classes> RetrieveClasses()
        {
            List<Classes> classList = new List<Classes>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                // Specify your SQL query to retrieve data from the "Extensions" table
                string query = "SELECT ClassID, ClassName, ClassExtensionID FROM Classes";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int classID = Convert.ToInt32(reader["ClassID"]);
                            string className = reader["ClassName"].ToString();
                            int classExtensionID = Convert.ToInt32(reader["ClassExtensionID"]);

                            // Create Extension object and add to the list
                            Classes classes = new Classes(classID, className, classExtensionID);
                            classList.Add(classes);
                        }
                    }
                }
            }

            return classList;
        }
        public List<Students> RetrieveStudents()
        {
            List<Students> studentList = new List<Students>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT StudentID, StudentName, StudentSurname, ClassName, StudentLogin, StudentPassword FROM Students";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int studentID = Convert.ToInt32(reader["StudentID"]);
                            string studentName = reader["StudentName"].ToString();
                            string studentSurname = reader["StudentSurname"].ToString();
                            string className = reader["ClassName"].ToString();
                            string studentLogin = reader["StudentLogin"].ToString();
                            string studentPassword = reader["StudentPassword"].ToString();
                            Students students = new Students(studentID, studentName, studentSurname, className, studentLogin, studentPassword);
                            studentList.Add(students);
                        }
                    }
                }
            }

            return studentList;
        }
        public List<Teacher> RetrieveTeachers()
        {
            List<Teacher> teacherList = new List<Teacher>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT TeacherID, TeacherName, TeacherSurname, TeachingSubject, HireDate, ContactNumber, TeacherLogin, TeacherPassword FROM Teachers";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int teacherID = Convert.ToInt32(reader["TeacherID"]);
                            string teacherName = reader["TeacherName"].ToString();
                            string teacherSurname = reader["TeacherSurname"].ToString();
                            string teachingSubject = reader["TeachingSubject"].ToString();
                            DateTime hireDate = Convert.ToDateTime(reader["HireDate"]);
                            string contactNumber = reader["ContactNumber"].ToString();
                            string teacherLogin = reader["TeacherLogin"].ToString();
                            string teacherPassword = reader["TeacherPassword"].ToString();

                            Teacher teacher = new Teacher(teacherID, teacherName, teacherSurname, teachingSubject, hireDate, contactNumber, teacherLogin, teacherPassword);

                            teacherList.Add(teacher);
                        }
                    }
                }
            }

            return teacherList;
        }
        public List<SupervisingTeacher> RetrieveSupervisingTeachers()
        {
            List<SupervisingTeacher> supervisingTeacherList = new List<SupervisingTeacher>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT SupervisingTeacherID, TeacherID, ClassID FROM SupervisingTeacher";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int supervisingTeacherID = Convert.ToInt32(reader["SupervisingTeacherID"]);
                            int teacherID = Convert.ToInt32(reader["TeacherID"]);
                            int classID = Convert.ToInt32(reader["ClassID"]);

                            SupervisingTeacher supervisingTeacher = new SupervisingTeacher(supervisingTeacherID, teacherID, classID);

                            supervisingTeacherList.Add(supervisingTeacher);
                        }
                    }
                }
            }

            return supervisingTeacherList;
        }
        public List<Subject> RetrieveSubjects()
        {
            List<Subject> subjectList = new List<Subject>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT SubjectID, SubjectName FROM Subjects";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int subjectID = Convert.ToInt32(reader["SubjectID"]);
                            string subjectName = reader["SubjectName"].ToString();

                            Subject subject = new Subject(subjectID, subjectName);

                            subjectList.Add(subject);
                        }
                    }
                }
            }

            return subjectList;
        }
        public List<Presence> RetrievePresence()
        {
            List<Presence> presenceList = new List<Presence>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT PresenceID, StudentID, PresenceDate, PresenceStatus FROM Presence";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int presenceID = Convert.ToInt32(reader["PresenceID"]);
                            int studentID = Convert.ToInt32(reader["StudentID"]);
                            DateTime presenceDate = Convert.ToDateTime(reader["PresenceDate"]);
                            string presenceStatus = reader["PresenceStatus"].ToString();

                            Presence presence = new Presence(presenceID, studentID, presenceDate, presenceStatus);

                            presenceList.Add(presence);
                        }
                    }
                }
            }

            return presenceList;
        }
        public List<Grade> RetrieveGrades()
        {
            List<Grade> gradeList = new List<Grade>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT GradeID, StudentID, TeacherID, SubjectID, Grade, GradeDate FROM Grades";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int gradeID = Convert.ToInt32(reader["GradeID"]);
                            int studentID = Convert.ToInt32(reader["StudentID"]);
                            int teacherID = Convert.ToInt32(reader["TeacherID"]);
                            int subjectID = Convert.ToInt32(reader["SubjectID"]);
                            int gradeValue = Convert.ToInt32(reader["Grade"]);
                            DateTime gradeDate = Convert.ToDateTime(reader["GradeDate"]);

                            Grade grade = new Grade(gradeID, studentID, teacherID, subjectID, gradeValue, gradeDate);

                            gradeList.Add(grade);
                        }
                    }
                }
            }

            return gradeList;
        }
    }
}
