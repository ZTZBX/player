using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace player.Client
{
    static public class Player
    {

        static public bool needToUpdatePlayerStatus = true;
        static public bool playerhaslogged = false;

        static public string currentToken;
        
        static public float defult_spawn_x = 2538.877f;
        static public float defult_spawn_y = 942.8683f;
        static public float defult_spawn_z = 21.82614f;

        static public bool spawned = false;
        static public bool configured = false;
        static public int hoursplayed = -1;
        static public string gender = null;
        static public int temporalPedForConfig = -1;
        static public bool playerLoaded = false;
        static public bool playerStatsLoaded = false;
        static public bool playerFaceLoaded = false;
        static public bool playerNuiOpened = false;

        // configuration for player aspect
        static public float blackRange = 0.1f;
        static public float noseWidthThinWide = 0.0f;
        static public float nosePeakUpDown = 0.0f;
        static public float noseLengthLongShort = 0.0f;
        static public float newoseBoneCurvenessCrookedCurved = 0.0f;
        static public float noseTipUpDown = 0.0f;
        static public float noseBoneTwistLeftRight = 0.0f;
        static public float eyebrowUpDown = 0.0f;
        static public float eyebrowInOut = 0.0f;
        static public float cheekBonesUpDown = 0.0f;
        static public float cheekSidewaysBoneSizeInOut = 0.0f;
        static public float cheekBonesWidthPuffedGaunt = 0.0f;
        static public float eyeOpeningBothWideSquinted = 0.0f;
        static public float lipThicknessBothFatThin = 0.0f;
        static public float jawBoneWidthNarrowWide = 0.0f;
        static public float jawBoneShapeRoundSquare = 0.0f;
        static public float chinBoneUpDown = 0.0f;
        static public float chinBoneLengthInOut = 0.0f;
        static public float chinBoneShapePointedSquare = 0.0f;
        static public float chinHoleChinBum = 0.0f;
        static public float neckThicknessThinThick = 0.0f;
        static public int eyes = 0;
        static public int hair = 0;
        static public int hairColor = 0;
        static public int hairHightLight = 0;

        // OverLay
        static public int facialHair = -1;
        static public int eyebrows = 0;
        static public int makeup = 0;
        static public int lipstick = 0;
    }
}