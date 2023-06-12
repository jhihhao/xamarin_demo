using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Demo_1 {
    public partial class MainPage:FlyoutPage {
        MenuPage flyoutPage;
        public MainPage() {
            InitializeComponent();
            flyoutPage = new MenuPage();
            Flyout = flyoutPage;
        }
    }
}
