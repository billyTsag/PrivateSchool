using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateSchool
{
    public static class HMCourseMenu
    {
        public static void Menu()
        {
            bool back = false;
            while (back == false)
            {
                Console.WriteLine("\n1. Create a Course");
                Console.WriteLine("2. View all Courses");
                Console.WriteLine("3. Delete a Course");
                Console.WriteLine("4. Update a Course");
                Console.WriteLine("5. Create a Schedule for a Course");
                Console.WriteLine("6. Update a Schedule for a Course");
                Console.WriteLine("7. Delete a Schedule for a Course");
                Console.WriteLine("8. View all Schedules per Course");
                Console.WriteLine("9. Enroll a Student to a Course");
                Console.WriteLine("10. Enroll a Trainer to a Course");
                Console.WriteLine("0. Go Back");
                string choice = Console.ReadLine();
                Console.Clear();
                switch (choice)
                {
                    case "1":
                        {
                            Console.WriteLine("Add a Course");
                            Console.Write("Title: ");
                            string title = Console.ReadLine();
                            Console.Write("Stream: ");
                            string stream = Console.ReadLine();
                            Console.Write("Type: ");
                            string type = Console.ReadLine();                            
                            int id = CourseManager.CreateCourse(title, stream, type);
                            Console.WriteLine($"Course {title} created with ID: {id}");
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("Viewing all Courses...\n");
                            foreach (var course in CourseManager.GetAllCourses())
                            {
                                Console.WriteLine(course);
                            }
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine("Viewing all Courses...\n");
                            foreach (var course in CourseManager.GetAllCourses())
                            {
                                Console.WriteLine(course);
                            }
                            Console.WriteLine("\nType the ID of the Course you want to delete!");
                            int id;
                            bool valid = int.TryParse(Console.ReadLine(), out id);
                            while (valid == false)
                            {
                                Console.WriteLine("Invalid Input!");
                                Console.WriteLine("\nType the ID of the Course you want to delete!");
                                valid = int.TryParse(Console.ReadLine(), out id);

                            }                            
                            CourseManager.DeleteCourse(id);
                            break;
                        }
                    case "4":
                        {
                            Console.WriteLine("Update a Course!");
                            Console.WriteLine("Viewing all Courses...\n");
                            foreach (var course in CourseManager.GetAllCourses())
                            {
                                Console.WriteLine(course);
                            }
                            Console.WriteLine("\nType the ID of the Course you want to update!");
                            int id;
                            bool valid = int.TryParse(Console.ReadLine(), out id);
                            while (valid == false)
                            {
                                Console.WriteLine("Invalid Input!");
                                Console.WriteLine("\nType the ID of the Course you want to delete!");
                                valid = int.TryParse(Console.ReadLine(), out id);

                            }                            
                            Console.Write("Title: ");
                            string title = Console.ReadLine();
                            Console.Write("Stream: ");
                            string stream = Console.ReadLine();
                            Console.Write("Type: ");
                            string type = Console.ReadLine();                            
                            CourseManager.UpdateCourse(id, title, stream, type);
                            break;
                        }
                    case "5":
                        {
                            Console.WriteLine("Create a Schedule!");
                            Console.WriteLine("Viewing all Courses...\n");
                            foreach (var course in CourseManager.GetAllCourses())
                            {
                                Console.WriteLine(course);
                            }
                            Console.WriteLine("\nType the ID of the Course you want to update!");
                            int id;
                            bool valid = int.TryParse(Console.ReadLine(), out id);
                            while (valid == false)
                            {
                                Console.WriteLine("Invalid Input!");
                                Console.WriteLine("\nType the ID of the Course you want to delete!");
                                valid = int.TryParse(Console.ReadLine(), out id);

                            }                            
                            Console.Write("Start Date(day/month/year): ");
                            DateTime startDate;
                            valid = DateTime.TryParse(Console.ReadLine(), out startDate);
                            while (valid == false)
                            {
                                Console.Write("Start Date(day/month/year): ");
                                valid = DateTime.TryParse(Console.ReadLine(), out startDate);
                            }
                            Console.Write("End Date(day/month/year): ");
                            DateTime endDate;
                            valid = DateTime.TryParse(Console.ReadLine(), out endDate);
                            while (valid == false)
                            {
                                Console.Write("End Date(day/month/year): ");
                                valid = DateTime.TryParse(Console.ReadLine(), out endDate);
                            }
                            ScheduleCourseManager.CreateSchedule(id, startDate, endDate);
                            break;
                        }
                    case "6":
                        {
                            Console.WriteLine("Update a Schedule!");
                            Console.WriteLine("Viewing all Courses...\n");
                            foreach (var course in CourseManager.GetAllCourses())
                            {
                                Console.WriteLine(course);
                            }
                            Console.WriteLine("\nType the ID of the Course you want to update!");
                            int id;
                            bool valid = int.TryParse(Console.ReadLine(), out id);
                            while (valid == false)
                            {
                                Console.WriteLine("Invalid Input!");
                                Console.WriteLine("\nType the ID of the Course you want to delete!");
                                valid = int.TryParse(Console.ReadLine(), out id);

                            }
                            Console.Write("Start Date(day/month/year): ");
                            DateTime startDate;
                            valid = DateTime.TryParse(Console.ReadLine(), out startDate);
                            while (valid == false)
                            {
                                Console.Write("Start Date(day/month/year): ");
                                valid = DateTime.TryParse(Console.ReadLine(), out startDate);
                            }
                            Console.Write("End Date(day/month/year): ");
                            DateTime endDate;
                            valid = DateTime.TryParse(Console.ReadLine(), out endDate);
                            while (valid == false)
                            {
                                Console.Write("End Date(day/month/year): ");
                                valid = DateTime.TryParse(Console.ReadLine(), out endDate);
                            }
                            ScheduleCourseManager.UpdateSchedule(id, startDate, endDate);
                            break;
                        }
                    case "7":
                        {
                            Console.WriteLine("Delete a Schedule!");
                            Console.WriteLine("Viewing all Courses...\n");
                            foreach (var course in CourseManager.GetAllCourses())
                            {
                                Console.WriteLine(course);
                            }
                            Console.WriteLine("\nType the ID of the Course you want to update!");
                            int id;
                            bool valid = int.TryParse(Console.ReadLine(), out id);
                            while (valid == false)
                            {
                                Console.WriteLine("Invalid Input!");
                                Console.WriteLine("\nType the ID of the Course you want to delete!");
                                valid = int.TryParse(Console.ReadLine(), out id);
                            }                            
                            ScheduleCourseManager.DeleteSchedule(id);
                            break;
                        }
                    case "8":
                        {
                            Console.WriteLine("Viewing all Courses...\n");
                            foreach (var course in CourseManager.GetAllCourses())
                            {
                                Console.WriteLine($"{course.ID}: Start Date: {course.StartDate}, End Date: {course.EndDate}");
                            }
                            break;
                        }
                    case "9":
                        {
                            Console.WriteLine("Viewing all Students...\n");
                            foreach (var student in StudentManager.GetAllStudents())
                            {
                                Console.WriteLine(student);
                            }
                            Console.WriteLine("Select a Student");
                            int studentID;
                            bool valid = int.TryParse(Console.ReadLine(), out studentID);
                            while (valid == false)
                            {
                                Console.WriteLine("Invalid Input!");
                                Console.WriteLine("Select a Student");
                                valid = int.TryParse(Console.ReadLine(), out studentID);

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
                                Console.WriteLine("Select a Course");
                                valid = int.TryParse(Console.ReadLine(), out courseID);

                            }
                            Console.Write("Tuition Fees: ");
                            int tuitionFees;
                            valid = int.TryParse(Console.ReadLine(), out tuitionFees);
                            while (valid == false)
                            {
                                Console.WriteLine("Invalid Input!");
                                Console.Write("Tuition Fees: ");
                                valid = int.TryParse(Console.ReadLine(), out tuitionFees);

                            }
                            StudentEnrollmentManager.EnrollStudent(studentID, courseID, tuitionFees);
                            break;
                        }
                    case "10":
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
                                Console.WriteLine("Select a Course");
                                valid = int.TryParse(Console.ReadLine(), out courseID);

                            }
                            Console.Write("Subject: ");
                            string subject = Console.ReadLine();
                            TrainerEnrollmentManager.EnrollTrainer(trainerID, courseID, subject);
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
