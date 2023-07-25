using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p1p2
{
    class Student
    {
        public string Name { get; set; }
        public string Class { get; set; }
    }

    class Program
    {
        static void Main()
        {
            do
            {
                Console.WriteLine("Enter the file path for student data:");
                string filePath = Console.ReadLine();

                List<Student> students = ReadStudentData(filePath);

                if (students.Count == 0)
                {
                    Console.WriteLine("No student data found.");
                    return;
                }

                // Sort the students by name
                students.Sort((s1, s2) => s1.Name.CompareTo(s2.Name));

                Console.WriteLine("Sorted Student Data:");
                DisplayStudents(students);

                Console.WriteLine("\nEnter a student name to search:");
                string searchName = Console.ReadLine();

                List<Student> searchResults = SearchStudents(students, searchName);

                if (searchResults.Count == 0)
                {
                    Console.WriteLine("Student not found.");
                }
                else
                {
                    Console.WriteLine("Search Results:");
                    DisplayStudents(searchResults);
                }

                Console.WriteLine("\nDo you want to continue? (y/n):");
            } while (Console.ReadLine().Trim().Equals("y", StringComparison.OrdinalIgnoreCase));
        }

        static List<Student> ReadStudentData(string filePath)
        {
            List<Student> students = new List<Student>();

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] data = line.Split(',');
                    if (data.Length == 2)
                    {
                        Student student = new Student
                        {
                            Name = data[0].Trim(),
                            Class = data[1].Trim()
                        };
                        students.Add(student);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading student data: " + ex.Message);
            }

            return students;
        }

        static List<Student> SearchStudents(List<Student> students, string searchName)
        {
            return students.FindAll(s => s.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase));
        }

        static void DisplayStudents(List<Student> students)
        {
            foreach (Student student in students)
            {
                Console.WriteLine($"Name: {student.Name}, Class: {student.Class}");
            }
            Console.ReadKey();
        }

    }

    /*public class Student
    {
        public string Name { get; set; }
        public int Class { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            // Read data from he text file and populate the 'students' list
            string filePath = @"C:\\Users\\91849\\OneDrive\\Desktop\\p1p2.txt\";
            ReadDataFromFile(filePath, students);

            // Sort the 'students' list by name
            students.Sort((s1, s2) => string.Compare(s1.Name, s2.Name, StringComparison.OrdinalIgnoreCase));

            // Display the sorted list of students
            DisplayStudents(students);

            // Allow searching of students by name
            Console.Write("\nEnter the student's name to search: ");
            string searchName = Console.ReadLine();
            SearchStudentByName(students, searchName);
        }

        // Read student data from the file and populate the list
        static void ReadDataFromFile(string filePath, List<Student> students)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] data = line.Split(',');
                    if (data.Length == 2)
                    {
                        string name = data[0].Trim();
                        int studentClass = int.Parse(data[1].Trim());

                        students.Add(new Student { Name = name, Class = studentClass });
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found. Please ensure 'students.txt' exists with the correct data format.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while reading the file: " + ex.Message);
            }
        }

        // Display the list of students
        static void DisplayStudents(List<Student> students)
        {
            Console.WriteLine("\nList of students:");
            Console.WriteLine("-----------------");
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Name}, Class {student.Class}");
            }
        }

        // Search for a student by name and display the result
        static void SearchStudentByName(List<Student> students, string searchName)
        {
            var result = students.FindAll(student => student.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase));

            if (result.Count > 0)
            {
                Console.WriteLine("\nSearch results:");
                Console.WriteLine("----------------");
                foreach (var student in result)
                {
                    Console.WriteLine($"{student.Name}, Class {student.Class}");
                }
            }
            else
            {
                Console.WriteLine("\nStudent not found.");*/



}
