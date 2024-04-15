﻿using HarmonyLib;
using RimWorld;
using Verse;

namespace BlueprintMaterialDebt;

[HarmonyPatch(typeof(PlaySettings), nameof(PlaySettings.DoPlaySettingsGlobalControls), typeof(WidgetRow), typeof(bool))]
internal static class PlaySettings_DoPlaySettingsGlobalControls_Patch
{
    private static void Postfix(WidgetRow row, bool worldView)
    {
        if (worldView)
        {
            return;
        }

        if (row == null || BlueprintTextures.ToggleIcon == null)
        {
            return;
        }

        row.ToggleableIcon(
            ref BlueprintMaterialDebt.SubtractResources,
            BlueprintTextures.ToggleIcon,
            "BlueprintMaterialDebt_toggleTip".Translate(),
            SoundDefOf.Mouseover_ButtonToggle
        );
    }
}