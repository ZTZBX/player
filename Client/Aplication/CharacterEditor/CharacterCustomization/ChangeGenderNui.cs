using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using System.Collections.Generic;
using Newtonsoft.Json;

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

            RegisterNuiCallbackType("get_player_gender");
            EventHandlers["__cfx_nui:get_player_gender"] += new Action<IDictionary<string, object>, CallbackDelegate>(GetPlayerGender);
        }


        private void GetPlayerGender(IDictionary<string, object> data, CallbackDelegate cb)
        {
            Dictionary<string, string> playerCharacterists = new Dictionary<string, string>();
            if (Player.gender == null)
            {
                Player.gender = "M";
            } 

            playerCharacterists.Add("gender", Player.gender);

            cb(new { data = JsonConvert.SerializeObject(playerCharacterists) });
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

                    // setting default female dress 
                    Clothes.Pants = 15;
                    Clothes.Torso = 15;
                    Clothes.Undershirt = 15;
                    Clothes.Shoes = 218;
                    Clothes.UpperBody = 15;
                    
                    SetPlayerClothes.SetPlayerBlackPerFem(temporalPed, Player.blackRange);
                }
                else
                {
                    model = Clothes.modelMale;
                    temporalPed = CreatePed(0, model, pedCoords.X, pedCoords.Y, pedCoords.Z, 150.0f, false, false);

                    // setting default male dress 
                    Clothes.Pants = 245;
                    Clothes.Torso = 15;
                    Clothes.Undershirt = 15;
                    Clothes.Shoes = 218;
                    Clothes.UpperBody = 15;

                    SetPlayerClothes.SetPlayerBlackPerMan(temporalPed, Player.blackRange);
                }

                SetPlayerClothes.ChangePlayerAparience(temporalPed, Clothes.Pants, Clothes.Torso, Clothes.Undershirt, Clothes.Shoes, Clothes.UpperBody);
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

                SetPedHairColor(Player.temporalPedForConfig, Player.hairColor, Player.hairHightLight);
                SetPedHeadOverlayColor(Player.temporalPedForConfig, 2, 1, Player.hairColor, Player.hairColor);
                SetPedHeadOverlay(Player.temporalPedForConfig, 2, Player.eyebrows, 255);

            }

            cb(new { data = "ok" });
        }

    }
}