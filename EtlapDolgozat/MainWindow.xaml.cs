using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EtlapDolgozat
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		EtlapService service = new EtlapService();
		public MainWindow()
		{
			// Azért új projektet kellett létrehoznom emiatt EtlapDolgozat a neve és nem sima Etlap ez a gitrepóra is igaz
			InitializeComponent();
			Read();
			
		}

		private void Read()
		{
			etlapTable.ItemsSource = service.GetAll();
			
		}


		private void etlapTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			Etel etel = etlapTable.SelectedItem as Etel;
			etelLabel.Content = etel.Leiras;

		}
	}
}
