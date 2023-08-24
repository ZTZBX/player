using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using System.Collections.Generic;
using static CitizenFX.Core.Native.API;


namespace player.Client
{
    public class HospitalBlip : BaseScript
    {
        public HospitalBlip()
        {
            EventHandlers["onClientResourceStart"] += new Action<string>(OnClientResourceStart);
        }

        private void OnClientResourceStart(string resourceName)
        {
            HospitalBlipPrint();
        }

        private void HospitalBlipPrint()
        {
            int blip = AddBlipForCoord(48.52929f, -61.24273f, 4.939085f);
            SetBlipSprite(blip, 61);
            SetBlipDisplay(blip, 4);
            SetBlipScale(blip, 1.0f);
            SetBlipColour(blip, 1);
            SetBlipAsShortRange(blip, true);
            BeginTextCommandSetBlipName("STRING");
            AddTextComponentString("Spitalul de Urgenta");
            EndTextCommandSetBlipName(blip);
        }

    }
}