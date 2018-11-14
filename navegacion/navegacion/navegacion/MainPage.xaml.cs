using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace navegacion
{
	public partial class MainPage : Xamarin.Forms.TabbedPage
	{
		public MainPage()
		{
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);//navigation bar down
			InitializeComponent();
		}
	}
}
