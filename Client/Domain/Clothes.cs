using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace player.Client
{
    static public class Clothes
    {
        static public bool itemsLoaded = false;

        public static Dictionary<string, string> clothesNamesToIds = new Dictionary<string, string>();
        static public int Body = 0;
        static public int Gloves = 0;
        static public int Pants = 0;
        static public int Shoes = 0;
    }
}