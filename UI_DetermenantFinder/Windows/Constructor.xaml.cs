using System;
using System.Windows;
using System.Windows.Controls;
using UI_DetermenantFinder.GUInterface;
using UI_DetermenantFinder.Objects;

namespace UI_DetermenantFinder.Windows
{
   public partial class Constructor : Window {
        public Constructor(MainWindow mainWindow) {
            InitializeComponent();
            UpdateInterface();
            
            MainWindow = mainWindow;
        }
        private MainWindow MainWindow { get; set; }
        private int _xSize = 2;
        private int _ySize = 2;
        public void IncreaseXSize(object sender, RoutedEventArgs routedEventArgs) {
            _xSize++;
            UpdateInterface();
        }
        public void IncreaseYSize(object sender, RoutedEventArgs routedEventArgs) {
            _ySize++;
            UpdateInterface();
        }
        public void DecreaseXSize(object sender, RoutedEventArgs routedEventArgs) {
            if (_xSize > 2) _xSize--;
            UpdateInterface();
        }
        public void DecreaseYSize(object sender, RoutedEventArgs routedEventArgs) {
            if (_ySize > 2) _ySize--;
            UpdateInterface();
        }
        private void UpdateInterface() {
            MatrixParent.Children.Clear();
            MatrixParent.Children.Add(GetMatrixGui.GetMatrix(_xSize, _ySize, this));
        }
        private void SaveMatrix(object sender, EventArgs e) {
            try {
                var temp     = new double[_xSize, _ySize];
                var count    = 0;

                var matrixGrid = MatrixParent.Children[^1] as Grid;
                
                for (var i = _xSize - 1; i >= 0; i--) {
                    for (var j = _ySize - 1; j >= 0; j--) {
                        if (double.TryParse((matrixGrid!.Children[^++count] as TextBox)!.Text, out var tempDouble)) {
                            temp[i, j] = tempDouble;
                        }
                        else {
                            MessageBox.Show($"Неккоректное значение в матрице в {i};{j}");
                            temp[i, j] = 0;
                        }
                    }
                }
                
                var matrix = new Matrix(temp);
                
                MainWindow.Matrix = matrix;
                Close();
            }
            catch (Exception exception) {
                MessageBox.Show($"{exception}", "Ошибка с сохранением!");
                throw;
            }
        }
   }
}