﻿using HarmonyLib;
using UnityEngine;
using Verse;

namespace DTimeControl.Core_Patches;

[HarmonyPatch(typeof(TimeSlower))]
[HarmonyPatch("SignalForceNormalSpeedShort")]
internal class Patch_SignalForceNormalSpeedShort_Prefix
{
    public static bool Prefix(TimeSlower __instance, ref int ___forceNormalSpeedUntil)
    {
        var currentForce = ___forceNormalSpeedUntil;
        var forceUntil = (int)Mathf.Max(currentForce,
            Find.TickManager.TicksGame + (240f / TimeControlSettings.speedMultiplier));
        ___forceNormalSpeedUntil = forceUntil;
        return false;
    }
}