using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using System.Collections.Generic;
using static CitizenFX.Core.Native.API;
using System.Linq;

namespace player.Client
{
    public class Spawner : BaseScript
    {
        public Spawner()
        {
            EventHandlers["onClientResourceStart"] += new Action<string>(OnClientResourceStart);
        }

        private void OnClientResourceStart(string resourceName)
        {
            PlayerDie.setEvent["goToHospital"] = new Action(GoToHospital);
            PlayerSpawned();
        }

        async public void PlayerSpawned()
        {
            while (true)
            {
                await Delay(100);

                try
                {
                    Exports["core-ztzbx"].playerToken();
                }
                catch
                {
                    continue;
                }

                if (!Player.spawned && Exports["core-ztzbx"].playerToken() != null)
                {
                    Exports["spawnmanager"].spawnPlayer(new Dictionary<string, dynamic>
                    {
                            {"x", Player.defult_spawn_x},
                            {"y", Player.defult_spawn_y},
                            {"z", Player.defult_spawn_z},
                            {"heading", -90.0f}
                    });
                    Player.spawned = true;
                    break;
                }
            }

            Exports["notification"].send("Bine ai venit!", "ZTZBX",  Exports["core-ztzbx"].playerUsername()+" bine ai venit in Liberty City, speram sa ai o experienta unica!");


        }

        async public void GoToHospital()
        {
            while (true)
            {
                await Delay(0);

                
                if (Player.playerStatsLoaded && Player.playerFaceLoaded)
                {
                    if (Clothes.itemsLoaded)
                    {
                        break;
                    }

                }
            }

            Exports["spawnmanager"].spawnPlayer(new Dictionary<string, dynamic>
            {
                            {"x", 48.52929f},
                            {"y", -61.24273f},
                            {"z", 4.939085f},
                            {"heading", 291.71}
            });
        }

    }
}