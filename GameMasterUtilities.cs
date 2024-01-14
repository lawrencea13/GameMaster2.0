using GameNetcodeStuff;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Netcode;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

namespace LCTutorialMod
{
    internal class GameMasterUtilities
    {
        /// <summary>
        /// Unused for now
        /// </summary>
        internal static void FixAllEnemySpawns()
        {
            foreach (UnityEngine.Object o in Resources.FindObjectsOfTypeAll(typeof(EnemyAI)))
            {
                EnemyAI ai = (EnemyAI)o;
                SpawnableEnemyWithRarity spawnable = new SpawnableEnemyWithRarity();
                spawnable.enemyType = ai.enemyType;

                if (spawnable.enemyType.isDaytimeEnemy || spawnable.enemyType.isOutsideEnemy)
                {
                    TutorialModBase.Instance.OutdoorEnemyList.Add(spawnable);
                    TutorialModBase.mls.LogInfo($"added outdoor enemy: {spawnable.enemyType.enemyName}");
                }
                else
                {
                    TutorialModBase.Instance.IndoorEnemyList.Add(spawnable);
                    TutorialModBase.mls.LogInfo($"added indoor enemy: {spawnable.enemyType.enemyName}");
                }
            }
        }


        internal static List<SpawnableEnemyWithRarity> FixIndoorEnemySpawns()
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

        internal static List<SpawnableEnemyWithRarity> FixOutdoorEnemySpawns()
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


        internal static void SpawnEnemyAtRandomLocation(string EnemyName = "", int Amount = 1)
        {
            if(EnemyName == "") { return; }

            int IndexOfEnemyToSpawn = -1;

            foreach(SpawnableEnemyWithRarity enemy in TutorialModBase.Instance.IndoorEnemyList)
            {
                if(enemy.enemyType.enemyName.ToLower() == EnemyName.ToLower())
                {
                    // found an existing indoor enemy in the game
#if DEBUG
                    Console.WriteLine("Found enemy in game, if it is not spawning, it doesn't exist on the level. Trying enabling EnemyFix.");
#endif
                    if (TutorialModBase.Instance.CurrentLevel.Enemies.Contains(enemy))
                    {
                        // found enemy in the current level
                        IndexOfEnemyToSpawn = TutorialModBase.Instance.CurrentLevel.Enemies.IndexOf(enemy);
                    }
                }
            }

            if(IndexOfEnemyToSpawn == -1)
            {
                foreach (SpawnableEnemyWithRarity enemy in TutorialModBase.Instance.OutdoorEnemyList)
                {
                    if (enemy.enemyType.enemyName.ToLower() == EnemyName.ToLower())
                    {
                        // found an existing indoor enemy in the game
#if DEBUG
                        Console.WriteLine("Found enemy in game, if it is not spawning, it doesn't exist on the level. Trying enabling EnemyFix.");
#endif
                        if (TutorialModBase.Instance.CurrentLevel.OutsideEnemies.Contains(enemy))
                        {
                            // found enemy in the current level
                            IndexOfEnemyToSpawn = TutorialModBase.Instance.CurrentLevel.OutsideEnemies.IndexOf(enemy);
                        }
                    }
                }

                if(IndexOfEnemyToSpawn == -1) { return; }

                // spawn outdoor enemy
                for (int i = 0; i < Amount; i++)
                {
                    GameObject obj = UnityEngine.Object.Instantiate(TutorialModBase.Instance.CurrentLevel.OutsideEnemies[IndexOfEnemyToSpawn].enemyType.enemyPrefab,
                        GameObject.FindGameObjectsWithTag("OutsideAINode")[UnityEngine.Random.Range(0, GameObject.FindGameObjectsWithTag("OutsideAINode").Length - 1)].transform.position,
                        Quaternion.Euler(Vector3.zero));

                    obj.gameObject.GetComponent<NetworkObject>().Spawn(destroyWithScene: true);
                }

                


            }
            else
            {
                // spawn inside enemy
                for(int i = 0; i < Amount; i++)
                {
                    EnemyVent spawnVent = TutorialModBase.Instance.CurrentRound.allEnemyVents[UnityEngine.Random.Range(0, TutorialModBase.Instance.CurrentRound.allEnemyVents.Length)];

                    TutorialModBase.Instance.CurrentRound.SpawnEnemyOnServer(spawnVent.floorNode.position, spawnVent.floorNode.eulerAngles.y, IndexOfEnemyToSpawn);
                }

               
            }

        }

