using System;

namespace StudentApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Приветствие и инструкция для пользователя
            Console.WriteLine("Student Grade Analyzer");
            Console.WriteLine("Enter grades for Math, Physics, and Informatics separated by a space.");
            Console.WriteLine("Grades must be from 0 to 5 inclusive.");
            Console.WriteLine("Type 'q' to quit.");

            while (true)
            {
                // Запрос ввода оценок
                Console.Write("\nEnter 3 grades: ");
                string? input = Console.ReadLine()?.Trim();

                // Проверка на пустой ввод
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Input is empty. Please try again.");
                    continue;
                }

                // Выход из программы
                if (input.ToLower() == "q")
                {
                    Console.WriteLine("Exiting the program...");
                    break;
                }

                // Разделение строки на части
                string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length != 3)
                {
                    Console.WriteLine("Please enter exactly three grades separated by spaces.");
                    continue;
                }

                // Попытка преобразовать оценки в целые числа
                if (!int.TryParse(parts[0], out int math) ||
                    !int.TryParse(parts[1], out int physics) ||
                    !int.TryParse(parts[2], out int info))
                {
                    Console.WriteLine("Error: Please enter **whole numbers only** (no decimals).");
                    continue;
                }

                // Проверка, что оценки в допустимом диапазоне
                if (!IsValidGrade(math) || !IsValidGrade(physics) || !IsValidGrade(info))
                {
                    Console.WriteLine("Grades must be between 0 and 5.");
                    continue;
                }

                // Запрос имени студента
                Console.Write("Enter student's name: ");
                string? name = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(name))
                    name = "Unnamed";

                // Создание объекта с оценками
                var scores = new StudentScores(math, physics, info);

                // Создание копии оценок
                var scoresCopy = new StudentScores(scores);

                // Создание объекта студента
                var student = new Student(name, scores);

                // Копирование студента
                var studentCopy = new Student(student);

                // Вывод результатов
                Console.WriteLine();
                Console.WriteLine("Analysis Results:");
                Console.WriteLine("Original Scores:");
                Console.WriteLine(scores);
                Console.WriteLine($"Highest grade: {scores.GetMax()}");

                Console.WriteLine("\nCopied Scores:");
                Console.WriteLine(scoresCopy);
                Console.WriteLine($"Highest grade: {scoresCopy.GetMax()}");

                Console.WriteLine("\nStudent Information:");
                student.PrintInfo();

                Console.WriteLine("\nCopied Student:");
                studentCopy.PrintInfo();

                // Предложение проанализировать другого студента
                Console.Write("Do you want to analyze another student? (y/n): ");
                string? answer = Console.ReadLine()?.Trim().ToLower();
                if (answer != "y" && answer != "yes")
                {
                    Console.WriteLine("Exiting the program...");
                    break;
                }
            }

            // Завершение программы
            Console.WriteLine("Thank you for using the program. Press any key to exit...");
            Console.ReadKey();
        }

        // Проверка, что оценка от 2 до 5 включительно
        static bool IsValidGrade(double grade)
        {
            return grade >= 2 && grade <= 5;
        }
    }
}
