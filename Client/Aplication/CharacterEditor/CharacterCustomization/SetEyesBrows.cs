using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using System.Collections.Generic;
using Newtonsoft.Json;

using static CitizenFX.Core.Native.API;

namespace player.Client
{
    public class SetEyesBrows : BaseScript
    {
        public SetEyesBrows()
        {
            RegisterNuiCallbackType("set_eyesbrows");
            EventHandlers["__cfx_nui:set_eyesbrows"] += new Action<IDictionary<string, object>, CallbackDelegate>(SetEyesBrowsNui);

            RegisterNuiCallbackType("get_eyebrows");
            EventHandlers["__cfx_nui:get_eyebrows"] += new Action<IDictionary<string, object>, CallbackDelegate>(GetEyesBrowsNui);
        }

        private void SetEyesBrowsNui(IDictionary<string, object> data, CallbackDelegate cb)
        {

            object value;
            if (!data.TryGetValue("value", out value)) { return; }
            int eyebrows = Int32.Parse(value.ToString());
            Player.eyebrows = eyebrows ;
            SetPedHeadOverlay(Player.temporalPedForConfig, 2, Player.eyebrows, 255);
            cb(new { data = "ok" });
        }


        private void GetEyesBrowsNui(IDictionary<string, object> data, CallbackDelegate cb)
        {
            Dictionary<string, int> playerCharacterists = new Dictionary<string, int>();
            playerCharacterists.Add("eyesbrow", Player.eyebrows);
            cb(new { data = JsonConvert.SerializeObject(playerCharacterists) });
        }


    }
}