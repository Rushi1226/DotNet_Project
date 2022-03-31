using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNet_MiniProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNet_MiniProject
{
    class CourseManager
    {
        public static void createCourse(Course course)
        {
            using (var context = new MyDbContext())
            {
                context.courses.Add(course);
                context.SaveChanges();
            }
        }

        public static List<Course> getCourses()
        {
            List<Course> course;
            using (var context = new MyDbContext())
            {
                course = context.courses.ToList();
            }
            return course;
        }

        public static void updateCourse(Course course)
        {
            Console.WriteLine("Update course name:");
            string name = Console.ReadLine();
            Console.WriteLine("Update course duration:");
            string duration = Console.ReadLine();

            using (var context = new MyDbContext())
            {
                course = context.courses.SingleOrDefault(c => c.CourseId == course.CourseId);
                course.CourseName = name;
                course.CourseDuration = duration;

                context.SaveChanges();
            }
        }

        public static void deleteCourse(Course course)
        {
            using (var context = new MyDbContext())
            {
                context.Entry(course).State = EntityState.Unchanged;
                context.courses.Remove(course);
                context.SaveChanges();
            }
        }


    }
}

