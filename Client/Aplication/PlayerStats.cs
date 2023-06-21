using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

// mp_m_freemode_01

namespace player.Client
{
    public class PlayerStats : PlayerConfig
    {
        public PlayerStats()
        {
            EventHandlers["onClientResourceStart"] += new Action<string>(OnClientResourceStart);
            EventHandlers["setPlayerStats"] += new Action<bool, int, string>(SetPlayerStats);
        }

        private void OnClientResourceStart(string resourceName)
        {
            CheckIfPlayerIsConfigured();
        }

        private void SetPlayerStats(bool configured, int hours, string gender)
        {
            Player.configured = configured;
            Player.hoursplayed = hours;
            Player.gender = gender;

            if (!Player.configured) 
            {
                ConfigPlayer();
            }
        }

        async private void CheckIfPlayerIsConfigured()
        {
            while (true)
            {
                await Delay(100);
                if (Exports["core-ztzbx"].playerToken() != null)
                {
                    TriggerServerEvent("getPlayerStatsInfo", Exports["core-ztzbx"].playerToken());
                    break;
                }
            }
        }


    }
}