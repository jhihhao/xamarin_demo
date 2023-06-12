using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Demo_1.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InputPage:ContentPage {
        public InputPage() {
            InitializeComponent();
        }

        private void BtnCheckNum_Clicked(object sender, EventArgs e) {
            if (entryNum.Text == "2") {
                checkResult.Text = "Wonderful!!";
            } else {
                checkResult.Text = "Sad~~~~~";
            }
        }
    }
}