using Datos;
using Logica;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Presentacion.Forms
{
    /// <summary>
    /// Lógica de interacción para UcAgregar.xaml
    /// </summary>
    public partial class UcAgregar : UserControl
    {
        CategoriaBLL catBll = new CategoriaBLL();
        TareaBLL tBll = new TareaBLL();

        public UcAgregar()
        {
            InitializeComponent();
            ListarCategorias();
            cargarTareas();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            txtTitulo.Text = string.Empty;
            txtCuerpo.Text = string.Empty;
            dpFechaVenc.SelectedDate = null;
            cmbCategorias.SelectedItem = null;
        }

        private void ListarCategorias()
        {
            cmbCategorias.ItemsSource = catBll.GetAllCategorias();
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            string mensajeError;
            if (ObtenerMsjError(out mensajeError))
            {
                MessageBox.Show(mensajeError, "Error al agregar", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            else
            {

                try
                {
                    string tituloNTarea = txtTitulo.Text;
                    string cuerpoNTarea = txtCuerpo.Text;
                    DateTime fechaActual = DateTime.Now.Date;
                    DateTime fechaVencimiento = dpFechaVenc.SelectedDate.Value.Date;
                    char estado = 'P';
                    Categoria categoriaSeleccionada = (Categoria)cmbCategorias.SelectedItem;
                    int idCategoria = categoriaSeleccionada.Id;
                    tBll.AddTarea(tituloNTarea, cuerpoNTarea, fechaActual, fechaVencimiento, estado, idCategoria);
                    MessageBox.Show("Tarea agregada correctamente.", "Nueva Tarea", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtTitulo.Text = string.Empty;
                    txtCuerpo.Text = string.Empty;
                    dpFechaVenc.SelectedDate = null;
                    cmbCategorias.SelectedItem = null;
                    cargarTareas();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Nueva Tarea", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }


        }

        private void cargarTareas()
        {
            dgListadoTareas.ItemsSource = null;
            dgListadoTareas.ItemsSource = tBll.GetAllTareas();
        }

        private bool ObtenerMsjError(out string mensajeError)
        {
            mensajeError = "";

            if (txtTitulo.Text.Length < 5)
            {
                mensajeError += "El título necesita tener un largo de al menos 5 caracteres.\n";
            }
            if (string.IsNullOrEmpty(txtCuerpo.Text))
            {
                mensajeError += "El cuerpo no puede estar vacío.\n";
            }
            if (cmbCategorias.SelectedItem == null)
            {
                mensajeError += "Debe seleccionar una categoría.\n";
            }

            return !string.IsNullOrEmpty(mensajeError); // Devuelve true si hay errores, false si no los hay
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Tarea tareaSeleccionada = (Tarea)dgListadoTareas.SelectedItem;
            string tituloTarea = tareaSeleccionada.Titulo;
            tBll.DeleteTarea(tituloTarea);
            MessageBox.Show("Tarea eliminada correctamente", "Tarea Eliminada", MessageBoxButton.OK, MessageBoxImage.Information);
            cargarTareas();
        }

        private void dgListadoTareas_Loaded(object sender, RoutedEventArgs e)
        {
            cargarTareas();
        }
    }
}
