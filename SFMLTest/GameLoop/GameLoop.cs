using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.Window;

namespace SFMLGame
{
    public abstract class GameLoop
    {

        public RenderWindow Window;

        public GameTime Time;

        public List<GameObject> GameObjects;

        public GameLoop(uint width, uint height, string windowTitle, float targetFps)
        {
            GameObjects = new List<GameObject>();

            this.Window = new RenderWindow(new VideoMode(width, height), windowTitle);
            Window.Closed += (object sender, EventArgs e) => Window.Close();

            this.Time = new GameTime(targetFps);

            // Do every frame
            Time.OnUpdate += (float deltaTime) => {
                Window.DispatchEvents();
                Update(deltaTime);
                Render(Window);
                Window.Display();
            };
        }

        public void Run()
        {
            Console.WriteLine("Running Game Loop...");
            LoadContent();
            Initialize();

            Console.WriteLine("Starting...");
            while (Window.IsOpen)
            {
                Time.Update();
            }
        }

        protected virtual void LoadContent()
        {
            Console.WriteLine("Loading content...");
            foreach (GameObject obj in GameObjects)
                obj.LoadContent();
            Console.WriteLine("Content Loaded!");
        }
        protected virtual void Initialize()
        {
            Console.WriteLine("Initializing...");
            foreach (GameObject obj in GameObjects)
                obj.Initialize();
            Console.WriteLine("Initialized!");
        }
        protected virtual void Update(float deltaTime)
        {
            foreach (GameObject obj in GameObjects)
                obj.Update(deltaTime);
        }
        protected virtual void Render(RenderTarget renderer)
        {
            renderer.Clear(Color.Black);
            foreach (GameObject obj in GameObjects)
                renderer.Draw(obj);
        }

    }
}
