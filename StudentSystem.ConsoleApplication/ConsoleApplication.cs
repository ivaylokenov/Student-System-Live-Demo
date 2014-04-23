namespace StudentSystem.ConsoleApplication
{
    using StudentSystem.Data;
    using StudentSystem.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ConsoleApplication
    {
        public static void Main()
        {
            var data = new StudentSystemData();

            var students = data.Students.All();

            var count = 1;
            foreach (var student in students)
            {
                student.FirstName += count.ToString();
                count++;
            }

            data.SaveChanges();

            var updatedStudents = data.Students.All();

            foreach (var student in updatedStudents)
            {
                data.Students.Delete(student);
            }

            var selectedStudents =
                data.Students
                .All()
                .Where(st => st.FirstName.Contains("Ivaylo"))
                .Select(st => new
                    {
                        FirstName = st.FirstName,
                        LastName = st.LastName
                    })
                .ToList();

            Console.WriteLine(selectedStudents.Count());

            data.SaveChanges();

            Console.WriteLine(data.Students.All().Count());

            var course = new Course
            {
                Name = "Pesho's course",
                Description = "The best course in the world"
            };

            data.Courses.Add(course);
            data.SaveChanges();

            var someStudent = new Student
            {
                FirstName = "Peshlqka",
                LastName = "Goshlqka",
                Information = new StudentInfo
                {
                    Email = "pesho@gosho.com"
                },
                StudentNumber = 12345
            };

            data.Students.Add(someStudent);
            data.SaveChanges();

            someStudent.Courses.Add(course);
            var homework = new Homework
            {
                FileUrl = "pesho.com/pesho.zip",
                Course = course,
                TimeSent = DateTime.Now
            };

            someStudent.Homeworks.Add(homework);
            data.SaveChanges();

            var studentFromDB = data.Students.All().FirstOrDefault();

            Console.WriteLine(studentFromDB.Homeworks.FirstOrDefault().FileUrl);
        }
    }
}
