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
            Exports.Add("updateShoes", new Action<string, int>(UpdateShoes));
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

        static public void UpdateShoes(string name, int ped)
        {
            if (Items.itemsTypes["clothing-shoes"].Contains(name))
            {
                Clothes.Shoes = Int32.Parse(Clothes.clothesNamesToIds[name]);
                SetClothes.SetShoes(ped, Clothes.Shoes, 0);

                // now update the real character
                SetClothes.SetShoes(PlayerPedId(), Clothes.Shoes, 0);

                // now lets add or replace the item on the character
                
            }

        }

    }
}