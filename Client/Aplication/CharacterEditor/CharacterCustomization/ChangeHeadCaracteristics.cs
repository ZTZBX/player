using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using System.Collections.Generic;

using static CitizenFX.Core.Native.API;

// mp_m_freemode_01

namespace player.Client
{
    public class ChangeHeadCaracteristics : BaseScript
    {
        public ChangeHeadCaracteristics()
        {
            RegisterNuiCallbackType("NoseWidthThinWide");
            EventHandlers["__cfx_nui:NoseWidthThinWide"] += new Action<IDictionary<string, object>, CallbackDelegate>(NoseWidthThinWide);

            RegisterNuiCallbackType("NosePeakUpDown");
            EventHandlers["__cfx_nui:NosePeakUpDown"] += new Action<IDictionary<string, object>, CallbackDelegate>(NosePeakUpDown);

            RegisterNuiCallbackType("NoseLengthLongShort");
            EventHandlers["__cfx_nui:NoseLengthLongShort"] += new Action<IDictionary<string, object>, CallbackDelegate>(NoseLengthLongShort);

            RegisterNuiCallbackType("NoseBoneCurvenessCrookedCurved");
            EventHandlers["__cfx_nui:NoseBoneCurvenessCrookedCurved"] += new Action<IDictionary<string, object>, CallbackDelegate>(NoseBoneCurvenessCrookedCurved);

            RegisterNuiCallbackType("NoseTipUpDown");
            EventHandlers["__cfx_nui:NoseTipUpDown"] += new Action<IDictionary<string, object>, CallbackDelegate>(NoseTipUpDown);

            RegisterNuiCallbackType("NoseBoneTwistLeftRight");
            EventHandlers["__cfx_nui:NoseBoneTwistLeftRight"] += new Action<IDictionary<string, object>, CallbackDelegate>(NoseBoneTwistLeftRight);

            RegisterNuiCallbackType("EyebrowUpDown");
            EventHandlers["__cfx_nui:EyebrowUpDown"] += new Action<IDictionary<string, object>, CallbackDelegate>(EyebrowUpDown);

            RegisterNuiCallbackType("EyebrowInOut");
            EventHandlers["__cfx_nui:EyebrowInOut"] += new Action<IDictionary<string, object>, CallbackDelegate>(EyebrowInOut);

            RegisterNuiCallbackType("CheekBonesUpDown");
            EventHandlers["__cfx_nui:CheekBonesUpDown"] += new Action<IDictionary<string, object>, CallbackDelegate>(CheekBonesUpDown);

            RegisterNuiCallbackType("CheekSidewaysBoneSizeInOut");
            EventHandlers["__cfx_nui:CheekSidewaysBoneSizeInOut"] += new Action<IDictionary<string, object>, CallbackDelegate>(CheekSidewaysBoneSizeInOut);

            RegisterNuiCallbackType("CheekBonesWidthPuffedGaunt");
            EventHandlers["__cfx_nui:CheekBonesWidthPuffedGaunt"] += new Action<IDictionary<string, object>, CallbackDelegate>(CheekBonesWidthPuffedGaunt);

            RegisterNuiCallbackType("EyeOpeningBothWideSquinted");
            EventHandlers["__cfx_nui:EyeOpeningBothWideSquinted"] += new Action<IDictionary<string, object>, CallbackDelegate>(EyeOpeningBothWideSquinted);

            RegisterNuiCallbackType("LipThicknessBothFatThin");
            EventHandlers["__cfx_nui:LipThicknessBothFatThin"] += new Action<IDictionary<string, object>, CallbackDelegate>(LipThicknessBothFatThin);

            RegisterNuiCallbackType("JawBoneWidthNarrowWide");
            EventHandlers["__cfx_nui:JawBoneWidthNarrowWide"] += new Action<IDictionary<string, object>, CallbackDelegate>(JawBoneWidthNarrowWide);

            RegisterNuiCallbackType("JawBoneShapeRoundSquare");
            EventHandlers["__cfx_nui:JawBoneShapeRoundSquare"] += new Action<IDictionary<string, object>, CallbackDelegate>(JawBoneShapeRoundSquare);

            RegisterNuiCallbackType("ChinBoneUpDown");
            EventHandlers["__cfx_nui:ChinBoneUpDown"] += new Action<IDictionary<string, object>, CallbackDelegate>(ChinBoneUpDown);

            RegisterNuiCallbackType("ChinBoneLengthInOut");
            EventHandlers["__cfx_nui:ChinBoneLengthInOut"] += new Action<IDictionary<string, object>, CallbackDelegate>(ChinBoneLengthInOut);

            RegisterNuiCallbackType("ChinBoneShapePointedSquare");
            EventHandlers["__cfx_nui:ChinBoneShapePointedSquare"] += new Action<IDictionary<string, object>, CallbackDelegate>(ChinBoneShapePointedSquare);


            RegisterNuiCallbackType("ChinHoleChinBum");
            EventHandlers["__cfx_nui:ChinHoleChinBum"] += new Action<IDictionary<string, object>, CallbackDelegate>(ChinHoleChinBum);


            RegisterNuiCallbackType("NeckThicknessThinThick");
            EventHandlers["__cfx_nui:NeckThicknessThinThick"] += new Action<IDictionary<string, object>, CallbackDelegate>(NeckThicknessThinThick);
        }

