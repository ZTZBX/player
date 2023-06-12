using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CitizenFX.Core;

namespace player.Server
{
    public class PlayerClothes : BaseScript
    {
        public PlayerClothes()
        {
            PlayerClothesMeta.clothesIds = ClothesIds();
            PlayerClothesMeta.itemsIdInGame = ItemsIdInGame();

        }

        public Dictionary<string, string> ClothesIds()
        {

            Dictionary<string, string> result = new Dictionary<string, string>();

            string query = "select id, name from itemscharternametoid";
            dynamic qr = Exports["fivem-mysql"].raw(query);

            foreach (dynamic cid in qr)
            {
                result.Add(cid[0], cid[1]);
            }

            return result;
        }

        public Dictionary<string, string> ItemsIdInGame()
        {

            Dictionary<string, string> result = new Dictionary<string, string>();

            string query = "select item, id from itemidingame";
            dynamic qr = Exports["fivem-mysql"].raw(query);

            foreach (dynamic cid in qr)
            {
                result.Add(cid[0], cid[1]);
            }

            return result;
        }

        public Dictionary<string, string> Get(string token)
        {

            bool statusOfC = false;
            string usernameQuery = $"SELECT username from players where token='{token}'";
            dynamic username = Exports["fivem-mysql"].raw(usernameQuery);

            Dictionary<string, string> result = new Dictionary<string, string>();

            string query = $"select idbodypart, name from itemsoncharters where username='{username[0][0]}'";

            dynamic qr = Exports["fivem-mysql"].raw(query);

            foreach (dynamic itemoncharacter in PlayerClothesMeta.clothesIds)
            {
                statusOfC = false;

                foreach (dynamic itemcur in qr)
                {
                    if (itemoncharacter.Key == itemcur[0])
                    {
                        result.Add(itemoncharacter.Key, PlayerClothesMeta.itemsIdInGame[itemcur[1]]);
                        statusOfC = true;
                        break;
                    }
                }

                if (!statusOfC)
                {
                    result.Add(itemoncharacter.Key, null);
                }
            }

            return result;

        }
    }
}