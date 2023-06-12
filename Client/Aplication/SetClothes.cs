using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

// mp_m_freemode_01

namespace player.Client
{
    public class SetClothes : BaseScript
    {
        public SetClothes()
        {
        }

        static public void SetBody()
        {
        }

        static  public void SetGloves()
        {

            
        }

        static public void SetPants()
        {

        }

        static public void SetShoes()
        {
            SetPedComponentVariation(PlayerPedId(), 6, 16, 0, 0);
        }

    }
}