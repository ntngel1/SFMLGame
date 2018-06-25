using System;
using SFML.Graphics;

namespace SFMLGame
{
    class TextObject : GameObject
    {
        private Text text;
        private Font font;

        public TextObject(string name) : base(name)
        {
        }

        public override void LoadContent()
        {
            font = new Font("raleway.ttf");
        }

        public override void Initialize()
        {
            text = new Text();
            text.Font = font;
            text.CharacterSize = 25;
        }

        public override void Update(float deltaTime)
        {
            text.DisplayedString = String.Format("Frame: {0}", Game.MainLoop.time.FPS);
        }

        public override void Render(RenderTarget renderer)
        {
            renderer.Draw(text);
        }
    }
}
