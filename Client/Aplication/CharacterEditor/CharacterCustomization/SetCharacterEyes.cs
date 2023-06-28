using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using System.Collections.Generic;

using static CitizenFX.Core.Native.API;


namespace player.Client
{
    public class SetCharacterEyes : BaseScript
    {
        public SetCharacterEyes()
        {
            RegisterNuiCallbackType("set_character_eye");
            EventHandlers["__cfx_nui:set_character_eye"] += new Action<IDictionary<string, object>, CallbackDelegate>(SetCharacterEye);
        }

        private void SetCharacterEye(IDictionary<string, object> data, CallbackDelegate cb)
        {
            object value;

            if (!data.TryGetValue("value", out value)) { return; }
            int eyesColor = Int32.Parse(value.ToString());
            SetPedEyeColor(Player.temporalPedForConfig, eyesColor);
            Player.eyes = eyesColor;

            cb(new { data = "ok" });
        }

    }
}