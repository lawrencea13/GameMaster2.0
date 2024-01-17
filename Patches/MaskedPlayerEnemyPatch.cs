using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace LCTutorialMod.Patches
{
    [HarmonyPatch(typeof(MaskedPlayerEnemy))]
    internal class MaskedPlayerEnemyPatch
    {
        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        public static void PatchStart(MaskedPlayerEnemy __instance)
        {
            try
            {
                UnityEngine.Object.Destroy(__instance.gameObject.transform.Find("ScavengerModel").Find("metarig").Find("spine").Find("spine.001")
                    .Find("spine.002").Find("spine.003").Find("spine.004").Find("HeadMaskComedy")
                    .Find("ComedyMaskLOD1").gameObject.GetComponent<MeshRenderer>());
            }
            catch { TutorialModBase.mls.LogInfo("Unable to remove mask from masked enemy"); }

            try
            {
                UnityEngine.Object.Destroy(__instance.gameObject.transform.Find("ScavengerModel").Find("metarig").Find("spine").Find("spine.001")
                    .Find("spine.002").Find("spine.003").Find("spine.004").Find("HeadMaskTragedy")
                    .Find("ComedyMaskLOD1").gameObject.GetComponent<MeshRenderer>());
            }
            catch { TutorialModBase.mls.LogInfo("Unable to remove mask from masked enemy"); }



        }
    }
}
