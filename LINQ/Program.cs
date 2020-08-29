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
            um.allStudentsFromBeijing();
            Console.WriteLine("put a input of a university id");
            string input = Console.ReadLine();
            int inputAsInt = Convert.ToInt32(input);
            um.AllStudentsFromThatUni(inputAsInt);
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
            students.Add(new Student { Id = 3, Name = "Frank", Gender = "male", Age = 22, UniversityId = 2 });
            students.Add(new Student { Id = 4, Name = "Leyla", Gender = "female", Age = 19, UniversityId = 2 });
            students.Add(new Student { Id = 5, Name = "James", Gender = "trans-gender", Age = 25, UniversityId = 2 });
            students.Add(new Student { Id = 6, Name = "Linda", Gender = "female", Age = 22, UniversityId = 2 });
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
        public void sortStudentsByAge()
        {
            var sortedStudents = from student in students orderby student.Age select student;
            Console.WriteLine("students sorted by age");
            foreach (Student student in sortedStudents)
            {
                student.Print();
            }
        }

        public void allStudentsFromBeijing()
        {
            IEnumerable<Student> bjtStudents = from student in students
                                               join University in universities on student.UniversityId equals University.Id
                                               where University.Name == "Beijing Tech"
                                               select student;

            Console.WriteLine("students from beijinb tech");
            foreach(Student student in bjtStudents)
            {
                student.Print();
            }
        }


        public void AllStudentsFromThatUni(int Id)
        {
            IEnumerable<Student> myStudents = from student in students
                                               join University in universities on student.UniversityId equals University.Id
                                               where University.Id == Id
                                               select student;

            Console.WriteLine("students from that uni{0}",Id);
            foreach (Student student in myStudents)
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
