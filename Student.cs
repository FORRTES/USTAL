using System;

namespace StudentApp
{
    internal class Student
    {
        private string _name;
        private bool _passed;
        private StudentScores _scores;

        public Student(string name, StudentScores scores)
        {
            _name = name;
            _scores = new StudentScores(scores); // защита от внешней мутации
            _passed = CheckIfPassed();
        }

        public Student(Student original)
        {
            _name = original._name;
            _scores = new StudentScores(original._scores);
            _passed = original._passed;
        }

        private bool CheckIfPassed()
        {
            return _scores.Math >= 3 && _scores.Physics >= 3 && _scores.Informatics >= 3;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Name: {_name}");
            Console.WriteLine(_scores);
            Console.WriteLine($"Average score: {_scores.Average():F2}");
            Console.WriteLine($"Result: {(_passed ? "Pass" : "Fail")}");
        }
    }
}
