using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace player.Client
{
    public class LoadCharacterFace : PlayerCharacterConfig
    {
        public LoadCharacterFace()
        {
            EventHandlers["onClientResourceStart"] += new Action<string>(OnClientResourceStart);
            EventHandlers["setPlayerFace"] += new Action<string>(SetPlayerFace);
        }

        private void OnClientResourceStart(string resourceName)
        {
            LoadPlayerFace();
        }

        private void SetPlayerFace(
           string data
        )
        {
            Dictionary<string, string> r = JsonConvert.DeserializeObject<Dictionary<string, string>>(data);

            Player.blackRange = float.Parse(r["blackrange"]);
            Player.noseWidthThinWide = float.Parse(r["nosewidththinwide"]);
            Player.nosePeakUpDown = float.Parse(r["nosepeakupdown"]);
            Player.noseLengthLongShort = float.Parse(r["noselengthlongshort"]);
            Player.newoseBoneCurvenessCrookedCurved = float.Parse(r["newosebonecurvenesscrookedcurved"]);
            Player.noseTipUpDown = float.Parse(r["nosetipupdown"]);
            Player.noseBoneTwistLeftRight = float.Parse(r["nosebonetwistleftright"]);
            Player.eyebrowUpDown = float.Parse(r["eyebrowupdown"]);
            Player.eyebrowInOut = float.Parse(r["eyebrowinout"]);
            Player.cheekBonesUpDown = float.Parse(r["cheekbonesupdown"]);
            Player.cheekSidewaysBoneSizeInOut = float.Parse(r["cheeksidewaysboneaizeinout"]);
            Player.cheekBonesWidthPuffedGaunt = float.Parse(r["cheekboneswidthpuffedgaunt"]);
            Player.eyeOpeningBothWideSquinted = float.Parse(r["eyeopeningbothwidesquinted"]);
            Player.lipThicknessBothFatThin = float.Parse(r["lipthicknessbothfatthin"]);
            Player.jawBoneWidthNarrowWide = float.Parse(r["jawbonewidthnarrowWide"]);
            Player.jawBoneShapeRoundSquare = float.Parse(r["jawboneshaperoundsquare"]);
            Player.chinBoneUpDown = float.Parse(r["chinboneupdown"]);
            Player.chinBoneLengthInOut = float.Parse(r["chinbonelengthinout"]);
            Player.chinBoneShapePointedSquare = float.Parse(r["chinboneshapepointedsquare"]);
            Player.chinHoleChinBum = float.Parse(r["chinholechinbum"]);
            Player.neckThicknessThinThick = float.Parse(r["neckthicknessthinthick"]);
            Player.eyes = Int32.Parse(r["eyes"]);
            Player.hair = Int32.Parse(r["hair"]);
            Player.hairColor = Int32.Parse(r["haircolor"]);
            Player.hairHightLight = Int32.Parse(r["hairhightlight"]);
            Player.facialHair = Int32.Parse(r["facialhair"]);
            Player.eyebrows = Int32.Parse(r["eyebrows"]);
            Player.makeup = Int32.Parse(r["makeup"]);
            Player.lipstick = Int32.Parse(r["lipstick"]);
            Player.playerFaceLoaded = true;
        }

        async private void LoadPlayerFace()
        {
            while (true)
            {
                await Delay(100);
                try
                {
                    Exports["core-ztzbx"].playerToken();
                }
                catch
                {
                    continue;
                }

                if (Exports["core-ztzbx"].playerToken() != null && Player.playerFaceLoaded == false)
                {
                    TriggerServerEvent("getPlayerFace", Exports["core-ztzbx"].playerToken());
                    break;
                }
            }
        }


    }
}