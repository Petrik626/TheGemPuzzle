using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GemPuzzle.DataModel
{
    internal sealed class PuzzleModel:UIElement
    {
        #region FIELDS
        private static Lazy<PuzzleModel> instance;
        public static DependencyProperty ActualRowIndexProperty;
        public static DependencyProperty ActualColumnIndexProperty;
        public static DependencyProperty MoveRowIndexProperty;
        public static DependencyProperty MoveColumnIndexProperty;
        private bool[,] gameField = new bool[4, 4]
        {
            {false,false,false,false },
            {false,false,false,false },
            {false,false,false,false },
            {false,false,false,true }
        };
        private Dictionary<Puzzle, PairIndexPuzzle> pairs = new Dictionary<Puzzle, PairIndexPuzzle>()
        {
            [new Puzzle(0, 112.5, 450, 337.5)] = new PairIndexPuzzle(0, 0),
            [new Puzzle(112.5, 225, 450, 337.5)] = new PairIndexPuzzle(0, 1),
            [new Puzzle(225, 337.5, 450, 337.5)] = new PairIndexPuzzle(0, 2),
            [new Puzzle(337.5, 450, 450, 337.5)] = new PairIndexPuzzle(0, 3),
            [new Puzzle(0, 112.5, 337.5, 225)] = new PairIndexPuzzle(1, 0),
            [new Puzzle(112.5, 225, 337.5, 225)] = new PairIndexPuzzle(1, 1),
            [new Puzzle(225, 337.5, 337.5, 225)] = new PairIndexPuzzle(1, 2),
            [new Puzzle(337.5, 450, 337.5, 225)] = new PairIndexPuzzle(1, 3),
            [new Puzzle(0, 112.5, 225, 112.5)] = new PairIndexPuzzle(2, 0),
            [new Puzzle(112.5, 225, 225, 112.5)] = new PairIndexPuzzle(2, 1),
            [new Puzzle(225, 337.5, 225, 112.5)] = new PairIndexPuzzle(2, 2),
            [new Puzzle(337.5, 450, 225, 112.5)] = new PairIndexPuzzle(2, 3),
            [new Puzzle(0, 112.5, 112.5, 0)] = new PairIndexPuzzle(3, 0),
            [new Puzzle(112.5, 225, 112.5, 0)] = new PairIndexPuzzle(3, 1),
            [new Puzzle(225, 337.5, 112.5, 0)] = new PairIndexPuzzle(3, 2),
            [new Puzzle(337.5, 450, 112.5, 0)] = new PairIndexPuzzle(3, 3)
        };
        #endregion
        #region CONSTRUCTORS
        private PuzzleModel() { }
        static PuzzleModel()
        {
            instance = new Lazy<PuzzleModel>(() => new PuzzleModel());

            FrameworkPropertyMetadata metadataActualRow = new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault);
            FrameworkPropertyMetadata metadataActualColumn = new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault);
            FrameworkPropertyMetadata metadataMoveRow = new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault);
            FrameworkPropertyMetadata metadataMoveColumn = new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault);


            ActualRowIndexProperty = DependencyProperty.Register("ActualRowIndex", typeof(int), typeof(PuzzleModel), metadataActualRow);
            ActualColumnIndexProperty = DependencyProperty.Register("ActualColumnIndex", typeof(int), typeof(PuzzleModel), metadataActualColumn);
            MoveRowIndexProperty = DependencyProperty.Register("MoveRowIndex", typeof(int), typeof(PuzzleModel), metadataMoveRow);
            MoveColumnIndexProperty = DependencyProperty.Register("MoveColumnIndex", typeof(int), typeof(PuzzleModel), metadataMoveColumn);
        }
        #endregion
        #region PROPERTIES
        public static PuzzleModel Source => instance.Value;
        public int ActualRowIndex
        {
            get => (int)GetValue(ActualRowIndexProperty);
            set => SetValue(ActualRowIndexProperty, value);
        }
        public int ActualColumnIndex
        {
            get => (int)GetValue(ActualColumnIndexProperty);
            set => SetValue(ActualColumnIndexProperty, value);
        }
        public int MoveRowIndex
        {
            get => (int)GetValue(MoveRowIndexProperty);
            set => SetValue(MoveRowIndexProperty, value);
        }
        public int MoveColumnIndex
        {
            get => (int)GetValue(MoveColumnIndexProperty);
            set => SetValue(MoveColumnIndexProperty, value);
        }
        #endregion
        #region METHODS
        public void FindIndexesMove()
        {
            int moveIndexRow = 0, moveIndexColumn = 0;
            for(int i=0; i<4; i++)
            {
                for(int j=0; j<4; j++)
                {
                    if(gameField[i,j])
                    {
                        moveIndexRow = i;
                        moveIndexColumn = j;
                    }
                }
            }

            MoveRowIndex = moveIndexRow; MoveColumnIndex = moveIndexColumn;
            gameField[ActualRowIndex, ActualColumnIndex] = true;
            gameField[moveIndexRow, moveIndexColumn] = false;
        }
        #endregion
    }

    internal sealed class Puzzle:IEquatable<Puzzle>
    {
        #region FIELDS
        private double _a;
        private double _b;
        private double _c;
        private double _d;
        #endregion
        #region CONSTRUCTORS
        public Puzzle(double a,double b, double c, double d)
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

    internal struct PairIndexPuzzle:IEquatable<PairIndexPuzzle>
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
