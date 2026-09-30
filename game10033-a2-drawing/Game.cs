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
        Color tree1 = new Color("22B14C"); // Initial color, identical to summer

        // Tree colors
        Color spring = new Color("FFB7C5"); // Cherry Blossom Pink
        Color summer = new Color("22B14C"); // Green
        Color fall = new Color("FF5728"); // Orange
        Color winter = new Color(0, 0); // Transparent, to get rid of leaves
        public void Setup()
        {
            Window.SetSize(400, 400);
            Window.SetTitle("Little House on a Hill");

        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.Cyan); // Placeholder colour
            Draw.SetLineSize(0);

            // Foreground Tree
            // Trunk
            Draw.FillColor = brown;
            Draw.Rectangle(new Vector2(-2, 200), new Vector2(80, 402));

            // Leaves
            Draw.FillColor = tree;
            Draw.Circle(new Vector2 (-20, 200), 60);
            Draw.Circle(new Vector2(80, 200), 60);
            Draw.Circle(new Vector2(30, 125), 60);
            Draw.Circle(new Vector2(30, 220), 40);
            Draw.Circle(new Vector2(75, 145), 50);

            // Season-changing inputs
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
        }
    }

}
