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

        private const int MENUWIDTH = 1000;
        private const int MENUHEIGHT = 400;
        private int MENUX;
        private int MENUY;
        private int ITEMWIDTH = 200;
        private int CENTERX;
        private int QUARTERX;
        private int THREEQUARTERX;
        private int TOOLBARDWIDTH = 200;
        private int MENUSTART;

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
            MENUSTART = MENUX + TOOLBARDWIDTH;
            CENTERX = MENUSTART + ((MENUWIDTH / 2) - (ITEMWIDTH / 2));



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


                MenuStyle.normal.textColor = Color.white;
                MenuStyle.normal.background = MakeTex(2, 2, new Color(0.01f, 0.01f, 0.1f, .9f));
                MenuStyle.fontSize = 18;
                MenuStyle.normal.background.hideFlags = HideFlags.HideAndDontSave;

                ButtonStyle.normal.textColor = Color.white;
                ButtonStyle.fontSize = 18;

                CustomButtonStyle.normal.textColor = Color.white;
                CustomButtonStyle.fontSize = 18;

                LabelStyle.normal.textColor = Color.white;
                LabelStyle.normal.background = MakeTex(2, 2, new Color(0.01f, 0.01f, 0.1f, .9f));
                LabelStyle.fontSize = 18;
                LabelStyle.alignment = TextAnchor.MiddleCenter;
                LabelStyle.normal.background.hideFlags = HideFlags.HideAndDontSave;

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
            ToolBarInt = GUI.SelectionGrid(new Rect(MENUX, MENUY, TOOLBARDWIDTH, MENUHEIGHT), ToolBarInt, ToolBarStrings, xCount: 1, style: ButtonStyle);

            switch (ToolBarInt)
            {
                case 0:
                    CustomButton(new Rect(MENUSTART, MENUY, ITEMWIDTH, 100), "Test", CustomButtonStyle, Blue);
                    break;
                case 1:
                    CustomButton(new Rect(MENUSTART, MENUY, ITEMWIDTH, 100), "Test1", CustomButtonStyle, Red);
                    break;
                case 2:
                    CustomButton(new Rect(MENUSTART, MENUY, ITEMWIDTH, 100), "Test2", CustomButtonStyle, Green);
                    break;
                case 3:
                    CustomButton(new Rect(MENUSTART, MENUY, ITEMWIDTH, 100), "Test3", CustomButtonStyle, Blue);
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
     

    }
}
