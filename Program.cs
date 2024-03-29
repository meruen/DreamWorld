using System;

namespace DreamWorld {
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (DreamWorldGame game = new DreamWorldGame())
            {
                game.Run();
            }
        }
    }
#endif
}

