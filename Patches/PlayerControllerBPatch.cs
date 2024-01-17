using GameNetcodeStuff;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace LCTutorialMod.Patches
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class PlayerControllerBPatch
    {
        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        static void UpdatePatch(ref float ___sprintMeter, ref float ___movementSpeed)
        {
            if(TutorialModBase.Instance.ConfigManager.CustomSprint) 
            {
                ___movementSpeed = TutorialModBase.Instance.ConfigManager.PlayerSpeed;
                ___sprintMeter = 1f;
            }
            if (TutorialModBase.Instance.ConfigManager.FlyHack)
            {
                GameMasterUtilities.FlyHack();
            }
        }

        [HarmonyPatch(nameof(PlayerControllerB.AllowPlayerDeath))]
        [HarmonyPostfix]
        static void PatchDeath(ref bool __result)
        {
            if(TutorialModBase.Instance.ConfigManager.GodMode || TutorialModBase.Instance.ConfigManager.FlyHack) { __result = false; }
        }

        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        static void StartPatch(PlayerControllerB __instance)
        {
            // expect to see some errors here while this is handled
            if(TutorialModBase.Instance.Player == null)
                Task.Delay(100).ContinueWith(t => { GameMasterUtilities.GetLocalPlayerController(); });
            

        }


    }
}
