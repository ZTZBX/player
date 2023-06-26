using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using System.Collections.Generic;
using static CitizenFX.Core.Native.API;
using System.Linq;


// mp_m_freemode_01

namespace player.Client
{
    public class PlayerConfig : BaseScript
    {

        static public void ConfigNui(bool createNewPreviewPed)
        {

            if (!Player.playerLoaded || Player.playerNuiOpened || !Player.playerStatsLoaded) { return; }

            Random rnd = new Random();
            // random skin color
            Player.blackRange = (float)rnd.Next(1, 11) / 10.0f;
            // random eyes
            Player.eyes = rnd.Next(0, 15);
            // random hair
            int randomHairIndex = rnd.Next(Hair.male.Count);
            KeyValuePair<string, int> randomHairObject = Hair.male.ElementAt(randomHairIndex);
            Player.hair = randomHairObject.Value;

            // random hair color
            Player.hairColor = rnd.Next(0, 64);
            Player.hairHightLight = rnd.Next(0, 64);

            // random eyesbrown 
            Player.eyebrows = rnd.Next(1, 8);

            // random Facial hair
            Player.facialHair = rnd.Next(-1, 7);

            if (createNewPreviewPed)
            {
                Vector3 pedCoords = GetEntityCoords(PlayerPedId(), false);
                int playerClone = ClonePed(
                PlayerPedId(),
                0.0f,
                false,
                false
                );
                SetEntityCoords(playerClone, pedCoords.X - 2.0f, pedCoords.Y, pedCoords.Z + 200.0f, false, false, false, false);

                FreezeEntityPosition(playerClone, true);
                SetEntityInvincible(playerClone, true);

                SetEntityHeading(playerClone, 150.0f);

                Vector3 pedClone = GetEntityCoords(playerClone, false);

                int cam_zoom = CreateCamWithParams("DEFAULT_SCRIPTED_CAMERA", pedClone.X - 0.3f, pedClone.Y - 1.0f, pedClone.Z + 0.5f, 0, 0, 0, GetGameplayCamFov(), true, 0);
                ClearFocus();
                SetCamActive(cam_zoom, true);
                RenderScriptCams(true, true, 1000, true, false);
                Player.temporalPedForConfig = playerClone;
                ChangeHeadCaracteristics.GenerateRandomFaceCharacteristics();
                ChangeHeadCaracteristics.UpdatePlayerFace(Player.temporalPedForConfig);
                SetPlayerClothes.SetPlayerBlackPerMan(Player.temporalPedForConfig, Player.blackRange);
                SetPedEyeColor(Player.temporalPedForConfig, Player.eyes);
                SetClothes.SetHair(Player.temporalPedForConfig, Player.hair, 0);
                SetPedHairColor(Player.temporalPedForConfig, Player.hairColor, Player.hairHightLight);
                SetPedHeadOverlayColor(Player.temporalPedForConfig, 2, 1, Player.hairColor, Player.hairColor);
                SetPedHeadOverlay(Player.temporalPedForConfig, 2, Player.eyebrows, 255);
                SetPedHeadOverlayColor(Player.temporalPedForConfig, 1, 1, Player.hairColor, Player.hairColor);
                SetPedHeadOverlay(Player.temporalPedForConfig, 1, Player.facialHair, 255);
            }

            string jsonString = "{\"showIn\": true }";


            SendNuiMessage(jsonString);
            DisplayRadar(false);
            SetNuiFocus(true, true);
            Player.playerNuiOpened = true;
        }

        public void ConfigPlayer()
        {
            SetEntityVisible(PlayerPedId(), false, false);
            ConfigNui(true);
        }

    }
}