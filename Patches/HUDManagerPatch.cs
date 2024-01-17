using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCTutorialMod.Patches
{
    [HarmonyPatch(typeof(HUDManager))]
    internal class HUDManagerPatch
    {
        [HarmonyPatch("SubmitChat_performed")]
        [HarmonyPrefix]
        static void CommandPatch(HUDManager __instance)
        {
            try
            {
                if (GameMasterUtilities.HandleCommand(__instance.chatTextField.text))
                {
                    __instance.chatTextField.text = "";
                }
            }
            catch(Exception e)
            {
                TutorialModBase.mls.LogInfo($"Unable to process chat command {e.Message}");
            }
        }
    }
}
