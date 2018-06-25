using System;
using SFML.Graphics;
using SFML.System;

namespace SFMLGame
{
    class BasicGameLoop : GameLoop
    {
        private TextObject text;

        public BasicGameLoop(uint width, uint height, string windowTitle, float targetFps) : base(width, height, windowTitle, targetFps)
        {
            text = new TextObject("test object", "Hello, world!", "raleway.ttf", 25);
            text.Position = new Vector2f(50, 50);
            Window.Resized += Window_Resized;
            GameObjects.Add(text);
        }

        private void Window_Resized(object sender, SFML.Window.SizeEventArgs e)
        {
            text.Position = new Vector2f(e.Width / 2, e.Height / 2);
            text.Text = "Resized!";
            text.Size = 90;
        }
    }
}
