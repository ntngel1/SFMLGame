using SFML.Graphics;

namespace SFMLGame
{
    interface IRenderable
    {
        void Render(RenderTarget renderer, RenderStates states);
    }
}
