using System.Windows;
using UI_DetermenantFinder.Windows;
using Matrix = UI_DetermenantFinder.Objects.Matrix;

namespace UI_DetermenantFinder {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }
        public Matrix Matrix { get; set; }
        private void CreateMatrix(object sender, RoutedEventArgs e) {
            new Constructor(this).Show();
        }
        private void GetDeterminant(object sender, RoutedEventArgs e) {
            Answer.Content = $"\nОпределитель равен: {Matrix.GetDeterminant()}\nХод вычеслений:\n{Matrix.Work}";
        }
    }
}