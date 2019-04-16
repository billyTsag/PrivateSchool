using PrivateSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateSchool
{
    public static class TrainerMenu
    {
        public static void MainMenu()
        {
            Trainer TRAINER = new Trainer();
            bool login = false;
            while (true)
            {                     
                while (login == false)
                {
                    Console.Write("Username: ");
                    string username = Console.ReadLine();
                    TRAINER = TrainerManager.FindPassword(username);
                    Console.Write("Password: ");
                    string password = Console.ReadLine();
                    if (TRAINER == null)
                    {
                        Console.WriteLine("\nError: Username and Password do not match\n");
                    }
                    else if (PasswordHashing.Verify(password, TRAINER.Password) == true)
                    {
                        Console.WriteLine("Successfull login\n");
                        login = true;
                    }
                    else
                    {
                        Console.WriteLine("\nError: Username and Password do not match\n");
                    }
                }                

                Console.WriteLine($"\nWelcome {TRAINER}!");
                Console.WriteLine("What do you want to access?\n");
                Console.WriteLine("1. View all the Courses that you are enrolled");
                Console.WriteLine("2. View all the Students that are enrolled in your Courses");
                Console.WriteLine("3. View all the Assignments per Student per Course");
                Console.WriteLine("4. Mark all the Assignments per Student per Course");
                Console.WriteLine("0. Exit");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        {
                            Console.WriteLine("\nViewing all the Courses that you are enrolled...\n");                            
                            foreach (var trainer in TrainerEnrollmentManager.GetAllCoursesOfTrainer(TRAINER.ID))
                            {
                                Console.WriteLine(trainer);
                            }
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("\nViewing all the Students that are enrolled in your Courses...\n");                            
                            foreach (var student in TrainerEnrollmentManager.GetAllEnrolledStudentsOfTrainer(TRAINER.ID))
                            {
                                Console.WriteLine(student);
                            }
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine("Viewing all the Assignments per Student per Course...\n");
                            foreach (var student in TrainerEnrollmentManager.ViewAssignmentsPerStudent(TRAINER.ID))
                            {
                                Console.WriteLine(student);
                            }
                            break;                            
                        }
                    case "4":
                        {
                            Console.WriteLine("Viewing all the Assignments per Student per Course...\n");
                            foreach (var assignment in TrainerEnrollmentManager.ViewAssignmentsPerStudent(TRAINER.ID))
                            {
                                Console.WriteLine(assignment);
                            }
                            int studentID;
                            Console.WriteLine("Type the ID of a Student that you want to access");
                            bool valid = int.TryParse(Console.ReadLine(), out studentID);
                            while (valid == false)
                            {
                                Console.WriteLine("Invalid Input!");
                                Console.WriteLine("Type the ID of a Student that you want to access");
                                valid = int.TryParse(Console.ReadLine(), out studentID);
                            }
                            int assignmentID;
                            Console.WriteLine("Type the ID of a Assignment that you want to mark");
                            valid = int.TryParse(Console.ReadLine(), out assignmentID);
                            while (valid == false)
                            {
                                Console.WriteLine("Invalid Input!");
                                Console.WriteLine("Type the ID of a Assignment that you want to mark");
                                valid = int.TryParse(Console.ReadLine(), out assignmentID);
                            }
                            Console.Write("Oral Mark: ");
                            int oralMark;
                            valid = int.TryParse(Console.ReadLine(), out oralMark);
                            while (valid == false)
                            {
                                Console.WriteLine("Invalid Input!");
                                Console.Write("Oral Mark: ");
                                valid = int.TryParse(Console.ReadLine(), out oralMark);
                            }
                            Console.Write("Total Mark: ");
                            int totalMark;
                            valid = int.TryParse(Console.ReadLine(), out totalMark);
                            while (valid == false)
                            {
                                Console.WriteLine("Invalid Input!");
                                Console.Write("Total Mark: ");
                                valid = int.TryParse(Console.ReadLine(), out totalMark);
                            }
                            TrainerEnrollmentManager.MarkAssingmentPerStudent(TRAINER.ID, studentID, assignmentID, oralMark, totalMark);
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
