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

            Debug.WriteLine(currentGender);

            if (currentGender == "F" || currentGender == "M")
            {
                uint model;
                int temporalPed;
                Vector3 pedCoords = GetEntityCoords(Player.temporalPedForConfig, false);

                if (currentGender == "F")
                {
                    model = Clothes.modelFemale;
                    temporalPed = CreatePed(0, model, pedCoords.X, pedCoords.Y, pedCoords.Z - (pedCoords.Z * 0.003865f), 150.0f, false, false);
                    SetPlayerClothes.ChangePlayerAparience(temporalPed, 16, 16, 7, 220, 16);
                
                }
                else
                {
                    model = Clothes.modelMale;
                    temporalPed = CreatePed(0, model, pedCoords.X, pedCoords.Y, pedCoords.Z - (pedCoords.Z * 0.003865f), 150.0f, false, false);
                    SetPlayerClothes.ChangePlayerAparience(temporalPed, 245, 15, 15, 218, 15);
                    
                }

                
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