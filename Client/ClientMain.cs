using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace player.Client
{
    public class ClientMain : BaseScript
    {
        public ClientMain()
        {
            EventHandlers["onClientResourceStart"] += new Action<string>(OnClientResourceStart);
        }


        private void OnClientResourceStart(string resourceName)
        {
            DisableScroll();
        }

        async private void DisableScroll()
        {
            while (true)
            {
                await Delay(0);

                if (IsControlJustPressed(0, 37))
                {
                    HideHudComponentThisFrame(19);
                }
            }

        }

    }
}