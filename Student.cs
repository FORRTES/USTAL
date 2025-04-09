using System;

namespace StudentApp
{
    internal class Student
    {
        // Имя студента
        private string _name;

        // Статус сдачи: сдал или нет
        private bool _passed;

        // Объект с оценками студента
        private StudentScores _scores;

        // Конструктор с параметрами
        public Student(string name, StudentScores scores)
        {
            _name = name;

            // Копируем оценки
            _scores = new StudentScores(scores);

            _passed = CheckIfPassed();
        }

        // Конструктор копирования
        public Student(Student original)
        {
            _name = original._name;

            // Создаем копию объекта оценок
            _scores = new StudentScores(original._scores);

            // Копируем флаг сдачи
            _passed = original._passed;
        }

        // Метод проверяет, сдал ли студент все предметы
        private bool CheckIfPassed()
        {
            return _scores.Math >= 3 && _scores.Physics >= 3 && _scores.Informatics >= 3;
        }

        // Метод вывода информации о студенте
        public void PrintInfo()
        {
            Console.WriteLine($"Name: {_name}");
            Console.WriteLine(_scores); // Использует ToString() из StudentScores
            Console.WriteLine($"Average score: {_scores.Average():F2}"); // Средний балл с 2 знаками после запятой
            Console.WriteLine($"Result: {(_passed ? "Pass" : "Fail")}"); // Вывод результата: Pass или Fail
        }
    }
}
