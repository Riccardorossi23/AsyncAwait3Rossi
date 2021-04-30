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

namespace AsyncAwait3Rossi
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
        public async Task<int> Multipli(int n)
        {
            int n_multipli = 0;
            await Task.Run(() =>
            {
                for (int i = 0; i < 200000000; i++)
                {
                    if (i % n == 0)
                    {
                        n_multipli++;
                    }
                    if (i % 2000000 == 0)
                    {
                        Progress.Dispatcher.Invoke(() => { Progress.Value++; });
                    }
                }
                lblMultpli.Dispatcher.Invoke(() => { lblMultpli.Content = n_multipli; });
            });
            return n_multipli;
        }

        private void btnEsegui_Click(object sender, RoutedEventArgs e)
        {
            Progress.Minimum = 0;
            Progress.Maximum = 100;
            Progress.Value = 0;
            lblPrimo.Content = "";
            bool primo = true;
            int n = int.Parse(txtNumero.Text);
            for (int i = 2; i <= n / 2; i++)
            {
                if (n % i == 0)
                {
                    primo = false;
                }
            }
            if (primo == false)
            {
                lblPrimo.Content = "Non è primo!!!";
            }
            else
            {
                lblPrimo.Content = "E' primo!!!";
            }
            Multipli(n);



        }
    }
}

