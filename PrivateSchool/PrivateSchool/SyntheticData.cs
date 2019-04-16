using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateSchool
{
    public static class SyntheticData
    {
        public static void DoItOnce()
        {
            StudentManager.CreateStudent("Billy", "Tsagliotis", new DateTime(1995, 10, 10));
            StudentManager.CreateStudent("George", "Arazos", new DateTime(1995, 10, 10));
            StudentManager.CreateStudent("Nikos", "Barlas", new DateTime(1995, 10, 10));
            StudentManager.CreateStudent("Vagelis", "Soultis", new DateTime(1995, 10, 10));
            StudentManager.CreateStudent("Stefanos", "Petrou", new DateTime(1995, 10, 10));
            StudentManager.CreateStudent("Xrisa", "Katsouli", new DateTime(1995, 10, 10));
            StudentManager.CreateStudent("Aleksandra", "Papadopoulou", new DateTime(1995, 10, 10));

            string password1 = "tsag";
            string hashedPassword1 = PasswordHashing.Hash(password1);
            StudentManager.CreateAccount(1, "billy", hashedPassword1);            

            CourseManager.CreateCourse("Hello", "Csharp", "Full-Time");
            CourseManager.CreateCourse("GoodBye", "Java", "Full-Time");
            CourseManager.CreateCourse("Greetings", "Csharp", "Part-Time");
            CourseManager.CreateCourse("ByeBye", "Java", "Part-Time");

            TrainerManager.CreateTrainer("George", "Pasparakis");
            TrainerManager.CreateTrainer("Vyron", "Vasileiadis");
            TrainerManager.CreateTrainer("Mixalis", "Nikolaidis");

            string password2 = "papa";
            string hashedPassword2 = PasswordHashing.Hash(password2);
            TrainerManager.CreateAccount(1, "geo", hashedPassword2);            

            TrainerEnrollmentManager.EnrollTrainer(1, 1, "Hello");
            TrainerEnrollmentManager.EnrollTrainer(2, 1, "Hello");
            TrainerEnrollmentManager.EnrollTrainer(3, 1, "Hello");
            TrainerEnrollmentManager.EnrollTrainer(1, 2, "Hello");
            TrainerEnrollmentManager.EnrollTrainer(1, 3, "Hello");
            TrainerEnrollmentManager.EnrollTrainer(3, 2, "Hello");
            TrainerEnrollmentManager.EnrollTrainer(2, 3, "Hello");

            StudentEnrollmentManager.EnrollStudent(1, 1, 500);
            StudentEnrollmentManager.EnrollStudent(1, 2, 500);
            StudentEnrollmentManager.EnrollStudent(1, 3, 500);
            StudentEnrollmentManager.EnrollStudent(1, 4, 500);
            StudentEnrollmentManager.EnrollStudent(2, 1, 500);
            StudentEnrollmentManager.EnrollStudent(2, 2, 500);
            StudentEnrollmentManager.EnrollStudent(3, 2, 500);
            StudentEnrollmentManager.EnrollStudent(4, 3, 500);
            StudentEnrollmentManager.EnrollStudent(5, 3, 500);
            StudentEnrollmentManager.EnrollStudent(6, 4, 500);
            StudentEnrollmentManager.EnrollStudent(7, 1, 500);

            AssignmentManager.CreateAssignment("Calculator", new DateTime(2020, 5, 5));
            AssignmentManager.CreateAssignment("NewCalculator", new DateTime(2020, 5, 5));
            AssignmentManager.CreateAssignment("SuperNewCalculator", new DateTime(2020, 5, 5));
            AssignmentManager.CreateAssignment("HyperSuperNewCalculator", new DateTime(2020, 5, 5));
            AssignmentManager.CreateAssignment("DuperHyperSuperNewCalculator", new DateTime(2020, 5, 5));
            AssignmentManager.CreateAssignment("WhateverDuperHyperSuperNewCalculator", new DateTime(2020, 5, 5));
            AssignmentManager.CreateAssignment("UltraWhateverDuperHyperSuperNewCalculator", new DateTime(2020, 5, 5));

            AssignmentCourseManager.CreateAssignmentPerCourse(1, 1);
            AssignmentCourseManager.CreateAssignmentPerCourse(2, 2);
            AssignmentCourseManager.CreateAssignmentPerCourse(3, 3);
            AssignmentCourseManager.CreateAssignmentPerCourse(4, 4);
            AssignmentCourseManager.CreateAssignmentPerCourse(5, 1);
            AssignmentCourseManager.CreateAssignmentPerCourse(6, 2); 

            AssignmentCourseManager.CreateAssignmentPerStudent(1, 1);
            AssignmentCourseManager.CreateAssignmentPerStudent(1, 2);
            AssignmentCourseManager.CreateAssignmentPerStudent(1, 3);
            AssignmentCourseManager.CreateAssignmentPerStudent(1, 4);
            AssignmentCourseManager.CreateAssignmentPerStudent(1, 5);
            AssignmentCourseManager.CreateAssignmentPerStudent(1, 6);
            AssignmentCourseManager.CreateAssignmentPerStudent(2, 1);
            AssignmentCourseManager.CreateAssignmentPerStudent(2, 2);
            AssignmentCourseManager.CreateAssignmentPerStudent(2, 5);
            AssignmentCourseManager.CreateAssignmentPerStudent(2, 6);
            AssignmentCourseManager.CreateAssignmentPerStudent(3, 2);
            AssignmentCourseManager.CreateAssignmentPerStudent(3, 6);
            AssignmentCourseManager.CreateAssignmentPerStudent(4, 3);
            AssignmentCourseManager.CreateAssignmentPerStudent(5, 3);
            AssignmentCourseManager.CreateAssignmentPerStudent(6, 4);
            AssignmentCourseManager.CreateAssignmentPerStudent(7, 1);
            AssignmentCourseManager.CreateAssignmentPerStudent(7, 5);

            string usernameHM1 = "sysadmin";
            string passwordHM1 = "unhackable";
            string hashedPasswordHM1 = PasswordHashing.Hash(passwordHM1);
            HeadMasterManager.CreateHeadMaster(usernameHM1, hashedPasswordHM1);

            string usernameHM2 = "billy";
            string passwordHM2 = "tsagliotis";
            string hashedPasswordHM2 = PasswordHashing.Hash(passwordHM2);
            HeadMasterManager.CreateHeadMaster(usernameHM2, hashedPasswordHM2);










        }
    }
}
