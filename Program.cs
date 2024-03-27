using System;
using SplashKitSDK;

namespace MakingAScene
{
    public class Program
    {
        public static void Main()
        {
            Window window = new Window ("Animation", 500,500);

            Bitmap cats = new Bitmap("cats","cat.png"); 
            Bitmap ufo = new Bitmap("ufo","ufo.png"); 
            Bitmap planet = new Bitmap("planet","planet.png"); 
            Bitmap grinch = new Bitmap("grinch","grinch.png"); 
            Bitmap hi = new Bitmap("hi","hi.png"); 

            SoundEffect drumRoll = new SoundEffect("drum", "drum_roll.wav");
            SoundEffect ufoSound = new SoundEffect("ufo", "ufo.wav");
            SoundEffect wow = new SoundEffect("wow", "woow.wav");

            double x = 260;
            double y = 130;

            window.Clear(Color.Beige); 
            drumRoll.Play();

            if(drumRoll.IsPlaying) {
                window.DrawBitmap(cats, 125, 138.5);
                window.DrawBitmap(hi, x,y);
                
                for(double i = y; i<220; i++){
                    window.Clear(Color.Beige); 
                    window.DrawBitmap(cats, 125, 138.5);
                    window.DrawBitmap(hi,x+1,i);
                    window.Refresh();
                    SplashKit.Delay(60);
                }

                for(double i = 220; i>=130; i--){
                    window.Clear(Color.Beige); 
                    window.DrawBitmap(cats, 125, 138.5);
                    window.DrawBitmap(hi,x-1,i);
                    window.Refresh();
                    SplashKit.Delay(60);
                }

                window.Refresh();
                SplashKit.Delay(1000);
            }

            if(!drumRoll.IsPlaying) {

                ufoSound.Play();
                
                // Define the parameters of the ellipse
                double a = 200; // semi-major axis length
                double b = 150; // semi-minor axis length
                double center_x = 215; // x-coordinate of the center
                double center_y = 130; // y-coordinate of the center

                // Define the angle increment for each step
                double delta_theta = 0.1; // some small angle increment

                // Initialize the angle
                double theta = 0;

                // Loop to move the point along the elliptical path
                            while (ufoSound.IsPlaying)
                            {
                                // Calculate the x and y coordinates of the point on the ellipse
                                double xx = center_x + a * Math.Cos(theta);
                                double yy = center_y + b * Math.Sin(theta);

                                window.Clear(Color.LightYellow);
                                window.DrawBitmap(planet, 130, 100);

                                // Print the coordinates of the UFO movement
                                window.DrawBitmap(ufo, xx, yy);
                                window.Refresh();
                                SplashKit.Delay(100);

                                // Increment the angle
                                theta += delta_theta;

                                // Check if the point has completed a 2 full revolutions
                                if (theta >= 2 * Math.PI)
                                {
                                    // Reset the angle if a 2 full revolutions is completed
                                    theta = 0;
                                    // break;

                                }
                                
                            } 
                            window.Refresh(); 

                if(!ufoSound.IsPlaying) {
                    wow.Play();
                    window.Clear(Color.Beige);
                    window.DrawBitmap(grinch, 150, 150);
                    
                    window.Refresh();
                    SplashKit.Delay(60000);

                }

            }
            

        }
    }
}
