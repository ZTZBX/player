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
            playerCharacterists.Add("blackrange", Player.blackRange.ToString());
            playerCharacterists.Add("nosewidththinwide", Player.noseWidthThinWide.ToString());
            playerCharacterists.Add("nosepeakupdown", Player.nosePeakUpDown.ToString());
            playerCharacterists.Add("noselengthlongshort", Player.noseLengthLongShort.ToString());
            playerCharacterists.Add("newosebonecurvenesscrookedcurved", Player.newoseBoneCurvenessCrookedCurved.ToString());
            playerCharacterists.Add("nosetipupdown", Player.noseTipUpDown.ToString());
            playerCharacterists.Add("nosebonetwistleftright", Player.noseBoneTwistLeftRight.ToString());
            playerCharacterists.Add("eyebrowupdown", Player.eyebrowUpDown.ToString());
            playerCharacterists.Add("eyebrowinout", Player.eyebrowInOut.ToString());
            playerCharacterists.Add("cheekbonesupdown", Player.cheekBonesUpDown.ToString());
            playerCharacterists.Add("cheeksidewaysboneaizeinout", Player.cheekSidewaysBoneSizeInOut.ToString());
            playerCharacterists.Add("cheekboneswidthpuffedgaunt", Player.cheekBonesWidthPuffedGaunt.ToString());
            playerCharacterists.Add("eyeopeningbothwidesquinted", Player.eyeOpeningBothWideSquinted.ToString());
            playerCharacterists.Add("lipthicknessbothfatthin", Player.lipThicknessBothFatThin.ToString());
            playerCharacterists.Add("jawbonewidthnarrowWide", Player.jawBoneWidthNarrowWide.ToString());
            playerCharacterists.Add("jawboneshaperoundsquare", Player.jawBoneShapeRoundSquare.ToString());
            playerCharacterists.Add("chinboneupdown", Player.chinBoneUpDown.ToString());
            playerCharacterists.Add("chinbonelengthinout", Player.chinBoneLengthInOut.ToString());
            playerCharacterists.Add("chinboneshapepointedsquare", Player.chinBoneShapePointedSquare.ToString());
            playerCharacterists.Add("chinholechinbum", Player.chinHoleChinBum.ToString());
            playerCharacterists.Add("neckthicknessthinthick", Player.neckThicknessThinThick.ToString());
            playerCharacterists.Add("eyes", Player.eyes.ToString());
            playerCharacterists.Add("hair", Player.hair.ToString());
            playerCharacterists.Add("haircolor", Player.hairColor.ToString());
            playerCharacterists.Add("hairhightlight", Player.hairHightLight.ToString());
            playerCharacterists.Add("facialhair", Player.facialHair.ToString());
            playerCharacterists.Add("eyebrows", Player.eyebrows.ToString());
            playerCharacterists.Add("makeup", Player.makeup.ToString());
            playerCharacterists.Add("lipstick", Player.lipstick.ToString());

            TriggerServerEvent("saveCharacter", Player.currentToken, JsonConvert.SerializeObject(playerCharacterists));

            string jsonString = "{\"showIn\": false }";
            SendNuiMessage(jsonString);
            DisplayRadar(true);
            ClearFocus();
            RenderScriptCams(false, false, 0, true, false);
            SetNuiFocus(false, false);
            Player.playerNuiOpened = true;
            DeletePed(ref Player.temporalPedForConfig);
            SetEntityVisible(PlayerPedId(), true, true);
            CharacterAparience.updatePlayerAparience();
            cb(new { data = "ok" });
        }

    }
}