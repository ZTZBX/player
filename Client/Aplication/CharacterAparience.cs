using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using System.Collections.Generic;

using static CitizenFX.Core.Native.API;

// mp_m_freemode_01

namespace player.Client
{
    public class CharacterAparience : BaseScript
    {
        public CharacterAparience()
        {
        }

        public static void updatePlayerAparience()
        {
            if (Player.gender == "M")
            {
                // setting default male dress 
                Clothes.Pants = 245;
                Clothes.Torso = 15;
                Clothes.Undershirt = 15;
                Clothes.Shoes = 218;
                Clothes.UpperBody = 15;

                SetPlayerClothes.ChangePlayerGender(PlayerId(), Player.gender);
                SetPlayerClothes.SetPlayerBlackPerMan(PlayerPedId(), Player.blackRange);

                SetPedHeadOverlayColor(PlayerPedId(), 1, 1, Player.hairColor, Player.hairColor);
                SetPedHeadOverlay(PlayerPedId(), 1, Player.facialHair, 255);
            }
            if (Player.gender == "F")
            {
                // setting default female dress 
                Clothes.Pants = 15;
                Clothes.Torso = 15;
                Clothes.Undershirt = 15;
                Clothes.Shoes = 218;
                Clothes.UpperBody = 15;

                SetPlayerClothes.ChangePlayerGender(PlayerId(), Player.gender);
                SetPlayerClothes.SetPlayerBlackPerFem(PlayerPedId(), Player.blackRange);
            }

            SetPlayerClothes.ChangePlayerAparience(PlayerPedId(), Clothes.Pants, Clothes.Torso, Clothes.Undershirt, Clothes.Shoes, Clothes.UpperBody);
            ChangeHeadCaracteristics.UpdatePlayerFace(PlayerPedId());
            SetPedHeadOverlayColor(PlayerPedId(), 2, 1, Player.hairColor, Player.hairColor);
            SetPedEyeColor(PlayerPedId(), Player.eyes);
            SetClothes.SetHair(PlayerPedId(), Player.hair, 0);
            SetPedHairColor(PlayerPedId(), Player.hairColor, Player.hairHightLight);

        }
    }
}