        static public void GenerateRandomFaceCharacteristics()
        {
            Random rnd = new Random();

            Player.noseWidthThinWide = (float)rnd.Next(-11, 11) / 10.0f;
            Player.nosePeakUpDown = (float)rnd.Next(-11, 11) / 10.0f;
            Player.noseLengthLongShort = (float)rnd.Next(-11, 11) / 10.0f;
            Player.newoseBoneCurvenessCrookedCurved = (float)rnd.Next(-11, 11) / 10.0f;
            Player.noseTipUpDown = (float)rnd.Next(-11, 11) / 10.0f;
            Player.noseBoneTwistLeftRight = (float)rnd.Next(-11, 11) / 10.0f;
            Player.eyebrowUpDown = (float)rnd.Next(-11, 11) / 10.0f;
            Player.eyebrowInOut = (float)rnd.Next(-11, 11) / 10.0f;
            Player.cheekBonesUpDown = (float)rnd.Next(-11, 11) / 10.0f;
            Player.cheekSidewaysBoneSizeInOut = (float)rnd.Next(-11, 11) / 10.0f;
            Player.cheekBonesWidthPuffedGaunt = (float)rnd.Next(-11, 11) / 10.0f;
            Player.eyeOpeningBothWideSquinted = (float)rnd.Next(-11, 11) / 10.0f;
            Player.lipThicknessBothFatThin = (float)rnd.Next(-11, 11) / 10.0f;
            Player.jawBoneWidthNarrowWide = (float)rnd.Next(-11, 11) / 10.0f;
            Player.jawBoneShapeRoundSquare = (float)rnd.Next(-11, 11) / 10.0f;
            Player.chinBoneUpDown = (float)rnd.Next(-11, 11) / 10.0f;
            Player.chinBoneLengthInOut = (float)rnd.Next(-11, 11) / 10.0f;
            Player.chinBoneShapePointedSquare = (float)rnd.Next(-11, 11) / 10.0f;
            Player.chinHoleChinBum = (float)rnd.Next(-11, 11) / 10.0f;
            Player.neckThicknessThinThick = (float)rnd.Next(-11, 11) / 10.0f;
        }
        
        static public void UpdatePlayerFace(int ped)
        {
            SetPedFaceFeature(ped, 0, Player.noseWidthThinWide);
            SetPedFaceFeature(ped, 1, Player.nosePeakUpDown);
            SetPedFaceFeature(ped, 2, Player.noseLengthLongShort);
            SetPedFaceFeature(ped, 3, Player.newoseBoneCurvenessCrookedCurved);
            SetPedFaceFeature(ped, 4, Player.noseTipUpDown);
            SetPedFaceFeature(ped, 5, Player.noseBoneTwistLeftRight);
            SetPedFaceFeature(ped, 6, Player.eyebrowUpDown);
            SetPedFaceFeature(ped, 7, Player.eyebrowInOut);
            SetPedFaceFeature(ped, 8, Player.cheekBonesUpDown);
            SetPedFaceFeature(ped, 9, Player.cheekSidewaysBoneSizeInOut);
            SetPedFaceFeature(ped, 10, Player.cheekBonesWidthPuffedGaunt);
            SetPedFaceFeature(ped, 11, Player.eyeOpeningBothWideSquinted);
            SetPedFaceFeature(ped, 12, Player.lipThicknessBothFatThin);
            SetPedFaceFeature(ped, 13, Player.jawBoneWidthNarrowWide);
            SetPedFaceFeature(ped, 14, Player.jawBoneShapeRoundSquare);
            SetPedFaceFeature(ped, 15, Player.chinBoneUpDown);
            SetPedFaceFeature(ped, 16, Player.chinBoneLengthInOut);
            SetPedFaceFeature(ped, 17, Player.chinBoneShapePointedSquare);
            SetPedFaceFeature(ped, 18, Player.chinHoleChinBum);
            SetPedFaceFeature(ped, 19, Player.neckThicknessThinThick);
        }

