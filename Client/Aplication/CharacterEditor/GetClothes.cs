using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;
using System.Linq;


namespace player.Client
{
    public class GetClothes : BaseScript
    {
        public GetClothes()
        {
            Exports.Add("getShoes", new Func<string>(GetShoes));
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

        static public string GetShoes()
        {

            string name = Clothes.clothesNamesToIds.FirstOrDefault(x => x.Value == Clothes.Shoes.ToString()).Key;
            if (name != null)
                return name;

            return "no-shoes";

        }

    }
}