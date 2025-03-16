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
            public int[] Marks
            {
                get
                {
                    if (_marks == null)
                    {
                        return null;
                    }
                    int[] array = new int[_marks.Length];
                    Array.Copy(_marks, array, _marks.Length);
                    return array;
                }    
            }
            public double AvgMark
            {
                get
                {
                    if (_marks == null || _marks.Length == 0)
                    {
                        return 0;
                    }
                    double summ = 0;
                    for (int i = 0; i < _marks.Length; i++)
                    {
                        summ += _marks[i];
                    }
                    return summ / _marks.Length;
                }
            }
            public Student(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[5];
            }
            public void Exam(int mark)
            {
                if (_marks == null)
                {
                    return;
                }
                if (mark < 2 || mark > 5)
                {
                    return;
                }
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
                Console.WriteLine($"{Name} {Surname}");
                Console.WriteLine($"Средний балл: {AvgMark:F2}");
            }
        }
        public struct Group
        {
            private string _name;
            private Student[] _students;
            private int _count;
            public string Name => _name;
            public Student[] Students => _students;
            public double AvgMark
            {
                get
                {
                    if (_students == null || _count == 0)
                    {
                        return 0;
                    }
                    int val = 0;
                    double avg = 0;

                    for (int i = 0; i < _count; i++)
                    {
                        if (_students[i].AvgMark > 0)
                        {
                            avg += _students[i].AvgMark;
                            val++;
                        }
                    }
                    return val == 0 ? 0 : avg / val;
                }
            }
            public Group(string name)
            {
                _name = name;
                _students = new Student[0];
                _count = 0;
            }
            public void Add(Student student)
            {
                if (_students == null)
                    _students = new Student[0];
                Array.Resize(ref _students, _count + 1);
                _students[_count] = student;
                _count++;
            }
            public void Add(Student[] Students)
            {
                if (Students == null)
                {
                    return;
                }
                if (_students == null)
                {
                    _students = new Student[0];
                }
                int len = _count + Students.Length;
                Array.Resize(ref _students, len);
                for (int i = 0; i < Students.Length; i++)
                {
                    _students[_count + i] = Students[i];
                }
                _count = len;
            }
            public void Print()
            {
                Console.WriteLine($"Группа: {Name} | Средний балл: {AvgMark:F2}");

                foreach (var st in _students)
                {
                    st.Print();
                }
            }
            public static void SortByAvgMark(Group[] array)
            {
                if (array == null || array.Length == 0)
                    return;
                bool swapped;
                do
                {
                    swapped = false;
                    for (int i = 0; i < array.Length - 1; i++)
                    {
                        if (array[i].AvgMark < array[i + 1].AvgMark)
                        {
                            Group vre = array[i];
                            array[i] = array[i + 1];
                            array[i + 1] = vre;
                            swapped = true;
                        }
                    }
                } while (swapped);
            }
        }
    }
}
