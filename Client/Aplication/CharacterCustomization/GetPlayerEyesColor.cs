using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using System.Collections.Generic;
using Newtonsoft.Json;

using static CitizenFX.Core.Native.API;

namespace player.Client
{
    public class GetPlayerEyesColor : BaseScript
    {
        public GetPlayerEyesColor()
        {
            RegisterNuiCallbackType("get_player_eye_color");
            EventHandlers["__cfx_nui:get_player_eye_color"] += new Action<IDictionary<string, object>, CallbackDelegate>(GetPlayerEyesColorNui);
        }

        private void GetPlayerEyesColorNui(IDictionary<string, object> data, CallbackDelegate cb)
        {

            Dictionary<string, int> playerCharacterists = new Dictionary<string, int>();
            playerCharacterists.Add("color", Player.eyes);

            cb(new { data = JsonConvert.SerializeObject(playerCharacterists) });
        }


    }
}