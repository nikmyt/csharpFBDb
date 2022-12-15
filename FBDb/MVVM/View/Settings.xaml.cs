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
using WPF.DB;

namespace WPF.MVVM.View
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void OnExit(object sender, RoutedEventArgs e)
        {
            App.Current.Windows[0].Close();
        }

        private void ClearData(object sender, RoutedEventArgs e)
        {
            using (var db = new myDbContext())
            {
                var ownedPets = db.UserPets.Where(x => x.isOwnedByThisUser == true).ToList(); //
                foreach (var pet in ownedPets)
                {
                    pet.ToxProduced = 0;
                    db.SaveChanges();
                }
            }
        }
        /*
        private void ClearData2(object sender, RoutedEventArgs e)
        {
            using (var db = new myDbContext())
            {
                var ownedPets = db.UserPets.Where(x => x.isOwnedByThisUser == true).ToList();
                foreach (var pet in ownedPets)
                {
                    pet.ToxProduced = 0;
                }
            }
        }*/
    }
}
