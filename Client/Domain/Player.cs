using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace player.Client
{
    static public class Player
    {
        static public bool configured = false;
        static public int hoursplayed = -1;
        static public string gender = null;
        static public int temporalPedForConfig = -1;
        static public bool playerLoaded = false;
        static public bool playerStatsLoaded = false;
        static public bool playerNuiOpened = false;
        
        // face
        static public float blackRange = 0.1f;
    }
}