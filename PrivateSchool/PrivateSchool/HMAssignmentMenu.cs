using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrivateSchool.Models;

namespace PrivateSchool
{
    public static class HMAssignmentMenu
    {
        public static void Menu()
        {
            bool back = false;
            while (back == false)
            {
                Console.WriteLine("1. Create an Assignment");
                Console.WriteLine("2. View all Assignments");
                Console.WriteLine("3. Delete an Assignment");
                Console.WriteLine("4. Update an Assignment");
                Console.WriteLine("5. Assign an Assignment to a Course");
                Console.WriteLine("6. Update an Assignment to a Course");
                Console.WriteLine("7. View all Assignments per Course");
                Console.WriteLine("8. Delete an Assignment from a Course");
                Console.WriteLine("9. Assign an Assignment to a Student");
                Console.WriteLine("10. Delete an Assignment from a Student");
                Console.WriteLine("0. Go Back");
                string choice = Console.ReadLine();
                Console.Clear();
                switch (choice)
                {
                    case "1":
                        {
                            Console.WriteLine("Add an Assignment!");
                            Console.Write("Title: ");
                            string title = Console.ReadLine();
                            Console.Write("Submission: ");
                            DateTime submission;
                            bool valid = DateTime.TryParse(Console.ReadLine(), out submission);
                            while (valid == false)
                            {
                                Console.WriteLine("Invalid Input!");
                                Console.Write("Submission: ");
                                valid = DateTime.TryParse(Console.ReadLine(), out submission);

                            }
                            int id = AssignmentManager.CreateAssignment(title, submission);
                            Console.WriteLine($"Assignment: {title} created with ID: {id}");
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("Viewing all Assignments...\n");
                            foreach (var assignment in AssignmentManager.GetAllAssignments())
                            {
                                Console.WriteLine(assignment);
                            }
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine("Delete an Assignment!");
                            Console.WriteLine("Viewing all Assignments...\n");
                            foreach (var assignment in AssignmentManager.GetAllAssignments())
                            {
                                Console.WriteLine(assignment);
                            }
                            Console.WriteLine("\nType the ID of the Assignment you want to delete!");
                            int id;
                            bool valid = int.TryParse(Console.ReadLine(), out id);
                            while (valid == false)
                            {
                                Console.WriteLine("Invalid Input!");
                                Console.WriteLine("\nType the ID of the Assignment you want to delete!");
                                valid = int.TryParse(Console.ReadLine(), out id);
                            }                            
                            AssignmentManager.DeleteAssignment(id);
                            break;
                        }
                    case "4":
                        {
                            Console.WriteLine("Update an Assignment!");
                            Console.WriteLine("Viewing all Assignments...\n");
                            foreach (var assignment in AssignmentManager.GetAllAssignments())
                            {
                                Console.WriteLine(assignment);
                            }
                            Console.WriteLine("\nType the ID of the Assignment you want to update!");
                            int id;
                            bool valid = int.TryParse(Console.ReadLine(), out id);
                            while (valid == false)
                            {
                                Console.WriteLine("Invalid Input!");
                                Console.WriteLine("\nType the ID of the Assignment you want to update!");
                                valid = int.TryParse(Console.ReadLine(), out id);

                            }
                            Console.Write("Title: ");
                            string title = Console.ReadLine();
                            Console.Write("Submission: ");
                            DateTime submission;
                            valid = DateTime.TryParse(Console.ReadLine(), out submission);
                            while (valid == false)
                            {
                                Console.WriteLine("Invalid Input!");
                                Console.Write("Submission: ");
                                valid = DateTime.TryParse(Console.ReadLine(), out submission);

                            }
                            AssignmentManager.UpdateAssignment(id, title, submission);
                            break;
                        }
                    case "5":
                        {
                            Console.WriteLine("Assign an Assignment to a Course!");
                            Console.WriteLine("Viewing all Assignments...\n");
                            foreach (var assignment in AssignmentManager.GetAllAssignments())
                            {
                                Console.WriteLine(assignment);
                            }
                            Console.WriteLine("\nType the ID of the Assignment you want to select!");
                            int assignmentID;
                            bool valid = int.TryParse(Console.ReadLine(), out assignmentID);
                            while (valid == false)
                            {
                                Console.WriteLine("Invalid Input!");
                                Console.WriteLine("\nType the ID of the Assignment you want to select!");
                                valid = int.TryParse(Console.ReadLine(), out assignmentID);

                            }
                            Console.WriteLine("Viewing all Courses...\n");
                            foreach (var course in CourseManager.GetAllCourses())
                            {
                                Console.WriteLine(course);
                            }
                            Console.WriteLine("\nType the ID of the Course you want to add the Assignment!");
                            int courseID;
                            valid = int.TryParse(Console.ReadLine(), out courseID);
                            while (valid == false)
                            {
                                Console.WriteLine("Invalid Input!");
                                Console.WriteLine("\nType the ID of the Course you want to add the Assignment!");
                                valid = int.TryParse(Console.ReadLine(), out courseID);

                            }
                            AssignmentCourseManager.CreateAssignmentPerCourse(assignmentID,courseID);
                            break;
                        }
                    case "6":
                        {
                            Console.WriteLine("Not here yet");
                            break;
                        }
                    case "8":
                        {
                            Console.WriteLine("Delete an Assignment from a Course");
                            Console.WriteLine("Viewing all Assignments...\n");
                            foreach (var assignment in AssignmentManager.GetAllAssignments())
                            {
                                Console.WriteLine(assignment);
                            }
                            Console.WriteLine("\nType the ID of the Assignment you want to delete!");
                            int assignmentID;
                            bool valid = int.TryParse(Console.ReadLine(), out assignmentID);
                            while (valid == false)
                            {
                                Console.WriteLine("Invalid Input!");
                                Console.WriteLine("\nType the ID of the Assignment you want to delete!");
                                valid = int.TryParse(Console.ReadLine(), out assignmentID);

                            }
                            AssignmentCourseManager.DeleteAssignmentPerCourse(assignmentID);
                            break;
                        }
                    case "9":
                        {
                            Console.WriteLine("Assign an Assignment to a Student");
                            Console.WriteLine("Viewing all Assignments...\n");
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
                                Console.WriteLine("Select an Assignment");
                                valid = int.TryParse(Console.ReadLine(), out assignmentID);

                            }
                            Console.WriteLine("Viewing all Students...\n");
                            foreach (var student in StudentManager.GetAllStudents())
                            {
                                Console.WriteLine(student);
                            }
                            Console.WriteLine("Select a Student");
                            int studentID;
                            valid = int.TryParse(Console.ReadLine(), out studentID);
                            while (valid == false)
                            {
                                Console.WriteLine("Invalid Input!");
                                Console.WriteLine("Select a Student");
                                valid = int.TryParse(Console.ReadLine(), out studentID);

                            }
                            AssignmentCourseManager.CreateAssignmentPerStudent(studentID, assignmentID);
                            break;
                        }
                    case "10":
                        {
                            Console.WriteLine("Delete an Assignment from a Student");
                            Console.WriteLine("Viewing all Assignments...\n");
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
                                Console.WriteLine("Select an Assignment");
                                valid = int.TryParse(Console.ReadLine(), out assignmentID);

                            }
                            Console.WriteLine("Viewing all Students...\n");
                            foreach (var student in StudentManager.GetAllStudents())
                            {
                                Console.WriteLine(student);
                            }
                            Console.WriteLine("Select a Student");
                            int studentID;
                            valid = int.TryParse(Console.ReadLine(), out studentID);
                            while (valid == false)
                            {
                                Console.WriteLine("Invalid Input!");
                                Console.WriteLine("Select a Student");
                                valid = int.TryParse(Console.ReadLine(), out studentID);

                            }
                            AssignmentCourseManager.DeleteAssignmentPerStudent(studentID, assignmentID);
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
