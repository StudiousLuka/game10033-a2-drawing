// Include the namespaces (code libraries) you need below.
using System;
using System.Net.Security;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Variables

        // Static colors
        Color brown = new Color("5B361C");
        Color tree = new Color("22B14C");
        Color bgGrass = new Color("48892A");
        Color tree1 = new Color("22B14C"); // Initial color, identical to summer

        // Tree colors
        Color spring = new Color("FFB7C5"); // Cherry Blossom Pink
        Color summer = new Color("22B14C"); // Green
        Color fall = new Color("FF5728"); // Orange
        Color winter = new Color(0, 0); // Transparent, to get rid of leaves

        // Time Changing Input Variables
        Vector2 dayTime = new Vector2(345, 55); // The sun's position
        Vector2 nightTime = new Vector2(345, 350); // The moon's position
        public void Setup()
        {
            Window.SetSize(400, 400);
            Window.SetTitle("The Hill");

        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            // Inputs

            // Changing Seasons
            if (Input.IsKeyboardKeyPressed(KeyboardKey.A))
            {
                tree = spring;
            }
            if (Input.IsKeyboardKeyPressed(KeyboardKey.S))
            {
                tree = summer;
            }
            if (Input.IsKeyboardKeyPressed(KeyboardKey.D))
            {
                tree = fall;
            }
            if (Input.IsKeyboardKeyPressed(KeyboardKey.F))
            {
                tree = winter;
            }

            // Changing the Time

            Vector2 sunInput = new Vector2(0, 0);
            Vector2 moonInput = new Vector2(0, 0);
            if (Input.IsKeyboardKeyDown(KeyboardKey.Down) && dayTime.Y < 350)
            {
                sunInput.Y = 1;
            }
            if (Input.IsKeyboardKeyDown(KeyboardKey.Down) && dayTime.Y == 350 && nightTime.Y > 55)
            {
                moonInput.Y = -1;
            }
            if (Input.IsKeyboardKeyDown(KeyboardKey.Up) && nightTime.Y < 350)
            {
                moonInput.Y = 1;
            }
            if (Input.IsKeyboardKeyDown(KeyboardKey.Up) && nightTime.Y == 350 && dayTime.Y > 55)
            {
                sunInput.Y = -1;
            }

            dayTime += sunInput * 300f * Time.DeltaTime;
            nightTime += moonInput * 300f * Time.DeltaTime;

            // Graphics

            Window.ClearBackground(Color.Cyan); // Placeholder colour
            Draw.SetLineSize(0);

            // Sun and Moon

            Draw.FillColor = Color.Yellow;
            Draw.Circle(dayTime, 50);

            Draw.FillColor = Color.OffWhite;
            Draw.Circle(nightTime, 30);

            // Background

            Draw.FillColor = bgGrass;
            Draw.Rectangle(new Vector2(0, 300), new Vector2(400, 400));

            // Foreground Tree
            // Trunk
            Draw.FillColor = brown;
            Draw.Rectangle(new Vector2(0, 200), new Vector2(80, 400));

            // Leaves
            Draw.FillColor = tree;
            Draw.Circle(new Vector2(-20, 200), 60);
            Draw.Circle(new Vector2(80, 200), 60);
            Draw.Circle(new Vector2(30, 125), 60);
            Draw.Circle(new Vector2(30, 220), 40);
            Draw.Circle(new Vector2(75, 145), 50);

        }
    }

}
