using System;
using System.Collections.Generic;
using System.Text;

namespace GemPuzzle.DataModel
{
    internal sealed class Puzzle : IEquatable<Puzzle>
    {
        #region FIELDS
        private double _a;
        private double _b;
        private double _c;
        private double _d;
        #endregion
        #region CONSTRUCTORS
        public Puzzle(double a, double b, double c, double d)
        {
            _a = a;
            _b = b;
            _c = c;
            _d = d;
        }
        #endregion
        #region METHODS
        public bool Equals(Puzzle other)
        {
            return (_a == other._a) && (_b == other._b) && (_c == other._c) && (_d == other._d);
        }

        public override bool Equals(object obj)
        {
            return (obj is Puzzle) ? Equals((Puzzle)obj) : false;
        }

        public override int GetHashCode()
        {
            return _a.GetHashCode() ^ _b.GetHashCode() ^ _c.GetHashCode() ^ _d.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"A={_a}");
            builder.Append($"B={_b}");
            builder.Append($"C={_c}");
            builder.Append($"D={_d}");

            return builder.ToString();
        }
        #endregion
        #region PROPERTIES
        public double A { get => _a; set => _a = value; }
        public double B { get => _b; set => _b = value; }
        public double C { get => _c; set => _c = value; }
        public double D { get => _d; set => _d = value; }
        #endregion
    }
}
