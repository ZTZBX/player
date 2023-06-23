using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using System.Collections.Generic;
using Newtonsoft.Json;

using static CitizenFX.Core.Native.API;

namespace player.Client
{
    public class GetPlayerSkinColor : BaseScript
    {
        public GetPlayerSkinColor()
        {
            RegisterNuiCallbackType("get_player_skin_color");
            EventHandlers["__cfx_nui:get_player_skin_color"] += new Action<IDictionary<string, object>, CallbackDelegate>(GetPlayerSkinColorNui);
        }

        private void GetPlayerSkinColorNui(IDictionary<string, object> data, CallbackDelegate cb)
        {

            Dictionary<string, float> playerCharacterists = new Dictionary<string, float>();
            playerCharacterists.Add("color", Player.blackRange);

            cb(new { data = JsonConvert.SerializeObject(playerCharacterists) });
        }


    }
}