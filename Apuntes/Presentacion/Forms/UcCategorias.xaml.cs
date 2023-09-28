using Logica;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Presentacion.Forms
{
    /// <summary>
    /// Lógica de interacción para UcCategorias.xaml
    /// </summary>
    public partial class UcCategorias : UserControl
    {
        CategoriaBLL catBll = new CategoriaBLL();
        public UcCategorias()
        {
            InitializeComponent();
            ListarCategorias();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            txtNombre.Text = string.Empty;
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string nombreNuevaCategoria = txtNombre.Text;
                catBll.AddCategoria(nombreNuevaCategoria);
                MessageBox.Show("Categoría agregada correctamente.", "Nueva Categoria", MessageBoxButton.OK, MessageBoxImage.Information);
                txtNombre.Text = string.Empty;
                ListarCategorias();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Nueva Categoria", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private void ListarCategorias()
        {
            lstCategorias.ItemsSource = catBll.GetAllCategorias();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            string nombre = lstCategorias.SelectedItem.ToString();
            catBll.DeleteCategoria(nombre);
            MessageBox.Show("Categoría eliminada correctamente", "Categoria Eliminada", MessageBoxButton.OK, MessageBoxImage.Information);
            ListarCategorias();
        }
    }
}
