using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Green_1
    {
        public struct Participant
        {
            private string _surname;
            private string _group;
            private string _trainer;
            private double _result;
            private bool _resultFilled;
            private static readonly double _standard;
            private static int _passedCount;
            public string Surname => _surname;
            public string Group => _group;
            public string Trainer => _trainer;
            public double Result => _result;
            public static int PassedTheStandard => _passedCount;
            public bool HasPassed => _resultFilled && _result > 0 && _result <= _standard;
            static Participant()
            {
                _standard = 100;
                _passedCount = 0;
            }
            public Participant(string surname, string group, string trainer)
            {
                _surname = surname ?? "";
                _group = group ?? "";
                _trainer = trainer ?? "";
                _result = 0;
                _resultFilled = false;
            }
            public void Run(double result)
            {
                if (result <= 0)
                {
                    return;
                }
                if (!_resultFilled)
                {
                    _result = result;
                    _resultFilled = true;
                    if (_result <= _standard)
                    {
                        _passedCount++;
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine($"Фамилия: {Surname}, Группа: {Group}, Тренер: {Trainer}, Результат: {Result:F2}, Прошла норматив: {HasPassed}");
            }
        }
    }

}
