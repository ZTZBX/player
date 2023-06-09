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
        static public bool modelsHasLoaded = false;

        static public uint modelFemale = 0; 
        static public uint modelMale = 0; 

        public static Dictionary<string, string> clothesNamesToIds = new Dictionary<string, string>();

        
        static public int Torso = 15;
        static public int UpperBody = 15;
        static public int Undershirt = 15;
        static public int Gloves = 0;
        static public int Pants = 245;
        static public int Shoes = 218;
    }
}