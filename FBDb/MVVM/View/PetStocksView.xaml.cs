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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF.DB;
using WPF.MVVM.Elements;

namespace WPF.MVVM.View
{
    /// <summary>
    /// Interaction logic for PetStockView.xaml
    /// </summary>

    //TODO buy dogs logic
    //damn itd be cool if i could dynamically load from db
    //TODO would be great to load dogs into memory instead of loading separately every screen


    public partial class PetStocksView : UserControl
    {
        myDbContext db = new myDbContext();
        public PetStocksView()
        {
            InitializeComponent();
            //InitDB();
            PetStockBoardFactory();

            //TODO here you may load ye doges
            //oh god its gonna be so much work
        }

        public void InitDB() //async pls. or dont
        {
            db.Database.EnsureCreated();
        }

        public void PetStockBoardFactory()
        {
            //for each entry in Pets, make a nice board to populate the stocks (no shid)

            //https://stackoverflow.com/questions/24728667/dynamically-adding-elements-to-a-ui-in-c-sharp
            //DataRepeater
            //flowLayoutPanel1.Controls.Add(
            //new MachineFunctionUC
            //{
            //    Parent = flowLayoutPanel1
            //});

            //So several options to try

                using (var db = new myDbContext())
                {
                    /*
                    //Console.WriteLine(db.Pets.Where(o => o.PetId == i) + " is the pet number " + i);
                    petid = db.Pets.Where(o => o.PetId == i).Select(o => o.PetId).FirstOrDefault();
                    name = db.Pets.Where(o => o.PetId == i).Select(o => o.Name).FirstOrDefault();
                    description = db.Pets.Where(o => o.PetId == i).Select(o => o.Description).FirstOrDefault();
                    toxingeneration = db.Pets.Where(o => o.PetId == i).Select(o => o.ToxGeneration).FirstOrDefault(); //stupdio!!
                    sprite = db.Pets.Where(o => o.PetId == i).Select(o => o.Sprite).FirstOrDefault(); //stupdio!!


                    if (db.UserPets.Where(o => o.PetId == i).Select(o => o.isOwnedByThisUser).FirstOrDefault() == true) //im not silly
                    {
                        isBought = true;
                    }
                    else { isBought = false; };

                    //look fam why is there a problem here. i rlly dont know
                }

                PetsStockPanel panel = new PetsStockPanel();
                panel.petid = petid; //so we ARE setting petid so wtf are you pissy about
                panel.isBought = isBought;
                panel.Description1.Text = description;
                panel.Name1.Text = name;
                panel.ToxinProduction1.Text = toxingeneration.ToString();
                BitmapImage sprito = new BitmapImage(new Uri(@"/Images/" + sprite + "/dog_sitting.png", UriKind.Relative));
                panel.DogStocksIcon.Source = sprito;
                //as for sprite, need special code to 1) set it 2)assign random sprite if no sprite is set

                StocksControl.Children.Add(panel);
            }*/

                    var pets = db.UserPets.ToList();
                    foreach (var pet in pets)
                    {
                        int petid = pet.PetId;
                        string name = pet.Name;
                        string description = pet.Description;
                        int toxinproduced = pet.ToxProduced;
                        double toxingeneration = pet.ToxGeneration;
                        string sprite = pet.Sprite;
                        bool isBought = pet.isOwnedByThisUser;

                        PetsStockPanel panel = new PetsStockPanel(isBought,petid); //HMMMMM??? will it work?
                        panel.petid = petid; //so we ARE setting petid so wtf are you pissy about
                        panel.isBought = isBought;
                        panel.Description1.Text = description;
                        panel.Name1.Text = name;
                        panel.ToxinProduction1.Text = toxingeneration.ToString();
                        BitmapImage sprito = new BitmapImage(new Uri(@"/Images/" + sprite + "/dog_sitting.png", UriKind.Relative));
                        panel.DogStocksIcon.Source = sprito;
                        //as for sprite, need special code to 1) set it 2)assign random sprite if no sprite is set

                        StocksControl.Children.Add(panel);
                    }
                }
            }
        }
    }