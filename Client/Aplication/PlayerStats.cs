using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

// mp_m_freemode_01

namespace player.Client
{
    public class PlayerStats : PlayerCharacterConfig
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
            
            if (gender == null)
            {
                Player.gender = "M";
            }
            else
            {
                Player.gender = gender;
            }

            Player.playerStatsLoaded = true;
            Player.needToUpdatePlayerStatus = true;
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
                    }

                    break;
                }
            }
        }

        async private void LoadPlayerStats()
        {
            while (true)
            {
                await Delay(0);

                if (Player.playerhaslogged)
                {
                    TriggerServerEvent("getPlayerStatsInfo", Player.currentToken);
                    break;
                }

                
            }
        }


    }
}