using SimpleApp.Models;
using SimpleApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SimpleApp.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private bool _isLoading = false;

        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {

                if (_isLoading != value)
                {
                    _isLoading = value;
                    OnPropertyChanged("IsLoading");
                }
            }
        }


        private IEnumerable<Equipo> _posiciones;

        public IEnumerable<Equipo> Posiciones
        {
            get { return _posiciones; }
            set {
                if(_posiciones!=value)
                {
                    _posiciones = value;
                    OnPropertyChanged("Posiciones");
                }
            }
        }

        public ICommand ObtenerPosicionesCommand { get; protected set; }

        public MainPageViewModel()
        {            
            ObtenerPosicionesCommand = new Command((Object o) => {
                IsLoading = true;
                ((Command)ObtenerPosicionesCommand).ChangeCanExecute();

                var service = new PosicionesService();
                service.LoadPosicionesCompleted += Service_LoadPosicionesCompleted;
                service.LoadPosiciones();
            }, (Object arg)=> {
                return !_isLoading;
            });
        }

        private void Service_LoadPosicionesCompleted(object sender, PosicionesEventArgs e)
        {
            IsLoading = false;
            ((Command)ObtenerPosicionesCommand).ChangeCanExecute();

            Posiciones = e.Results;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
