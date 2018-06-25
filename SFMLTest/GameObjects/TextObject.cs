using SFML.System;
using SFML.Graphics;
using System;

namespace SFMLGame
{
    public class TextObject : GameObject
    {
        private const string defaultFontPath = "raleway.ttf";

        private string _text;
        public string Text
        {
            get { return _text; }
            set { _text = value; isTextChanged = true; }
        }
        private string _fontPath;
        public string FontPath
        {
            get { return _fontPath; }
            set { _fontPath = value; isFontChanged = true; }
        }
        private uint _size;
        public uint Size
        {
            get { return _size; }
            set { _size = value; isSizeChanged = true; }
        }

        protected Text text;
        protected Font font;
        protected bool isTextChanged;
        protected bool isFontChanged;
        protected bool isSizeChanged;

        public TextObject(string name) : base(name)
        {
        }

        public TextObject(string name, string text, string fontPath = defaultFontPath, uint size = 14) : base(name)
        {
            this.Text = text;
            this.FontPath = fontPath;
            this.Size = size;
        }

        public override void LoadContent()
        {
            LoadFont();
        }

        public override void Initialize()
        {
            text = new Text(Text, font, Size);
        }

        public override void Update(float deltaTime)
        {
            // Updating text if some fields were changed
            if (isTextChanged)
            {
                Console.WriteLine("Updating text on object: {0}", Name);
                text.DisplayedString = Text;
                isTextChanged = false;
            }

            if (isFontChanged)
            {
                Console.WriteLine("Updating font on object: {0}", Name);
                LoadFont();
                isFontChanged = false;
            }

            if (isSizeChanged)
            {
                Console.WriteLine("Updating text size on object: {0}", Name);
                text.CharacterSize = Size;
                isSizeChanged = false;
            }
        }

        public override void Render(RenderTarget renderer, RenderStates states)
        {
            states.Transform *= Transform;
            renderer.Draw(text, states);
        }

        private void LoadFont()
        {
            font = new Font(FontPath);
        }

    }
}
