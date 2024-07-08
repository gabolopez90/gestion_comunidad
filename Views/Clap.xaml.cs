using GestionComunidad.Controller;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GestionComunidad.Views
{
    /// <summary>
    /// Lógica de interacción para Clap.xaml
    /// </summary>
    public partial class Clap : UserControl
    {
        List<BcvModel> bcv;
        List<ResponsablesDataModel> dataArchivado;
        public Clap()
        {
            InitializeComponent();

            //Carga dolar bcv para cálculos
            try
            {
                bcv = SQLiteDataAccess.BCV();
                dolar.Text = bcv[0].TASA.ToString();
            }
            catch (Exception p)
            {
                MessageBox.Show("ERROR AL CARGAR TASA BCV");
                MessageBox.Show(p.ToString());
            }

            //Llena lista desplegable de responsables del pago
            try
            {
                dataArchivado = SQLiteDataAccess.CargaResponsablesClap();
                foreach (var item in dataArchivado)
                {
                    listaResponsables.Items.Add(item.NOMBRE);
                }
            }
            catch (Exception p)
            {
                MessageBox.Show("ERROR AL CARGAR RESPONSABLES");
                MessageBox.Show(p.ToString());
            }
        }

        private void Archivar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(listaResponsables.Text))
                {
                    MessageBox.Show("Seleccione responsable", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    listaResponsables.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(listaMes.Text))
                {
                    MessageBox.Show("Ingrese mes del pago", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    listaMes.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(metodoPago.Text))
                {
                    MessageBox.Show("Seleccione moneda del pago", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    metodoPago.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(montoPago.Text))
                {
                    MessageBox.Show("Ingrese monto del pago", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    montoPago.Focus();
                    return;
                }

                //Datos para el archivado
                string NOMBRE = listaResponsables.Text;
                string EDIFICIO = edificio.Text;
                string APARTAMENTO = apartamento.Text;
                string MES = listaMes.Text;
                string MONTO_USD, MONTO_BS;
                
                if (metodoPago.Text == "Dolar")
                {
                    MONTO_USD = montoPago.Text.Replace(",", ".");
                    MONTO_BS = (double.Parse(montoPago.Text.Replace(".", ",")) * bcv[0].TASA).ToString("N2").Replace(".", "").Replace(",", ".");

                }
                else
                {
                    MONTO_BS = montoPago.Text.Replace(",", ".");
                    MONTO_USD = (double.Parse(montoPago.Text.Replace(".", ",")) / bcv[0].TASA).ToString("N2").Replace(".", "").Replace(",", ".");
                }
                string FECHA_PAGO = fechaPago.Text;
                string OBSERVACIONES = observaciones.Text;

                SQLiteArchivar.PagoClap(NOMBRE, EDIFICIO, APARTAMENTO, MES, MONTO_USD, MONTO_BS, FECHA_PAGO, OBSERVACIONES);
                MessageBox.Show("REGISTRO ARCHIVADO EXITOSAMENTE");

            }
            catch (Exception p)
            {
                MessageBox.Show("ERROR EN ARCHIVADO");
                MessageBox.Show(p.ToString());
            }
        }

        private void SoloNumero_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1) && e.Text != "." && e.Text != ",")
            {
                e.Handled = true;
            }
        }// Solo permite ingresa numeros en textbox

        private void Responsable_DropDownClosed(object sender, EventArgs e)
        {
            apartamento.Text = string.Empty;
            edificio.Text = string.Empty;
            if (listaResponsables.SelectedItem != null)
            {
                apartamento.Text = dataArchivado.Find(item => item.NOMBRE.ToString() == listaResponsables.Text).NRO_EDF_CASA.ToString();
                edificio.Text = dataArchivado.Find(item => item.NOMBRE.ToString() == listaResponsables.Text).EDF_CASA.ToString();
            }
        }
    }
}
