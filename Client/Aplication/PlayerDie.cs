using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using System.Collections.Generic;

using static CitizenFX.Core.Native.API;

// mp_m_freemode_01

namespace player.Client
{
    public class PlayerDie : BaseScript
    {
        public static Dictionary<string, Delegate> setEvent = new Dictionary<string, Delegate>();
        public PlayerDie()
        {
            EventHandlers["onClientResourceStart"] += new Action<string>(OnClientResourceStart);
        }

        private void OnClientResourceStart(string resourceName)
        {
            Die();
        }

        async void Die()
        {
            while (true)
            {
                await Delay(0);
                if (IsEntityDead(GetPlayerPed(PlayerId()))){
                    foreach (var i in PlayerDie.setEvent)
                    {
                        PlayerDie.setEvent[i.Key].DynamicInvoke();
                    }
                }
            }
        }

    }
}