using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GestionComunidad.ViewModels
{
    public class MainViewModel:ViewModelBase
    {
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;
        
        //Propiedades
        public ViewModelBase CurrentChildView { 
            get => _currentChildView; 
            set { 
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            } 
        }
        public string Caption
        {
            get => _caption;
            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }
        public IconChar Icon
        {
            get => _icon;
            set { 
                _icon = value; 
                OnPropertyChanged(nameof(Icon));
            } 
        }

        public ICommand ShowInicioCommand { get; set; }
        public ICommand ShowIncorporacionCommand { get; set; }
        public ICommand ShowClapCommand { get; set; }
        public ICommand ShowConsultaCommand { get; set; }
        public ICommand ShowResponsableCommand { get; set; }


        public MainViewModel()
        {
            ShowInicioCommand = new ViewModelCommand(ExecuteShowInicioCommand);
            ShowIncorporacionCommand = new ViewModelCommand(ExecuteShowIncorporacionCommand);
            ShowClapCommand = new ViewModelCommand(ExecuteShowClapCommand);
            ShowConsultaCommand = new ViewModelCommand(ExecuteShowConsultaCommand);
            ShowResponsableCommand = new ViewModelCommand(ExecuteShowResponsableCommand);

            ExecuteShowInicioCommand(obj: null);
        }

        private void ExecuteShowInicioCommand(object? obj)
        {
            CurrentChildView = new InicioModel();
            Caption = "Inicio";
            Icon = IconChar.Home;
        }

        private void ExecuteShowIncorporacionCommand(object obj)
        {
            CurrentChildView = new IncorporacionModel();
            Caption = "Incorporacion";
            Icon = IconChar.Search;
        }

        private void ExecuteShowClapCommand(object obj)
        {
            CurrentChildView = new ClapModel();
            Caption = "Clap";
            Icon = IconChar.Search;
        }

        private void ExecuteShowConsultaCommand(object obj)
        {
            CurrentChildView = new ConsultaModel();
            Caption = "Consulta";
            Icon = IconChar.Search;
        }

        private void ExecuteShowResponsableCommand(object obj)
        {
            CurrentChildView = new ResponsableModel();
            Caption = "Responsable";
            Icon = IconChar.Person;
        }
    }
}
