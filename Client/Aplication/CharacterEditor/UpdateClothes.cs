using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

// mp_m_freemode_01

namespace player.Client
{
    public class UpdateClothes : BaseScript
    {
        public UpdateClothes()
        {
            Exports.Add("updateShoes", new Action<string, int, string>(UpdateShoes));
        }

        static public void UpdateBody()
        {
        }

        static public void UpdateGloves()
        {


        }

        static public void UpdatePants()
        {

        }

        static public void UpdateShoes(string name, int ped, string token)
        {
            if (Items.itemsTypes["clothing-shoes"].Contains(name))
            {
                Clothes.Shoes = Int32.Parse(Clothes.clothesNamesToIds[name]);
            } else 
            {
                Clothes.Shoes = 218;
            }

            SetClothes.SetShoes(ped, Clothes.Shoes, 0);
            SetClothes.SetShoes(PlayerPedId(), Clothes.Shoes, 0);

            TriggerServerEvent("setPlayerShoes", token, name);

        }

    }
}