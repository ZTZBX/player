using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CitizenFX.Core;

namespace player.Server
{
    public class PlayerItemsMetadaData : BaseScript
    {
        public PlayerItemsMetadaData()
        {
            ItemsMeta.itemsTypes = ItemsTypes();
        }

        public Dictionary<string, List<string>> ItemsTypes()
        {
            Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();

            string query = "select type, name from itemsmetadata";
            dynamic qr = Exports["fivem-mysql"].raw(query);

            foreach (dynamic cid in qr)
            {
                List<string> tempList = new List<string>();

                if (!result.ContainsKey(cid[0]))
                {
                    result.Add(cid[0], tempList);
                }

                result[cid[0]].Add(cid[1]);
            }

            return result;
        }

    }
}