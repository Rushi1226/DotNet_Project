using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.EntityFrameworkCore;
using DotNet_MiniProject.Models;

namespace DotNet_MiniProject
{
    class StudentManager
    {
        static string password, username, studentName, email, location, gender, contactNo;

       
        public static void registerStudent()
        {
            DateTime dob;
           
            Console.WriteLine("Please Enter Username :");
            username = Console.ReadLine();
           
            //pass check
            bool passCheck;
            //string password1;
            do
            {
                Console.WriteLine("Enter Password:");
               // password = " ";
                string pass , errormsg;
                //password1 = Console.ReadLine();

                pass = Console.ReadLine();

                passCheck = Validation.isValidPassword( pass , out errormsg);

               // error = "incorrect";
                if (passCheck == true)
                {
                    password = pass;
                }
                else
                {
                    Console.WriteLine(errormsg);
                }

            } while (passCheck != true);

            Console.WriteLine("Please Enter StudentName :");
            studentName =  Console.ReadLine();

            Console.WriteLine("Please Enter dob :");
            DateTime.TryParse(Console.ReadLine(), out dob);

            //email check
            bool emailCheck;
            do
            {
                Console.WriteLine("Enter Email:");
                
                string emailCatch;
                emailCatch = Console.ReadLine();


                emailCheck = Validation.isValidEmail(emailCatch);


                if (emailCheck == true)
                {
                    email = emailCatch;
                }
                else
                {
                    Console.WriteLine("please enter email in correct format");

                }

            } while (emailCheck!= true);




            //location check
            bool locationCheck;
            do
            {
                Console.WriteLine("Enter Location:");
                string locationCatch;
                locationCatch = Console.ReadLine();

                locationCheck = Validation.isValidName(locationCatch);


                if (locationCheck == true)
                {
                    location = locationCatch;
                }
                else
                {
                    Console.WriteLine("please enter location in correct format");

                }

            } while (locationCheck != true);
            //


     


            
            //Gender Check
            bool genderCheck;
            do
            {
                Console.WriteLine("Please select Gender (M/F):");
                string genderCatch;
                genderCatch = Console.ReadLine();


                genderCheck = Validation.isValidGender(genderCatch);


                if (genderCheck == true)
                {
                    gender = genderCatch;
                }
                else
                {
                    Console.WriteLine("please enter gender in correct format");

                }

            } while (genderCheck != true);

            //



            //Contact check
            bool contactCheck;
            do
            {
                Console.WriteLine("Please enter Contact No. :");
                string contactCatch;
                contactCatch = Console.ReadLine();

                contactCheck = Validation.isValidContact(contactCatch);


                if (contactCheck == true)
                {
                    contactNo = contactCatch;
                }
                else
                {
                    Console.WriteLine("please enter contact no. in correct format(10 digit without country code)");

                }

            } while (contactCheck != true);






            



      
            using (var add = new MyDbContext())
            {
                Student student = new Student();
                
               // student.StudentID = id;
                student.UserName = username;
                student.Password = password;

                student.Email = email;
                student.StudentName = studentName;
                student.DateOfBirth = dob;
                
                student.Location = location;
                student.Gender = gender;
                student.ContactNo = contactNo;


                
                add.Add(student);

                add.SaveChanges();

                Console.WriteLine("Registration Successful");
                Console.ReadLine();
            }




        }
        public static string getUserName()
        {
            Student student;
            string userName;
            do
            {
                Console.WriteLine("Enter Username : ");
                userName = Console.ReadLine();
                using(var context = new MyDbContext())
                {
                    student = context.students.SingleOrDefault(s => s.UserName.Equals(userName));
                }
            } while (student == null);
            return userName;
        }

        public static Student getPassword(string userName)
        {
            string password;
            Student student;
            do
            {
                Console.WriteLine("Please insert password");
                password = Console.ReadLine();

                using (var context = new MyDbContext())
                {
                    student = context.students.SingleOrDefault(s => s.Password.Equals(password) && s.UserName.Equals(userName));
                }
            } while (student == null);
            return student;
        }

        public static void createStudent(Student studnt)
        {
            using (var context = new MyDbContext())
            {
                context.students.Add(studnt);
                context.SaveChanges();
                Console.WriteLine("Added Student Successfully !");
            }
        }



        internal static List<Student> getStudents()
        {
            List<Student> students;
            using (var context = new MyDbContext())
            {
                students = context.students.ToList();
            }
            return students;
        }

        internal static void updateStudent(Student student)
        {
            Console.WriteLine("Update Student name:");
            var studentname = Console.ReadLine();
            DateTime DateOfBirth;
            do
            {
                Console.WriteLine("Update birthdate:");
            } while (!DateTime.TryParse(Console.ReadLine(), out DateOfBirth));
            Console.WriteLine("Update Email:");
            var email = Console.ReadLine();
            Console.WriteLine("Update Location : ");
            var location = Console.ReadLine();
            Console.WriteLine("Update Gender : ");
            var gender = Console.ReadLine();
            Console.WriteLine("Update Contact No : ");
            var contactno = Console.ReadLine();

            using (var context = new MyDbContext())
            {
                student = context.students.SingleOrDefault(c => c.StudentID == student.StudentID);
                student.StudentName = studentname;
                student.DateOfBirth = DateOfBirth;
                student.Email = email;
                student.Location = location;
                student.Gender = gender;
                student.ContactNo = contactno;
                context.SaveChanges();
                Console.WriteLine("Data Updateded Successfully !");
            }
        }

        internal static void deleteStudent(Student student)
        {
            using (var context = new MyDbContext())
            {
                context.Entry(student).State = EntityState.Unchanged;
                context.students.Remove(context.students.SingleOrDefault(sa => sa.StudentID == student.StudentID));
                context.students.Remove(student);
                context.SaveChanges();
                Console.WriteLine("Deleted Student Successfully !");
            }
        }
    }
}
