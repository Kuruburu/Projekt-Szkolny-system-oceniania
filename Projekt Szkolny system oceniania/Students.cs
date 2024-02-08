using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Szkolny_system_oceniania
{
    public class Students : Person
    {
        

        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public string ClassName { get; set; }
        public string StudentLogin { get; set; }
        public string StudentPassword { get; set; }
        public Students(int studentID, string personName, string personSurName, string className, string studentLogin, string studentPassword) : base(personName, personSurName)
        {
            StudentID = studentID;
            StudentName = personName;
            StudentSurname = personSurName;
            ClassName = className;
            StudentLogin = studentLogin;
            StudentPassword = studentPassword;
        }
        public static void StudentsMenu()
        {
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
                    List<Students> students = dbManager.RetrieveStudents();
                    foreach (var student in students)
                    {
                        if (student.StudentLogin == response)
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
                                else if (password == student.StudentPassword)
                                {
                                    var studentid = student.StudentID;
                                    Console.WriteLine("Congrats!");
                                    Console.WriteLine("to exit, type 'exit'");
                                    Console.WriteLine("Choose 1 to show Grades");
                                    Console.WriteLine("Choose 2 to show avarage");
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
                                                List<Subject> subjects = dbManager.RetrieveSubjects();
                                                foreach (var grade in grades)
                                                {
                                                    if (studentid == grade.StudentID)
                                                    {
                                                        Console.WriteLine($"Ocena: {grade.GradeValue}\n ID przedmiotu: {grade.SubjectID}");
                                                    }
                                                }
                                                break;
                                            case "2":
                                                List<Grade> gradess = dbManager.RetrieveGrades();
                                                List<int> gradeArray = new List<int>();
                                                foreach(var grade in gradess)
                                                {
                                                    if (studentid == grade.StudentID)
                                                    {
                                                        gradeArray.Add(grade.GradeValue);
                                                    }
                                                }
                                                Console.WriteLine($"your avarage is {gradeArray.Average()}");
                                                break;
                                        }
                                    }

                                }
                                else { Console.WriteLine("Wrong Password"); }
                            }
                        }
                    }
                }               
            }
        }
    }
}
