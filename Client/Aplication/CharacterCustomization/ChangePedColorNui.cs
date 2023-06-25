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


            Random rnd = new Random();

            float currentColor = (float)Int32.Parse(color.ToString()) / 10.0f;
            if (Player.gender == "M" || Player.gender == null)
            {
                SetPlayerClothes.SetPlayerBlackPerMan(Player.temporalPedForConfig, currentColor);

                int randomHairIndex = rnd.Next(Hair.male.Count);
                KeyValuePair<string, int> randomHairObject = Hair.male.ElementAt(randomHairIndex);
                Player.hair = randomHairObject.Value;
                SetClothes.SetHair(Player.temporalPedForConfig, Player.hair, 0);

            }
            else
            {
                SetPlayerClothes.SetPlayerBlackPerFem(Player.temporalPedForConfig, currentColor);

                int randomHairIndex = rnd.Next(Hair.female.Count);
                KeyValuePair<string, int> randomHairObject = Hair.female.ElementAt(randomHairIndex);
                Player.hair = randomHairObject.Value;
                SetClothes.SetHair(Player.temporalPedForConfig, Player.hair, 0);
            }


            ChangeHeadCaracteristics.GenerateRandomFaceCharacteristics();
            ChangeHeadCaracteristics.UpdatePlayerFace(Player.temporalPedForConfig);

            Player.eyes = rnd.Next(0, 15);
            Player.blackRange = currentColor;
            SetPedEyeColor(Player.temporalPedForConfig, Player.eyes);



            Player.hairColor = rnd.Next(0, 64);
            Player.hairHightLight = rnd.Next(0, 64);
            Player.eyebrows = rnd.Next(1, 8);

            SetPedHairColor(Player.temporalPedForConfig, Player.hairColor, Player.hairHightLight);
            SetPedHeadOverlayColor(Player.temporalPedForConfig, 2, 1, Player.hairColor, Player.hairColor);
            SetPedHeadOverlay(Player.temporalPedForConfig, 2, Player.eyebrows, 255);

            cb(new { data = "ok" });
        }

    }
}