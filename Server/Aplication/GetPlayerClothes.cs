using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CitizenFX.Core;
using Newtonsoft.Json;

namespace player.Server
{
    public class GetPlayerClothes : BaseScript
    {
        PlayerClothes pC = new PlayerClothes();

        public GetPlayerClothes()
        {
            EventHandlers["playerClothesOnBody"] += new Action<Player, string>(PlayerClothesOnBody);
        }

        private void PlayerClothesOnBody([FromSource] Player user, string token)
        {
            TriggerClientEvent(user, "updateDomainClothes", JsonConvert.SerializeObject(pC.Get(token)));
        }


    }
}