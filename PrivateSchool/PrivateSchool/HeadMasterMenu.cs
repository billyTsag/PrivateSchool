using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrivateSchool.Models;

namespace PrivateSchool
{
    public static class HeadMasterMenu
    {
        public static void MainMenu()
        {
            bool login = false;
            while (true)
            {
                while (login == false)
                {
                    Console.Write("Username: ");
                    string username = Console.ReadLine();
                    HeadMaster headMaster = HeadMasterManager.FindPassword(username);
                    Console.Write("Password: ");
                    string password = Console.ReadLine();
                    if (headMaster == null)
                    {
                        Console.WriteLine("\nError: Username and Password do not match\n");
                    }
                    else if (PasswordHashing.Verify(password, headMaster.Password) == true)
                    {
                        Console.WriteLine("Successfull login\n");
                        login = true;
                    }
                    else
                    {
                        Console.WriteLine("\nError: Username and Password do not match\n");
                    }
                }
                Console.WriteLine("Welcome Head Master!");
                Console.WriteLine("What do you want to access?\n");
                Console.WriteLine("1. Students");
                Console.WriteLine("2. Trainers");
                Console.WriteLine("3. Courses");
                Console.WriteLine("4. Assignments");
                Console.WriteLine("0. Exit");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "0":
                        Environment.Exit(0);
                        break;
                    case "1":
                        HMStudentMenu.Menu();
                        Console.Clear();
                        break;
                    case "2":
                        HMTrainerMenu.Menu();
                        Console.Clear();
                        break;
                    case "3":
                        HMCourseMenu.Menu();
                        Console.Clear();
                        break;
                    case "4":
                        HMAssignmentMenu.Menu();
                        Console.Clear();
                        break;
                    default:
                        break;
                }
            }
        
        }
    }
}
