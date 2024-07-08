using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GestionComunidad.Views;

namespace GestionComunidad.Controller
{
    public class SQLiteArchivar
    {
        public static void BCV(string FECHA, string TASA)
        {
            using IDbConnection cnn = new SQLiteConnection(LoadConnectionString());
            cnn.Execute("DELETE FROM BCV");
            cnn.Execute("INSERT INTO BCV (FECHA, TASA) VALUES ('"+ FECHA +"', '" + TASA +"')");
        }

        public static void Responsable_Clap(string NOMBRE, string EDF_CASA, string NRO_EDF_CASA, string TELEFONO)
        {
            using IDbConnection cnn = new SQLiteConnection(LoadConnectionString());            
            cnn.Execute("INSERT INTO RESPONSABLES_CLAP (NOMBRE, EDF_CASA, NRO_EDF_CASA, TELEFONO) VALUES ('" + NOMBRE + "', '" + EDF_CASA + "', '" + NRO_EDF_CASA + "', '" + TELEFONO + "')");
        }

        public static void Responsable_Cond(string NOMBRE, string EDF_CASA, string NRO_EDF_CASA, string TELEFONO)
        {
            using IDbConnection cnn = new SQLiteConnection(LoadConnectionString());
            cnn.Execute("INSERT INTO RESPONSABLES_COND (NOMBRE, EDF_CASA, NRO_EDF_CASA, TELEFONO) VALUES ('" + NOMBRE + "', '" + EDF_CASA + "', '" + NRO_EDF_CASA + "', '" + TELEFONO + "')");
        }

        public static void PagoCondominio(string NOMBRE, string EDIFICIO, string APARTAMENTO, string MES, string MONTO_USD, string MONTO_BS, string FECHA_PAGO, string OBSERVACIONES)
        {
            using IDbConnection cnn = new SQLiteConnection(LoadConnectionString());
            cnn.Execute("INSERT INTO CONDOMINIO (NOMBRE, EDIFICIO, APARTAMENTO, MES, MONTO_USD, MONTO_BS, FECHA_PAGO, OBSERVACIONES) VALUES ('" + NOMBRE + "', '" + EDIFICIO + "', '" + APARTAMENTO + "', '" + 
                MES + "', '" + MONTO_USD + "', '" + MONTO_BS + "', '" + FECHA_PAGO + "', '" + OBSERVACIONES + "')");
        }

        public static void PagoClap(string NOMBRE, string EDIFICIO, string APARTAMENTO, string MES, string MONTO_USD, string MONTO_BS, string FECHA_PAGO, string OBSERVACIONES)
        {
            using IDbConnection cnn = new SQLiteConnection(LoadConnectionString());
            cnn.Execute("INSERT INTO CLAP (NOMBRE, EDIFICIO, APARTAMENTO, MES, MONTO_USD, MONTO_BS, FECHA_PAGO, OBSERVACIONES) VALUES ('" + NOMBRE + "', '" + EDIFICIO + "', '" + APARTAMENTO + "', '" +
                MES + "', '" + MONTO_USD + "', '" + MONTO_BS + "', '" + FECHA_PAGO + "', '" + OBSERVACIONES + "')");
        }
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
