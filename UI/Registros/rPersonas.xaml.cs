using System;
/*using System.Collections.Generic;
using System.Text;*/
using System.Windows;
using System.Windows.Controls;
/*using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;*/
using RegistroP.Entidades;
//using System.Globalization;
using RegistroP.BLL;
using RegistroP.UI.Registros;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace RegistroP.UI.Registros
{
    /// <summary>
    /// Interaction logic for rPersonas.xaml
    /// </summary>
    public partial class rPersonas : Window
    {
        public rPersonas()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            idTextBox.Text = "0";
            NombreTextBox.Text = string.Empty;
            TelefonoTextBox.Text = string.Empty;
            CedulaTextBox.Text = string.Empty;
            DireccionTextBox.Text = string.Empty;
            FechaNacDatePicker.SelectedDate = DateTime.Now;

        }
       
        private Personas LlenaClase()
        {
            Personas personas = new Personas();
            personas.PersonaId = Convert.ToInt32(idTextBox.Text);
                
                //idTextBox.Text.ToInt();
            personas.Nombre = NombreTextBox.Text;
            personas.Telefono = TelefonoTextBox.Text;
            personas.Cedula = CedulaTextBox.Text;
            personas.Direccion = DireccionTextBox.Text;
            personas.FechaNacimiento = (DateTime)FechaNacDatePicker.SelectedDate;

            return personas;
        }
      
        private void LlenaCampo(Personas personas)
        {
            idTextBox.Text = Convert.ToString(personas.PersonaId);
            NombreTextBox.Text = personas.Nombre;
            TelefonoTextBox.Text = personas.Telefono;
            CedulaTextBox.Text = personas.Cedula;
            DireccionTextBox.Text = personas.Direccion;
            FechaNacDatePicker.SelectedDate = personas.FechaNacimiento;

        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            Personas persona = new Personas();
            int.TryParse(idTextBox.Text, out id);

            Limpiar();

            persona = PersonasBLL.Buscar(id);

            if (persona != null)
            {
                MessageBox.Show("Persona Encontrada");
                LlenaCampo(persona);
            }

            else
            {
                MessageBox.Show("Persona no Encontrada");
            }

        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(idTextBox.Text, out id);

            Limpiar();

            if (PersonasBLL.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show(idTextBox.Text, "No se puede eliminar una persona que no existe");
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            Personas personas;
            bool paso = false;

            if (!Validar())
                return;

            personas = LlenaClase();

            //Determinar si es guardar o modificar
            //if (idTextBox.Text.ToInt() == 0)

            if (string.IsNullOrWhiteSpace(idTextBox.Text) || idTextBox.Text == "0")
                paso = PersonasBLL.Guardar(personas);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar una persona que no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                paso = PersonasBLL.Modificar(personas);
            }

            //Informar el resultado
            if (paso)
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Personas personas = PersonasBLL.Buscar((int)idTextBox.Text.ToInt());
            return (personas != null);
        }

        private bool Validar()
        {
            bool paso = true;

            if(NombreTextBox.Text == string.Empty)
            {
                MessageBox.Show(NombreTextBox.Text, "El campo Nombre no puede estar vacio ");
                NombreTextBox.Focus();
                paso = false;
            }

            if(string.IsNullOrWhiteSpace(DireccionTextBox.Text))
            {
                MessageBox.Show(DireccionTextBox.Text, "El campo Direccion no puede estar vacio");
                DireccionTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(CedulaTextBox.Text)) 
            {
                MessageBox.Show(CedulaTextBox.Text, "El campo Cedula no puede estar vacio");
                CedulaTextBox.Focus();
                paso = false;
            }

            Personas personas = PersonasBLL.Buscar((int)idTextBox.Text.ToInt());
            return paso;
        }

        private void TelefonoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void NombreTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void idTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
    }
    
}
