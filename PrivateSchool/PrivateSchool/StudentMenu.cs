using PrivateSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateSchool
{
    public static class StudentMenu
    {
        public static void MainMenu()
        {
            Student STUDENT = new Student();
            bool login = false;
            while (true)
            {
                while (login == false)
                {
                    Console.Write("Username: ");
                    string username = Console.ReadLine();
                    STUDENT = StudentManager.FindPassword(username);
                    Console.Write("Password: ");
                    string password = Console.ReadLine();
                    if (STUDENT == null)
                    {
                        Console.WriteLine("\nError: Username and Password do not match\n");
                    }
                    else if (PasswordHashing.Verify(password, STUDENT.Password) == true)
                    {
                        Console.WriteLine("Successfull login\n");
                        login = true;
                    }
                    else
                    {
                        Console.WriteLine("\nError: Username and Password do not match\n");
                    }
                }

                Console.WriteLine($"Welcome {STUDENT}!");
                Console.WriteLine("What do you want to access?\n");
                Console.WriteLine("1. Enroll to a Course");
                Console.WriteLine("2. View your daily Schedule per Course");
                Console.WriteLine("3. View the dates of submission of the Assignments per Course");
                Console.WriteLine("4. Submit an Assignment");
                Console.WriteLine("0. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        {
                            Console.WriteLine("Viewing all Courses...\n");
                            foreach (var course in CourseManager.GetAllCourses())
                            {
                                Console.WriteLine(course);
                            }
                            Console.WriteLine("Select a Course that you want to enroll to");
                            int courseID = int.Parse(Console.ReadLine());
                            Console.Write("Tuition Fees: ");
                            int tuitionFees = int.Parse(Console.ReadLine());
                            StudentEnrollmentManager.EnrollStudent(STUDENT.ID, courseID, tuitionFees);
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("Viewing the dates of submission of the Assignments per Course");
                            AssignmentCourseManager.ScheduleOfStudent(STUDENT.ID);
                            // des tin methodo
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine("Viewing the dates of submission of the Assignments per Course");
                            AssignmentCourseManager.DateSubmissionOfAssignment(STUDENT.ID);
                            // des tin methodo
                            break;
                        }
                    case "4":
                        {
                            Console.WriteLine("Submitting an Assignment...\n");
                            foreach (var assignment in AssignmentManager.GetAllAssignments())
                            {
                                Console.WriteLine(assignment);
                            }
                            Console.WriteLine("Select an Assignment");
                            int assignmentID;
                            bool valid = int.TryParse(Console.ReadLine(), out assignmentID);
                            while (valid == false)
                            {
                                Console.WriteLine("Invalid Input!");
                                Console.WriteLine("\nType the ID of the Assignment you want to submit!");
                                valid = int.TryParse(Console.ReadLine(), out assignmentID);
                            }
                            StudentEnrollmentManager.SubmitAnAssignment(STUDENT.ID, assignmentID);
                            break;
                        }
                    case "0":
                        {
                            Environment.Exit(0);
                            break;
                        }
                    default:
                        break;
                }
            }            
        }
    }
}
