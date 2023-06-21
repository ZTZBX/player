using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CitizenFX.Core;
using Newtonsoft.Json;

namespace player.Server
{
    public class PlayerStats : BaseScript
    {
        PlayerConfiguration playerConf = new PlayerConfiguration();

        public PlayerStats()
        {
            EventHandlers["getPlayerStatsInfo"] += new Action<Player, string>(GetPlayerStatsInfo);
        }

        private void GetPlayerStatsInfo([FromSource] Player user, string token)
        {
            Dictionary<string, string> conf = playerConf.GetPlayerStats(token);

            bool configured;
            int hoursplayed;

            if (conf["configured"] == null || conf["configured"] == "0")
            {
                configured = false;
            }
            else
            {
                configured = true;
            }

            if (conf["hoursplayed"] == null)
            {
                hoursplayed = -1;
            }
            else
            {
                hoursplayed = Int32.Parse(conf["hoursplayed"]);
            }

            TriggerClientEvent(user, "setPlayerStats", configured, hoursplayed, conf["gender"]);
        }
    }
}