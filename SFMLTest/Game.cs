using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFMLGame
{
    public static class Game
    {
        public static GameLoop MainLoop;

        static void Main(string[] args)
        {
            MainLoop = new BasicGameLoop(800, 600, "Test Window", 60.0f);
            MainLoop.Run();
        }
    }
}
