using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateSchool
{
    public static class HMTrainerMenu
    {
        public static void Menu()
        {
            bool back = false;
            while (back == false)
            {
                Console.WriteLine("1. Create a Trainer");
                Console.WriteLine("2. Create/Update Username/Password for a Trainer");
                Console.WriteLine("3. View all Trainers");
                Console.WriteLine("4. Delete a Trainer");
                Console.WriteLine("5. Update a Trainer");
                Console.WriteLine("6. Enroll a Trainer to a Course");
                Console.WriteLine("7. View all Trainers that are enrolled to Courses");
                Console.WriteLine("8. Update the enrollment of a Trainer");
                Console.WriteLine("9. Delete the enrollment of a Trainer");
                Console.WriteLine("0. Go Back");
                string choice = Console.ReadLine();
                Console.Clear();
                switch (choice)
                {
                    case "1":
                        {
                            Console.WriteLine("Add a Trainer!");
                            Console.Write("First Name: ");
                            string firstName = Console.ReadLine();
                            Console.Write("Last Name: ");
                            string lastName = Console.ReadLine();
                            int id = TrainerManager.CreateTrainer(firstName, lastName);
                            Console.WriteLine($"\nTrainer: {firstName} {lastName} created with ID: {id}\n");
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("Creating Login Information");
                            Console.WriteLine("Viewing all Trainers...");
                            foreach (var trainer in TrainerManager.GetAllTrainers())
                            {
                                Console.WriteLine(trainer);
                            }
                            Console.WriteLine("\nType the ID of a Trainer that you want to access");
                            int trainerID;
                            bool valid = int.TryParse(Console.ReadLine(), out trainerID);
                            while (valid == false)
                            {
                                Console.WriteLine("Invalid Input!");
                                Console.WriteLine("\nType the ID of a Trainer that you want to access");
                                valid = int.TryParse(Console.ReadLine(), out trainerID);
                            }
                            Console.Write("Username: ");
                            string username = Console.ReadLine();
                            Console.Write("Password: ");
                            string password = Console.ReadLine();
                            string hashedPassword = PasswordHashing.Hash(password);
                            TrainerManager.CreateAccount(trainerID, username, hashedPassword);
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine("Viewing all Trainers...\n");
                            foreach (var trainer in TrainerManager.GetAllTrainers())
                            {
                                Console.WriteLine(trainer);
                            }
                            break;
                        }
                    case "4":
                        {
                            Console.WriteLine("Viewing all Trainers...\n");
                            foreach (var trainer in TrainerManager.GetAllTrainers())
                            {
                                Console.WriteLine(trainer);
                            }
                            Console.WriteLine("\nType the ID of the Trainer you want to delete!");
                            int trainerID;
                            bool valid = int.TryParse(Console.ReadLine(), out trainerID);
                            while (valid == false)
                            {
                                Console.WriteLine("Invalid Input!");
                                Console.WriteLine("\nType the ID of the Trainer you want to delete!");
                                valid = int.TryParse(Console.ReadLine(), out trainerID);
                            }
                            TrainerManager.DeleteTrainer(trainerID);
                            break;
                        }
                    case "5":
                        {
                            Console.WriteLine("Update a Trainer!");
                            Console.WriteLine("Viewing all Trainers...\n");
                            foreach (var trainer in TrainerManager.GetAllTrainers())
                            {
                                Console.WriteLine(trainer);
                            }
                            Console.WriteLine("\nType the ID of the Trainer you want to update!");
                            int trainerID;
                            bool valid = int.TryParse(Console.ReadLine(), out trainerID);
                            while (valid == false)
                            {
                                Console.WriteLine("Invalid Input!");
                                Console.WriteLine("\nType the ID of the Trainer you want to delete!");
                                valid = int.TryParse(Console.ReadLine(), out trainerID);
                            }
                            Console.Write("First Name: ");
                            string firstName = Console.ReadLine();
                            Console.Write("Last Name: ");
                            string lastName = Console.ReadLine();                            
                            TrainerManager.UpdateTrainer(trainerID, firstName, lastName);
                            break;
                        }
                    case "6":
                        {
                            Console.WriteLine("Viewing all Trainers...\n");
                            foreach (var trainer in TrainerManager.GetAllTrainers())
                            {
                                Console.WriteLine(trainer);
                            }
                            Console.WriteLine("Select a Trainer");
                            int trainerID;
                            bool valid = int.TryParse(Console.ReadLine(), out trainerID);
                            while (valid == false)
                            {
                                Console.WriteLine("Invalid Input!");
                                Console.WriteLine("Select a Trainer");
                                valid = int.TryParse(Console.ReadLine(), out trainerID);
                            }
                            Console.WriteLine("Viewing all Courses...\n");
                            foreach (var course in CourseManager.GetAllCourses())
                            {
                                Console.WriteLine(course);
                            }
                            int courseID;
                            valid = int.TryParse(Console.ReadLine(), out courseID);
                            while (valid == false)
                            {
                                Console.WriteLine("Invalid Input!");
                                Console.WriteLine("Select a Trainer");
                                valid = int.TryParse(Console.ReadLine(), out courseID);
                            }
                            Console.Write("Subject: ");
                            string subject = Console.ReadLine();
                            TrainerEnrollmentManager.EnrollTrainer(trainerID, courseID, subject);
                            break;
                        }
                    case "7":
                        {
                            Console.WriteLine("Viewing all Trainers and their respective Courses...\n");
                            foreach (var trainer in TrainerEnrollmentManager.GetAllEnrolledTrainers())
                            {
                                Console.WriteLine(trainer);
                            }
                            break;
                        }
                    case "8":
                        {
                            Console.WriteLine("Update the enrollment of a Trainer");
                            Console.WriteLine("Viewing all Trainers and their respective Courses...");
                            foreach (var trainer in TrainerEnrollmentManager.GetAllEnrolledTrainers())
                            {
                                Console.WriteLine(trainer);
                            }
                            Console.WriteLine("Select a Trainer");
                            int trainerID;
                            bool valid = int.TryParse(Console.ReadLine(), out trainerID);
                            while (valid == false)
                            {
                                Console.WriteLine("Invalid Input!");
                                Console.WriteLine("Select a Trainer");
                                valid = int.TryParse(Console.ReadLine(), out trainerID);
                            }
                            Console.WriteLine("Select a Course that he is already enrolled");
                            int courseID;
                            valid = int.TryParse(Console.ReadLine(), out courseID);
                            while (valid == false)
                            {
                                Console.WriteLine("Invalid Input!");
                                Console.WriteLine("Select a Trainer");
                                valid = int.TryParse(Console.ReadLine(), out courseID);
                            }
                            Console.Write("Subject: ");
                            string subject = Console.ReadLine();
                            TrainerEnrollmentManager.UpdateEnrolledTrainer(trainerID, courseID, subject);
                            break;
                        }
                    case "9":
                        {
                            Console.WriteLine("Delete the enrollment of a Trainer");
                            Console.WriteLine("Viewing all Trainers and their respective Courses...");
                            foreach (var trainer in TrainerEnrollmentManager.GetAllEnrolledTrainers())
                            {
                                Console.WriteLine(trainer);
                            }
                            Console.WriteLine("Select a Trainer");
                            int trainerID;
                            bool valid = int.TryParse(Console.ReadLine(), out trainerID);
                            while (valid == false)
                            {
                                Console.WriteLine("Invalid Input!");
                                Console.WriteLine("Select a Trainer");
                                valid = int.TryParse(Console.ReadLine(), out trainerID);
                            }
                            Console.WriteLine("Select a Course that he is already enrolled");
                            int courseID;
                            valid = int.TryParse(Console.ReadLine(), out courseID);
                            while (valid == false)
                            {
                                Console.WriteLine("Invalid Input!");
                                Console.WriteLine("Select a Trainer");
                                valid = int.TryParse(Console.ReadLine(), out courseID);
                            }
                            TrainerEnrollmentManager.DeleteEnrolledTrainer(trainerID, courseID);
                            break;
                        }
                    case "0":
                        {
                            back = true;
                            break;
                        }
                    default:
                        break;
                }
            }            
        }
    }
}
