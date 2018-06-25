using System;
using SFML.Graphics;
using System.Collections.Generic;

namespace SFMLGame
{
    public class GameStats : GameObject
    {
        public string FontPath
        {
            get;
            set;
        }

        public uint TextSize
        {
            get;
            set;
        }

        private List<Object> parameters;
        private Text text;
        private Font font;

        public GameStats(string name) : base(name)
        {
            parameters = new List<Object>();
        }

        public override void Initialize()
        {
            text = new Text(String.Empty, font, 14);
        }

        public override void LoadContent()
        {
            if (FontPath.Equals(String.Empty))
                FontPath = "raleway.ttf";
            font = new Font(FontPath);
        }

        public override void Render(RenderTarget renderer, RenderStates states)
        {
            states.Transform *= Transform;

            renderer.Draw(text, states);
        }

        public override void Update(float deltaTime)
        {
            text.DisplayedString = String.Empty;

            text.DisplayedString += String.Format("FPS: {0}\n", Game.MainLoop.Time.FPS);
            text.DisplayedString += String.Format("Total Frames: {0}\n", Game.MainLoop.Time.TotalFramesElapsed);
        }
    }
}
