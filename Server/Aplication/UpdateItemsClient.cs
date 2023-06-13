using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CitizenFX.Core;
using Newtonsoft.Json;

namespace player.Server
{
    public class UpdateItemsClient : BaseScript
    {
        PlayerItemsMetadaData meta = new PlayerItemsMetadaData();

        public UpdateItemsClient()
        {
            EventHandlers["updateItemsMeta"] += new Action<Player>(UpdateItemsMeta);
        }

        private void UpdateItemsMeta([FromSource] Player user)
        {
            TriggerClientEvent(user, "updateItemsMetaClient", JsonConvert.SerializeObject(ItemsMeta.itemsTypes));
        }


    }
}