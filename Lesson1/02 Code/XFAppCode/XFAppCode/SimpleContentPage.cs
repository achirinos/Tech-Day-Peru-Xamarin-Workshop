using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace XFAppCode
{
    public class SimpleContentPage : ContentPage
    {
        public SimpleContentPage()
        {
            Label label1 = new Label
            {
                Text = "Bienvenidos a Xamarin Forms"
            };

            Entry entry1 = new Entry
            {
                Placeholder = "Escribe tu nombre"
            };

            Button buton1 = new Button
            {
                Text = "Saludar"
            };

            buton1.Clicked += (Object s, EventArgs e) =>
            {
                label1.Text = string.Format("Hola {0}!", entry1.Text);
            };

            Content = new StackLayout
            {
                Children = {
                    label1, entry1, buton1
                }
            };
        }

    }
}
