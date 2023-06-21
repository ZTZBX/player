using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;
using System.Collections.Generic;
using Newtonsoft.Json;

// mp_m_freemode_01

namespace player.Client
{
    public class SetPlayerClothes : BaseScript
    {
        public SetPlayerClothes()
        {
            EventHandlers["onClientResourceStart"] += new Action<string>(OnClientResourceStart);
            EventHandlers["updateDomainClothes"] += new Action<string>(UpdateDomainClothes);
            EventHandlers["updateClothesNamesToId"] += new Action<string>(UpdateClothesNamesToId);
            EventHandlers["updateItemsMetaClient"] += new Action<string>(UpdateItemsMetaClient);
        }

        private void OnClientResourceStart(string resourceName)
        {
            LoadDefaultSkin();
            GetItemsClothes();
            PlayerDie.setEvent["resetSkin"] = new Action(LoadDefaultSkin);
        }

        private void UpdateItemsMetaClient(string items)
        {
            if (items != null && items.Length > 0)
            {
                Items.itemsTypes = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(items);
            }
        }

        private void UpdateClothesNamesToId(string items)
        {
            if (items != null && items.Length > 0)
            {
                Clothes.clothesNamesToIds = JsonConvert.DeserializeObject<Dictionary<string, string>>(items);
            }
        }

        private void UpdateDomainClothes(string items)
        {
            if (items != null && items.Length > 0)
            {

                Dictionary<string, string> r = JsonConvert.DeserializeObject<Dictionary<string, string>>(items);


                if (r["6"] != null)
                {
                    Clothes.Shoes = Int32.Parse(r["6"]);
                }

                Clothes.itemsLoaded = true;
            }
        }

        async private void GetItemsClothes()
        {
            while (true)
            {
                await Delay(100);
                if (Exports["core-ztzbx"].playerToken() != null)
                {
                    TriggerServerEvent("playerClothesOnBody", Exports["core-ztzbx"].playerToken());
                    TriggerServerEvent("updateClothesNamesToIdInClient", Exports["core-ztzbx"].playerToken());
                    TriggerServerEvent("updateItemsMeta");
                    break;
                }
            }
        }

        async public void LoadDefaultSkin()
        {
            while (true)
            {
                await Delay(0);
                if (Clothes.itemsLoaded)
                {
                    break;
                }
            }

            uint model = (uint)GetHashKey("mp_m_freemode_01");
            RequestModel(model);

            while (HasModelLoaded(model) == false)
            {
                RequestModel(model);
                await Delay(0);
            }

            SetPlayerModel(PlayerId(), model);

            SetClothes.SetBody(Clothes.Undershirt, Clothes.Torso);
            SetClothes.SetGloves();
            SetClothes.SetPants(Clothes.Pants, 0);
            SetClothes.SetShoes(Clothes.Shoes, 0);

            Player.playerLoaded = true;

        }

    }
}