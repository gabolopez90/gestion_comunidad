using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionComunidad.Models
{
    public class CondominioModel
    {
        public string NOMBRE { get; set; }
        public string EDIFICIO { get; set; }
        public string APARTAMENTO { get; set; }
        public string MES { get; set; }
        public double MONTO_USD { get; set; }
        public double MONTO_BS { get; set; }
        public string FECHA_PAGO { get; set; }
        public string OBSERVACIONES { get; set; }
    }
}
