using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Green_4
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private double[] _jumps;
            private int _attempts;
            public string Name => _name;
            public string Surname => _surname;
            public double[] Jumps => _jumps != null ? (double[])_jumps.Clone() : new double[3];
            public double BestJump
            {
                get
                {
                    if (_jumps == null) return 0;
                    double best = 0;
                    foreach (var jump in _jumps)
                    {
                        if (jump > best)
                            best = jump;
                    }
                    return best;
                }
            }
            public Participant(string name, string surname)
            {
                _name = name ?? string.Empty;
                _surname = surname ?? string.Empty; 
                _jumps = new double[3]; 
                _attempts = 0;
            }
            public void Jump(double result)
            {
                if (_attempts < 3 && result >= 0)
                {
                    _jumps[_attempts] = result;
                    _attempts++;
                }
            }
            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0) return;
                Array.Sort(array, (p1, p2) => p2.BestJump.CompareTo(p1.BestJump));
            }
            public void Print()
            {
                Console.WriteLine($"{Name} {Surname} - Best Jump: {BestJump:F2}");
            }
        }
    }

}
