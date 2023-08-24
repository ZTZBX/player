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
        
        public static void FreezePlayer(int playerId, bool freeze)
        {
            var ped = GetPlayerPed(playerId);
            
            SetPlayerControl(playerId, !freeze, 0);

            if (!freeze)
            {
                if (!IsEntityVisible(ped))
                    SetEntityVisible(ped, true, false);
                
                if (!IsPedInAnyVehicle(ped, true))
                    SetEntityCollision(ped, true, true);

                FreezeEntityPosition(ped, false);
                //SetCharNeverTargetted(ped, false)
                SetPlayerInvincible(playerId, false);
            } 
            else 
            {
                if (IsEntityVisible(ped))
                    SetEntityVisible(ped, false, false);

                SetEntityCollision(ped, false, true);
                FreezeEntityPosition(ped, true);
                //SetCharNeverTargetted(ped, true)
                SetPlayerInvincible(playerId, true);
                
                if (IsPedFatallyInjured(ped))
                    ClearPedTasksImmediately(ped);
            }
        }

        async public void PlayerSpawned()
        {
            while (true)
            {
                await Delay(0);

                if (!Player.spawned && Player.playerhaslogged)
                {
                    Exports["spawnmanager"].spawnPlayer(new Dictionary<string, dynamic>
                    {
                            {"x", Player.defult_spawn_x},
                            {"y", Player.defult_spawn_y},
                            {"z", Player.defult_spawn_z},
                            {"heading", -90.0f}
                    });
                    Player.spawned = true;
                    FreezePlayer(PlayerId(), false);

                    break;
                }
            }
            Exports["notification"].send("Bine ai venit!", "ZTZBX", Exports["core-ztzbx"].playerUsername() + " bine ai venit in Liberty City, speram sa ai o experienta unica!");
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