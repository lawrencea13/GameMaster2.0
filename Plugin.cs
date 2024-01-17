using BepInEx;
using BepInEx.Bootstrap;
using BepInEx.Logging;
using GameNetcodeStuff;
using HarmonyLib;
using LCTutorialMod.Patches;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace LCTutorialMod
{
    [BepInPlugin(bModGUID, modName, modVersion)]
    public class TutorialModBase : BaseUnityPlugin
    {
        private static readonly string modGUID;
        private const string bModGUID = "Poseidon.LCTutorialMod";
        private const string modName = "GameMaster Rewrite";
        private const string modVersion = "0.3.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        internal static TutorialModBase Instance;

        internal static ManualLogSource mls;

        private static System.Random random = new System.Random();

        #region InstanceVars
        internal ConfigurationContoller ConfigManager;
        internal ModMenu Menu;

        // stores all enemy AI references
        internal List<SpawnableEnemyWithRarity> IndoorEnemyList;
        internal List<SpawnableEnemyWithRarity> OutdoorEnemyList;

        // current level always exists while in a match
        internal RoundManager CurrentRound;
        // will only be set if the player is host
        internal SelectableLevel CurrentLevel;
        internal PlayerControllerB Player;

        internal bool EnemySpawnsFixed = false;

        #endregion

        #region Testing
        static TutorialModBase()
        {
            modGUID = GenerateGUID();
        }

        static string GenerateGUID()
        {
            string result = string.Empty;
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            try
            {
                string resultPt1 = "com.";
                string resultPt2 = new string(Enumerable.Repeat(chars, 8).Select(s => s[random.Next(s.Length)]).ToArray());
                string resultPt3 = ".Minx";
                
                result = resultPt1 + resultPt2 + resultPt3;
            }
            catch { }

            if (string.IsNullOrEmpty(result))
            {
                Console.WriteLine("Failed to generate GUID, using default");
                return bModGUID;
            }
            return result;
        }

        #endregion

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo("Message on mod load");

            harmony.PatchAll(typeof(PlayerControllerBPatch));
            harmony.PatchAll(typeof(QuickMenuManagerPatch));
            harmony.PatchAll(typeof(RoundManagerPatch));
            harmony.PatchAll(typeof(HUDManagerPatch));
            harmony.PatchAll(typeof(MaskedPlayerEnemyPatch));
            harmony.PatchAll(typeof(StartOfRoundPatch));


            mls = Logger;


            /*
             * Spawn enemies inside and out
             * Spawn enemies nearby instead of randomly
             * Still give all host settings, godmode, speedhack, nightvision
             * By default, until settings are modified, the game should act as if nothing is happening
             * Spawn all enemies on all maps without any weird hacks
             * Want a fully functioning GUI
             * Maybe chat commands
             * ability to customize server settings, including AI settings
             * Want to fix bugs from previous versions
             * better gui handling, e.g. opens with esc menu instead of on its own with insert
             * Ability to kill/destoy enemies
             */

            ConfigManager = new ConfigurationContoller(Config);

            /* 
             * When do we want the menu to open?
             * When we open the ESC menu
             * 
             * Do we want the menu to be opened while nonhost
             * If so, do we want the ability to disable features?
             * Yes, but disable non host features
             */
            //Task.Delay(500).ContinueWith(t => { EditGUID(); });
            //Task.Delay(1000).ContinueWith(t => { PrintMods(); });
            Task.Delay(2000).ContinueWith(t => { CreateMenu(); });
            
        }

        private void CreateMenu()
        {
            var gameObject = new UnityEngine.GameObject("ModMenu");
            UnityEngine.Object.DontDestroyOnLoad(gameObject);
            gameObject.hideFlags = (HideFlags)61;
            gameObject.AddComponent<ModMenu>();
            Menu = (ModMenu)gameObject.GetComponent("ModMenu");
        }












#if DEBUG
        private void EditGUID()
        {
            foreach (var plugin in Chainloader.PluginInfos)
            {
                if(plugin.Value.Metadata.GUID == bModGUID)
                {                    
                    Type type = typeof(PluginInfo);
                    PropertyInfo pInfo = type.GetProperty("MetaData");
                    pInfo.SetValue(plugin.Value.Metadata, modGUID);
                }
            }

        }

        private void PrintMods()
        {
            foreach (var plugin in Chainloader.PluginInfos)
            {
                Console.WriteLine(plugin.Value.Metadata.GUID);
            }

        }
#endif
    }

}
