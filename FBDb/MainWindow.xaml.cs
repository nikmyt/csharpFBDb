using Microsoft.EntityFrameworkCore;
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
using WPF;
using WPF.DB;

namespace FBDb
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    //start db
    //TODO load pets from db and populate dog stocks
    //go into mainlgoic.cs?
    //oh i guess you can just start everything here

    public partial class MainWindow : Window
    {
        //Total TX, for each pet owned.
        //public int totalTX;

        public MainWindow()
        {
            InitializeComponent();
            //Console.WriteLine("hello");

            //DatabaseLogic();
            //DatabaseLogic.cleanDb();

            //addPet();
            //removePet();
        }

        public async void addPet() //i dont NEED this here, right. just when im putting stuff in. TODO remove
        {
            var db = new myDbContext();
            db.Database.EnsureCreated();

            //now you know how to send pets to db, altho most likely you'd be editing them. o well

            //UserPets pet = new UserPets() { Name = "Leon", Description = "He's a little neurotic.", ToxGeneration = 1.8, ToxProduced = 0, Sprite = "Dog1", isOwnedByThisUser = false };
            //UserPets pet = new UserPets { Name = "Kiki", Description = "She's just a plain ol' dog on the inside.", ToxGeneration = 1.3, ToxProduced = 0, Sprite = "Dog3" };
            UserPets pet = new UserPets { Name = "Ultimate Daniel", Description = "He has evolved.", ToxGeneration = 10, ToxProduced = 0, Sprite = "Dog2" };
            db.UserPets.Add(pet);
            db.SaveChangesAsync();
            //i was spose to use await here but i cannot

        }

        public void removePet() //shid aint work
        {
            var db = new myDbContext();
            db.Database.EnsureCreated();

            //var pet = db.UserPets.Where(x => x.PetId == 4);
            UserPets pet = new UserPets() { PetId = 4 };
            db.UserPets.Attach(pet);
            db.UserPets.Remove(pet);
            db.SaveChanges();
        }
    }
}
