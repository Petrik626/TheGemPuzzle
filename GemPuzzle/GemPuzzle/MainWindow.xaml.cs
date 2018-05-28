using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GemPuzzle.DataModel;

namespace GemPuzzle
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PuzzleModel model;
        public MainWindow()
        {
            InitializeComponent();
            model = PuzzleModel.Source;
            this.DataContext = model;
        }

        private void PuzzleButton_Click(object sender, RoutedEventArgs e)
        {
            model.ActualColumnIndex = 3; model.ActualRowIndex = 2;
            model.FindIndexesMove();
        }

        private void PuzzeGrid_MouseMove(object sender, MouseEventArgs e)
        {
            model.CoordinateWindowX = e.GetPosition(null).X;
            model.CoordinateWindowY = e.GetPosition(null).Y;
        }
    }
}
