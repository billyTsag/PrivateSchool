using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrivateSchool.Models;

namespace PrivateSchool
{
    class Program
    {        
        static void Main(string[] args)
        {         

            // HeadMaster
            // Username: sysadmin
            // Password: unhackable

            // Student 1
            // Username: billy
            // Password: tsag

            // Trainer 1
            // Username: geo
            // Password: papa

            Console.WriteLine("Welcome!\n");
            
            while (true)
            {                
                Console.WriteLine("\t|Log-In System|\n");
                Console.WriteLine("Are you a : 1. Student | 2. Trainer | 3. Head Master");
                string role = Console.ReadLine();
                switch (role)
                {
                    case "1":
                        {
                           
                             StudentMenu.MainMenu();                          
                             break;
                        }
                    case "2":
                        {
                            TrainerMenu.MainMenu();
                            break;
                        }                        
                    case "3":
                        {                                                      
                            HeadMasterMenu.MainMenu();
                            break;
                        }
                    default:
                        break;
                }
            }                  
        }
    }
}
