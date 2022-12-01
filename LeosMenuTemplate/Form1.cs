using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ezOverLay;
using System.Threading;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace LeosMenuTemplate
{
    public partial class Form1 : Form
    {
        ez ez = new ez();

        // initiate your memory dll here

        // global variables
        bool menuOpen = true;
        int menuItemSelected = 0;
        int menuPageSelected = 0;
        string[,] menuItems = new string[9, 8] { 
            { "Aimbot >", "ESP >", "Online >", "Story Mode >", "Spawner >", "Player >", "Weapon >", "Misc >" }, 
            { "Enable", "Fov", "Smoothing", "RCS", "Feature 4", "Feature 5", "Feature 6", "Feature 7" }, 
            { "Enable", "Box", "Cornered", "Team", "Tracers", "Feature 5", "Feature 6", "Feature 7" }, 
            { "Enable", "Feature 1", "Feature 2", "Feature 3", "Feature 4", "Feature 5", "Feature 6", "Feature 7" }, 
            { "Enable", "Feature 1", "Feature 2", "Feature 3", "Feature 4", "Feature 5", "Feature 6", "Feature 7" }, 
            { "Enable", "Feature 1", "Feature 2", "Feature 3", "Feature 4", "Feature 5", "Feature 6", "Feature 7" },
            { "Enable", "Feature 1", "Feature 2", "Feature 3", "Feature 4", "Feature 5", "Feature 6", "Feature 7" },
            { "Enable", "Feature 1", "Feature 2", "Feature 3", "Feature 4", "Feature 5", "Feature 6", "Feature 7" },
            { "Enable", "Feature 1", "Feature 2", "Feature 3", "Feature 4", "Feature 5", "Feature 6", "Feature 7" }
        };
    


        [DllImport("User32.dll")]
        public static extern short GetAsyncKeyState(Keys vKey);

        struct Offsets // put your offsets in here
        {

        }

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            ez.SetInvi(this);
            ez.DoStuff("Counter-Strike: Global Offensive - Direct3D 9", this); // replace "Counter-Strike: Global Offensive - Direct3D 9" with game name

            label1.Text = menuItems[0, 0];
            label2.Text = menuItems[0, 1];
            label3.Text = menuItems[0, 2];
            label4.Text = menuItems[0, 3];
            label5.Text = menuItems[0, 4];
            label6.Text = menuItems[0, 5];
            label7.Text = menuItems[0, 6];
            label8.Text = menuItems[0, 7];

            Thread menuControls = new Thread(Menu) { IsBackground = true };
            menuControls.Start();
        }

        void Menu()
        {
            while (true)
            {
                if (GetAsyncKeyState(Keys.Insert) < 0)
                {
                    menuOpen = !menuOpen;
                    Thread.Sleep(150);
                }

                if (menuOpen == true) 
                { 
                    panel1.Visible = true; 

                    if (GetAsyncKeyState(Keys.Down) < 0)
                    {
                        var item = menuSelector(menuItemSelected);
                        item.ForeColor = Color.Black;
                        menuItemSelected += 1;
                        if (menuItemSelected > 7) { menuItemSelected = 0; } else if (menuItemSelected < 0) { menuItemSelected = 7; }
                        item = menuSelector(menuItemSelected);
                        item.ForeColor = Color.Yellow;
                        Thread.Sleep(150);

                    }

                    if (GetAsyncKeyState(Keys.Up) < 0)
                    {
                        var item = menuSelector(menuItemSelected);
                        item.ForeColor = Color.Black;
                        menuItemSelected -= 1;
                        if (menuItemSelected > 7) { menuItemSelected = 0; } else if (menuItemSelected < 0) { menuItemSelected = 7; }
                        item = menuSelector(menuItemSelected);
                        item.ForeColor = Color.Yellow;
                        Thread.Sleep(150);
                    }

                    if (GetAsyncKeyState(Keys.Enter) < 0)
                    {
                        menuPageSelected = menuItemSelected + 1;
                        label1.Text = menuItems[menuPageSelected, 0];
                        label2.Text = menuItems[menuPageSelected, 1];
                        label3.Text = menuItems[menuPageSelected, 2];
                        label4.Text = menuItems[menuPageSelected, 3];
                        label5.Text = menuItems[menuPageSelected, 4];
                        label6.Text = menuItems[menuPageSelected, 5];
                        label7.Text = menuItems[menuPageSelected, 6];
                        label8.Text = menuItems[menuPageSelected, 7];

                        menuSelector(menuItemSelected).ForeColor = Color.Black;
                        menuItemSelected = 0;
                        menuSelector(menuItemSelected).ForeColor = Color.Yellow;

                        Thread.Sleep(150);
                    }

                    if (GetAsyncKeyState(Keys.Back) < 0)
                    {
                        label1.Text = menuItems[0, 0];
                        label2.Text = menuItems[0, 1];
                        label3.Text = menuItems[0, 2];
                        label4.Text = menuItems[0, 3];
                        label5.Text = menuItems[0, 4];
                        label6.Text = menuItems[0, 5];
                        label7.Text = menuItems[0, 6];
                        label8.Text = menuItems[0, 7];

                        menuSelector(menuItemSelected).ForeColor = Color.Black;
                        menuItemSelected = 0;
                        menuSelector(menuItemSelected).ForeColor = Color.Yellow;

                        Thread.Sleep(150);
                    }

                } 
                else 
                { 
                    panel1.Visible = false; 
                }


                Thread.Sleep(10);
            }
            
        }

        public Label menuSelector(int selected)
        {
            if (selected == 0) { return label1; } else if (selected == 1) { return label2; } else if (selected == 2) { return label3; } else if (selected == 3) { return label4; } else if (selected == 4) { return label5; } else if (selected == 5) { return label6; } else if (selected == 6) { return label7; } else if (selected == 7) { return label8; } else { return label1; }
        }


    }
}
