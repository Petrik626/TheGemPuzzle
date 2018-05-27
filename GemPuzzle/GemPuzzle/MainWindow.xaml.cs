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

        private void Button15_Click(object sender, RoutedEventArgs e)
        {
            //Blanket
            model.ActualRowIndex = 3;
            model.ActualColumnIndex = 2;
            model.MoveRowIndex = 3;
            model.MoveColumnIndex = 3;
        }
    }
}
