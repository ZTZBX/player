using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using System.Collections.Generic;
using Newtonsoft.Json;

using static CitizenFX.Core.Native.API;

namespace player.Client
{
    public class GetPlayerHeadCaracteristcs : BaseScript
    {
        public GetPlayerHeadCaracteristcs()
        {
            RegisterNuiCallbackType("get_player_head_info");
            EventHandlers["__cfx_nui:get_player_head_info"] += new Action<IDictionary<string, object>, CallbackDelegate>(GetPlayerHeadInfo);
        }

        private void GetPlayerHeadInfo(IDictionary<string, object> data, CallbackDelegate cb)
        {

            Dictionary<string, float> playerCharacterists = new Dictionary<string, float>();

            playerCharacterists.Add("noseWidthThinWide", Player.noseWidthThinWide);
            playerCharacterists.Add("nosePeakUpDown", Player.nosePeakUpDown);
            playerCharacterists.Add("noseLengthLongShort", Player.noseLengthLongShort);
            playerCharacterists.Add("newoseBoneCurvenessCrookedCurved", Player.newoseBoneCurvenessCrookedCurved);
            playerCharacterists.Add("noseTipUpDown", Player.noseTipUpDown);
            playerCharacterists.Add("noseBoneTwistLeftRight", Player.noseBoneTwistLeftRight);
            playerCharacterists.Add("eyebrowUpDown", Player.eyebrowUpDown);
            playerCharacterists.Add("eyebrowInOut", Player.eyebrowInOut);
            playerCharacterists.Add("cheekBonesUpDown", Player.cheekBonesUpDown);
            playerCharacterists.Add("cheekSidewaysBoneSizeInOut", Player.cheekSidewaysBoneSizeInOut);
            playerCharacterists.Add("cheekBonesWidthPuffedGaunt", Player.cheekBonesWidthPuffedGaunt);
            playerCharacterists.Add("eyeOpeningBothWideSquinted", Player.eyeOpeningBothWideSquinted);
            playerCharacterists.Add("lipThicknessBothFatThin", Player.lipThicknessBothFatThin);
            playerCharacterists.Add("jawBoneWidthNarrowWide", Player.jawBoneWidthNarrowWide);
            playerCharacterists.Add("jawBoneShapeRoundSquare", Player.jawBoneShapeRoundSquare);
            playerCharacterists.Add("chinBoneUpDown", Player.chinBoneUpDown);
            playerCharacterists.Add("chinBoneLengthInOut", Player.chinBoneLengthInOut);
            playerCharacterists.Add("chinBoneShapePointedSquare", Player.chinBoneShapePointedSquare);
            playerCharacterists.Add("chinHoleChinBum", Player.chinHoleChinBum);
            playerCharacterists.Add("neckThicknessThinThick", Player.neckThicknessThinThick);

            cb(new { data = JsonConvert.SerializeObject(playerCharacterists) });
        }


    }
}