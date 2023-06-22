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

        static public void SetBody(int ped, int id_undershorit, int id_torso, int upperBody)
        {
           
            SetPedComponentVariation(ped, 3, upperBody, 0, 0);
            SetPedComponentVariation(ped, 11, id_torso, 0, 0);
            SetPedComponentVariation(ped, 8, id_undershorit, 0, 0);
        }

        static public void SetGloves()
        {

        }

        static public void SetPants(int ped, int id, int variation)
        {
            SetPedComponentVariation(ped, 4, id, variation, 0);
        }

        static public void SetShoes(int ped, int id, int variation)
        {
            SetPedComponentVariation(ped, 6, id, variation, 0);
        }

    }
}