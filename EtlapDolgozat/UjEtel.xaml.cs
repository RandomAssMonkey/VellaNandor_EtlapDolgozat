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
using System.Windows.Shapes;

namespace EtlapDolgozat
{
    /// <summary>
    /// Interaction logic for UjEtel.xaml
    /// </summary>
    public partial class UjEtel : Window
    {

		EtlapService service = new EtlapService();
        public UjEtel()
        {
            InitializeComponent();
        }

		private void btnAdd_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				Etel etel = CreateEtelFromInputData();
				if (service.Create(etel))
				{
					MessageBox.Show("Sikeres hozzáadás");
					tbNev.Text = "";
					tbLeiras.Text = "";
					tbAr.Text = "";
				}
				else
				{
					MessageBox.Show("Hiba történt a hozzáadás során");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private Etel CreateEtelFromInputData()
		{
				string nev = tbNev.Text.Trim();
				string leiras = tbLeiras.Text.Trim();
				string ar = tbAr.Text.Trim();
				string kategoria = cbKategoria.Text.Trim();

				if (string.IsNullOrEmpty(nev))
				{
					throw new Exception("Név megadása kötelező");
				}

				if (string.IsNullOrEmpty(leiras))
				{
					throw new Exception("Leírás megadása kötelező");
				}
				if (!int.TryParse(ar, out int resultAr))
				{
					throw new Exception("Ár csak szám lehet");
				}

				if (string.IsNullOrEmpty(kategoria))
				{
					throw new Exception("Kategória megadása kötelező");
				}

				Etel etel = new Etel();
				etel.Nev = nev;
				etel.Leiras = leiras;
				etel.Ar = resultAr;
				etel.Kategoria = kategoria;
				return etel;
			}
	}
}
