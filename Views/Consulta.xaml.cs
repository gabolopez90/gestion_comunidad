using GestionComunidad.Models;
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
using ArrayToExcel;
using System.IO;

namespace GestionComunidad.Views
{
    /// <summary>
    /// Lógica de interacción para Consulta.xaml
    /// </summary>
    public partial class Consulta : UserControl
    {
        List<ResponsablesDataModel> dataResponsables;
        List<CondominioModel> dataCondominio;
        string cedu;
        
        public Consulta()
        {
            InitializeComponent();
        }

        private void buscarData(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (tablas.Text)
                {
                    case "RESPONSABLES CLAP":
                        dataResponsables = SQLiteDataAccess.CargaResponsablesClap();
                        gridDatos.ItemsSource = dataResponsables;
                        break;
                    case "RESPONSABLES CONDOMINIO":
                        dataResponsables = SQLiteDataAccess.CargaResponsablesCond();
                        gridDatos.ItemsSource = dataResponsables;
                        break;
                    case "PAGOS CLAP":
                        dataCondominio = SQLiteDataAccess.CargaClap();
                        gridDatos.ItemsSource = dataCondominio;
                        break;
                    case "PAGOS CONDOMINIO":
                        dataCondominio = SQLiteDataAccess.CargaCondominio();
                        gridDatos.ItemsSource = dataCondominio;
                        break;
                }
                exportarData.IsEnabled = true;
            }
            catch
            {
                MessageBox.Show("NO SE LOGRÓ CONEXIÓN CON LA BASE DE DATOS");
            }
        }

        private void consultarData_Click(object sender, RoutedEventArgs e)
        {
            buscarData(sender, e);
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                consultarData_Click((object)sender, e);
            }
        }//Al darle enter ejecuta la consulta

        private void exportarData_Click(object sender, RoutedEventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            switch (tablas.Text)
            {
                case "RESPONSABLES CLAP":
                    try
                    {
                        var excel = dataResponsables.ToExcel();
                        File.WriteAllBytes($@"{path}\Responsables_clap.xlsx", excel);

                        MessageBox.Show("Archivo exportado a su escritorio con éxito");
                    }
                    catch
                    {
                        MessageBox.Show("Error al exportar");
                    }                    
                    break;
                case "RESPONSABLES CONDOMINIO":
                    try
                    {
                        var excel1 = dataResponsables.ToExcel();
                        File.WriteAllBytes($@"{path}\Responsables_condominio.xlsx", excel1);

                        MessageBox.Show("Archivo exportado a su escritorio con éxito");
                    }
                    catch
                    {
                        MessageBox.Show("Error al exportar");
                    }
                    break;
                case "PAGOS CLAP":
                    try
                    {
                        var excel2 = dataCondominio.ToExcel();
                        File.WriteAllBytes($@"{path}\Pagos_clap.xlsx", excel2);

                        MessageBox.Show("Archivo exportado a su escritorio con éxito");
                    }
                    catch
                    {
                        MessageBox.Show("Error al exportar");
                    }
                    break;
                case "PAGOS CONDOMINIO":
                    try
                    {
                        var excel3 = dataCondominio.ToExcel();
                        File.WriteAllBytes($@"{path}\Pagos_condominio.xlsx", excel3);

                        MessageBox.Show("Archivo exportado a su escritorio con éxito");
                    }
                    catch
                    {
                        MessageBox.Show("Error al exportar");
                    }
                    break;
            }
            exportarData.IsEnabled = false;
        }
    }
}
