using System;
using SFML.System;

namespace SFMLGame
{

    // TODO: Unlimited framerate

    public class GameTime
    {
        private float timeUntilUpdate;
        private Clock timer;

        private float targetFps;
        public float TargetFPS
        {
            get { return targetFps; }
            set { targetFps = value; timeUntilUpdate = 1.0f / value; }
        }

        private float fpsTimer;
        private float fpsCounter;
        public uint FPS
        {
            get;
            private set;
        }

        public float TimeScale
        {
            get;
            set;
        }

        public float DeltaTime
        {
            get;
            private set;
        }

        public float TotalTimeElapsed
        {
            get;
            private set;
        }

        public uint TotalFramesElapsed
        {
            get;
            private set;
        }

        public delegate void GameTimeHandler(float deltaTime);
        public event GameTimeHandler onUpdate;

        public GameTime(float targetFPS = 60.0f)
        {
            this.TargetFPS = targetFPS;
            this.timer = new Clock();
            timer.Restart();
        }

        public void Update()
        {
            float currentDelta = timer.ElapsedTime.AsSeconds();
            DeltaTime += currentDelta;
            TotalTimeElapsed += currentDelta;

            if (DeltaTime >= timeUntilUpdate)
            {
                if (onUpdate != null)
                    onUpdate(DeltaTime);

                TotalFramesElapsed = (uint)Math.Floor(TotalTimeElapsed / timeUntilUpdate);

                DeltaTime = 0.0f;
                fpsCounter++;
            }

            // Calculating Frames Per Second
            fpsTimer += currentDelta;
            if (fpsTimer >= 1.0f)
            {
                FPS = (uint)Math.Ceiling(1.0f / (fpsTimer / fpsCounter));
                fpsTimer = 0;
                fpsCounter = 0;
            }
                
            timer.Restart();
        }
    }
}
