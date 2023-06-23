using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

// mp_m_freemode_01

namespace player.Client
{
    public class PlayerConfig : BaseScript
    {

        static public void ConfigNui(bool createNewPreviewPed)
        {

            if (!Player.playerLoaded || Player.playerNuiOpened || !Player.playerStatsLoaded) { return; }

            Random rnd = new Random();
            Player.blackRange = (float)rnd.Next(1, 11) / 10.0f;
            Player.eyes = rnd.Next(0, 15);

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
            }

            string jsonString = "{\"showIn\": true }";


            SendNuiMessage(jsonString);
            DisplayRadar(false);
            SetNuiFocus(true, true);

            Player.playerNuiOpened = true;
        }

        async public void ConfigPlayer()
        {
            int entity = PlayerPedId();
            SetEntityVisible(entity, false, false);
            ConfigNui(true);

            while (true)
            {
                await Delay(0);
                SetEntityLocallyVisible(entity);
            }

        }

    }
}