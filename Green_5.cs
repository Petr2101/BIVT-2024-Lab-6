using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5
{
    public class Green_5
    {
        public struct Student
        {
            private string _name;
            private string _surname;
            private int[] _marks;
            public string Name => _name;
            public string Surname => _surname;
            public int[] Marks => (int[])_marks.Clone();
            public double AvgMark
            {
                get
                {
                    int count = 0;
                    double sum = 0;
                    foreach (var mark in _marks)
                    {
                        if (mark > 0)
                        {
                            sum += mark;
                            count++;
                        }
                    }
                    return count > 0 ? sum / count : 0;
                }
            }
            public Student(string name, string surname)
            {
                _name = name ?? "";
                _surname = surname ?? "";
                _marks = new int[5]; 
            }
            public void Exam(int mark)
            {
                if (mark < 2 || mark > 5) return; 
                for (int i = 0; i < _marks.Length; i++)
                {
                    if (_marks[i] == 0) 
                    {
                        _marks[i] = mark;
                        break;
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine($"{Name} {Surname} - Avg: {AvgMark:F2}, Marks: {string.Join(", ", Marks)}");
            }
        }
        public struct Group
        {
            private string _name;
            private Student[] _students;
            private int _count;

            public string Name => _name;
            public Student[] Students => (Student[])_students.Take(_count).ToArray();
            public double AvgMark => _count > 0 ? _students.Take(_count).Average(s => s.AvgMark) : 0; 
            public Group(string name)
            {
                _name = name ?? "";
                _students = new Student[0]; 
                _count = 0;
            }
            public void Add(Student student)
            {
                Array.Resize(ref _students, _count + 1);
                _students[_count] = student;
                _count++;
            }
            public void Add(Student[] students)
            {
                if (students == null) return;
                int newCount = _count + students.Length;
                Array.Resize(ref _students, newCount);
                Array.Copy(students, 0, _students, _count, students.Length);
                _count = newCount;
            }
            public static void SortByAvgMark(Group[] array)
            {
                if (array == null || array.Length == 0) return;
                Array.Sort(array, (g1, g2) => g2.AvgMark.CompareTo(g1.AvgMark));
            }
            public void Print()
            {
                Console.WriteLine($"Group: {Name}, Avg Mark: {AvgMark:F2}");
                for (int i = 0; i < _count; i++)
                {
                    _students[i].Print();
                }
            }
        }
    }
}
