using GestionComunidad.Controller;
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
    /// Lógica de interacción para Responsable.xaml
    /// </summary>
    public partial class Responsable : UserControl
    {
        public Responsable()
        {
            InitializeComponent();
        }

        private void Archivar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string NOMBRE = nombreResponsable.Text;
                string EDF_CASA = edificio.Text;
                string NRO_EDF_CASA = numApt.Text;
                string TELEFONO = numeroResponsable.Text;
                
                if ((bool)condominio.IsChecked)
                {
                    SQLiteArchivar.Responsable_Cond(NOMBRE, EDF_CASA, NRO_EDF_CASA, TELEFONO);

                    MessageBox.Show("REGISTRO ARCHIVADO EXITOSAMENTE");
                }
                else
                {
                    SQLiteArchivar.Responsable_Clap(NOMBRE, EDF_CASA, NRO_EDF_CASA, TELEFONO);

                    MessageBox.Show("REGISTRO ARCHIVADO EXITOSAMENTE");
                }                
            }
            catch (Exception p)
            {
                MessageBox.Show(p.ToString());
            }
        }
    }
}
