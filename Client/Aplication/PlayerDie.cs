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
                    
                    Exports["spawnmanager"].setAutoSpawn(false);
                    FreezeEntityPosition(GetPlayerPed(PlayerId()), true);

                    // first
                    Exports["notification"].send("Ai murit " + Exports["core-ztzbx"].playerUsername(), "Hospital", "Mai ai de asteptat 10 secunde...");
                    await Delay(1000);
                    await Delay(1000);
                    Exports["notification"].send("Ai murit " + Exports["core-ztzbx"].playerUsername(), "Hospital", "Mai ai de asteptat 8 secunde...");
                    await Delay(1000);
                    await Delay(1000);
                    Exports["notification"].send("Ai murit " + Exports["core-ztzbx"].playerUsername(), "Hospital", "Mai ai de asteptat 6 secunde...");
                    await Delay(1000);
                    await Delay(1000);
                    Exports["notification"].send("Ai murit " + Exports["core-ztzbx"].playerUsername(), "Hospital", "Mai ai de asteptat 4 secunde...");
                    await Delay(1000);
                    await Delay(1000);
                    Exports["notification"].send("Ai murit " + Exports["core-ztzbx"].playerUsername(), "Hospital", "Mai ai de asteptat 2 secunde...");
                    await Delay(1000);
                    await Delay(1000);

                    foreach (var i in PlayerDie.setEvent)
                    {
                        PlayerDie.setEvent[i.Key].DynamicInvoke();
                    }

                    
                }
            }
        }

    }
}