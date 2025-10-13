using System;

namespace GameEngine
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using Game game = new Game();
            game.Run();
        }
    }
}