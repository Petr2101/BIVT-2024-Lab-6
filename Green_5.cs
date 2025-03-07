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
            private string firstName;
            private string lastName;
            private int[] subjectScores;
            public string Name => firstName;
            public string Surname => lastName;
            public int[] Marks => subjectScores != null ? (int[])subjectScores.Clone() : null;
            public Student(string name, string surname)
            {
                firstName = name;
                lastName = surname;
                subjectScores = new int[5];
                Array.Clear(subjectScores, 0, subjectScores.Length); 
            }
            public double AvgMark
            {
                get
                {
                    if (subjectScores == null || subjectScores.Length == 0)
                        return 0;
                    double total = 0;
                    int count = 0;
                    foreach (int score in subjectScores)
                    {
                        if (score != 0)
                        {
                            total += score;
                            count++;
                        }
                    }
                    return count > 0 ? total / count : 0;
                }
            }
            public void SetExamScore(int mark)
            {
                if (subjectScores == null || mark < 2 || mark > 5)
                    return;
                for (int i = 0; i < subjectScores.Length; i++)
                {
                    if (subjectScores[i] == 0)
                    {
                        subjectScores[i] = mark;
                        return;
                    }
                }
            }
            public void ShowDetails()
            {
                string scoresText = Marks != null ? string.Join(", ", Marks) : "No scores";
                Console.WriteLine($"{Name,-12} {Surname,-12} {AvgMark,-12:F2} {scoresText}");
            }
        }
        public struct Group
        {
            private string groupTitle;
            private Student[] enrolledStudents;
            private int enrolledCount;

            public string Name => groupTitle;
            public Student[] Students => enrolledStudents;

            public Group(string title)
            {
                groupTitle = title;
                enrolledStudents = new Student[0];
                enrolledCount = 0;
            }
            public double AvgMark
            {
                get
                {
                    if (enrolledStudents == null || enrolledCount == 0)
                        return 0;

                    double sum = 0;
                    int markCount = 0;
                    for (int i = 0; i < enrolledCount; i++)
                    {
                        int[] studentMarks = enrolledStudents[i].Marks;
                        if (studentMarks != null)
                        {
                            foreach (int mark in studentMarks)
                            {
                                if (mark != 0)
                                {
                                    sum += mark;
                                    markCount++;
                                }
                            }
                        }
                    }
                    return markCount > 0 ? sum / markCount : 0;
                }
            }
            public void EnrollStudent(Student student)
            {
                if (enrolledStudents == null)
                    enrolledStudents = new Student[0];

                Array.Resize(ref enrolledStudents, enrolledCount + 1);
                enrolledStudents[enrolledCount] = student;
                enrolledCount++;
            }
            public void EnrollMultipleStudents(Student[] students)
            {
                if (students == null || students.Length == 0)
                    return;

                if (enrolledStudents == null)
                    enrolledStudents = new Student[0];

                int newSize = enrolledCount + students.Length;
                Array.Resize(ref enrolledStudents, newSize);
                Array.Copy(students, 0, enrolledStudents, enrolledCount, students.Length);
                enrolledCount = newSize;
            }
            public static void OrderByAverageScore(Group[] groups)
            {
                if (groups == null || groups.Length <= 1)
                    return;

                for (int i = 0; i < groups.Length - 1; i++)
                {
                    for (int j = 0; j < groups.Length - i - 1; j++)
                    {
                        if (groups[j].AvgMark < groups[j + 1].AvgMark)
                        {
                            Group temp = groups[j];
                            groups[j] = groups[j + 1];
                            groups[j + 1] = temp;
                        }
                    }
                }
            }
            public void DisplayGroupInfo()
            {
                Console.WriteLine($"{Name,-12} {AvgMark,-15:F2}");
            }
        }
    }
}
