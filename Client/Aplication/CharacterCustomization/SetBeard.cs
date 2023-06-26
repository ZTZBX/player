using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using System.Collections.Generic;
using Newtonsoft.Json;

using static CitizenFX.Core.Native.API;

namespace player.Client
{
    public class SetBeard : BaseScript
    {
        public SetBeard()
        {
            RegisterNuiCallbackType("set_beard");
            EventHandlers["__cfx_nui:set_beard"] += new Action<IDictionary<string, object>, CallbackDelegate>(SetBeardNui);

            RegisterNuiCallbackType("get_beard");
            EventHandlers["__cfx_nui:get_beard"] += new Action<IDictionary<string, object>, CallbackDelegate>(GetBeardNui);

        }

        private void SetBeardNui(IDictionary<string, object> data, CallbackDelegate cb)
        {

            object value;
            if (!data.TryGetValue("value", out value)) { return; }
            int facialHair = Int32.Parse(value.ToString());
            Player.facialHair = facialHair;
            SetPedHeadOverlayColor(Player.temporalPedForConfig, 1, 1, Player.hairColor, Player.hairColor);
            SetPedHeadOverlay(Player.temporalPedForConfig, 1, Player.facialHair, 255);
            cb(new { data = "ok" });
        }

        private void GetBeardNui(IDictionary<string, object> data, CallbackDelegate cb)
        {
            Dictionary<string, int> playerCharacterists = new Dictionary<string, int>();
            playerCharacterists.Add("beard", Player.facialHair);
            cb(new { data = JsonConvert.SerializeObject(playerCharacterists) });
        }
    }
}