using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CitizenFX.Core;

namespace player.Server
{
    public class PlayerAparece : BaseScript
    {
        public PlayerAparece()
        { }

        public Dictionary<string, string> Get(string token)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            string usernameQuery = $"SELECT username from players where token='{token}'";
            dynamic username = Exports["fivem-mysql"].raw(usernameQuery);

            string query = $"SELECT blackrange, nosewidththinwide, nosepeakupdown, noselengthlongshort, newosebonecurvenesscrookedcurved, nosetipupdown, nosebonetwistleftright, eyebrowupdown, eyebrowinout, cheekbonesupdown, cheeksidewaysboneaizeinout, cheekboneswidthpuffedgaunt, eyeopeningbothwidesquinted, lipthicknessbothfatthin, jawbonewidthnarrowWide, jawboneshaperoundsquare, chinboneupdown, chinbonelengthinout, chinboneshapepointedsquare, chinholechinbum, neckthicknessthinthick, eyes, hair, haircolor, hairhightlight, facialhair, eyebrows, makeup, lipstick FROM `playeraspect` WHERE username='{username[0][0]}';";
            dynamic queryResult = Exports["fivem-mysql"].raw(query);

            if (queryResult.Count == 0)
            {
                result.Add("blackrange", "0.0");
                result.Add("nosewidththinwide", "0.0");
                result.Add("nosepeakupdown", "0.0");
                result.Add("noselengthlongshort", "0.0");
                result.Add("newosebonecurvenesscrookedcurved", "0.0");
                result.Add("nosetipupdown", "0.0");
                result.Add("nosebonetwistleftright", "0.0");
                result.Add("eyebrowupdown", "0.0");
                result.Add("eyebrowinout", "0.0");
                result.Add("cheekbonesupdown", "0.0");
                result.Add("cheeksidewaysboneaizeinout", "0.0");
                result.Add("cheekboneswidthpuffedgaunt", "0.0");
                result.Add("eyeopeningbothwidesquinted", "0.0");
                result.Add("lipthicknessbothfatthin", "0.0");
                result.Add("jawbonewidthnarrowWide", "0.0");
                result.Add("jawboneshaperoundsquare", "0.0");
                result.Add("chinboneupdown", "0.0");
                result.Add("chinbonelengthinout", "0.0");
                result.Add("chinboneshapepointedsquare", "0.0");
                result.Add("chinholechinbum", "0.0");
                result.Add("neckthicknessthinthick", "0.0");
                result.Add("eyes", "0");
                result.Add("hair", "0");
                result.Add("haircolor", "0");
                result.Add("hairhightlight", "0");
                result.Add("facialhair", "-1");
                result.Add("eyebrows", "0");
                result.Add("makeup", "0");
                result.Add("lipstick", "0");

                return result;
            }

            result.Add("blackrange", queryResult[0][0]);
            result.Add("nosewidththinwide", queryResult[0][1]);
            result.Add("nosepeakupdown", queryResult[0][2]);
            result.Add("noselengthlongshort", queryResult[0][3]);
            result.Add("newosebonecurvenesscrookedcurved", queryResult[0][4]);
            result.Add("nosetipupdown", queryResult[0][5]);
            result.Add("nosebonetwistleftright", queryResult[0][6]);
            result.Add("eyebrowupdown", queryResult[0][7]);
            result.Add("eyebrowinout", queryResult[0][8]);
            result.Add("cheekbonesupdown", queryResult[0][9]);
            result.Add("cheeksidewaysboneaizeinout", queryResult[0][10]);
            result.Add("cheekboneswidthpuffedgaunt", queryResult[0][11]);
            result.Add("eyeopeningbothwidesquinted", queryResult[0][12]);
            result.Add("lipthicknessbothfatthin", queryResult[0][13]);
            result.Add("jawbonewidthnarrowWide", queryResult[0][14]);
            result.Add("jawboneshaperoundsquare", queryResult[0][15]);
            result.Add("chinboneupdown", queryResult[0][16]);
            result.Add("chinbonelengthinout", queryResult[0][17]);
            result.Add("chinboneshapepointedsquare", queryResult[0][18]);
            result.Add("chinholechinbum", queryResult[0][19]);
            result.Add("neckthicknessthinthick", queryResult[0][20]);
            result.Add("eyes", queryResult[0][21]);
            result.Add("hair", queryResult[0][22]);
            result.Add("haircolor", queryResult[0][23]);
            result.Add("hairhightlight", queryResult[0][24]);
            result.Add("facialhair", queryResult[0][25]);
            result.Add("eyebrows", queryResult[0][26]);
            result.Add("makeup", queryResult[0][27]);
            result.Add("lipstick", queryResult[0][28]);

