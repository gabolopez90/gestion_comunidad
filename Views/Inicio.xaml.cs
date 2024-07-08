using GestionComunidad.Controller;
using GestionComunidad.Models;
using Microsoft.VisualBasic.ApplicationServices;
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

namespace GestionComunidad.Views
{
    /// <summary>
    /// Lógica de interacción para Inicio.xaml
    /// </summary>
    public partial class Inicio : UserControl
    {
        List<BcvModel> bcv;
        public Inicio()
        {
            InitializeComponent();
            version.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();            
        }

        private void SoloNumero_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1) && e.Text != "." && e.Text != ",")
            {
                e.Handled = true;
            }
        }// Solo permite ingresa numeros en textbox

        private void Dolar_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                //bcv = SQLiteDataAccess.BCV();
                //MessageBox.Show(bcv[0].TASA.ToString());
                string FECHA = fechaDolar.Text;
                string TASA = dolarbcv.Text.Replace(",", ".");
                SQLiteArchivar.BCV(FECHA, TASA);

                MessageBox.Show("REGISTRO ARCHIVADO EXITOSAMENTE");
            }
            catch (Exception p)
            {                
                MessageBox.Show(p.ToString());
            }
            
        }
    }
}
