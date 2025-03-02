using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Green_2
    {
        public struct Student
        {
            private string _name;
            private string _surname;
            private int[] _marks;

            public string Name => _name;
            public string Surname => _surname;
            public int[] Marks => _marks.ToArray(); 

            public double AvgMark => _marks.Length > 0 ? (double)_marks.Sum() / _marks.Length : 0;
            public bool IsExcellent => _marks.Length > 0 && _marks.All(mark => mark >= 4); 

            public Student(string name, string surname)
            {
                _name = name ?? "";
                _surname = surname ?? "";
                _marks = new int[4];
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

            public static void SortByAvgMark(Student[] array)
            {
                if (array == null || array.Length == 0) return;
                Array.Sort(array, (a, b) => b.AvgMark.CompareTo(a.AvgMark));
            }

            public void Print()
            {
                Console.WriteLine($"{Name} {Surname} - Средний балл: {AvgMark:F2}, Отличник: {IsExcellent}");
            }
        }
    }

}
