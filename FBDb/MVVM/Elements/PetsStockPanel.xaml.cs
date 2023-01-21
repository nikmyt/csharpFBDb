using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF.DB;

namespace WPF.MVVM.Elements
{
    /// <summary>
    /// Interaction logic for PetsStockPanel.xaml
    /// </summary>
    /// 

    //this cannot be a task, right? how do i make sure it gets the petid?
    public partial class PetsStockPanel : UserControl
    {
        //this IS set
        public int petid;
        public bool isBought; //local-to-app variable is fine, oddly enough, so wheres the mistake
        //DogStocksIcon

        /*
        Let's return to when it was working. It was simply attached to button, no asyncs, no shit. Then I needed to check if it actually
        existed and it all went to piss.
        IsBought worked fine.
        Remove asyncs. That did not do it.

        Actually, maybe I biffed the null thing. Let me check.

        Another idea. Copy the whole pets table. Then simply have a bool of OWNED. (Yeah, it takes more space. Whatever. It's text.
        but surely not a good practice, image if every item in a game was in a table for each of millions of players. OOF.)
        */

        public PetsStockPanel(bool isBought, int petId) //yo can we add args???
        {
            //I think the issue begins before this, and may have to do something with the panel factory.
            InitializeComponent();
            /*using (var db = new myDbContext())
            {
                if (db.UserPets.Where(o => o.isOwnedByThisUser == true).Select(o => o.isOwnedByThisUser).FirstOrDefault())
                {
                    BoughtPet();
                } else { UnBoughtPet(); }
            }*/

            if (!isBought) { UnBoughtPet(petId); } else { BoughtPet(petId); }
            //Well, okay. It still didn't initialize. There Must be a way to get it to refresh!... Man I don't want to put
            //empty buttons n shit. But maybe I must.

            //it doesnt have enough time to initialize!!! apparently!!
            //oh, i could put it in the class above, to run thru
            /*using(var db = new myDbContext())
            {
                if (db.OwnedPets.Where(o => o.PetId == petid) != null) //Select(o => o.PetId).FirstOrDefault()
                {
                    isBought = true;
                    } else { isBought = false;}
            }*/
            //AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAa
            //AAAAAAAAAAAAAAAAAAAAAAAAAAAAA
            //okay try putting it a class above

            //if petid is in ownedpets, then isBought = true
            
        }

        private void Buytton_Click(object sender, RoutedEventArgs e) //Buying button. Adds pet to owned pets
        {
            //Console.WriteLine(petid);
            //i could do it by elements number lol
            //Console.WriteLine(db.Pets.Where(o => o.PetId == i) + " is the pet number " + i);
            //petid = db.OwnedPets.Where(o => o.PetId == i).Select(o => o.PetId).FirstOrDefault();

            //Hmm. Its flipped. Let's check upstream.
            if (!isBought) {
                    isBought = true;
                    UnBoughtPet(petid);
                    } else {
                    isBought = false;
                    BoughtPet(petid);
            }
        }

        private void BoughtPet(int petId)
        {
            using (var db = new myDbContext()) {
            Buytton.Content = "Sell"; //+ petid; //STILL... is 0 at first >:(
            Buytton.Background = (Brush)new BrushConverter().ConvertFrom("#FFD11414");
            isBought = true;
            //db.OwnedPets.Add(new OwnedPets() { PetId = petid }); //wait, this is bad??
            //db.SaveChanges();

            //so what's wrong here. alright.
            var pet = db.UserPets.SingleOrDefault(p => p.PetId == petId);
                //Buytton.Content = db.UserPets.SingleOrDefault(p => p.PetId == petid).PetId; //oh right, this is debug checker. so i'm screwing up somewhere
                //Buytton.Content = pet.PetId.ToString(); //oh right, this is debug checker. so i'm screwing up somewhere
                Buytton.Content = petId;

                if (pet != null)
                {
                    try {
                        pet.isOwnedByThisUser = true;
                        db.SaveChanges();
                    } catch(Exception ex) { throw; }
                }
                //db.SaveChangesAsync();
                return;
            }
        }

        private void UnBoughtPet(int petId) //async task... <t>
        {
            using (var db = new myDbContext())
            {
                Buytton.Content = "Buy"; //+ petid;
                Buytton.Background = (Brush)new BrushConverter().ConvertFrom("#FF8FE877"); //#FF8FE877
                isBought = false;
                var pet = db.UserPets.SingleOrDefault(p => p.PetId == petId);
                Buytton.Content = petId;
                if (pet != null)
                {
                    try
                    {
                        pet.isOwnedByThisUser = false;
                        db.SaveChanges();
                    }
                    catch (Exception ex) { throw; }
                }

                //db.OwnedPets.Remove(new OwnedPets() { PetId = petid });
                db.SaveChangesAsync();
                return;
            }
        }
    }
}
