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
        public int totalTX;

        public MainWindow()
        {
            InitializeComponent();
            //Console.WriteLine("hello");

            //DatabaseLogic();
            //DatabaseLogic.cleanDb();
        }

        public async void nothing() //i dont NEED this here, right. just when im putting stuff in. TODO remove
        {
            var db = new myDbContext();
            db.Database.EnsureCreated();

            //now you know how to send pets to db, altho most likely you'd be editing them. o well

            Pet pet;
            pet = new Pet() { Name = "Leonard", Description = "He's a little neurotic.", ToxGeneration = 1.8, ToxProduced = 0, Sprite = "Dog1" };
            db.Pets.Add(pet);
            db.SaveChangesAsync();
            //i was spose to use await here but i cannot

        }
    }
}
