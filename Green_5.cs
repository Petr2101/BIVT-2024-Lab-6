using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
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
            public int[] Marks => _marks?.Clone() as int[] ?? new int[0];
            public double AvgMark
            {
                get
                {
                    if (_marks == null || _marks.Length == 0) return 0;
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
            public Student()
            {
                _name = "";
                _surname = "";
                _marks = new int[0]; 
            }
            public void Exam(int mark)
            {
                if (_marks == null || mark < 2 || mark > 5) return;
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
            public Student[] Students => _students?.Take(_count).ToArray() ?? new Student[0];
            public double AvgMark
            {
                get
                {
                    if (_students == null || _count == 0) return 0;
                    double sum = 0;
                    int studentCount = 0;
                    for (int i = 0; i < _count; i++)
                    {
                        if (_students[i].AvgMark > 0)
                        {
                            sum += _students[i].AvgMark;
                            studentCount++;
                        }
                    }
                    return studentCount > 0 ? sum / studentCount : 0;
                }
            }
            public Group(string name)
            {
                _name = name ?? "";
                _students = new Student[0]; 
                _count = 0;
            }
            public Group()
            {
                _name = "";
                _students = new Student[0];
                _count = 0;
            }
            public void Add(Student student)
            {
                if (_students == null) _students = new Student[0];
                Array.Resize(ref _students, _count + 1);
                _students[_count] = student;
                _count++;
            }
            public void Add(Student[] students)
            {
                if (students == null) return;
                if (_students == null) _students = new Student[0];
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
