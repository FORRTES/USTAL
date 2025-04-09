using System;

namespace StudentApp
{
    internal class StudentScores
    {
        // Приватные поля для хранения оценок
        private double _math;
        private double _physics;
        private double _informatics;

        // Конструктор с параметрами — инициализация оценок
        public StudentScores(double math, double physics, double informatics)
        {
            _math = math;
            _physics = physics;
            _informatics = informatics;
        }

        // Конструктор копирования — создает копию объекта
        public StudentScores(StudentScores original)
        {
            if (original == null)
                throw new ArgumentNullException(nameof(original));

            _math = original._math;
            _physics = original._physics;
            _informatics = original._informatics;
        }

        // Метод для получения максимальной оценки
        public double GetMax()
        {
            double max = _math;
            if (_physics > max) max = _physics;
            if (_informatics > max) max = _informatics;
            return max;
        }

        // Метод для вычисления среднего арифметического
        public double Average()
        {
            return (_math + _physics + _informatics) / 3.0;
        }

        // Переопределение метода ToString() для удобного вывода
        public override string ToString()
        {
            return $"Mathematics: {_math}, Physics: {_physics}, Informatics: {_informatics}";
        }

        // Свойства только для чтения (get-only)
        public double Math => _math;
        public double Physics => _physics;
        public double Informatics => _informatics;
    }
}
