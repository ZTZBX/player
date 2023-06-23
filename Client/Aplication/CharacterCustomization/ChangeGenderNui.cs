using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using System.Collections.Generic;

using static CitizenFX.Core.Native.API;

// mp_m_freemode_01

namespace player.Client
{
    public class ChangeGender : BaseScript
    {
        public ChangeGender()
        {
            RegisterNuiCallbackType("change_character_gender");
            EventHandlers["__cfx_nui:change_character_gender"] += new Action<IDictionary<string, object>, CallbackDelegate>(ChangeCharacterGender);
        }

        private void ChangeCharacterGender(IDictionary<string, object> data, CallbackDelegate cb)
        {
            object gender;

            if (!data.TryGetValue("gender", out gender)) { return; }

            string currentGender = gender.ToString();

            if ((currentGender == "F" || currentGender == "M") && (Player.gender != currentGender))
            {
                uint model;
                int temporalPed;
                Vector3 pedCoords = GetEntityCoords(Player.temporalPedForConfig, false);

                Player.gender = currentGender;

                if (currentGender == "F")
                {
                    model = Clothes.modelFemale;
                    temporalPed = CreatePed(0, model, pedCoords.X, pedCoords.Y, pedCoords.Z, 150.0f, false, false);
                    SetPlayerClothes.ChangePlayerAparience(temporalPed, 16, 16, 7, 220, 16);
                }
                else
                {
                    model = Clothes.modelMale;
                    temporalPed = CreatePed(0, model, pedCoords.X, pedCoords.Y, pedCoords.Z, 150.0f, false, false);
                    SetPlayerClothes.ChangePlayerAparience(temporalPed, 245, 15, 15, 218, 15);
                    SetPlayerClothes.SetPlayerBlackPerMan(temporalPed, Player.blackRange);
                }

                ChangeHeadCaracteristics.GenerateRandomFaceCharacteristics();
                ChangeHeadCaracteristics.UpdatePlayerFace(temporalPed);
                SetPedEyeColor(temporalPed, Player.eyes);
                SetClothes.SetHair(temporalPed, Player.hair, 0);
                

            
                Vector3 pedClone = GetEntityCoords(temporalPed, false);

                int cam_zoom = CreateCamWithParams("DEFAULT_SCRIPTED_CAMERA", pedClone.X - 0.3f, pedClone.Y - 1.0f, pedClone.Z + 0.5f, 0, 0, 0, GetGameplayCamFov(), true, 0);
                ClearFocus();
                SetCamActive(cam_zoom, true);
                RenderScriptCams(true, true, 1000, true, false);

                
                DeletePed(ref Player.temporalPedForConfig);

                FreezeEntityPosition(temporalPed, true);
                SetEntityInvincible(temporalPed, true);
                SetEntityHeading(temporalPed, 150.0f);
                Player.temporalPedForConfig = temporalPed; 


            }

            cb(new { data = "ok" });
        }

    }
}