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

namespace GestionComunidad.Models
{
    public class SQLiteDataAccess
    {
        public static List<BcvModel> BCV()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<BcvModel>("Select * from BCV", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<ResponsablesDataModel> CargaResponsablesClap()
        {
            using IDbConnection cnn = new SQLiteConnection(LoadConnectionString());
            var output = cnn.Query<ResponsablesDataModel>("Select * from RESPONSABLES_CLAP", new DynamicParameters());
            return output.ToList();
        }

        public static List<CondominioModel> CargaClap()
        {
            using IDbConnection cnn = new SQLiteConnection(LoadConnectionString());
            var output = cnn.Query<CondominioModel>("Select * from CLAP", new DynamicParameters());
            return output.ToList();
        }

        public static List<ResponsablesDataModel> CargaResponsablesCond()
        {
            using IDbConnection cnn = new SQLiteConnection(LoadConnectionString());
            var output = cnn.Query<ResponsablesDataModel>("Select * from RESPONSABLES_COND", new DynamicParameters());
            return output.ToList();
        }

        public static List<CondominioModel> CargaCondominio()
        {
            using IDbConnection cnn = new SQLiteConnection(LoadConnectionString());
            var output = cnn.Query<CondominioModel>("Select * from CONDOMINIO", new DynamicParameters());
            return output.ToList();
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}

    
