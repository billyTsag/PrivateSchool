using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateSchool
{
    public static class HMStudentMenu
    {
        public static void Menu()
        {
            bool back = false;
            while (back == false)
            {
                Console.WriteLine("\n1. Create a Student");
                Console.WriteLine("2. Create/Update Username/Password for a Student");
                Console.WriteLine("3. View all Students");
                Console.WriteLine("4. Delete a Student");
                Console.WriteLine("5. Update a Student");
                Console.WriteLine("6. Enroll a Student to a Course");
                Console.WriteLine("7. View all Students that are enrolled to Courses");
                Console.WriteLine("8. Update the enrollment of a Student");
                Console.WriteLine("9. Delete the enrollment of a Student");
                Console.WriteLine("0. Go Back");
                string choice = Console.ReadLine();
                Console.Clear();
                switch (choice)
                {
                    case "1":
                        {
                            Console.WriteLine("Add a student!");
                            Console.Write("First Name: ");
                            string firstName = Console.ReadLine();
                            Console.Write("Last Name: ");
                            string lastName = Console.ReadLine();
                            Console.Write("Date of Birth: ");
                            DateTime dateOfBirth;
                            bool valid = DateTime.TryParse(Console.ReadLine(), out dateOfBirth);
                            while (valid == false)
                            {
                                Console.WriteLine("Invalid Input!");
                                Console.Write("Date of Birth: ");
                                valid = DateTime.TryParse(Console.ReadLine(), out dateOfBirth);
                            }
                            int id = StudentManager.CreateStudent(firstName, lastName, dateOfBirth);
                            Console.WriteLine($"Student: {firstName} {lastName} created with ID: {id}\n");
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("Creating Login Information");
                            Console.WriteLine("Viewing all Students...");
                            foreach (var student in StudentManager.GetAllStudents())
                            {
                                Console.WriteLine(student);
                            }
                            Console.WriteLine("\nType the ID of a Student that you want to access");
                            int studentID;
                            bool valid = int.TryParse(Console.ReadLine(), out studentID);
                            while (valid == false)
                            {
                                Console.WriteLine("Invalid Input!");
                                Console.WriteLine("Type the ID of a Student that you want to access");
                                valid = int.TryParse(Console.ReadLine(), out studentID);
                            }
                            Console.Write("Username: ");
                            string username = Console.ReadLine();
                            Console.Write("Password: ");
                            string password = Console.ReadLine();
                            string hashedPassword = PasswordHashing.Hash(password);
                            StudentManager.CreateAccount(studentID, username, hashedPassword);
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine("Viewing all Students...");
                            foreach (var student in StudentManager.GetAllStudents())
                            {
                                Console.WriteLine(student);
                            }
                            break;
                        }
                    case "4":
                        {
                            Console.WriteLine("Viewing all Students...\n");
                            foreach (var student in StudentManager.GetAllStudents())
                            {
                                Console.WriteLine(student);
                            }
                            Console.WriteLine("\nType the ID of the Student you want to delete!");
                            int studentID;
                            bool valid = int.TryParse(Console.ReadLine(), out studentID);
                            while (valid == false)
                            {
                                Console.WriteLine("Invalid Input!");
                                Console.WriteLine("\nType the ID of the Student you want to delete!");
                                valid = int.TryParse(Console.ReadLine(), out studentID);

                            }
                            StudentManager.DeleteStudent(studentID);
                            break;
                        }
                    case "5":
                        {
                            Console.WriteLine("Update a Student!");
                            Console.WriteLine("Viewing all Students...\n");
                            foreach (var student in StudentManager.GetAllStudents())
                            {
                                Console.WriteLine(student);
                            }
                            Console.WriteLine("\nType the ID of the Student you want to update!");
                            int studentID;
                            bool valid = int.TryParse(Console.ReadLine(), out studentID);
                            while (valid == false)
                            {
                                Console.WriteLine("Invalid Input!");
                                Console.WriteLine("\nType the ID of the Student you want to update!");
                                valid = int.TryParse(Console.ReadLine(), out studentID);
                            }
                            Console.Write("First Name: ");
                            string firstName = Console.ReadLine();
                            Console.Write("Last Name: ");
                            string lastName = Console.ReadLine();
                            Console.Write("Date of Birth: ");
                            DateTime dateOfBirth;
                            valid = DateTime.TryParse(Console.ReadLine(), out dateOfBirth);
                            while (valid == false)
                            {
                                Console.WriteLine("Invalid Input!");
                                Console.Write("Date of Birth: ");
                                valid = DateTime.TryParse(Console.ReadLine(), out dateOfBirth);
                            }
                            StudentManager.UpdateStudent(studentID, firstName, lastName, dateOfBirth);
                            break;
                        }
                    case "6":
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
                            Console.WriteLine("Select a Course");
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
                    case "7":
                        {
                            Console.WriteLine("Viewing all Students and their respective Courses...");
                            foreach (var student in StudentEnrollmentManager.GetAllEnrolledStudents())
                            {
                                Console.WriteLine(student);
                            }
                            break;
                        }
                    case "8":
                        {
                            Console.WriteLine("Update the enrollment of a Student");
                            Console.WriteLine("Viewing all Students and their respective Courses...");
                            foreach (var student in StudentEnrollmentManager.GetAllEnrolledStudents())
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
                            Console.WriteLine("Select a Course that he is already enrolled");
                            int courseID;
                            valid = int.TryParse(Console.ReadLine(), out courseID);
                            while (valid == false)
                            {
                                Console.WriteLine("Invalid Input!");
                                Console.WriteLine("Select a Course that he is already enrolled");
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
                            StudentEnrollmentManager.UpdateEnrolledStudent(studentID, courseID, tuitionFees);
                            break;
                        }
                    case "9":
                        {
                            Console.WriteLine("Delete the enrollment of a Student");
                            Console.WriteLine("Viewing all Students and their respective Courses...");
                            foreach (var student in StudentEnrollmentManager.GetAllEnrolledStudents())
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
                            Console.WriteLine("Select a Course that he is already enrolled");
                            int courseID;
                            valid = int.TryParse(Console.ReadLine(), out courseID);
                            while (valid == false)
                            {
                                Console.WriteLine("Invalid Input!");
                                Console.WriteLine("Select a Course that he is already enrolled");
                                valid = int.TryParse(Console.ReadLine(), out courseID);
                            }
                            StudentEnrollmentManager.DeleteEnrolledStudent(studentID,courseID);
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