            return result;
        }


        public void Update
        (
            string token,
            float blackrange,
            float nosewidththinwide,
            float nosepeakupdown,
            float noselengthlongshort,
            float newosebonecurvenesscrookedcurved,
            float nosetipupdown,
            float nosebonetwistleftright,
            float eyebrowupdown,
            float eyebrowinout,
            float cheekbonesupdown,
            float cheeksidewaysboneaizeinout,
            float cheekboneswidthpuffedgaunt,
            float eyeopeningbothwidesquinted,
            float lipthicknessbothfatthin,
            float jawbonewidthnarrowWide,
            float jawboneshaperoundsquare,
            float chinboneupdown,
            float chinbonelengthinout,
            float chinboneshapepointedsquare,
            float chinholechinbum,
            float neckthicknessthinthick,
            int eyes,
            int hair,
            int haircolor,
            int hairhightlight,
            int facialhair,
            int eyebrows,
            int makeup,
            int lipstick
        )
        {
            string usernameQuery = $"SELECT username from players where token='{token}'";
            dynamic username = Exports["fivem-mysql"].raw(usernameQuery);

            string query = $"select username from playeraspect where username='{username[0][0]}';";
            dynamic configResult = Exports["fivem-mysql"].raw(query);

            if (configResult.Count > 0)
            {
                // update line
                return;
            }

            // insert line
            string insertQuery = $"INSERT INTO `playeraspect` (`username`, `blackrange`, `nosewidththinwide`, `nosepeakupdown`, `noselengthlongshort`, `newosebonecurvenesscrookedcurved`, `nosetipupdown`, `nosebonetwistleftright`, `eyebrowupdown`, `eyebrowinout`, `cheekbonesupdown`, `cheeksidewaysboneaizeinout`, `cheekboneswidthpuffedgaunt`, `eyeopeningbothwidesquinted`, `lipthicknessbothfatthin`, `jawbonewidthnarrowWide`, `jawboneshaperoundsquare`, `chinboneupdown`, `chinbonelengthinout`, `chinboneshapepointedsquare`, `chinholechinbum`, `neckthicknessthinthick`, `eyes`, `hair`, `haircolor`, `hairhightlight`, `facialhair`, `eyebrows`, `makeup`, `lipstick`) VALUES ('{username[0][0]}', '{blackrange}', '{nosewidththinwide}', '{nosepeakupdown}', '{noselengthlongshort}', '{newosebonecurvenesscrookedcurved}', '{nosetipupdown}', '{nosebonetwistleftright}', '{eyebrowupdown}', '{eyebrowinout}', '{cheekbonesupdown}', '{cheeksidewaysboneaizeinout}', '{cheekboneswidthpuffedgaunt}', '{eyeopeningbothwidesquinted}', '{lipthicknessbothfatthin}', '{jawbonewidthnarrowWide}', '{jawboneshaperoundsquare}', '{chinboneupdown}', '{chinbonelengthinout}', '{chinboneshapepointedsquare}', '{chinholechinbum}', '{neckthicknessthinthick}', '{eyes}', '{hair}', '{haircolor}', '{hairhightlight}', '{facialhair}', '{eyebrows}', '{makeup}', '{lipstick}');";
            Exports["fivem-mysql"].raw(insertQuery);

        }
    }
}