using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Netcode;
using UnityEngine;

namespace LCTutorialMod.Patches
{
    [HarmonyPatch(typeof(RoundManager))]
    internal class RoundManagerPatch
    {
        [HarmonyPatch("Start")]
        [HarmonyPrefix]
        static void RoundManagerStart(RoundManager __instance)
        {
            TutorialModBase.Instance.CurrentRound = __instance;
            
        }


        [HarmonyPatch(nameof(RoundManager.LoadNewLevel))]
        [HarmonyPrefix]
        static void ModifyLevel(ref SelectableLevel newLevel)
        {
            // don't need to check if setting enabled because this alone won't impact the game.
            if(!TutorialModBase.Instance.EnemySpawnsFixed) 
            {
                TutorialModBase.Instance.IndoorEnemyList = GameMasterUtilities.FixIndoorEnemySpawns();
                TutorialModBase.Instance.OutdoorEnemyList = GameMasterUtilities.FixOutdoorEnemySpawns();
                //GameMasterUtilities.FixAllEnemySpawns();
                foreach (SpawnableEnemyWithRarity enemy in TutorialModBase.Instance.IndoorEnemyList)
                {
                    Console.WriteLine(enemy.enemyType.enemyName);
                }
                foreach (SpawnableEnemyWithRarity enemy in TutorialModBase.Instance.OutdoorEnemyList)
                {
                    Console.WriteLine(enemy.enemyType.enemyName);
                }
                

                TutorialModBase.Instance.EnemySpawnsFixed = true;
            }


            foreach (SpawnableEnemyWithRarity enemy in newLevel.Enemies)
            {
                GameMasterUtilities.EnemyRarity[enemy] = enemy.rarity;
            }
            foreach (SpawnableEnemyWithRarity enemy in newLevel.OutsideEnemies)
            {
                GameMasterUtilities.EnemyRarity[enemy] = enemy.rarity;
            }
            foreach (SpawnableEnemyWithRarity enemy in newLevel.DaytimeEnemies)
            {
                GameMasterUtilities.EnemyRarity[enemy] = enemy.rarity;
            }


            GameMasterUtilities.CurrentLevelEnemies = newLevel.Enemies;
            GameMasterUtilities.CurrentLevelDaytimeEnemies = newLevel.DaytimeEnemies;
            GameMasterUtilities.CurrentLevelOutsideEnemies = newLevel.OutsideEnemies;

            // TODO: add behind an enable wall e.g. bool customEnemy
            if (TutorialModBase.Instance.ConfigManager.AllowAllEnemiesOnMap)
            {
                newLevel.Enemies = TutorialModBase.Instance.IndoorEnemyList;
                newLevel.OutsideEnemies = TutorialModBase.Instance.OutdoorEnemyList;
            }


            TutorialModBase.Instance.CurrentLevel = newLevel;

            if (!TutorialModBase.Instance.ConfigManager.NaturalEnemySpawn)
            {
                foreach (SpawnableEnemyWithRarity enemy in TutorialModBase.Instance.CurrentLevel.Enemies)
                {
                    GameMasterUtilities.EnemyRarity[enemy] = enemy.rarity;
                    enemy.rarity = 0;
                }
                foreach (SpawnableEnemyWithRarity enemy in TutorialModBase.Instance.CurrentLevel.OutsideEnemies)
                {
                    GameMasterUtilities.EnemyRarity[enemy] = enemy.rarity;
                    enemy.rarity = 0;
                }
                foreach (SpawnableEnemyWithRarity enemy in TutorialModBase.Instance.CurrentLevel.DaytimeEnemies)
                {
                    GameMasterUtilities.EnemyRarity[enemy] = enemy.rarity;
                    enemy.rarity = 0;
                }
            }

        }
        

    }
}
