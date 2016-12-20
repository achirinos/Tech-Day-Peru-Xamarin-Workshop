using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Commanding.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private string _value;

        public string Value
        {
            get { return _value; }
            set
            {
                if (_value != value)
                {
                    _value = value;
                    OnPropertyChanged("Value");
                }
            }
        }


        private bool _isToggle;

        public bool IsToggle
        {
            get { return _isToggle; }
            set {
                if(_isToggle!=value)
                {
                    _isToggle = value;
                    OnPropertyChanged("IsToggle");
                    ((Command)ButtonCommand).ChangeCanExecute();
                }
            }
        }

        public ICommand ButtonCommand { get; protected set; }
        
        public MainPageViewModel()
        {
            IsToggle = false;

            ButtonCommand = new Command(Excute, CanExecute);
        }

        private bool CanExecute(object arg)
        {
            return IsToggle;
        }

        private void Excute(object obj)
        {
            Value = "Command Ejecutado";
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
