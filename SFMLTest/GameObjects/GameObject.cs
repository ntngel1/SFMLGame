using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace SFMLGame
{
    public abstract class GameObject : Transformable, Drawable, IUpdatable, IRenderable
    {
        public string Name
        {
            get;
            set;
        }

        public GameObject(string name)
        {
            this.Name = name;
        }

        void Drawable.Draw(RenderTarget target, RenderStates states)
        {
            Render(target, states);
        }

        public abstract void LoadContent();
        public abstract void Initialize();
        public abstract void Update(float deltaTime);
        public abstract void Render(RenderTarget renderer, RenderStates states);
 
    }
}
