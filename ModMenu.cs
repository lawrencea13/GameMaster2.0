using BepInEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Device;

namespace LCTutorialMod
{
    internal class ModMenu : MonoBehaviour
    {
        internal static ModMenu Instance;
        
        internal bool Visible = false;

        private string EnemyToSpawn;
        private string AmountToSpawn;

        private string PlayerToSpawnEnemyOn;
        private int PlayerID;

        private string ErrorStatus;

        private Vector2 scrollPosition;
        private float scrollStart;

        #region MenuDimensions
        // actual menu location/dimensions
        private const int MENUWIDTH = 850;
        private const int MENUHEIGHT = 400;
        private int MENUX;
        private int MENUY;
        // end dimensions

        //ITEM DIMENSIONS
        private int TOOLBARWIDTH = 200;
        private int ITEMWIDTH = 200;
        // end ITEM DIMENSIONS

        // 
        private int CENTERX;
        private int QUARTERX;
        private int THREEQUARTERX;

        // DRAW AREA DIMENSIONS
        private int DRAWAREAX;
        private int DRAWAREAY;
        private int DRAWAREAWIDTH;
        private int DRAWAREAHEIGHT;
        private int DRAWAREAEND;
        private int PADDING = 10;
        // end draw area
        #endregion

        private int ToolBarInt = 0;
        private string[] ToolBarStrings = { "Spawn Enemies", "Host Settings", "Server Settings", "Empty" };

        #region Styles
        private bool Initialized = false;
        private GUIStyle MenuStyle;
        private GUIStyle ButtonStyle;
        private GUIStyle CustomButtonStyle;
        private GUIStyle LabelStyle;
        private GUIStyle ToggleStyle;
        private GUIStyle hScrollStyle;
        private GUIStyle vScrollStyle;
        #endregion

        #region Colors
        private List<Texture2D> Red = new List<Texture2D>();
        private List<Texture2D> Green = new List<Texture2D>();
        private List<Texture2D> Blue = new List<Texture2D>();
        #endregion

        void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }

