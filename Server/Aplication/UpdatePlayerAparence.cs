using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CitizenFX.Core;
using Newtonsoft.Json;

namespace player.Server
{
    public class UpdatePlayerAparence : BaseScript
    {
        PlayerAparece playerA = new PlayerAparece();
        PlayerConfiguration playerC = new PlayerConfiguration();

        public UpdatePlayerAparence()
        {
            EventHandlers["saveCharacter"] += new Action<Player, string, string>(SaveCharacter);
            EventHandlers["getPlayerFace"] += new Action<Player, string>(SetPlayerFace);

        }

        private void SetPlayerFace([FromSource] Player user, string token)
        {
            TriggerClientEvent(user, "setPlayerFace",  JsonConvert.SerializeObject(playerA.Get(token)));
        }


        private void SaveCharacter([FromSource] Player user, string token, string jsonData)
        {
            Dictionary<string, string> data = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonData);

            playerC.Insert(token, 1, 0, data["gender"]);

            playerA.Update(
                token,
                float.Parse(data["blackrange"]),
                float.Parse(data["nosewidththinwide"]),
                float.Parse(data["nosepeakupdown"]),
                float.Parse(data["noselengthlongshort"]),
                float.Parse(data["newosebonecurvenesscrookedcurved"]),
                float.Parse(data["nosetipupdown"]),
                float.Parse(data["nosebonetwistleftright"]),
                float.Parse(data["eyebrowupdown"]),
                float.Parse(data["eyebrowinout"]),
                float.Parse(data["cheekbonesupdown"]),
                float.Parse(data["cheeksidewaysboneaizeinout"]),
                float.Parse(data["cheekboneswidthpuffedgaunt"]),
                float.Parse(data["eyeopeningbothwidesquinted"]),
                float.Parse(data["lipthicknessbothfatthin"]),
                float.Parse(data["jawbonewidthnarrowWide"]),
                float.Parse(data["jawboneshaperoundsquare"]),
                float.Parse(data["chinboneupdown"]),
                float.Parse(data["chinbonelengthinout"]),
                float.Parse(data["chinboneshapepointedsquare"]),
                float.Parse(data["chinholechinbum"]),
                float.Parse(data["neckthicknessthinthick"]),
                Int32.Parse(data["eyes"]),
                Int32.Parse(data["hair"]),
                Int32.Parse(data["haircolor"]),
                Int32.Parse(data["hairhightlight"]),
                Int32.Parse(data["facialhair"]),
                Int32.Parse(data["eyebrows"]),
                Int32.Parse(data["makeup"]),
                Int32.Parse(data["lipstick"])
            );
        }
    }
}