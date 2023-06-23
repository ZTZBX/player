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
            LoadPlayerStats();
            OpenPlayerConfigMenu();
        }

        private void SetPlayerStats(bool configured, int hours, string gender)
        {
            Player.configured = configured;
            Player.hoursplayed = hours;
            Player.gender = gender;
            Player.playerStatsLoaded = true;
        }


        async private void OpenPlayerConfigMenu()
        {
            while (true)
            {
                await Delay(500);
                if (Player.playerStatsLoaded && Player.playerLoaded)
                {
                    if (!Player.configured)
                    {
                        ConfigPlayer();
                        //SetEntityVisible(PlayerPedId(), true, false);
                    }

                    break;
                }
            }
        }

        async private void LoadPlayerStats()
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