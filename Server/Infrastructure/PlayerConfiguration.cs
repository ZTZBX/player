using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CitizenFX.Core;

namespace player.Server
{
    public class PlayerConfiguration : BaseScript
    {
        public PlayerConfiguration()
        {}

        public Dictionary<string, string> GetPlayerStats(string token)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            string usernameQuery = $"SELECT username from players where token='{token}'";
            dynamic username = Exports["fivem-mysql"].raw(usernameQuery);

            string query = $"select configured, hoursplayed, gender from playerstats where username='{username[0][0]}';";
            dynamic configResult = Exports["fivem-mysql"].raw(query);

            if (configResult.Count == 0)
            {
                result.Add("configured", null);
                result.Add("hoursplayed", null);
                result.Add("gender", null);
                return result;
            }

            result.Add("configured", configResult[0][0]);
            result.Add("hoursplayed", configResult[0][1]);
            result.Add("gender", configResult[0][2]);

            return result;
        }
    }
}