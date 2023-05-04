using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dynatrace.Xamarin;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace ButtonDemos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserIdentifyPage : ContentPage
    {
        private IDynatrace dynatrace = DependencyService.Get<IDynatrace>();
        public UserIdentifyPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var userPicker = this.FindByName<Xamarin.Forms.Picker>("userPicker");
            Console.WriteLine("Usuário identificado: " + userPicker.Items[userPicker.SelectedIndex]);
            dynatrace.IdentifyUser(userPicker.Items[userPicker.SelectedIndex]);

        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            var picker = (Xamarin.Forms.Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {

                
                Console.WriteLine(picker.Items[selectedIndex]);
            }
        }
    }
}