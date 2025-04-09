using System;

namespace StudentApp
{
    internal class StudentScores
    {
        private double _math;
        private double _physics;
        private double _informatics;

        public StudentScores(double math, double physics, double informatics)
        {
            _math = math;
            _physics = physics;
            _informatics = informatics;
        }

        public StudentScores(StudentScores original)
        {
            if (original == null)
                throw new ArgumentNullException(nameof(original));

            _math = original._math;
            _physics = original._physics;
            _informatics = original._informatics;
        }

        public double GetMax()
        {
            double max = _math;
            if (_physics > max) max = _physics;
            if (_informatics > max) max = _informatics;
            return max;
        }


        public double Average()
        {
            return (_math + _physics + _informatics) / 3.0;
        }

        public override string ToString()
        {
            return $"Mathematics: {_math}, Physics: {_physics}, Informatics: {_informatics}";
        }

        public double Math => _math;
        public double Physics => _physics;
        public double Informatics => _informatics;
    }
}
