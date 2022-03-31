using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNet_MiniProject.Models;

namespace DotNet_MiniProject
{
    class CourseView
    {
        public static Course createCourse()
        {
                Course course;
                Console.WriteLine("Give a course name:");
                string coursename = Console.ReadLine();
                Console.WriteLine("Give a course duration:");
                string courseduration = Console.ReadLine();
                return course = new Course() { CourseName = coursename, CourseDuration = courseduration };
            }
        public static void showCourse(List<Course> courses)
        {
            //using (var context = new MyDbContext())
            //{
            //    foreach (var c in courses)
            //    {
            //        Console.WriteLine(c.CourseName);
            //    }
            //}
            //Console.WriteLine("Press any key to continue...");
            //Console.ReadLine();


             using (var context = new MyDbContext())
            {
                var header = String.Format("-----------------------------------------------------------------------------------------------------------------\n" +
                    "\t\t\tCourse List\n" +
                    "-----------------------------------------------------------------------------------------------------------------\n" +
                    "{0,4}{1,15}{2,20}\n-----------------------------------------------------------------------------------------------------------------",
                    "CourseID","CourseName", "Duration");
                Console.WriteLine(header);
                foreach (var s in courses)
                {
                    //Console.WriteLine(s.ToString());
                    var output = String.Format("{0,4}{1,15}{2,30}",s.CourseId , s.CourseName, s.CourseDuration);
                    Console.WriteLine(output);
                }
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
            }
            Console.WriteLine("Press any key to continue..");
            Console.ReadLine();
            
        }
        public static int deleteCourseMenu(List<Course> courses)
        {
            int userInput;
            do
            {
                for (int i = 0; i < courses.Count; i++)
                {
                    Console.WriteLine($"Press {i} to delete {courses[i].CourseName} course");
                }
            } while (!int.TryParse(Console.ReadLine(), out userInput));
            return userInput;
        }

        public static int updateCourseMenu(List<Course> courses)
        {
            int userInput;
            do
            {
                for (int i = 0; i < courses.Count; i++)
                {
                    Console.WriteLine($"Press {i} to update {courses[i].CourseName} course");
                }
            } while (!int.TryParse(Console.ReadLine(), out userInput));
            return userInput;
        }
    }
    }
