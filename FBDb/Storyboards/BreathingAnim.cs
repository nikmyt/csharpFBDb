using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace WPF.Storyboards
{
    public class BreathingAnim : Page
    {
        //wtf is this even for.
        //but okay, my idea is to animate for a time, and when done, animate back
        //SOUNDS EASY...


        /*
        public Storyboard myStoryboard;
        DoubleAnimation myDoubleAnimation = new DoubleAnimation();

        public BreathingAnim(){
            //NameScope.SetNameScope(this, new NameScope());

            myDoubleAnimation.From = 1.0;
            myDoubleAnimation.To = 0.0;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(5000));
            myDoubleAnimation.AutoReverse = true;

        // Create the storyboard.
        myStoryboard = new Storyboard();
        myStoryboard.Children.Add(myDoubleAnimation);
        Storyboard.SetTargetName(myDoubleAnimation, myRectangle.Name); //here i get targit
        Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Rectangle.OpacityProperty));
    }*/
}
}
