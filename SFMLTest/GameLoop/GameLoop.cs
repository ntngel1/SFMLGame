using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.Window;

namespace SFMLGame
{
    public abstract class GameLoop
    {

        public RenderWindow window;

        public GameTime time;

        public List<GameObject> gameObjects;

        public GameLoop(uint width, uint height, string windowTitle, float targetFps)
        {
            gameObjects = new List<GameObject>();

            this.window = new RenderWindow(new VideoMode(width, height), windowTitle);
            window.Closed += (object sender, EventArgs e) => window.Close();

            this.time = new GameTime(targetFps);

            time.onUpdate += (float deltaTime) => {
                window.DispatchEvents();
                Update(deltaTime);
                Render(window);
            };
        }

        public void Run()
        {
            LoadContent();
            Initialize();

            while (window.IsOpen)
            {
                time.Update();
            }
        }

        protected virtual void LoadContent()
        {
            foreach (GameObject obj in gameObjects)
                obj.LoadContent();
        }
        protected virtual void Initialize()
        {
            foreach (GameObject obj in gameObjects)
                obj.Initialize();
        }
        protected virtual void Update(float deltaTime)
        {
            foreach (GameObject obj in gameObjects)
                obj.Update(deltaTime);
        }
        protected virtual void Render(RenderTarget renderer)
        {
            renderer.Clear(Color.Black);
            foreach (GameObject obj in gameObjects)
                obj.Render(renderer);

            if (renderer is Window)
                ((Window)renderer).Display();
        }

    }
}
