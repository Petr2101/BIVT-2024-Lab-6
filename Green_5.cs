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
            public int[] Marks => _marks != null ? (int[])_marks.Clone() : new int[5];

            public double AvgMark => _marks != null && _marks.Length > 0 ? _marks.Average() : 0;

            public Student(string name, string surname)
            {
                _name = name ?? "";
                _surname = surname ?? "";
                _marks = new int[5];
                for (int i = 0; i < _marks.Length; i++)
                {
                    _marks[i] = 2; 
                }
            }

            public void Exam(int mark)
            {
                if (mark < 2 || mark > 5) return;
                for (int i = 0; i < _marks.Length; i++)
                {
                    if (_marks[i] == 2) 
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
            public Student[] Students => _students != null ? _students.Take(_count).ToArray() : new Student[0];
            public double AvgMark => _count > 0 ? _students.Take(_count).Average(s => s.AvgMark) : 0;

            public Group(string name)
            {
                _name = name ?? "";
                _students = new Student[10]; 
                _count = 0;
            }

            public void Add(Student student)
            {
                if (_students == null) _students = new Student[10];
                if (_count >= _students.Length) Array.Resize(ref _students, _students.Length * 2);
                _students[_count] = student;
                _count++;
            }

            public void Add(Student[] students)
            {
                if (students == null) return;
                if (_students == null) _students = new Student[students.Length];
                int newCount = _count + students.Length;
                if (newCount > _students.Length) Array.Resize(ref _students, newCount);
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
