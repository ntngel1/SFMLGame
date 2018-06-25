using System;
using SFML.Graphics;
using SFML.System;

namespace SFMLGame
{
    class BasicGameLoop : GameLoop
    {
        private GameObject text;

        public BasicGameLoop(uint width, uint height, string windowTitle, float targetFps) : base(width, height, windowTitle, targetFps)
        {
            text = new TextObject("My Text");
            this.gameObjects.Insert(0, text);
        }
    }
}
