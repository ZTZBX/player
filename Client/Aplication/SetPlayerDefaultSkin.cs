using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

// mp_m_freemode_01

namespace player.Client
{
    public class SetPlayerDefaultSkin : BaseScript
    {
        public SetPlayerDefaultSkin()
        {
            EventHandlers["onClientResourceStart"] += new Action<string>(OnClientResourceStart);
        }

        private void OnClientResourceStart(string resourceName)
        {
            SetPlayerDefaultSkin.LoadDefaultSkin();
            PlayerDie.setEvent["resetSkin"] = new Action(SetPlayerDefaultSkin.LoadDefaultSkin);
        }

        static async void LoadDefaultSkin()
        {

            uint model = (uint)GetHashKey("mp_m_freemode_01");
            RequestModel(model);

            while (HasModelLoaded(model) == false)
            {
                RequestModel(model);
                await Delay(0);
            }

            SetPlayerModel(PlayerId(), model);
            SetModelAsNoLongerNeeded(model);
            SetPedDefaultComponentVariation(PlayerPedId());
            
            SetClothes.SetBody();
            SetClothes.SetGloves();
            SetClothes.SetPants();
            SetClothes.SetShoes();
        }

    }
}