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
        [HarmonyPatch(nameof(RoundManager.LoadNewLevel))]
        [HarmonyPrefix]
        static void ModifyLevel(ref SelectableLevel newLevel)
        {
            // don't need to check if setting enabled because this alone won't impact the game.
            if(!TutorialModBase.Instance.EnemySpawnsFixed) 
            {
                TutorialModBase.Instance.IndoorEnemyList = FixIndoorEnemySpawns();
                TutorialModBase.Instance.OutdoorEnemyList = FixOutdoorEnemySpawns();
            }

            // if allow all enemies is true
            //newLevel.Enemies = TutorialModBase.Instance.IndoorEnemyList;
            //newLevel.OutsideEnemies = TutorialModBase.Instance.OutdoorEnemyList;
        }

        static List<SpawnableEnemyWithRarity> FixIndoorEnemySpawns()
        {
            /*
             * typeof(JesterAI),
                typeof(DressGirlAI),
                typeof(SandSpiderAI),
                typeof(CrawlerAI),
                typeof(BlobAI),
                typeof(CentipedeAI),
                typeof(FlowermanAI),
                typeof(HoarderBugAI),
                typeof(LassoManAI),
                typeof(PufferAI),
                typeof(SpringManAI),
                typeof(NutcrackerEnemyAI)
            */

            
            List<SpawnableEnemyWithRarity> returnList = new List<SpawnableEnemyWithRarity>();

            

            JesterAI jesterRef = null;
            DressGirlAI dressGirlRef = null;
            SandSpiderAI spiderRef = null;
            CrawlerAI crawlerRef = null;
            BlobAI blobRef = null;
            CentipedeAI centipedeRef = null;
            FlowermanAI brackenRef = null;
            HoarderBugAI bugRef = null;
            LassoManAI lassoRef = null;
            PufferAI pufferRef = null;
            SpringManAI springRef = null;
            NutcrackerEnemyAI nutRef = null;

            

            foreach (UnityEngine.Object o in Resources.FindObjectsOfTypeAll(typeof(JesterAI)))
            {
                jesterRef = (JesterAI)o;
            }
            SpawnableEnemyWithRarity jesterSpawnable = new SpawnableEnemyWithRarity();
            if (jesterRef != null) { jesterSpawnable.enemyType = jesterRef.enemyType; }
            returnList.Add(jesterSpawnable);
            
            foreach (UnityEngine.Object o in Resources.FindObjectsOfTypeAll(typeof(DressGirlAI)))
            {
                dressGirlRef = (DressGirlAI)o;
            }
            SpawnableEnemyWithRarity girlSpawnable = new SpawnableEnemyWithRarity();
            if (dressGirlRef != null) { girlSpawnable.enemyType = dressGirlRef.enemyType; }
            returnList.Add(girlSpawnable);

            foreach (UnityEngine.Object o in Resources.FindObjectsOfTypeAll(typeof(SandSpiderAI)))
            {
                spiderRef = (SandSpiderAI)o;
            }
            SpawnableEnemyWithRarity spiderSpawnable = new SpawnableEnemyWithRarity();
            if (spiderRef != null) { spiderSpawnable.enemyType = spiderRef.enemyType; }
            returnList.Add(spiderSpawnable);

            foreach (UnityEngine.Object o in Resources.FindObjectsOfTypeAll(typeof(CrawlerAI)))
            {
                crawlerRef = (CrawlerAI)o;
            }
            SpawnableEnemyWithRarity crawlerSpawnable = new SpawnableEnemyWithRarity();
            if (crawlerRef != null) { crawlerSpawnable.enemyType = crawlerRef.enemyType; }
            returnList.Add(crawlerSpawnable);

            foreach (UnityEngine.Object o in Resources.FindObjectsOfTypeAll(typeof(BlobAI)))
            {
                blobRef = (BlobAI)o;
            }
            SpawnableEnemyWithRarity blobSpawnable = new SpawnableEnemyWithRarity();
            if (blobRef != null) { blobSpawnable.enemyType = blobRef.enemyType; }
            returnList.Add(blobSpawnable);

            foreach (UnityEngine.Object o in Resources.FindObjectsOfTypeAll(typeof(CentipedeAI)))
            {
                centipedeRef = (CentipedeAI)o;
            }
            SpawnableEnemyWithRarity centipedeSpawnable = new SpawnableEnemyWithRarity();
            if (centipedeRef != null) { centipedeSpawnable.enemyType = centipedeRef.enemyType; }
            returnList.Add(centipedeSpawnable);

            foreach (UnityEngine.Object o in Resources.FindObjectsOfTypeAll(typeof(FlowermanAI)))
            {
                brackenRef = (FlowermanAI)o;
            }
            SpawnableEnemyWithRarity brackenSpawnable = new SpawnableEnemyWithRarity();
            if (brackenRef != null) { brackenSpawnable.enemyType = brackenRef.enemyType; }
            returnList.Add(brackenSpawnable);

            foreach (UnityEngine.Object o in Resources.FindObjectsOfTypeAll(typeof(HoarderBugAI)))
            {
                bugRef = (HoarderBugAI)o;
            }
            SpawnableEnemyWithRarity bugSpawnable = new SpawnableEnemyWithRarity();
            if (bugRef != null) { bugSpawnable.enemyType = bugRef.enemyType; }
            returnList.Add(bugSpawnable);

            foreach (UnityEngine.Object o in Resources.FindObjectsOfTypeAll(typeof(LassoManAI)))
            {
                lassoRef = (LassoManAI)o;
            }
            SpawnableEnemyWithRarity lassoSpawnable = new SpawnableEnemyWithRarity();
            if (lassoRef != null) { lassoSpawnable.enemyType = lassoRef.enemyType; }
            returnList.Add(lassoSpawnable);

            foreach (UnityEngine.Object o in Resources.FindObjectsOfTypeAll(typeof(PufferAI)))
            {
                pufferRef = (PufferAI)o;
            }
            SpawnableEnemyWithRarity pufferSpawnable = new SpawnableEnemyWithRarity();
            if (pufferRef != null) { pufferSpawnable.enemyType = pufferRef.enemyType; }
            returnList.Add(pufferSpawnable);

            foreach (UnityEngine.Object o in Resources.FindObjectsOfTypeAll(typeof(SpringManAI)))
            {
                springRef = (SpringManAI)o;
            }
            SpawnableEnemyWithRarity springSpawnable = new SpawnableEnemyWithRarity();
            if (springRef != null) { springSpawnable.enemyType = springRef.enemyType; }
            returnList.Add(springSpawnable);

            foreach (UnityEngine.Object o in Resources.FindObjectsOfTypeAll(typeof(NutcrackerEnemyAI)))
            {
                nutRef = (NutcrackerEnemyAI)o;
            }
            SpawnableEnemyWithRarity nutSpawnable = new SpawnableEnemyWithRarity();
            if (nutRef != null) { nutSpawnable.enemyType = nutRef.enemyType; }
            returnList.Add(nutSpawnable);

            return returnList;
        }

        static List<SpawnableEnemyWithRarity> FixOutdoorEnemySpawns()
        {
            /*
             * typeof(DressGirlAI),
                typeof(SandWormAI),
                typeof(MouthDogAI),
                typeof(BaboonBirdAI),
                typeof(DocileLocustBeesAI),
                typeof(DoublewingAI),
                typeof(ForestGiantAI),
            */

            List<SpawnableEnemyWithRarity> returnList = new List<SpawnableEnemyWithRarity>();

            DressGirlAI dressGirlRef = null;
            SandWormAI sandwormRef = null;
            MouthDogAI mouthDogRef = null;
            BaboonBirdAI baboonRef = null;
            DocileLocustBeesAI locustRef = null;
            DoublewingAI birdRef = null;
            ForestGiantAI giantRef = null;


            foreach (UnityEngine.Object o in Resources.FindObjectsOfTypeAll(typeof(DressGirlAI)))
            {
                dressGirlRef = (DressGirlAI)o;
            }
            SpawnableEnemyWithRarity girlSpawnable = new SpawnableEnemyWithRarity();
            if (dressGirlRef != null) { girlSpawnable.enemyType = dressGirlRef.enemyType; }
            returnList.Add(girlSpawnable);

            foreach (UnityEngine.Object o in Resources.FindObjectsOfTypeAll(typeof(SandWormAI)))
            {
                sandwormRef = (SandWormAI)o;
            }
            SpawnableEnemyWithRarity sandwormSpawnable = new SpawnableEnemyWithRarity();
            if (sandwormRef != null) { sandwormSpawnable.enemyType = sandwormRef.enemyType; }
            returnList.Add(sandwormSpawnable);

            foreach (UnityEngine.Object o in Resources.FindObjectsOfTypeAll(typeof(MouthDogAI)))
            {
                mouthDogRef = (MouthDogAI)o;
            }
            SpawnableEnemyWithRarity dogSpawnable = new SpawnableEnemyWithRarity();
            if (mouthDogRef != null) { dogSpawnable.enemyType = mouthDogRef.enemyType; }
            returnList.Add(dogSpawnable);

            foreach (UnityEngine.Object o in Resources.FindObjectsOfTypeAll(typeof(BaboonBirdAI)))
            {
                baboonRef = (BaboonBirdAI)o;
            }
            SpawnableEnemyWithRarity baboonSpawnable = new SpawnableEnemyWithRarity();
            if (baboonRef != null) { baboonSpawnable.enemyType = baboonRef.enemyType; }
            returnList.Add(baboonSpawnable);

            foreach (UnityEngine.Object o in Resources.FindObjectsOfTypeAll(typeof(DocileLocustBeesAI)))
            {
                locustRef = (DocileLocustBeesAI)o;
            }
            SpawnableEnemyWithRarity locustSpawnable = new SpawnableEnemyWithRarity();
            if (locustRef != null) { locustSpawnable.enemyType = locustRef.enemyType; }
            returnList.Add(locustSpawnable);

            foreach (UnityEngine.Object o in Resources.FindObjectsOfTypeAll(typeof(DoublewingAI)))
            {
                birdRef = (DoublewingAI)o;
            }
            SpawnableEnemyWithRarity birdSpawnable = new SpawnableEnemyWithRarity();
            if (birdRef != null) { birdSpawnable.enemyType = birdRef.enemyType; }
            returnList.Add(birdSpawnable);

            foreach (UnityEngine.Object o in Resources.FindObjectsOfTypeAll(typeof(ForestGiantAI)))
            {
                giantRef = (ForestGiantAI)o;
            }
            SpawnableEnemyWithRarity giantSpawnable = new SpawnableEnemyWithRarity();
            if (giantRef != null) { giantSpawnable.enemyType = giantRef.enemyType; }
            returnList.Add(giantSpawnable);

          
            return returnList;
        }
    }
}
