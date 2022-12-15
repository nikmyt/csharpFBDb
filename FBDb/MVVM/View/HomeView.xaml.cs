using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Xps.Serialization;
using WPF.DB;
//using static System.Windows.Media.Animation.SizeAnimationBase; //wew static

namespace WPF.MVVM.View
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    /// 

    //global varible which dog is choosen or smth

    public partial class HomeView : UserControl
    {
        //Pet params
        int petid = -1;
        string petname = null;
        string petsprite = "Dog3";
        int txAmount = -1; //this id store in DB
        int ToxinAdded = 0;


        //Labels
        BitmapImage DogLabelHighlight = new BitmapImage(new Uri(@"/Images/ui/DogLabel.png", UriKind.Relative));
        BitmapImage DogLabelActive = new BitmapImage(new Uri(@"/Images/ui/DogLabelActive.png", UriKind.Relative));
        BitmapImage DogLabelLight = new BitmapImage(new Uri(@"/Images/ui/DogLabelLight.png", UriKind.Relative));
        BitmapImage DogLabelBase = new BitmapImage(new Uri(@"/Images/ui/DogLabelBase.png", UriKind.Relative));

        //DogPics
        BitmapImage DogSitting = new BitmapImage(new Uri(@"/Images/dog1/dog_sitting1.png", UriKind.Relative));
        BitmapImage DogEating = new BitmapImage(new Uri(@"/Images/dog1/dog_eating1.png", UriKind.Relative));
        BitmapImage missingpix = new BitmapImage(new Uri(@"/Images/extra/missing.png", UriKind.Relative));

        private Storyboard myStoryboard;
        DoubleAnimation myDoubleAnimation = new DoubleAnimation();
        Int32Animation integerAnimation = new Int32Animation();


        bool doBreathe = true;
        bool doEat = false;
        bool doPoo = false;

        int animationDuration = 1000;
        int animationDelay = 750;

        //Image<"DogImage"> = ;
        //nwm it just is.

        public HomeView()
        {
            InitializeComponent(); //okay
            DogImage.Source = missingpix;
            GetOwnedPets(); //yup
            
            DogBreatheAnim(); //sure

            //DisplayPet(); //only when... SELECTED

            //LoadPet(petsprite,txAmount); // Because you need to show correct TX.
            

        }

        public void DogBreatheAnim()
        {
            DogBreatheAnimWidth();
            DogBreatheAnimHeight();
            //TODO: should keep track where the anims ended so its continuous when switching
        }

        public void DogBreatheAnimWidth() //id put all dog anims in DogAnimations.cs and then reference, preferably
        {
            //make this a method. DogBreatheAnim()
            myDoubleAnimation.From = 480; //481, 443
            myDoubleAnimation.To = 440;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(animationDuration)); //5000 is like 5 seconds bruh
            myDoubleAnimation.AutoReverse = true;
            myDoubleAnimation.RepeatBehavior = RepeatBehavior.Forever;

            // Create the storyboard.
            myStoryboard = new Storyboard();
            myStoryboard.Children.Add(myDoubleAnimation);
            Storyboard.SetTargetName(myDoubleAnimation, DogImage.Name); //why set name? hmm
            //Storyboard.SetTarget(DogImage, myDoubleAnimation);
            Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath("Width"));

            myStoryboard.Begin(this, true);

        }

        public void DogBreatheAnimHeight()
        {
            //make this a method. DogBreatheAnim()
            myDoubleAnimation.From = 480; //481, 443
            myDoubleAnimation.To = 440; //detachedly: dogheight - (int)dogheight / 10 to get 1%
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(animationDuration + animationDelay)); //5000 is like 5 seconds bruh
            myDoubleAnimation.AutoReverse = true;
            myDoubleAnimation.RepeatBehavior = RepeatBehavior.Forever;
            //myDoubleAnimation.BeginTime = TimeSpan.FromMilliseconds(animationDelay);

            // Create the storyboard.
            myStoryboard = new Storyboard();
            myStoryboard.Children.Add(myDoubleAnimation);
            Storyboard.SetTargetName(myDoubleAnimation, DogImage.Name); //why set name? hmm
            //Storyboard.SetTarget(DogImage, myDoubleAnimation);
            Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath("Height"));

            myStoryboard.Begin(this, true);
        }
        async Task playAnimation()
        {
        }

        void OnClickFeed(object sender, RoutedEventArgs e)
        {
            //FeedButton.FontSize = 16;
            //FeedButton.Background = Brushes.Red;
            //FeedLabel.Source = DogLabelHighlight;
            //also dog should perfom eating animation
            //and increase TX counter
            //would be cool to have it fade animatedly yes i love the animations
            //if (FeedButton.IsMouseOver != true) //aint work
            //{
            //    FeedLabel.Source = DogLabelBase;
            //}
            //FeedLabel.Source = DogLabelActive;

            if (petid <= 0) { return; } else { 
            txAmount += 1;
            ToxinAdded += 1;
            ToxinAmount.Text = "TX: " + txAmount.ToString();

            //if i were to just leave this screen (eg, hover over one of the windows or perhaps click off?) this triggers but rn it triggers
            //all the time. oop.
            //also every 10 seconds or so. autosave
            //if(petid <= 0)
            //{
            SaveToxins(txAmount, petid);
            //}
            //EatingAnimation();

            //TODO: make this anim
            //DogImage.Source = DogEating;
            //EatingAnimation();
            }
        }

        public void SaveToxins(int ToxinValue, int petid)
        {
            using (var db = new myDbContext())
            {
                //oh shit this is mindbreaking
                //var result = db.UserPets.SingleOrDefault(o => o.PetId == petid);
                //if (result != null) //why is it null dude. why
                //{
                //result.ToxProduced += ToxinValue;
                db.UserPets.SingleOrDefault(o => o.PetId == petid).ToxProduced += ToxinAdded; //works
                db.SaveChanges();
                ToxinAdded = 0;
                //}
            }
        }
        private void SetTimer(System.Timers.Timer aTimer)
        {
            // Create a timer with a two second interval.
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            BitmapImage sprite = new BitmapImage(new Uri(@"/Images/" + petsprite + "/dog_eating.png", UriKind.Relative));
            DogImage.Source = sprite; //well its not loading this, nword
            //aTimer.Dispose();
            DogBreatheAnim();
        }

        public void EatingAnimation()
        {
            doEat = true;
            System.Timers.Timer aTimer = new System.Timers.Timer(2000);
            SetTimer(aTimer);
            BitmapImage sprite = new BitmapImage(new Uri(@"/Images/" + petsprite + "/dog_eating.png", UriKind.Relative));
            DogImage.Source = sprite; //well its not loading this, nword

            /*
            myStoryboard = new Storyboard();
            myStoryboard.Children.Add(myDoubleAnimation); //just duration
            Storyboard.SetTargetName(myDoubleAnimation, DogImage.Name); //why set name? hmm
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(100));
            myDoubleAnimation.AutoReverse = false;
            //myDoubleAnimation.RepeatBehavior.2x;
            //Storyboard.SetTarget(DogImage, myDoubleAnimation);
            Storyboard.SetTargetProperty(DogEating, new PropertyPath("Source"));

            myStoryboard.Begin(this, true);
            */
        }

        private void OnHoverEnterFeed(object sender, MouseEventArgs e)
        {
            FeedLabel.Source = DogLabelHighlight;
        }

        private void OnHoverLeaveFeed(object sender, MouseEventArgs e)
        {
            FeedLabel.Source = DogLabelBase;
        }

        //selector dropdown = combo box
        //get dogs i bought (table bought pets)
        /*public void ComboBoxDataBindingSample()
        {
            Selector.ItemsSource = typeof(Colors).GetProperties();
        }*/

        public void GetOwnedPets()
        {
            

            using (var db = new myDbContext())
            {
                //Console.WriteLine(db.Pets.Where(o => o.PetId == i) + " is the pet number " + i);
                //db.UserPets.Where(o => o.isOwnedByThisUser == true).Count()
                //should load into an array which id then split, but whatever
                //oh nwm i fucked it here too

                /*for (int i = 1; i < db.UserPets.Where(o => o.isOwnedByThisUser == true).Count(); i++)
                {
                    if (db.UserPets.Where(o => o.PetId == i).Where(o => o.isOwnedByThisUser == true).FirstOrDefault().isOwnedByThisUser != true) //prolem here prolly
                    { continue; }
                    else
                    {

                        int petid;
                        string petName;
                        petid = db.UserPets.Where(o => o.PetId == i).Where(o => o.isOwnedByThisUser == true).Select(o => o.PetId).FirstOrDefault();
                        petName = db.UserPets.Where(o => o.PetId == i).Where(o => o.isOwnedByThisUser == true).Select(o => o.Name).FirstOrDefault();

                        Selector.Items.Add(petName.ToString()); //last thing that works
                        petid = 0;
                        petName = null;
                    }
                }*/

                //we need id and petname
                //"This is bad code, it generates 3 queries!"
                var ownedPets = db.UserPets.Where(x => x.isOwnedByThisUser == true).ToList();
                foreach (var pet in ownedPets)
                {
                    //int petid = db.Entry(pet).Reference(x => x.PetId).Load();
                    int petid = pet.PetId;
                    string petname = pet.Name;
                    Selector.Items.Add(petname.ToString());
                }
            }
        }
        //selected item: ComboBoxItem cbi = (ComboBoxItem)ComboBox1.SelectedItem;  

        private bool handle = true;
        private void ComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (handle) Handle();
            handle = true;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            handle = !cmb.IsDropDownOpen;
            Handle();
        }

        private void Handle()
        {
            DisplayPet();
            /*switch (Selector.SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last())
            {
                case "1":
                    this.Content = "peepee";
                    break;
                case "2":
                    this.Content = "poeoeop";
                    break;
            }*/
        }

        public void DisplayPet() //should be a two parter, the other one should... LoadPet()!
        {
            using (var db = new myDbContext())
            {
                if (Selector.SelectedItem.ToString() == null) { return; }
                String s = Selector.SelectedItem.ToString();
                for (int i = 0; i < db.UserPets.Count(); i++)
                {
                    //var result = db.UserPets.Where(o => o.PetId == i);
                    //long way
                    if (s == db.UserPets.Where(o => o.PetId == i).Select(o => o.Name).FirstOrDefault()) //a very silly way to go about it, what if theres 2 pets of same name?
                        {
                        //k so i get the pet thats named like that, cool. oh maybe put db.user.id into a var so i can reuse
                        //display sprite, and achieved tx amount
                        petid = db.UserPets.Where(o => o.PetId == i).Select(o => o.PetId).FirstOrDefault();
                        petname = db.UserPets.Where(o => o.PetId == i).Select(o => o.Name).FirstOrDefault();
                        petsprite = db.UserPets.Where(o => o.PetId == i).Select(o => o.Sprite).FirstOrDefault(); //sprite
                        txAmount = db.UserPets.Where(o => o.PetId == i).Select(o => o.ToxProduced).FirstOrDefault();
                        LoadPet(petsprite, txAmount); //maybe onsert? or maybe not
                        } //else { return 0; }
                }
            }
        }

        public void LoadPet(string sprito, int txo)
        {
            //sprite, tx
            BitmapImage sprite = new BitmapImage(new Uri(@"/Images/" + sprito + "/dog_sitting.png", UriKind.Relative));
            DogImage.Source = sprite; //well its not loading this, nword
            ToxinAmount.Text = "TX: " + txo; //soz not loading, cool
            DogBreatheAnim(); //oh its probably hardcoded somewhere innit
        }
    }
}