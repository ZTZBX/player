using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using static CitizenFX.Core.Native.API;


namespace player.Client
{
    public class SetCharacterHair : BaseScript
    {
        public SetCharacterHair()
        {
            RegisterNuiCallbackType("set_character_hair");
            EventHandlers["__cfx_nui:set_character_hair"] += new Action<IDictionary<string, object>, CallbackDelegate>(SetCharacterHairNui);

            RegisterNuiCallbackType("get_hair");
            EventHandlers["__cfx_nui:get_hair"] += new Action<IDictionary<string, object>, CallbackDelegate>(GetHair);

            // in this section will add the dispobile hears
            Hair.disponible.Add("Bold.png", 0);
            Hair.disponible.Add("Dreds.png", 16);
            Hair.disponible.Add("Curly.png", 17);
            Hair.disponible.Add("MaxPayne.png", 18);
            Hair.disponible.Add("Afro.png", 19);
            Hair.disponible.Add("BunHair.png", 20);
            Hair.disponible.Add("Scruffy.png", 21);

        }

        private void GetHair(IDictionary<string, object> data, CallbackDelegate cb)
        {
            Dictionary<string, string> playerCharacterists = new Dictionary<string, string>();
            playerCharacterists.Add("hair", Hair.disponible.FirstOrDefault(x => x.Value == Player.hair).Key);
            cb(new { data = JsonConvert.SerializeObject(playerCharacterists) });
        }

        private void SetCharacterHairNui(IDictionary<string, object> data, CallbackDelegate cb)
        {
            object value;

            if (!data.TryGetValue("value", out value)) { return; }
            string hair = value.ToString();
            SetClothes.SetHair(Player.temporalPedForConfig, Hair.disponible[hair], 0);
            cb(new { data = "ok" });
        }

    }
}