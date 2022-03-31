using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNet_MiniProject.Models;

namespace DotNet_MiniProject
{
    class AdminView
    {
        public static int menu()
        {
            int userInput;
            do
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("--------------------------------------------------------------------------------------");
                Console.WriteLine("                                          MENU");
                Console.WriteLine("--------------------------------------------------------------------------------------");
                Console.WriteLine("Press 0 to Exit Application");
                Console.WriteLine("Press 1 to Course Deatils");
                Console.WriteLine("Press 2 to Student Deatils");
                Console.WriteLine("Press 3 for Back to Main Menu");
            } while (!int.TryParse(Console.ReadLine(), out userInput));
            return userInput;
        }

        public static int entityCourseMenu(string entity)
        {
            int userInput;
            do
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("--------------------------------------------------------------------------------------");
                Console.WriteLine("                                         COURSE MENU");
                Console.WriteLine("--------------------------------------------------------------------------------------");
                Console.WriteLine($"Press 0 to CREATE {entity}");
                Console.WriteLine($"Press 1 to SHOW {entity}");
                Console.WriteLine($"Press 2 to UPDATE {entity}");
                Console.WriteLine($"Press 3 to DELETE {entity}");
            } while (!int.TryParse(Console.ReadLine(), out userInput));
            return userInput;
        }

        public static int entityStudentMenu(string entity)
        {
            int userInput;
            do
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("--------------------------------------------------------------------------------------");
                Console.WriteLine("                                         STUDENT MENU");
                Console.WriteLine("--------------------------------------------------------------------------------------");
                Console.WriteLine($"Press 0 to CREATE {entity}");
                Console.WriteLine($"Press 1 to SHOW {entity}");
                Console.WriteLine($"Press 2 to UPDATE {entity}");
                Console.WriteLine($"Press 3 to DELETE {entity}");

            } while (!int.TryParse(Console.ReadLine(), out userInput));
            return userInput;
        }


        internal static void createStudent()
        {
            string username, studentName, password, email, location, gender, contactNo;
            DateTime dob;

            Console.WriteLine("Please Enter Username :");
            username = Console.ReadLine();

            //Console.WriteLine("Please Enter Password :");
            //string password = Console.ReadLine();

            bool passCheck;

            do
            {
                Console.WriteLine("Enter Password:");
                password = " ";
                string errormsg;
                passCheck = Validation.isValidPassword(Console.ReadLine(), out errormsg);

                // error = "incorrect";
                if (passCheck == true)
                {
                    password = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine(errormsg);
                }

            } while (passCheck != true);

            Console.WriteLine("Enter Student name:");
            string studentname = Console.ReadLine();
            DateTime DateOfBirth;
            do
            {
                Console.WriteLine("Enter birthdate:");
            } while (!DateTime.TryParse(Console.ReadLine(), out DateOfBirth));

            //Console.WriteLine("Enter Email:");
            //string email = Console.ReadLine();


            
            bool emailCheck;
            
            do
            {
                Console.WriteLine("Enter Email:");
                email = " ";
                emailCheck = Validation.isValidEmail(Console.ReadLine());


                if (emailCheck == true)
                {
                    email = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("please enter email in correct format");

                }

            } while (emailCheck != true);

            //Console.WriteLine("Enter Location : ");
            //string location = Console.ReadLine();

            bool locationCheck;
            do
            {
                Console.WriteLine("Enter Location:");
                location = "";
                locationCheck = Validation.isValidName(Console.ReadLine());


                if (locationCheck == true)
                {
                    location = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("please enter location in correct format");

                }

            } while (locationCheck != true);

            //Console.WriteLine("Enter Gender : ");
            //string gender = Console.ReadLine();

            bool genderCheck;
            do
            {
                Console.WriteLine("Please select Gender (M/F):");
                gender = "";
                genderCheck = Validation.isValidGender(Console.ReadLine());


                if (genderCheck == true)
                {
                    gender = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("please enter gender in correct format");

                }

            } while (genderCheck != true);

            //Console.WriteLine("Enter Contact No : ");
            //string contactno = Console.ReadLine();

            bool contactCheck;
            do
            {
                Console.WriteLine("Please enter Contact No. :");
                contactNo = "";
                contactCheck = Validation.isValidContact(Console.ReadLine());


                if (contactCheck == true)
                {
                    contactNo = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("please enter contact no. in correct format(10 digit without country code)");

                }

            } while (contactCheck != true);

            //Student studnt = new Student { UserName = username, Password = password, StudentName = studentname, DateOfBirth = DateOfBirth, Email = email, Location = location, Gender = gender, ContactNo = contactNo };

            //return studnt;
            using (var add = new MyDbContext())
            {
                Student student = new Student();

                // student.StudentID = id;
                student.UserName = username;
                student.Password = password;

                student.Email = email;
                student.StudentName = studentname;
                student.DateOfBirth = DateOfBirth;

                student.Location = location;
                student.Gender = gender;
                student.ContactNo = contactNo;



                add.Add(student);

                add.SaveChanges();

                Console.WriteLine("Student Registration Successful");
                Console.ReadLine();
            }

        }

        internal static void showStudents(List<Student> students)
        {
            using (var context = new MyDbContext())
            {
                var header = String.Format("--------------------------------------------------------------------------------\n" +
                    "\t\t\tUsers List\n" +
                    "--------------------------------------------------------------------------------\n" +
                    "{0,4}{1,15}{2,15}{3,10}{4,15}{5,20}{6,25}{7,30}{8,35}\n--------------------------------------------------------------------------------",
                    "StudentId", "StudentName","UserName","Password", "D.O.B", "Email", "Gender", "Location", "ContactNo");
                Console.WriteLine(header);
                foreach (var s in students)
                {
                    //Console.WriteLine(s.ToString());
                    var output = String.Format("{0,4}{1,15}{2,15}{3,10}{4,15}{5,20}{6,25}{7,30}{8,35}", s.StudentID, s.StudentName,s.UserName,s.Password, s.DateOfBirth, s.Email, s.Gender,s.Location, s.ContactNo);
                    Console.WriteLine(output);
                }
                Console.WriteLine("--------------------------------------------------------------------------------");

            }
            Console.WriteLine("Press any key to continue..");
            Console.ReadLine();
        }

        internal static int studentMenu(List<Student> students)
        {
            int userInput;
            do
            {
                for (int i = 0; i < students.Count; i++)
                {
                    Console.WriteLine($"Press {i} to update/delete student: {students[i].ToString()}");
                }
            } while (!int.TryParse(Console.ReadLine(), out userInput));
            return userInput;
        }
    }
}
