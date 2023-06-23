using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using System.Collections.Generic;
using System.Linq;
using static CitizenFX.Core.Native.API;

// mp_m_freemode_01

namespace player.Client
{
    public class ChangePedColorNui : BaseScript
    {
        public ChangePedColorNui()
        {
            RegisterNuiCallbackType("change_ped_color");
            EventHandlers["__cfx_nui:change_ped_color"] += new Action<IDictionary<string, object>, CallbackDelegate>(ChangeColorSkin);
        }

        private void ChangeColorSkin(IDictionary<string, object> data, CallbackDelegate cb)
        {
            object color;

            if (!data.TryGetValue("color", out color)) { return; }

            float currentColor = (float)Int32.Parse(color.ToString()) / 10.0f;
            SetPlayerClothes.SetPlayerBlackPerMan(Player.temporalPedForConfig, currentColor);

            ChangeHeadCaracteristics.GenerateRandomFaceCharacteristics();
            ChangeHeadCaracteristics.UpdatePlayerFace(Player.temporalPedForConfig);
            Random rnd = new Random();
            Player.eyes = rnd.Next(0, 15);
            Player.blackRange = currentColor;
            SetPedEyeColor(Player.temporalPedForConfig, Player.eyes);

            int randomHairIndex = rnd.Next(Hair.disponible.Count);
            KeyValuePair<string, int> randomHairObject = Hair.disponible.ElementAt(randomHairIndex);
            Player.hair = randomHairObject.Value;
            SetClothes.SetHair(Player.temporalPedForConfig, Player.hair, 0);

            Player.hairColor = rnd.Next(0, 64);
            Player.hairHightLight = rnd.Next(0, 64);

            SetPedHairColor(Player.temporalPedForConfig, Player.hairColor, Player.hairHightLight);

            cb(new { data = "ok" });
        }

    }
}