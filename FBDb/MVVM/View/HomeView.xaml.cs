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
//using static System.Windows.Media.Animation.SizeAnimationBase; //wew static

namespace WPF.MVVM.View
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {

        private Storyboard myStoryboard;
        DoubleAnimation myDoubleAnimation = new DoubleAnimation();
        Int32Animation integerAnimation = new Int32Animation();

        bool doBreathe = true;
        bool doEat = false;
        bool doPoo = false;
        
        //Image<"DogImage"> = ;
        //nwm it just is.

        public HomeView()
        {
            InitializeComponent();
            //dog logic
            //toxin accumulates
            //pet dog
            //feed dog

            //System.Printing.Print(DogImage.Width);
            DogBreatheAnim();

        }

        public void DogBreatheAnim() //id put all dog anims in DogAnimations.cs and then reference, preferably
        {
            //make this a method. DogBreatheAnim()
            myDoubleAnimation.From = 480; //481, 443
            myDoubleAnimation.To = 240; 
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(500)); //5000 is like 5 seconds bruh
            myDoubleAnimation.AutoReverse = true;

            // Create the storyboard.
            myStoryboard = new Storyboard();
            myStoryboard.Children.Add(myDoubleAnimation);
            Storyboard.SetTargetName(myDoubleAnimation, DogImage.Name); //why set name? hmm
            //Storyboard.SetTarget(DogImage, myDoubleAnimation);
            Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath("Width"));

            //this needs to loop. maybe a while and a bool?
            //NOO. BECAUSE IT GETS STUCK HERE okay so i should multithread this probably.
            //yes thats the correct interpretation of this problem, not enough threads
            //okay, maybe id do an even or something
            playAnimation();

            }
        async Task playAnimation()
        {
            //okay i never use while myself. just do like, recursion
            myStoryboard.Begin(this, true);
            //it is unhappy
            //if (doBreathe || doEat || doPoo) { playAnimation(); }
            
            //TODO: make this into event

        }
        }
    }