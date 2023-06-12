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
            EventHandlers["updateClothesNamesToIdInClient"] += new Action<Player>(UpdateClothesNamesToIdInClient);

        }


        private void UpdateClothesNamesToIdInClient([FromSource] Player user)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            
            foreach (dynamic item in PlayerClothesMeta.itemsIdInGame)
            {
                result.Add(item.Key, PlayerClothesMeta.itemsIdInGame[item.Key]);
            }

            TriggerClientEvent(user, "updateClothesNamesToId", JsonConvert.SerializeObject(result));
        }



        private void PlayerClothesOnBody([FromSource] Player user, string token)
        {
            TriggerClientEvent(user, "updateDomainClothes", JsonConvert.SerializeObject(pC.Get(token)));
        }

    }
}