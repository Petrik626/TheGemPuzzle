using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GemPuzzle.DataModel
{
    internal class PuzzleModel:UIElement
    {
        #region FIELDS
        private static Lazy<PuzzleModel> instance;
        public static DependencyProperty ActualRowIndexProperty;
        public static DependencyProperty ActualColumnIndexProperty;
        public static DependencyProperty MoveRowIndexProperty;
        public static DependencyProperty MoveColumnIndexProperty;
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
    }
}
