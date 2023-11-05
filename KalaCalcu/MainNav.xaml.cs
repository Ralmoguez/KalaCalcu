using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KalaCalcu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainNav : TabbedPage
    {
        public MainNav(string accountName, string contactNo)
        {
            InitializeComponent();

            this.BarBackgroundColor = Color.Black;

            CurrentPage = Children[1];
            ((Calculator)Children[1]).SetAccount(accountName, contactNo);
        }
    }
}