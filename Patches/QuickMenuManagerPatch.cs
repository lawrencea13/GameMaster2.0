using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LCTutorialMod.GameMasterUtilities;

namespace LCTutorialMod.Patches
{
    [HarmonyPatch(typeof(QuickMenuManager))]
    internal class QuickMenuManagerPatch
    {
        [HarmonyPatch(nameof(QuickMenuManager.OpenQuickMenu))]
        [HarmonyPrefix]
        public static void OpenMenu()
        {
            TutorialModBase.Instance.Menu.Visible = true;
            //TutorialModBase.mls.LogInfo(GameMasterUtilities.GetBestEnemyMatch("Cragler"));
            //SpawnEnemyAtNearestLocation("Masked");
        }

        [HarmonyPatch(nameof(QuickMenuManager.CloseQuickMenu))]
        [HarmonyPrefix]
        public static void CloseMenu()
        {
            TutorialModBase.Instance.Menu.Visible = false;
        }

        [HarmonyPatch(nameof(QuickMenuManager.LeaveGameConfirm))]
        [HarmonyPrefix]
        public static void CloseMenuOnLeaveGame()
        {
            TutorialModBase.Instance.Menu.Visible = false;
        }
    }
}