        private void NoseWidthThinWide(IDictionary<string, object> data, CallbackDelegate cb)
        {
            object value;
            if (!data.TryGetValue("value", out value)) { return; }
            float valueGender = float.Parse(value.ToString());
            SetPedFaceFeature(Player.temporalPedForConfig, 0, valueGender);
            Player.noseWidthThinWide = valueGender;
            cb(new { data = "ok" });
        }

        private void NosePeakUpDown(IDictionary<string, object> data, CallbackDelegate cb)
        {
            object value;
            if (!data.TryGetValue("value", out value)) { return; }
            float valueGender = float.Parse(value.ToString());
            SetPedFaceFeature(Player.temporalPedForConfig, 1, valueGender);
            Player.nosePeakUpDown = valueGender;
            cb(new { data = "ok" });
        }

        private void NoseLengthLongShort(IDictionary<string, object> data, CallbackDelegate cb)
        {
            object value;
            if (!data.TryGetValue("value", out value)) { return; }
            float valueGender = float.Parse(value.ToString());
            SetPedFaceFeature(Player.temporalPedForConfig, 2, valueGender);
            Player.noseLengthLongShort = valueGender;
            cb(new { data = "ok" });
        }

        private void NoseBoneCurvenessCrookedCurved(IDictionary<string, object> data, CallbackDelegate cb)
        {
            object value;
            if (!data.TryGetValue("value", out value)) { return; }
            float valueGender = float.Parse(value.ToString());
            SetPedFaceFeature(Player.temporalPedForConfig, 3, valueGender);
            Player.newoseBoneCurvenessCrookedCurved = valueGender;
            cb(new { data = "ok" });
        }

        private void NoseTipUpDown(IDictionary<string, object> data, CallbackDelegate cb)
        {
            object value;
            if (!data.TryGetValue("value", out value)) { return; }
            float valueGender = float.Parse(value.ToString());
            SetPedFaceFeature(Player.temporalPedForConfig, 4, valueGender);
            Player.noseTipUpDown = valueGender;
            cb(new { data = "ok" });
        }

        private void NoseBoneTwistLeftRight(IDictionary<string, object> data, CallbackDelegate cb)
        {
            object value;
            if (!data.TryGetValue("value", out value)) { return; }
            float valueGender = float.Parse(value.ToString());
            SetPedFaceFeature(Player.temporalPedForConfig, 5, valueGender);
            Player.noseBoneTwistLeftRight = valueGender;
            cb(new { data = "ok" });
        }

        private void EyebrowUpDown(IDictionary<string, object> data, CallbackDelegate cb)
        {
            object value;
            if (!data.TryGetValue("value", out value)) { return; }
            float valueGender = float.Parse(value.ToString());
            SetPedFaceFeature(Player.temporalPedForConfig, 6, valueGender);
            Player.eyebrowUpDown = valueGender;
            cb(new { data = "ok" });
        }

        private void EyebrowInOut(IDictionary<string, object> data, CallbackDelegate cb)
        {
            object value;
            if (!data.TryGetValue("value", out value)) { return; }
            float valueGender = float.Parse(value.ToString());
            SetPedFaceFeature(Player.temporalPedForConfig, 7, valueGender);
            Player.eyebrowInOut = valueGender;
            cb(new { data = "ok" });
        }

        private void CheekBonesUpDown(IDictionary<string, object> data, CallbackDelegate cb)
        {
            object value;
            if (!data.TryGetValue("value", out value)) { return; }
            float valueGender = float.Parse(value.ToString());
            SetPedFaceFeature(Player.temporalPedForConfig, 8, valueGender);
            Player.cheekBonesUpDown = valueGender;
            cb(new { data = "ok" });
        }

        private void CheekSidewaysBoneSizeInOut(IDictionary<string, object> data, CallbackDelegate cb)
        {
            object value;
            if (!data.TryGetValue("value", out value)) { return; }
            float valueGender = float.Parse(value.ToString());
            SetPedFaceFeature(Player.temporalPedForConfig, 9, valueGender);
            Player.noseWidthThinWide = valueGender;
            cb(new { data = "ok" });
        }

