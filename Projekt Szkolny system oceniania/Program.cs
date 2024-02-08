using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Projekt_Szkolny_system_oceniania;

namespace Projekt_Szkolny_system_oceniania
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }
        public static void Menu()
        {
            /*List<Students> students = dbManager.RetrieveStudents();
            foreach (var student in students)
            {
                Console.WriteLine($"login: {student.StudentLogin}, password: {student.StudentPassword}");

                Console.WriteLine();
            }*/

            Console.WriteLine("Welcome to ESchool Grading System!");
            Console.WriteLine("Would you like to log in as Student, or Teacher ?");
            Console.WriteLine("Choose 1 to log in as Student");
            Console.WriteLine("Choose 2 to log in as Teacher");
            Console.WriteLine("To exit, type 'exit'");
            string response = "";
            while (response != "exit")
            {
                response = Console.ReadLine();
                switch (response.ToLower())
                {
                    case "exit":
                        Console.WriteLine();
                        break;
                    case "1":
                        Students.StudentsMenu();
                        break;
                    case "2":
                        Teacher.TeachersMenu();
                        break;
                }
            }
        }
        public static void Lists()
        {
            DatabaseManager dbManager = new DatabaseManager();
            List<Extensions> extensions = dbManager.RetrieveExtensions();
            List<Subject> subjects = dbManager.RetrieveSubjects();
            List<Classes> classes = dbManager.RetrieveClasses();
            List<Teacher> teachers = dbManager.RetrieveTeachers();
            List<SupervisingTeacher> supervisingTeachers = dbManager.RetrieveSupervisingTeachers();
            List<Students> students = dbManager.RetrieveStudents();
            List<Grade> grades = dbManager.RetrieveGrades();
            List<Presence> presence = dbManager.RetrievePresence();
        }
    }
}