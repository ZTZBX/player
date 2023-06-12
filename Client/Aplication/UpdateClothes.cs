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
            Exports.Add("updateShoes", new Action<string>(UpdateShoes)); 
            EventHandlers["addItemToInventory"] += new Action<string>(AddItemToInventory);
            EventHandlers["removeItemToInventory"] += new Action<string>(RemoveItemToInventory);
        }
        private void AddItemToInventory(string item)
        {
            Exports["inventory"].addItemInventory(item, 1);
        }

        private void RemoveItemToInventory(string item)
        {
            Exports["inventory"].addItemInventory(item, -1);
        }

        static public void UpdateBody()
        {
        }

        static  public void UpdateGloves()
        {

            
        }

        static public void UpdatePants()
        {

        }

        static public void UpdateShoes(string name)
        {
            Clothes.Shoes = Int32.Parse(Clothes.clothesNamesToIds[name]);
            SetClothes.SetShoes(Clothes.Shoes, 0);

        }

    }
}