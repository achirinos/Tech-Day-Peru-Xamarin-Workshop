using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFAppCode.ViewModels
{
    public class MainPageViewModel: INotifyPropertyChanged
    {
        private DateTime dateTime;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(String propertyName)
        {
            if(PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public DateTime DateTime
        {
            get { return dateTime; }
            set {
                if (dateTime != value)
                {
                    dateTime = value;
                    OnPropertyChanged("DateTime");
                }
            }
        }

        public MainPageViewModel()
        {
            this.DateTime = DateTime.Now;

            Xamarin.Forms.Device.StartTimer(TimeSpan.FromSeconds(1), () => {
                this.DateTime = DateTime.Now;
                return true;
            });
        }

    }
}
