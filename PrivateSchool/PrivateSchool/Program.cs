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
            // VERY IMPORTANT
            SyntheticData.DoItOnce(); // Trexto mia fora na bei i vasi sto pc ke meta kanto comment POLI SIMADIKO allios tha crasharei
            // VERY IMPORTANT
            // Elpizw na treksei to synthetic, den to dokimasa gt eixa idi data ke fovomoun na to crasharw gt pezw me IDs

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
