using BepInEx.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCTutorialMod
{
    /// <summary>
    /// This will hold and manage all configs used by the config manager
    /// </summary>
    internal class ConfigurationContoller
    {
        private ConfigEntry<string> ServerNameCfg;
        private ConfigEntry<bool> GodModeCfg;
        private ConfigEntry<float> PlayerSpeedCfg;
        private ConfigEntry<bool> CustomSprintCfg;
        private ConfigEntry<bool> FlyHackCfg;
        private ConfigEntry<bool> MaskedEnemyModsCfg;
        private ConfigEntry<bool> SpringHeadModsCfg;
        private ConfigEntry<bool> JesterModsCfg;
        private ConfigEntry<bool> NaturalEnemySpawnCfg;
        private ConfigEntry<bool> AllowAllEnemiesOnMapCfg;

        internal bool IsHost 
        { 
            get 
            {
                if(TutorialModBase.Instance.CurrentRound != null)
                {
                    return TutorialModBase.Instance.CurrentRound.NetworkManager.IsHost;
                }
                return false;  
            } 
        }

        internal string ServerName
        {
            get
            {
                if(ServerNameCfg.Value == "")
                {
                    ServerNameCfg.Value = (string)ServerNameCfg.DefaultValue;
                    return (string)ServerNameCfg.DefaultValue;
                }
                return ServerNameCfg.Value;
            }
            set => ServerNameCfg.Value = value;
        }
        internal bool GodMode 
        { 
            get 
            {
                if (IsHost)
                {
                    return (bool)GodModeCfg.Value;
                }
                return false;
            } 
            set => GodModeCfg.Value = value; 
        }
        internal float PlayerSpeed
        {
            get 
            { 
                if(PlayerSpeedCfg.Value < 0)
                {
                    return (float)PlayerSpeedCfg.DefaultValue;
                }
                return PlayerSpeedCfg.Value;
            }
            set => PlayerSpeedCfg.Value = value;
        }
        internal bool CustomSprint 
        { 
            get 
            {
                if (IsHost)
                {
                    return (bool)CustomSprintCfg.Value;
                }
                return false;
            } 
            set => CustomSprintCfg.Value = value; 
        }
        internal bool FlyHack 
        {   
            get 
            {
                if (IsHost)
                {
                    return (bool)FlyHackCfg.Value;
                }
                return false;
            } 
            set => FlyHackCfg.Value = value; 
        }
        internal bool MaskedEnemyMods
        {
            get
            {
                if (IsHost)
                {
                    return (bool)MaskedEnemyModsCfg.Value;
                }
                return false;
            }
            set => MaskedEnemyModsCfg.Value = value;
        }
        internal bool SpringHeadMods
        {
            get
            {
                if (IsHost)
                {
                    return (bool)SpringHeadModsCfg.Value;
                }
                return false;
            }
            set => SpringHeadModsCfg.Value = value;
        }
        internal bool JesterMods
        {
            get
            {
                if (IsHost)
                {
                    return (bool)JesterModsCfg.Value;
                }
                return false;
            }
            set => JesterModsCfg.Value = value;
        }

        // doesn't need host check, only impacts game if is host
        internal bool NaturalEnemySpawn
        {
            get => NaturalEnemySpawnCfg.Value;
            set
            {
                NaturalEnemySpawnCfg.Value = value;
                if(!value)
                {
                    if(TutorialModBase.Instance.CurrentLevel != null)
                    {
                        foreach(SpawnableEnemyWithRarity enemy in TutorialModBase.Instance.CurrentLevel.Enemies)
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
                else
                {
                    if (TutorialModBase.Instance.CurrentLevel != null)
                    {
                        foreach (SpawnableEnemyWithRarity enemy in TutorialModBase.Instance.CurrentLevel.Enemies)
                        {
                            enemy.rarity = GameMasterUtilities.EnemyRarity[enemy];
                        }
                        foreach (SpawnableEnemyWithRarity enemy in TutorialModBase.Instance.CurrentLevel.OutsideEnemies)
                        {
                            enemy.rarity = GameMasterUtilities.EnemyRarity[enemy];
                        }
                        foreach (SpawnableEnemyWithRarity enemy in TutorialModBase.Instance.CurrentLevel.DaytimeEnemies)
                        {
                            enemy.rarity = GameMasterUtilities.EnemyRarity[enemy];
                        }
                    }
                }
            }
        }

        internal bool AllowAllEnemiesOnMap 
        { 
            get => AllowAllEnemiesOnMapCfg.Value;
            set
            {
                AllowAllEnemiesOnMapCfg.Value = value;
                if (!value)
                {
                    if(TutorialModBase.Instance.CurrentLevel != null)
                    {
                        TutorialModBase.Instance.CurrentLevel.Enemies = GameMasterUtilities.CurrentLevelEnemies;
                        TutorialModBase.Instance.CurrentLevel.DaytimeEnemies = GameMasterUtilities.CurrentLevelDaytimeEnemies;
                        TutorialModBase.Instance.CurrentLevel.OutsideEnemies = GameMasterUtilities.CurrentLevelOutsideEnemies;
                    }
                }
                else
                {
                    if(TutorialModBase.Instance.CurrentLevel != null)
                    {
                        // ensure data is properly stored before adjusting just in case the player wants to toggle it again.
                        GameMasterUtilities.CurrentLevelEnemies = TutorialModBase.Instance.CurrentLevel.Enemies;
                        GameMasterUtilities.CurrentLevelDaytimeEnemies = TutorialModBase.Instance.CurrentLevel.DaytimeEnemies;
                        GameMasterUtilities.CurrentLevelOutsideEnemies = TutorialModBase.Instance.CurrentLevel.OutsideEnemies;

                        TutorialModBase.Instance.CurrentLevel.Enemies = TutorialModBase.Instance.IndoorEnemyList;
                        // not worried about these things not spawning tbh, if I get complaints I will implement
                        //TutorialModBase.Instance.CurrentLevel.DaytimeEnemies
                        TutorialModBase.Instance.CurrentLevel.OutsideEnemies = TutorialModBase.Instance.OutdoorEnemyList;
                    }
                }
            }
        }

        public ConfigurationContoller(ConfigFile Config) 
        {
            ServerNameCfg = Config.Bind("Server Settings", "Server Name", "Default Server Name", 
                "The name used when creating a server. Overwrites the in game menu input.");
            GodModeCfg = Config.Bind("Host Settings", "God Mode", false,
                "It's godmode..what do you think it does?");
            PlayerSpeedCfg = Config.Bind("Host Settings", "Player Speed", 5f,
                "ZOOOOOOOOOOOOOOOM");
            CustomSprintCfg = Config.Bind("Host Settings", "Custom Sprint", false,
                "Can't stop, won't stop, never gonna stop. Enables infinite sprint and allows for custom move speed.");
            FlyHackCfg = Config.Bind("Host Settings", "Fly Hack", false,
                "Freeeeeeeeeeee Fallin!");
            MaskedEnemyModsCfg = Config.Bind("Server Settings", "Masked Enemy Mods", false,
                "Spooky scary skeletons");
            SpringHeadModsCfg = Config.Bind("Server Settings", "Coilhead Mods", false,
                "Spooky scary skeletons");
            JesterModsCfg = Config.Bind("Server Settings", "Jester Mods", false,
                "Spooky scary skeletons");
            NaturalEnemySpawnCfg = Config.Bind("Server Settings", "Natural Enemy Spawns", true,
                "Allows enemies to spawn normally throughout the day.");
            AllowAllEnemiesOnMapCfg = Config.Bind("Server Settings", "Allow All Enemies", false,
                "Allow any enemy to spawn on any map.");

        }
    }
}
