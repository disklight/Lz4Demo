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
using LZ4;

namespace Lz4Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Compressbtn_Click(object sender, RoutedEventArgs e)
        {
            var result = LZ4Codec.Wrap(Encoding.UTF8.GetBytes(textboxforlz4.Text));
            textboxforlz4.Text = Convert.ToBase64String(result);
        }

        private void Decompressbtn_Click(object sender, RoutedEventArgs e)
        {
            var result1 = Encoding.UTF8.GetString(
                    LZ4Codec.Unwrap(Convert.FromBase64String(textboxforlz4.Text)));
            textboxforlz4.Text = result1;
        }
    }
}
