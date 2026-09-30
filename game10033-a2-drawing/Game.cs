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

        // Custom Colors
        Color brown = new Color("5B361C");
        Color brick = new Color("FF7E6D");

        // Season Colors

        // Tree Colors
        Color tree = new Color("5DCC2A"); // Initial tree color, identical to summer
        Color spring = new Color("FFB7C5"); // Cherry Blossom Pink
        Color summer = new Color("5DCC2A"); // Green
        Color fall = new Color("FF5728"); // Orange
        Color winter = new Color(0, 0); // Transparent, to get rid of leaves

        // Hill Grass Colors
        Color hillGrass = new Color("34BC3C");
        Color normHillGrass = new Color("34BC3C");
        Color snowHillGrass = Color.White;

        // Background Grass Colors
        Color bgGrass = new Color("1C8228");
        Color normBgGrass = new Color("1C8228");
        Color snowBgGrass = new Color(210);

        // Time Variables

        // Sun and Moon Positions
        Vector2 dayTime = new Vector2(345, 55); // The sun's position
        Vector2 nightTime = new Vector2(345, 350); // The moon's position

        // Sky Color
        Color sky = new Color(190, 255, 255);
        Color daySky = new Color(190, 255, 255);
        Color nightSky = new Color(45, 35, 105);

        // Window Color

        Color window = new Color(0);
        Color lightsOff = new Color(0);
        Color lightsOn = new Color("FFFF00");


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
                hillGrass = normHillGrass;
                bgGrass = normBgGrass;
            }
            if (Input.IsKeyboardKeyPressed(KeyboardKey.S))
            {
                tree = summer;
                hillGrass = normHillGrass;
                bgGrass = normBgGrass;
            }
            if (Input.IsKeyboardKeyPressed(KeyboardKey.D))
            {
                tree = fall;
                hillGrass = normHillGrass;
                bgGrass = normBgGrass;
            }
            if (Input.IsKeyboardKeyPressed(KeyboardKey.F))
            {
                tree = winter;
                hillGrass = snowHillGrass;
                bgGrass = snowBgGrass;
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

            if (dayTime.Y == 350)
            {
                sky = nightSky;
                window = lightsOn;
            }
            else
                sky = daySky;
                window = lightsOff;

            // Graphics

            Window.ClearBackground(sky);
            Draw.SetLineSize(0);

            // Sun and Moon
            Draw.FillColor = Color.Yellow;
            Draw.Circle(dayTime, 50);

            Draw.FillColor = Color.OffWhite;
            Draw.Circle(nightTime, 30);

            // Background
            Draw.FillColor = bgGrass;
            Draw.Rectangle(new Vector2(0, 300), new Vector2(400, 400));

            // Hill

            // Grass
            Draw.FillColor = hillGrass;
            Draw.Ellipse(new Vector2(225, 425), new Vector2(350, 300));

            // House
            Draw.FillColor = brick;
            Draw.Rectangle(new Vector2(150, 235), new Vector2(155, 115));
            Draw.FillColor = brown;
            Draw.Rectangle(new Vector2(205, 270), new Vector2(45, 80));
            Draw.Triangle(new Vector2(125, 250), new Vector2(330, 250), new Vector2(227.5f, 170));


            Draw.FillColor = window;
            Draw.Rectangle(new Vector2(160, 270), new Vector2(35, 35));
            Draw.FillColor = window;
            Draw.Rectangle(new Vector2(260, 270), new Vector2(35, 35));

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
