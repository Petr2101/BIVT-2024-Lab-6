using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Green_3
    {
        public struct Student
        {
            private string _name;
            private string _surname;
            private int[] _marks;
            private bool _isExpelled;

            public string Name => _name;
            public string Surname => _surname;
            public int[] Marks => _marks?.ToArray() ?? new int[3];
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
            public bool IsExpelled => _isExpelled;
            public Student(string name, string surname)
            {
                _name = name ?? "";
                _surname = surname ?? "";
                _marks = new int[3]; 
                _isExpelled = false;
            }
            public void Exam(int mark)
            {
                if (_isExpelled || mark < 2 || mark > 5) return;
                for (int i = 0; i < _marks.Length; i++)
                {
                    if (_marks[i] == 0)
                    {
                        _marks[i] = mark;
                        if (mark == 2) _isExpelled = true;
                        break;
                    }
                }
            }
            public static void SortByAvgMark(Student[] array)
            {
                if (array == null || array.Length == 0) return;
                Array.Sort(array, (a, b) => b.AvgMark.CompareTo(a.AvgMark));
            }
            public void Print()
            {
                Console.WriteLine($"{Name} {Surname} - Средний балл: {AvgMark:F2}, Отчислен: {IsExpelled}");
            }
        }
    }
}
