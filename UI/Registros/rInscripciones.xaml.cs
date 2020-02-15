using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using RegistroP.BLL;
using RegistroP.Entidades;
using RegistroP.DAL;
using RegistroP.UI;

namespace RegistroP.UI.Registros
{
    /// <summary>
    /// Interaction logic for rInscripciones.xaml
    /// </summary>
    public partial class rInscripciones : Window
    {
        public rInscripciones()
        {
            InitializeComponent();
            LlenarComboBox();
        }

        public class ConvertEventArgs : EventArgs
        {
            public object Value { get; internal set; }
        }

        private class ConvertEventHandler
        {
            private Action<object, ConvertEventArgs> formatoMoneda;

            public ConvertEventHandler(Action<object, ConvertEventArgs> formatoMoneda)
            {
                this.formatoMoneda = formatoMoneda;
            }
        }



        private void Limpiar()
        {
            InscripIDTextBox.Text = "0";
            FechaDatePicker.SelectedDate = DateTime.Now;
            PersonaComBox.SelectedIndex = 0;
            ComentariosTextBox.Clear();
            MontoTextBox.Clear();
            BalanceTextBox.Clear();
            CambiarBalance();
        }

        private Inscripciones LlenaClase()
        {
            return new Inscripciones()
            {
                InscripcionId = Convert.ToInt32(InscripIDTextBox.Text),
                Fecha = (DateTime)FechaDatePicker.SelectedDate,

                PersonaId = Convert.ToInt32(PersonaComBox.SelectedValue),
                Comentarios = ComentariosTextBox.Text,

                Monto = ToDecimal(MontoTextBox.Text),
                Balance = ToDecimal(BalanceTextBox.Text),
                            

            };
        
        }

        private void LlenaCampo(Inscripciones inscripion)
        {
            InscripIDTextBox.Text = Convert.ToString(inscripion.InscripcionId);
            PersonaComBox.SelectedValue = inscripion.PersonaId;
            BalanceTextBox.Text = inscripion.Balance.ToString();
            MontoTextBox.Text = inscripion.Monto.ToString();
            ComentariosTextBox.Text = inscripion.Comentarios;
            FechaDatePicker.SelectedDate = inscripion.Fecha;
            CambiarBalance();
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Personas personas = PersonasBLL.Buscar((int)InscripIDTextBox.Text.ToInt());
            return (personas != null);
        }

        private bool Validar()
        {
            bool paso = true;

            if (PersonaComBox.Text == string.Empty)
            {
                MessageBox.Show(PersonaComBox.Text, "El campo Persona no puede estar vacio ");
                PersonaComBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(ComentariosTextBox.Text))
            {
                MessageBox.Show(ComentariosTextBox.Text, "El campo Comentarios no puede estar vacio");
                ComentariosTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(MontoTextBox.Text))
            {
                MessageBox.Show(MontoTextBox.Text, "El campo Monto no puede estar vacio");
                MontoTextBox.Focus();
                paso = false;
            }

            Inscripciones inscripciones = InscripcionesBLL.Buscar((int)InscripIDTextBox.Text.ToInt());
            return paso;
        }


        //Muestra el nombre de la persona y guarda id Persona.....
        private void LlenarComboBox()
        {
            PersonaComBox.ItemsSource = PersonasBLL.GetList(x => true);
            PersonaComBox.SelectedValue = "PersonaId";
            PersonaComBox.DisplayMemberPath = "Nombre";

          //  TraerBalance();
        }
        // Especifica el formato de moneda y convierte un número en una cadena que representa una cantidad de moneda.....
        private void FormatoMoneda(object sender, ConvertEventArgs cevent)
        {
            double valor = 0;
            double.TryParse(cevent.Value.ToString(), out valor);
            cevent.Value = valor.ToString("#,##.00;(#,##.00);0.00");
        }

        // Metodo para llevar balance a tipo moneda y presentarlo en pantalla.....
        private void CambiarBalance()
        {

        /*    BalanceTextBox.DataBindings.Clear();
            Binding binding = new Binding("Text", PersonaComBox.ItemsSource, "Balance");
            binding.StringFormat += new ConvertEventHandler(FormatoMoneda);
            BalanceTextBox.DataBindings.Add(binding);*/

        }

        private void LlenarBalance()
        {
            List<Personas> listaPersonas = PersonasBLL.GetList(x => x.Nombre.Equals(PersonaComBox.Text));
            foreach (var item in listaPersonas)
            {
                BalanceTextBox.Text = item.Balance.ToString();
            }
        }


        public static decimal ToDecimal(string valor)
        {
            decimal retorno = 0;
            decimal.TryParse(valor, out retorno);

            return retorno;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {

            int id_inscripcion = Convert.ToInt32(InscripIDTextBox.Text.ToInt());
            Inscripciones inscripcion = InscripcionesBLL.Buscar(id_inscripcion);


            if (inscripcion == null)
            {
                if (InscripcionesBLL.Guardar(LlenaClase()))
                {
                    MessageBox.Show("Guardado", "Realizado", MessageBoxButton.OK, MessageBoxImage.Information);
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("No Guardado", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    Limpiar();
                }

            }
            else
            {
                inscripcion = LlenaClase();
                if (InscripcionesBLL.Modificar(inscripcion))  /// Metodo para modificar informacion de alguna persona.....
                {
                    MessageBox.Show("Modificado", "Realizado", MessageBoxButton.OK, MessageBoxImage.Information);
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("No Modificado", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    Limpiar();
                }
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id_inscripcion = Convert.ToInt32(InscripIDTextBox.Text);
            Inscripciones inscripcion = InscripcionesBLL.Buscar(id_inscripcion);

            if (inscripcion != null)
            {
                if (InscripcionesBLL.Eliminar(inscripcion.InscripcionId))
                {
                    MessageBox.Show("Eliminado", "Realizado", MessageBoxButton.OK, MessageBoxImage.Information);
                    // NuevoButton.PerformClick();
                                        NuevoButton.Click += new RoutedEventHandler(NuevoButton_Click);


                }
                else
                {
                    MessageBox.Show("No Eliminado", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                   // NuevoButton.Click(NuevoButton);
                    NuevoButton.Click += new RoutedEventHandler(NuevoButton_Click);
                }
            }
            else
                MessageBox.Show("No Hay Resultado", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            int id_inscripcion = Convert.ToInt32(InscripIDTextBox.Text);
            Inscripciones inscripcion = InscripcionesBLL.Buscar(id_inscripcion);
            /*int id_inscripcion;
            Personas persona = new Personas();
            int.TryParse(InscripIDTextBox.Text, out id_inscripcion);*/

        //    Limpiar();

          //  persona = PersonasBLL.Buscar(id_inscripcion);

            if (inscripcion != null)
            {
                MessageBox.Show("Persona Encontrada");
                LlenaCampo(inscripcion);
            }
            else
            {
                MessageBox.Show("Persona no Encontada");
                Limpiar();
            }
        }

        private void PersonaComBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            LlenarBalance();
            CambiarBalance();
        }
    }
}
