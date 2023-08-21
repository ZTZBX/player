using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CitizenFX.Core;
using Newtonsoft.Json;

namespace player.Server
{
    public class SetPlayerClothes : BaseScript
    {
        PlayerClothes pC = new PlayerClothes();

        public SetPlayerClothes()
        {
            EventHandlers["setPlayerShoes"] += new Action<Player, string, string>(SetPlayerShoes);
        }

        private void SetPlayerShoes([FromSource] Player user, string token, string itemName)
        {
            if (itemName != "no-shoes")
            {
                pC.SetPlayerClothes(user, token, "6", itemName);
                return;
            }
            

            pC.SetPlayerClothes(user, token, "6", null);
        }


    }
}