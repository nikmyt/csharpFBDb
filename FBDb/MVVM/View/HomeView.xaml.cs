using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        //Labels
        BitmapImage DogLabelHighlight = new BitmapImage(new Uri(@"/Images/ui/DogLabel.png", UriKind.Relative));
        BitmapImage DogLabelActive = new BitmapImage(new Uri(@"/Images/ui/DogLabelActive.png", UriKind.Relative));
        BitmapImage DogLabelLight = new BitmapImage(new Uri(@"/Images/ui/DogLabelLight.png", UriKind.Relative));
        BitmapImage DogLabelBase = new BitmapImage(new Uri(@"/Images/ui/DogLabelBase.png", UriKind.Relative));

        //DogPics
        BitmapImage DogSitting = new BitmapImage(new Uri(@"/Images/dog1/dog_sitting1.png", UriKind.Relative));
        BitmapImage DogEating = new BitmapImage(new Uri(@"/Images/dog1/dog_eating1.png", UriKind.Relative));

        private Storyboard myStoryboard;
        DoubleAnimation myDoubleAnimation = new DoubleAnimation();
        Int32Animation integerAnimation = new Int32Animation();


        bool doBreathe = true;
        bool doEat = false;
        bool doPoo = false;

        int txAmount; //this id store in DB

        int animationDuration = 1000;
        int animationDelay = 750;


        //Image<"DogImage"> = ;
        //nwm it just is.

        public HomeView()
        {
            InitializeComponent();
            //dog logic
            //toxin accumulates
            //pet dog
            //feed dog

            GetOwnedPets();


            //LoadPet();

            DogBreatheAnim();
            

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

            txAmount += 1;

            ToxinAmount.Text = "TX: " + txAmount.ToString();



            //TODO: make this anim
            //DogImage.Source = DogEating;
            //EatingAnimation();
        }

        public void EatingAnimation()
        {
            myStoryboard = new Storyboard();
            myStoryboard.Children.Add(myDoubleAnimation); //just duration
            Storyboard.SetTargetName(myDoubleAnimation, DogImage.Name); //why set name? hmm
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(animationDuration));
            //Storyboard.SetTarget(DogImage, myDoubleAnimation);
            Storyboard.SetTargetProperty(DogEating, new PropertyPath("Source"));

            myStoryboard.Begin(this, true);
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
        public void ComboBoxDataBindingSample()
        {
            Selector.ItemsSource = typeof(Colors).GetProperties();
        }

        public void GetOwnedPets()
        {
            int petid;

            using (var db = new myDbContext())
            {
                for (int i = 1; i < db.OwnedPets.Count() + 1; i++)
                {
                    //Console.WriteLine(db.Pets.Where(o => o.PetId == i) + " is the pet number " + i);
                    petid = db.OwnedPets.Where(o => o.PetId == i).Select(o => o.PetId).FirstOrDefault();
                    //select the damn thing backward

                    Selector.Items.Add(petid.ToString());
                }
            }
        }
        //selected item: ComboBoxItem cbi = (ComboBoxItem)ComboBox1.SelectedItem;  


    }
}