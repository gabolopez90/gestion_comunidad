using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionComunidad.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string[] Nacionalidad { get; set; } = {
                "V",
                "E",
                "J",
                "P",
                "M"
        };

        public string[] consultaNacionalidad { get; set; } = {
                "V",
                "E",
                "NM"

        };

        public string[] consultaTablas { get; set; } = {
                "RESPONSABLES CLAP",
                "RESPONSABLES CONDOMINIO",
                "PAGOS CLAP",
                "PAGOS CONDOMINIO"
        };

        public string[] Hipoteca { get; set; } = {
                "SIN HIPOTECA",                
                "HIPOTECA DE PRIMER GRADO"
        };

        public string[] Mercado { get; set; } = {
                "Primario",
                "Secundario"
        };

        public string[] Estado { get; set; } =
        {
            "AMAZONAS",
            "ANZOATEGUI",
            "APURE",
            "ARAGUA",
            "BARINAS",
            "BOLIVAR",
            "CARABOBO",
            "COJEDES",
            "DELTA AMACURO",
            "FALCON",
            "DISTRITO CAPITAL",
            "GUARICO",
            "LA GUAIRA",
            "LARA",
            "MERIDA",
            "MIRANDA",
            "MONAGAS",
            "NUEVA ESPARTA",
            "PORTUGUESA",
            "SUCRE",
            "TACHIRA",
            "YARACUY",
            "TRUJILLO",
            "ZULIA"
        };

        public string[] Meses { get; set; } = 
        {
            "ENERO",
            "FEBRERO",
            "MARZO",
            "ABRIL",
            "MAYO",
            "JUNIO",
            "JULIO",
            "AGOSTO",
            "SEPTIEMBRE",
            "OCTUBRE",
            "NOVIEMBRE",
            "DICIEMBRE"
        };

        public string[] Moneda { get; set; } =
        {
            "Dolar",
            "Bolivar"
        };
    }
}
