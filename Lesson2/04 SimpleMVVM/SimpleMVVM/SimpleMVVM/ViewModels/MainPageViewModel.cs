using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SimpleMVVM.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {

        private DateTime dateTime;

        public DateTime DateTime
        {
            get { return dateTime; }
            set {
                if(dateTime!=value)
                {

                    dateTime = value;
                    OnPropertyChanged("DateTime");
                }
            }
        }

        public MainPageViewModel()
        {
            this.DateTime = DateTime.Now;

            Device.StartTimer(TimeSpan.FromSeconds(1), () => {
                this.DateTime = DateTime.Now;
                return true;
            });
        }
    }
}