        private void CheekBonesWidthPuffedGaunt(IDictionary<string, object> data, CallbackDelegate cb)
        {
            object value;
            if (!data.TryGetValue("value", out value)) { return; }
            float valueGender = float.Parse(value.ToString());
            SetPedFaceFeature(Player.temporalPedForConfig, 10, valueGender);
            Player.cheekSidewaysBoneSizeInOut = valueGender;
            cb(new { data = "ok" });
        }

        private void EyeOpeningBothWideSquinted(IDictionary<string, object> data, CallbackDelegate cb)
        {
            object value;
            if (!data.TryGetValue("value", out value)) { return; }
            float valueGender = float.Parse(value.ToString());
            SetPedFaceFeature(Player.temporalPedForConfig, 11, valueGender);
            Player.eyeOpeningBothWideSquinted = valueGender;
            cb(new { data = "ok" });
        }

        private void LipThicknessBothFatThin(IDictionary<string, object> data, CallbackDelegate cb)
        {
            object value;
            if (!data.TryGetValue("value", out value)) { return; }
            float valueGender = float.Parse(value.ToString());
            SetPedFaceFeature(Player.temporalPedForConfig, 12, valueGender);
            Player.lipThicknessBothFatThin = valueGender;
            cb(new { data = "ok" });
        }

        private void JawBoneWidthNarrowWide(IDictionary<string, object> data, CallbackDelegate cb)
        {
            object value;
            if (!data.TryGetValue("value", out value)) { return; }
            float valueGender = float.Parse(value.ToString());
            SetPedFaceFeature(Player.temporalPedForConfig, 13, valueGender);
            Player.jawBoneWidthNarrowWide = valueGender;
            cb(new { data = "ok" });
        }
        private void JawBoneShapeRoundSquare(IDictionary<string, object> data, CallbackDelegate cb)
        {
            object value;
            if (!data.TryGetValue("value", out value)) { return; }
            float valueGender = float.Parse(value.ToString());
            SetPedFaceFeature(Player.temporalPedForConfig, 14, valueGender);
            Player.jawBoneShapeRoundSquare = valueGender;
            cb(new { data = "ok" });
        }
        private void ChinBoneUpDown(IDictionary<string, object> data, CallbackDelegate cb)
        {
            object value;
            if (!data.TryGetValue("value", out value)) { return; }
            float valueGender = float.Parse(value.ToString());
            SetPedFaceFeature(Player.temporalPedForConfig, 15, valueGender);
            Player.chinBoneUpDown = valueGender;
            cb(new { data = "ok" });
        }
        private void ChinBoneLengthInOut(IDictionary<string, object> data, CallbackDelegate cb)
        {
            object value;
            if (!data.TryGetValue("value", out value)) { return; }
            float valueGender = float.Parse(value.ToString());
            SetPedFaceFeature(Player.temporalPedForConfig, 16, valueGender);
            Player.chinBoneLengthInOut = valueGender;
            cb(new { data = "ok" });
        }
        private void ChinBoneShapePointedSquare(IDictionary<string, object> data, CallbackDelegate cb)
        {
            object value;
            if (!data.TryGetValue("value", out value)) { return; }
            float valueGender = float.Parse(value.ToString());
            SetPedFaceFeature(Player.temporalPedForConfig, 17, valueGender);
            Player.chinBoneShapePointedSquare = valueGender;
            cb(new { data = "ok" });
        }
        private void ChinHoleChinBum(IDictionary<string, object> data, CallbackDelegate cb)
        {
            object value;
            if (!data.TryGetValue("value", out value)) { return; }
            float valueGender = float.Parse(value.ToString());
            SetPedFaceFeature(Player.temporalPedForConfig, 18, valueGender);
            Player.chinHoleChinBum = valueGender;
            cb(new { data = "ok" });
        }
        private void NeckThicknessThinThick(IDictionary<string, object> data, CallbackDelegate cb)
        {
            object value;
            if (!data.TryGetValue("value", out value)) { return; }
            float valueGender = float.Parse(value.ToString());
            SetPedFaceFeature(Player.temporalPedForConfig, 19, valueGender);
            Player.neckThicknessThinThick = valueGender;
            cb(new { data = "ok" });
        }

    }
}