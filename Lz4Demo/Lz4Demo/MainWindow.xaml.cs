using System;
using System.Text;
using System.Windows;
using LZ4;
using HiPerfMetrics;

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
            HiPerfMetric hiPerfMetric = new HiPerfMetric("Compress");
            hiPerfMetric.Start();
            var result = LZ4Codec.Wrap(Encoding.UTF8.GetBytes(textboxforlz4.Text));
            textboxforlz4.Text = Convert.ToBase64String(result);
            hiPerfMetric.Stop();
            TimeResult.Text = "compress time spend time(s) is:" + hiPerfMetric.TotalTimeInSeconds.ToString();
        }

        private void Decompressbtn_Click(object sender, RoutedEventArgs e)
        {
            HiPerfMetric hiPerfMetric = new HiPerfMetric("Decompress");
            hiPerfMetric.Start();
            textboxforlz4.Text = Encoding.UTF8.GetString(
                    LZ4Codec.Unwrap(Convert.FromBase64String(textboxforlz4.Text)));
            hiPerfMetric.Stop();
            TimeResult.Text = "compress time spend time(s) is:" + hiPerfMetric.TotalTimeInSeconds.ToString();

        }
    }
}
