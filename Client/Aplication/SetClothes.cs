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

        static public void SetBody(int id_undershorit, int id_torso)
        {
            if (id_torso == 15 && id_undershorit == 15)
            {
                SetPedComponentVariation(PlayerPedId(), 3, 16, 0, 0);
            }
            
            SetPedComponentVariation(PlayerPedId(), 11, id_torso, 0, 0);
            SetPedComponentVariation(PlayerPedId(), 8, id_undershorit, 0, 0);
            }

        static  public void SetGloves()
        {
            
        }

        static public void SetPants(int id, int variation)
        {
            SetPedComponentVariation(PlayerPedId(), 4, id, variation, 0);
        }

        static public void SetShoes(int id, int variation)
        {
            SetPedComponentVariation(PlayerPedId(), 6, id, variation, 0);
        }

    }
}