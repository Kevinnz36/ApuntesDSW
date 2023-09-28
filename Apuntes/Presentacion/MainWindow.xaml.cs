using Presentacion.Forms;
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

namespace Presentacion
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnInicio_Click(object sender, RoutedEventArgs e)
        {
            UserControl ventanaListado = new UcListar();
            grdMain.Children.Clear();
            grdMain.Children.Add(ventanaListado);
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            UserControl ventanaAgregar = new UcAgregar();
            grdMain.Children.Clear();
            grdMain.Children.Add(ventanaAgregar);
        }

        private void btnListar_Click(object sender, RoutedEventArgs e)
        {
            UserControl ventanaCategorias = new UcCategorias();
            grdMain.Children.Clear();
            grdMain.Children.Add(ventanaCategorias);
        }
    }
}
