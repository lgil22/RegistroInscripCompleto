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
using RegistroP.UI.Registros;
using RegistroP.UI.Consultas;

namespace RegistroP
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

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            rPersonas pers = new rPersonas();
            // pers.MdiParent = this;
            pers.Show();
            // RegistroPersona(new Page.rPersonas());
        }

   
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            cPersonas cpersonas = new cPersonas();
            cpersonas.Show();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            rInscripciones rinscripciones = new rInscripciones();
            rinscripciones.Show();

        }
    }
}