        internal static void SpawnEnemyAtNearestLocation(string EnemyName = "", int PlayerIndex = 0)
        {
            GameObject playerObj = StartOfRound.Instance.allPlayerObjects[PlayerIndex];
            PlayerControllerB playerCtrl = StartOfRound.Instance.allPlayerScripts[PlayerIndex];

            Vector3 pos = playerObj.transform.position;
            bool inside = playerCtrl.isInsideFactory;
            int IndexOfEnemyToSpawn = -1;

            if (inside)
            {
                // decide which indoor enemy to spawn
                foreach (SpawnableEnemyWithRarity enemy in TutorialModBase.Instance.IndoorEnemyList)
                {
                    if (enemy.enemyType.enemyName.ToLower() == EnemyName.ToLower())
                    {
                        // found an existing indoor enemy in the game
#if DEBUG
                        Console.WriteLine("Found enemy in game, if it is not spawning, it doesn't exist on the level. Trying enabling EnemyFix.");
#endif
                        if (TutorialModBase.Instance.CurrentLevel.Enemies.Contains(enemy))
                        {
                            // found enemy in the current level
                            IndexOfEnemyToSpawn = TutorialModBase.Instance.CurrentLevel.Enemies.IndexOf(enemy);
                        }
                    }
                }

                // if we couldn't find enemy to spawn, stop.
                if (IndexOfEnemyToSpawn == -1) { return; }

                // figure out where to spawn that enemy
                EnemyVent[] vents = TutorialModBase.Instance.CurrentRound.allEnemyVents;
                EnemyVent closestVent = null;
                float distance = Mathf.Infinity;

                foreach(EnemyVent vent in vents)
                {
                    Vector3 diff = vent.floorNode.position - pos;
                    float curDistance = diff.sqrMagnitude;
                    if(curDistance < distance)
                    {
                        closestVent = vent;
                        distance = curDistance;
                    }
                }
                if(closestVent == null) { return; }
                // spawn the enemy
                TutorialModBase.Instance.CurrentRound.SpawnEnemyOnServer(closestVent.floorNode.position, closestVent.floorNode.eulerAngles.y, IndexOfEnemyToSpawn);
            }
            else
            {
                // decide which outdoor enemy to spawn
                foreach (SpawnableEnemyWithRarity enemy in TutorialModBase.Instance.OutdoorEnemyList)
                {
                    if (enemy.enemyType.enemyName.ToLower() == EnemyName.ToLower())
                    {
                        // found an existing indoor enemy in the game
#if DEBUG
                        Console.WriteLine("Found enemy in game, if it is not spawning, it doesn't exist on the level. Trying enabling EnemyFix.");
#endif
                        if (TutorialModBase.Instance.CurrentLevel.OutsideEnemies.Contains(enemy))
                        {
                            // found enemy in the current level
                            IndexOfEnemyToSpawn = TutorialModBase.Instance.CurrentLevel.OutsideEnemies.IndexOf(enemy);
                        }
                    }
                }

                // if we couldn't find enemy to spawn, stop.
                if (IndexOfEnemyToSpawn == -1) { return; }

                // figure out where to spawn that enemy
                var objs = GameObject.FindGameObjectsWithTag("OutsideAINode");
                GameObject closestSpawn = null;
                float distance = Mathf.Infinity;

                foreach(GameObject gameObj in objs)
                {
                    Vector3 diff = gameObj.transform.position - pos;
                    float curDistance = diff.sqrMagnitude;
                    if (curDistance < distance)
                    {
                        closestSpawn = gameObj;
                        distance = curDistance;
                    }
                }

                if(closestSpawn == null) { return; }
                // spawn the enemy
                GameObject obj = UnityEngine.Object.Instantiate(TutorialModBase.Instance.CurrentLevel.OutsideEnemies[IndexOfEnemyToSpawn].enemyType.enemyPrefab,
                        closestSpawn.transform.position, Quaternion.Euler(Vector3.zero));

                obj.gameObject.GetComponent<NetworkObject>().Spawn(destroyWithScene: true);
            }

        }

        private static int ComputeStringDifference(string s, string t)
        {
            if (string.IsNullOrEmpty(s))
            {
                if (string.IsNullOrEmpty(t))
                    return 0;
                return t.Length;
            }
            if (string.IsNullOrEmpty(t))
            {
                return s.Length;
            }

            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            for (int i = 0; i <= n; d[i, 0] = i++) ;
            for (int j = 1; j <= m; d[0, j] = j++) ;

            for(int i = 1; i <= n; i++)
            {
                for(int j = 1; j <= m; j++)
                {
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;
                    int min1 = d[i - 1, j] + 1;
                    int min2 = d[i, j - 1] + 1;
                    int min3 = d[i - 1, j - 1] + cost;
                    d[i, j] = Math.Min(Math.Min(min1, min2), min3);
                }
            }
            return d[n, m];
        }

        internal static string GetBestEnemyMatch(string name)
        {
            string result = string.Empty;

            List<SpawnableEnemyWithRarity> allEnemies = new List<SpawnableEnemyWithRarity>();
            allEnemies.AddRange(TutorialModBase.Instance.IndoorEnemyList);
            allEnemies.AddRange(TutorialModBase.Instance.OutdoorEnemyList);

            int SmallestDifference = 10000;

            foreach(SpawnableEnemyWithRarity enemy in allEnemies)
            {
                int currentAmount = ComputeStringDifference(name, enemy.enemyType.enemyName);
                if(currentAmount < SmallestDifference)
                {
                    SmallestDifference = currentAmount;
                    result = enemy.enemyType.enemyName;
                }
            }

            return result;
        }
    }
}
