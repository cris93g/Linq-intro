using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[] { 1,2,3,4,5,6,7,8,9};
            OddNumbers(numbers);
        }

        static void OddNumbers(int[] numbers)
        {
            UniversityManager um = new UniversityManager();
            um.FemaleStudents();
        }
    }

    class UniversityManager
    {
        public List<University> universities;
        public List<Student> students;

        public UniversityManager()
        {
            universities = new List<University>();
            students = new List<Student>();

            universities.Add(new University { Id = 1, Name = "Yale" });
            universities.Add(new University { Id = 2, Name = "Beijing Tech" });

            students.Add(new Student { Id = 1, Name = "Carla", Gender = "female", Age = 17, UniversityId = 1 });
            students.Add(new Student { Id = 2, Name = "Toni", Gender = "male", Age = 21, UniversityId = 1 });
            students.Add(new Student { Id = 2, Name = "Frank", Gender = "male", Age = 22, UniversityId = 2 });
            students.Add(new Student { Id = 3, Name = "Leyla", Gender = "female", Age = 19, UniversityId = 2 });
            students.Add(new Student { Id = 4, Name = "James", Gender = "trans-gender", Age = 25, UniversityId = 2 });
            students.Add(new Student { Id = 5, Name = "Linda", Gender = "female", Age = 22, UniversityId = 2 });
        }


        public void MaleStudents()
        {
            IEnumerable<Student> maleStudents = from student in students where student.Gender == "male" select student;
            Console.WriteLine("male= students: ");
            foreach(Student student in maleStudents)
            {
                student.Print();
            }
        }

        public void FemaleStudents()
        {
            IEnumerable<Student> femalStudents = from student in students where student.Gender == "female" select student;
            Console.WriteLine("female = students: ");
            foreach(Student student in femalStudents)
            {
                student.Print();
            }
        }

    }


    class University
    {
        public int Id { get; set;}
        public string Name { get; set; }

        public void Print()
        {
            Console.WriteLine("university {0} with id {1}", Name, Id);
        }

    }

    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Gender { get; set; }

        public int Age { get; set; }

        //foreing key
        public int UniversityId { get; set; }

        public void Print()
        {
            Console.WriteLine("student{0} with Id{1} Gender{2} and Age{3} from University{4}", Name, Id, Gender, Age, UniversityId);
        }
    }

}
