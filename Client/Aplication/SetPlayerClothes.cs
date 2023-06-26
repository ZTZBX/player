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
            LoadModels();
            LoadDefaultSkin();
            GetItemsClothes();
            PlayerDie.setEvent["resetSkin"] = new Action(LoadDefaultSkin);
        }

        async private void LoadModels()
        {

            Clothes.modelFemale = (uint)GetHashKey("mp_f_freemode_01");
            RequestModel(Clothes.modelFemale);

            while (HasModelLoaded(Clothes.modelFemale) == false)
            {
                RequestModel(Clothes.modelFemale);
                await Delay(0);
            }

            Clothes.modelMale = (uint)GetHashKey("mp_m_freemode_01");
            RequestModel(Clothes.modelMale);

            while (HasModelLoaded(Clothes.modelMale) == false)
            {
                RequestModel(Clothes.modelMale);
                await Delay(0);
            }

            Clothes.modelsHasLoaded = true;
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

        public static void ChangePlayerGender(int player, string gender)
        {
            if (gender == "M" || gender == null)
            {
                SetPlayerModel(player, Clothes.modelMale);
            }

            if (gender == "F")
            {
                SetPlayerModel(player, Clothes.modelFemale);
            }

        }

        public static void ChangePlayerAparience(int ped, int pants, int torso, int undershirt, int shoes, int upperBody)
        {
            SetPedDefaultComponentVariation(ped);

            SetClothes.SetBody(ped, undershirt, torso, upperBody);
            SetClothes.SetGloves();
            SetClothes.SetPants(ped, pants, 0);
            SetClothes.SetShoes(ped, shoes, 0);
        }

        public static void SetPlayerBlackPerMan(int ped, float pers)
        {
            SetPedHeadBlendData(
            ped,
            44,
            44,
            2,
            44,
            44,
            2,
            pers,
            0.5f,
            pers,
            true);
        }

        public static void SetPlayerBlackPerFem(int ped, float pers)
        {
            SetPedHeadBlendData(
            ped,
            45,
            45,
            23,
            45,
            45,
            23,
            pers,
            0.5f,
            pers,
            true);
        }



        async public void LoadDefaultSkin()
        {
            while (true)
            {
                await Delay(0);
                if (Clothes.itemsLoaded && Player.playerStatsLoaded && Player.playerFaceLoaded)
                {
                    break;
                }
            }

            CharacterAparience.updatePlayerAparience();

            Player.playerLoaded = true;
        }

    }
}