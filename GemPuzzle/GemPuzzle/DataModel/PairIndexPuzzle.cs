using System;
using System.Text;

namespace GemPuzzle.DataModel
{
    internal struct PairIndexPuzzle : IEquatable<PairIndexPuzzle>
    {
        #region FIELDS
        private readonly int _index1;
        private readonly int _index2;
        #endregion
        #region CONSTRUCORS
        public PairIndexPuzzle(int i, int j)
        {
            _index1 = i;
            _index2 = j;
        }
        #endregion
        #region METHODS
        public bool Equals(PairIndexPuzzle other)
        {
            return (_index1 == other._index1) && (_index2 == other._index2);
        }

        public override bool Equals(object obj)
        {
            return (obj is PairIndexPuzzle) ? Equals((PairIndexPuzzle)obj) : false;
        }

        public override int GetHashCode()
        {
            return _index1.GetHashCode() ^ _index2.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"I={_index1}");
            builder.Append($"J={_index2}");

            return builder.ToString();
        }
        #endregion
        #region PROPERTIES
        public int I { get => _index1; }
        public int J { get => _index2; }
        #endregion
    }
}
