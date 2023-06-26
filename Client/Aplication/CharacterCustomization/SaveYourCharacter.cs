using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using System.Collections.Generic;
using Newtonsoft.Json;

using static CitizenFX.Core.Native.API;

namespace player.Client
{
    public class SaveYourCharacter : BaseScript
    {
        public SaveYourCharacter()
        {
            RegisterNuiCallbackType("save_your_character");
            EventHandlers["__cfx_nui:save_your_character"] += new Action<IDictionary<string, object>, CallbackDelegate>(SaveYourCharacterNui);

        }

        private void SaveYourCharacterNui(IDictionary<string, object> data, CallbackDelegate cb)
        {
            Dictionary<string, string> playerCharacterists = new Dictionary<string, string>();

            playerCharacterists.Add("gender", Player.gender.ToString());
            playerCharacterists.Add("blackRange", Player.blackRange.ToString());
            playerCharacterists.Add("noseWidthThinWide", Player.noseWidthThinWide.ToString());
            playerCharacterists.Add("nosePeakUpDown", Player.nosePeakUpDown.ToString());
            playerCharacterists.Add("noseLengthLongShort", Player.noseLengthLongShort.ToString());
            playerCharacterists.Add("newoseBoneCurvenessCrookedCurved", Player.newoseBoneCurvenessCrookedCurved.ToString());
            playerCharacterists.Add("noseTipUpDown", Player.noseTipUpDown.ToString());
            playerCharacterists.Add("noseBoneTwistLeftRight", Player.noseBoneTwistLeftRight.ToString());
            playerCharacterists.Add("eyebrowUpDown", Player.eyebrowUpDown.ToString());
            playerCharacterists.Add("eyebrowInOut", Player.eyebrowInOut.ToString());
            playerCharacterists.Add("cheekBonesUpDown", Player.cheekBonesUpDown.ToString());
            playerCharacterists.Add("cheekSidewaysBoneSizeInOut", Player.cheekSidewaysBoneSizeInOut.ToString());
            playerCharacterists.Add("cheekBonesWidthPuffedGaunt", Player.cheekBonesWidthPuffedGaunt.ToString());
            playerCharacterists.Add("eyeOpeningBothWideSquinted", Player.eyeOpeningBothWideSquinted.ToString());
            playerCharacterists.Add("lipThicknessBothFatThin", Player.lipThicknessBothFatThin.ToString());
            playerCharacterists.Add("jawBoneWidthNarrowWide", Player.jawBoneWidthNarrowWide.ToString());
            playerCharacterists.Add("jawBoneShapeRoundSquare", Player.jawBoneShapeRoundSquare.ToString());
            playerCharacterists.Add("chinBoneUpDown", Player.chinBoneUpDown.ToString());
            playerCharacterists.Add("chinBoneLengthInOut", Player.chinBoneLengthInOut.ToString());
            playerCharacterists.Add("chinBoneShapePointedSquare", Player.chinBoneShapePointedSquare.ToString());
            playerCharacterists.Add("chinHoleChinBum", Player.chinHoleChinBum.ToString());
            playerCharacterists.Add("neckThicknessThinThick", Player.neckThicknessThinThick.ToString());
            playerCharacterists.Add("eyes", Player.eyes.ToString());
            playerCharacterists.Add("hair", Player.hair.ToString());
            playerCharacterists.Add("hairColor", Player.hairColor.ToString());
            playerCharacterists.Add("hairHightLight", Player.hairHightLight.ToString());
            playerCharacterists.Add("facialHair", Player.facialHair.ToString());
            playerCharacterists.Add("eyebrows", Player.eyebrows.ToString());
            playerCharacterists.Add("makeup", Player.makeup.ToString());
            playerCharacterists.Add("lipstick", Player.lipstick.ToString());

            TriggerServerEvent("saveCharacter", Exports["core-ztzbx"].playerToken(), JsonConvert.SerializeObject(playerCharacterists));

            cb(new { data = "ok" });
        }

    }
}