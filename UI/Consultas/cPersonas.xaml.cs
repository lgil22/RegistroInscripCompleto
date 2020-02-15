using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Linq;
using RegistroP.Entidades;
using RegistroP.BLL;
using System.Data;

namespace RegistroP.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cPersonas.xaml
    /// </summary>
    public partial class cPersonas : Window
    {
        public cPersonas()
        {
            InitializeComponent();
        }

        private void CriterioTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Personas>();

            if (CriterioTextBox.Text.Trim().Length > 0 )
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //Todo
                        listado = PersonasBLL.GetList(p => true);
                        break;

                    case 1: //ID
                        int id = Convert.ToInt32(CriterioTextBox.Text);
                        listado = PersonasBLL.GetList(p => p.PersonaId == id);
                        break;

                    case 2://Nombre
                        listado = PersonasBLL.GetList(p => p.Nombre.Contains(CriterioTextBox.Text));
                        break;

                    case 3://Cedula
                        listado = PersonasBLL.GetList(p => p.Cedula.Contains(CriterioTextBox.Text));
                        break;

                    case 4://Direccion
                        listado = PersonasBLL.GetList(p => p.Direccion.Contains(CriterioTextBox.Text));
                        break;
                }

               listado = listado.Where(c => c.FechaNacimiento.Date >= DesdeDatePicker.SelectedDate && c.FechaNacimiento.Date <= HastaDatePicker.SelectedDate).ToList();
            }
            else
            {
                listado = PersonasBLL.GetList(p => true);
            }

            DataGridConsulta.ItemsSource = listado;
            DataGridConsulta.ItemsSource = listado;
        }
    }
}