            MENUX = UnityEngine.Device.Screen.width / 8;
            MENUY = UnityEngine.Device.Screen.height / 10;
            DRAWAREAX = MENUX + TOOLBARWIDTH + PADDING;
            DRAWAREAWIDTH = DRAWAREAX + MENUWIDTH - TOOLBARWIDTH - (PADDING * 2);
            CENTERX = DRAWAREAX + DRAWAREAWIDTH - (ITEMWIDTH / 2);
            DRAWAREAY = MENUY + PADDING;
            DRAWAREAHEIGHT = MENUHEIGHT - (PADDING * 2);
            DRAWAREAEND = DRAWAREAWIDTH - ITEMWIDTH;
            scrollStart = DRAWAREAY;

        }

        void Update()
        {
           
        }

       private void InitializeMenu()
        {
            if(MenuStyle == null)
            {
                //initialize

                Red.Add(MakeTex(2, 2, new Color(0.6f, 0, 0, 1f)));
                Red.Add(MakeTex(2, 2, new Color(0.8f, 0, 0, 1f)));
                Red.Add(MakeTex(2, 2, new Color(1f, 0, 0, 1f)));

                Green.Add(MakeTex(2, 2, new Color(0, 0.6f, 0, 1f)));
                Green.Add(MakeTex(2, 2, new Color(0, 0.8f, 0, 1f)));
                Green.Add(MakeTex(2, 2, new Color(0, 1f, 0, 1f)));

                Blue.Add(MakeTex(2, 2, new Color(0, 0, 0.6f, 1f)));
                Blue.Add(MakeTex(2, 2, new Color(0, 0, 0.8f, 1f)));
                Blue.Add(MakeTex(2, 2, new Color(0, 0, 1f, 1f)));

                MenuStyle = new GUIStyle(GUI.skin.box);
                ButtonStyle = new GUIStyle(GUI.skin.button);
                CustomButtonStyle = new GUIStyle(GUI.skin.button);
                LabelStyle = new GUIStyle(GUI.skin.label);
                ToggleStyle = new GUIStyle(GUI.skin.toggle);
                hScrollStyle = new GUIStyle(GUI.skin.horizontalScrollbar);
                vScrollStyle = new GUIStyle(GUI.skin.verticalScrollbar);


                MenuStyle.normal.textColor = Color.white;
                MenuStyle.normal.background = MakeTex(2, 2, new Color(0.01f, 0.01f, 0.1f, .9f));
                MenuStyle.fontSize = 18;
                MenuStyle.normal.background.hideFlags = HideFlags.HideAndDontSave;

                ButtonStyle.normal.textColor = Color.white;
                ButtonStyle.fontSize = 18;

                CustomButtonStyle.normal.textColor = Color.white;
                CustomButtonStyle.fontSize = 18;
                CustomButtonStyle.wordWrap = true;

                LabelStyle.normal.textColor = Color.white;
                LabelStyle.normal.background = MakeTex(2, 2, new Color(0.01f, 0.01f, 0.1f, .9f));
                LabelStyle.font = Font.CreateDynamicFontFromOSFont("Verdana", 16);
                LabelStyle.fontSize = 18;
                LabelStyle.alignment = TextAnchor.MiddleCenter;
                LabelStyle.normal.background.hideFlags = HideFlags.HideAndDontSave;
                LabelStyle.font.hideFlags = HideFlags.HideAndDontSave;
                

                ToggleStyle.normal.textColor = Color.white;
                ToggleStyle.fontSize = 18;

                hScrollStyle.normal.textColor = Color.white;
                hScrollStyle.normal.background = MakeTex(2, 2, new Color(0.0f, 0.0f, 0.2f, .9f));
                hScrollStyle.normal.background.hideFlags = HideFlags.HideAndDontSave;

            }


        }

        public void OnGUI()
        {
            if(!Visible) { return; }
            if (!Initialized)
            {
                InitializeMenu();
                Initialized = true;
            }

            GUI.Box(new Rect(MENUX, MENUY, MENUWIDTH, MENUHEIGHT), "");
            ToolBarInt = GUI.SelectionGrid(new Rect(MENUX, MENUY, TOOLBARWIDTH, MENUHEIGHT), ToolBarInt, ToolBarStrings, xCount: 1, style: ButtonStyle);

            switch (ToolBarInt)
            {
                case 0:
                    // spawn enemies
                    // Textbox for which enemy to spawn
                    // button to spawn randomly, list of player buttons to spawn near
                    GUI.Label(new Rect(DRAWAREAX, DRAWAREAY, ITEMWIDTH, 60), "Enemy Name", LabelStyle);
                    EnemyToSpawn = GUI.TextField(new Rect(DRAWAREAX, DRAWAREAY + 60, ITEMWIDTH, 30), EnemyToSpawn);

                    GUI.Label(new Rect(DRAWAREAX + ITEMWIDTH + PADDING, DRAWAREAY, ITEMWIDTH, 60), "Amount To Spawn For Random", LabelStyle);
                    AmountToSpawn = GUI.TextField(new Rect(DRAWAREAX + ITEMWIDTH + PADDING, DRAWAREAY + 60, ITEMWIDTH, 30), AmountToSpawn);

                    if(CustomButton(new Rect(DRAWAREAX, DRAWAREAY + 100, ITEMWIDTH, 75), "Spawn Enemy Randomly", CustomButtonStyle, Blue))
                    {
                        if (Int32.TryParse(AmountToSpawn, out int numValue))
                        {
                            GameMasterUtilities.SpawnEnemyAtRandomLocation(EnemyToSpawn, numValue);
                            ErrorStatus = "Success.";
                        }
                        else
                        {
                            ErrorStatus = "Amount to spawn was not an integer.";
                        }
                    }

                    if(CustomButton(new Rect(DRAWAREAX, DRAWAREAY + 200, ITEMWIDTH, 75), "Spawn Enemy Near Selected Player", CustomButtonStyle, Blue))
                    {
                        try
                        {
                            GameMasterUtilities.SpawnEnemyAtNearestLocation(EnemyToSpawn, PlayerID);
                            ErrorStatus = "Success.";
                        }
                        catch
                        {
                            ErrorStatus = "Unable to spawn enemy near player. Check the player id.";
                        }
                    }

                    GUI.Label(new Rect(DRAWAREAX + ITEMWIDTH + PADDING, DRAWAREAY + 100, ITEMWIDTH, 30), "Selected Player:", LabelStyle);
                    GUI.Label(new Rect(DRAWAREAX + ITEMWIDTH + PADDING, DRAWAREAY + 130, ITEMWIDTH, 60), PlayerToSpawnEnemyOn, LabelStyle);

                    GUI.Label(new Rect(DRAWAREAX + ITEMWIDTH + PADDING, DRAWAREAY + 200, ITEMWIDTH, 60), "Error Status:", LabelStyle);
                    GUI.Label(new Rect(DRAWAREAX + ITEMWIDTH + PADDING, DRAWAREAY + 260, ITEMWIDTH, 80), ErrorStatus, LabelStyle);

                    scrollPosition = GUI.BeginScrollView(new Rect(DRAWAREAEND - 20, DRAWAREAY, ITEMWIDTH + 20, DRAWAREAHEIGHT), scrollPosition, new Rect(DRAWAREAEND, scrollStart, ITEMWIDTH, GameMasterUtilities.GetAllPlayers().Count * 50), false, true, hScrollStyle, vScrollStyle);
                    try
                    {
                        foreach(var player in GameMasterUtilities.GetAllPlayers())
                        {
                            if (CustomButton(new Rect(DRAWAREAEND + 15, DRAWAREAY + (player.Key * 50), ITEMWIDTH - 30, 50), player.Value, CustomButtonStyle, Green))
                                UpdateSelectedPlayer(player.Key, player.Value);
                        }
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    GUI.EndScrollView();
                    break;
                case 1:
                    // host settings
                    string godModeButtonLabel = (TutorialModBase.Instance.ConfigManager.GodMode) ? "GodMode: Enabled" : "GodMode: Disabled";
                    string customSprintButtonLabel = (TutorialModBase.Instance.ConfigManager.CustomSprint) ? "Custom Movement: Enabled" : "Custom Movement: Disabled";
                    string flyHackButtonLabel = (TutorialModBase.Instance.ConfigManager.FlyHack) ? "Fly Hack: Enabled" : "Fly Hack: Disabled";

                    if (CustomButton(new Rect(DRAWAREAX, DRAWAREAY, ITEMWIDTH, 100), godModeButtonLabel, CustomButtonStyle, Blue))
                        TutorialModBase.Instance.ConfigManager.GodMode = !TutorialModBase.Instance.ConfigManager.GodMode;
                    if (CustomButton(new Rect(DRAWAREAX, DRAWAREAY + 100 + PADDING, ITEMWIDTH, 100), customSprintButtonLabel, CustomButtonStyle, Blue))
                    {
                        TutorialModBase.Instance.ConfigManager.CustomSprint = !TutorialModBase.Instance.ConfigManager.CustomSprint;
                        if (!TutorialModBase.Instance.ConfigManager.CustomSprint)
                        {
                            TutorialModBase.Instance.Player.movementSpeed = 5f;
                        }
                    }

                    if (CustomButton(new Rect(DRAWAREAX, DRAWAREAY + PADDING * 2 + 200, ITEMWIDTH, 100), flyHackButtonLabel, CustomButtonStyle, Blue))
                        TutorialModBase.Instance.ConfigManager.FlyHack = !TutorialModBase.Instance.ConfigManager.FlyHack;

                    GUI.Label(new Rect(DRAWAREAX + ITEMWIDTH + PADDING, DRAWAREAY + 100, ITEMWIDTH, 30), Math.Round(TutorialModBase.Instance.ConfigManager.PlayerSpeed, 2).ToString(), LabelStyle);
                    TutorialModBase.Instance.ConfigManager.PlayerSpeed = GUI.HorizontalSlider(new Rect(DRAWAREAX + ITEMWIDTH + PADDING, MENUY + 130, ITEMWIDTH, 30), 
                        TutorialModBase.Instance.ConfigManager.PlayerSpeed, 5f, 75f);
                    break;
                case 2:
                    // server settings
                    string maskedEnemyButtonLabel = (TutorialModBase.Instance.ConfigManager.MaskedEnemyMods) ? "Masked Enemy Mods: Enabled" : "Masked Enemy Mods: Disabled";
                    string springHeadButtonLabel = (TutorialModBase.Instance.ConfigManager.SpringHeadMods) ? "CoilHead Mods: Enabled" : "CoilHead Mods: Disabled";
                    string jesterButtonLabel = (TutorialModBase.Instance.ConfigManager.JesterMods) ? "Jester Mods: Enabled" : "Jester Mods: Disabled";
                    if (CustomButton(new Rect(DRAWAREAX, DRAWAREAY, ITEMWIDTH, 100), maskedEnemyButtonLabel, CustomButtonStyle, Red))
                        TutorialModBase.Instance.ConfigManager.MaskedEnemyMods = !TutorialModBase.Instance.ConfigManager.MaskedEnemyMods;
                    if (CustomButton(new Rect(DRAWAREAX, DRAWAREAY + 100 + PADDING, ITEMWIDTH, 100), springHeadButtonLabel, CustomButtonStyle, Red))
                        TutorialModBase.Instance.ConfigManager.SpringHeadMods = !TutorialModBase.Instance.ConfigManager.SpringHeadMods;
                    if (CustomButton(new Rect(DRAWAREAX, DRAWAREAY + 200 + PADDING * 2, ITEMWIDTH, 100), jesterButtonLabel, CustomButtonStyle, Red))
                        TutorialModBase.Instance.ConfigManager.JesterMods = !TutorialModBase.Instance.ConfigManager.JesterMods;

                    string naturalEnemySpawningButtonLabel = (TutorialModBase.Instance.ConfigManager.NaturalEnemySpawn) ? "Natural Spawning: Enabled" : "Natural Spawning: Disabled";
                    string allowAllEnemyButtonLabel = (TutorialModBase.Instance.ConfigManager.AllowAllEnemiesOnMap) ? "Allow All Enemies: Enabled" : "Allow All Enemies: Disabled";

                    if (CustomButton(new Rect(DRAWAREAX + ITEMWIDTH + PADDING, DRAWAREAY, ITEMWIDTH, 100), naturalEnemySpawningButtonLabel, CustomButtonStyle, Green))
                        TutorialModBase.Instance.ConfigManager.NaturalEnemySpawn = !TutorialModBase.Instance.ConfigManager.NaturalEnemySpawn;
                    if (CustomButton(new Rect(DRAWAREAX + ITEMWIDTH + PADDING, DRAWAREAY + 100 + PADDING, ITEMWIDTH, 100), allowAllEnemyButtonLabel, CustomButtonStyle, Green))
                        TutorialModBase.Instance.ConfigManager.AllowAllEnemiesOnMap = !TutorialModBase.Instance.ConfigManager.AllowAllEnemiesOnMap;

                    break;
                case 3:
                    // other
                    CustomButton(new Rect(DRAWAREAX, DRAWAREAY, ITEMWIDTH, 100), "This button does nothing", CustomButtonStyle, Red);
                    break;  
            }
        }

        private Texture2D MakeTex(int width, int height, Color color)
        {
            Color[] pix = new Color[width * height];
            for(int i = 0; i < pix.Length; i++) 
            {
                pix[i] = color;
            }
            Texture2D result = new Texture2D(width, height);
            result.SetPixels(pix);
            result.Apply();
            return result;
        }

        private bool CustomButton(Rect pos, string text,GUIStyle style, List<Texture2D> color)
        {
            style.normal.background = color[0];
            style.hover.background = color[1];
            style.active.background = color[2];
            

            bool returnVar = GUI.Button(pos, text, style);

            return returnVar;
        }

        private void UpdateSelectedPlayer(int playerID, string playerName)
        {
            PlayerToSpawnEnemyOn = playerName;
            PlayerID = playerID;
        }

    }
}
