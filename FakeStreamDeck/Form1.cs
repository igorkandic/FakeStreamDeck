using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Configuration;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;



namespace FakeStreamDeck
{
    public partial class Form1 : Form
    {

        // this is import of libraries
        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey); // Keys enumeration

        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(System.Int32 vKey);

        public static bool IsKeyPushedDown(System.Windows.Forms.Keys vKey)
        {
            return 0 != (GetAsyncKeyState((int)vKey) & 0x8000);
        }

        const int KEYEVENTF_KEYDOWN = 0x0000;
        const int KEYEVENTF_KEYUP = 0x0002;

        [DllImport("User32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        static void SendKeys(List<Keys> key)
        {
            foreach(Keys k in key)
                keybd_event((byte)k, 0, KEYEVENTF_KEYDOWN, 0);
            foreach (Keys k in key)
                keybd_event((byte)k, 0, KEYEVENTF_KEYUP, 0);
        }
        static void KeysDown(List<Keys> key)
        {
            foreach (Keys k in key)
                keybd_event((byte)k, 0, KEYEVENTF_KEYDOWN, 0);
        }
        static void KeysUp(List<Keys> key)
        {
            foreach (Keys k in key)
                keybd_event((byte)k, 0, KEYEVENTF_KEYUP, 0);
        }

        public Form1()
        {
            InitializeComponent();
        }
        int selectedButton = 1;
        bool recording = false;
        string[] macro = new string[9];


        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "Selected Key: none";
            if (File.Exists("macros.conf"))
            {
                using(StreamReader sr = new StreamReader("macros.conf"))
                {
                    string line;
                    int i = 0;
                    while((line = sr.ReadLine()) != null)
                    {
                        line.Replace("\n", "");
                        macro[i++] = line;
                    }
                }
            }
            else
            {
                using(StreamWriter sw = new StreamWriter("macros.conf"))
                {
                    for (int i = 0; i < macro.Length; i++)
                    {
                        sw.WriteLine(i + 1);
                        macro[i] = $"D{i+1}";
                    }
                        
                }
            }

        }
        bool btn1Held = false;
        bool btn2Held = false;
        bool btn3Held = false;
        bool btn4Held = false;
        bool btn5Held = false;
        bool btn6Held = false;
        bool btn7Held = false;
        bool btn8Held = false;
        bool btn9Held = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 3;
            if (IsKeyPushedDown(Keys.F13) && !btn1Held)
            {
                btn1Held = true;
                button1.BackColor = ColorTranslator.FromHtml("#144272");
                string[] keys = macro[0].Split(' ');
                List<Keys> makaron = new List<Keys>();
                foreach (string sKey in keys)
                {
                    try
                    {
                        Keys key = (Keys)Enum.Parse(typeof(Keys), sKey.Trim(), true);
                        makaron.Add(key);
                    }
                    catch
                    {

                    }
                }
                KeysDown(makaron);
            }
            else if(!IsKeyPushedDown(Keys.F13) && btn1Held)
            {
                btn1Held = false;
                button1.BackColor = ColorTranslator.FromHtml("#205295");
                string[] keys = macro[0].Split(' ');
                List<Keys> makaron = new List<Keys>();
                foreach (string sKey in keys)
                {
                    try
                    {
                        Keys key = (Keys)Enum.Parse(typeof(Keys), sKey.Trim(), true);
                        makaron.Add(key);
                    }
                    catch
                    {

                    }
                }
                KeysUp(makaron);
            }

            if (IsKeyPushedDown(Keys.F14) && !btn2Held)
            {
                btn2Held = true;
                button2.BackColor = ColorTranslator.FromHtml("#144272");
                string[] keys = macro[1].Split(' ');
                List<Keys> makaron = new List<Keys>();
                foreach (string sKey in keys)
                {
                    try
                    {
                        Keys key = (Keys)Enum.Parse(typeof(Keys), sKey.Trim(), true);
                        makaron.Add(key);
                    }
                    catch
                    {

                    }
                }
                KeysDown(makaron);
            }
            else if (!IsKeyPushedDown(Keys.F14) && btn2Held)
            {
                btn2Held = false;
                button2.BackColor = ColorTranslator.FromHtml("#205295");
                string[] keys = macro[1].Split(' ');
                List<Keys> makaron = new List<Keys>();
                foreach (string sKey in keys)
                {
                    try
                    {
                        Keys key = (Keys)Enum.Parse(typeof(Keys), sKey.Trim(), true);
                        makaron.Add(key);
                    }
                    catch
                    {

                    }
                }
                KeysUp(makaron);
            }

            if (IsKeyPushedDown(Keys.F21) && !btn3Held)
            {
                btn3Held= true;
                button3.BackColor = ColorTranslator.FromHtml("#144272");
                string[] keys = macro[2].Split(' ');
                List<Keys> makaron = new List<Keys>();
                foreach (string sKey in keys)
                {
                    try
                    {
                        Keys key = (Keys)Enum.Parse(typeof(Keys), sKey.Trim(), true);
                        makaron.Add(key);
                    }
                    catch
                    {

                    }
                }
                KeysDown(makaron);
            }
            else if (!IsKeyPushedDown(Keys.F21) && btn3Held)
            {
                btn3Held= false;
                button3.BackColor = ColorTranslator.FromHtml("#205295");
                string[] keys = macro[2].Split(' ');
                List<Keys> makaron = new List<Keys>();
                foreach (string sKey in keys)
                {
                    try
                    {
                        Keys key = (Keys)Enum.Parse(typeof(Keys), sKey.Trim(), true);
                        makaron.Add(key);
                    }
                    catch
                    {

                    }
                }
                KeysUp(makaron);
            }

            if (IsKeyPushedDown(Keys.F15) && !btn4Held)
            {
                btn4Held= true;
                button4.BackColor = ColorTranslator.FromHtml("#144272");
                string[] keys = macro[3].Split(' ');
                List<Keys> makaron = new List<Keys>();
                foreach (string sKey in keys)
                {
                    try
                    {
                        Keys key = (Keys)Enum.Parse(typeof(Keys), sKey.Trim(), true);
                        makaron.Add(key);
                    }
                    catch
                    {

                    }
                }
                KeysDown(makaron);
            }
            else if (!IsKeyPushedDown(Keys.F15) && btn4Held)
            {
                btn4Held= false;
                button4.BackColor = ColorTranslator.FromHtml("#205295");
                string[] keys = macro[3].Split(' ');
                List<Keys> makaron = new List<Keys>();
                foreach (string sKey in keys)
                {
                    try
                    {
                        Keys key = (Keys)Enum.Parse(typeof(Keys), sKey.Trim(), true);
                        makaron.Add(key);
                    }
                    catch
                    {

                    }
                }
                KeysUp(makaron);
            }
            if (IsKeyPushedDown(Keys.F16) && !btn5Held)
            {
                btn5Held= true;
                button5.BackColor = ColorTranslator.FromHtml("#144272");
                string[] keys = macro[4].Split(' ');
                List<Keys> makaron = new List<Keys>();
                foreach (string sKey in keys)
                {
                    try
                    {
                        Keys key = (Keys)Enum.Parse(typeof(Keys), sKey.Trim(), true);
                        makaron.Add(key);
                    }
                    catch
                    {

                    }
                }
                KeysDown(makaron);
            }
            else if (!IsKeyPushedDown(Keys.F16) && btn5Held)
            {
                btn5Held= false;
                button5.BackColor = ColorTranslator.FromHtml("#205295");
                string[] keys = macro[4].Split(' ');
                List<Keys> makaron = new List<Keys>();
                foreach (string sKey in keys)
                {
                    try
                    {
                        Keys key = (Keys)Enum.Parse(typeof(Keys), sKey.Trim(), true);
                        makaron.Add(key);
                    }
                    catch
                    {

                    }
                }
                KeysUp(makaron);
            }
            if (IsKeyPushedDown(Keys.F20) && !btn6Held)
            {  
                btn6Held= true;
                button6.BackColor = ColorTranslator.FromHtml("#144272");
                string[] keys = macro[5].Split(' ');
                List<Keys> makaron = new List<Keys>();
                foreach (string sKey in keys)
                {
                    try
                    {
                        Keys key = (Keys)Enum.Parse(typeof(Keys), sKey.Trim(), true);
                        makaron.Add(key);
                    }
                    catch
                    {

                    }
                }
                KeysDown(makaron);
            }
            else if (!IsKeyPushedDown(Keys.F20) && btn6Held)
            {
                btn6Held= false;
                button6.BackColor = ColorTranslator.FromHtml("#205295");
                string[] keys = macro[5].Split(' ');
                List<Keys> makaron = new List<Keys>();
                foreach (string sKey in keys)
                {
                    try
                    {
                        Keys key = (Keys)Enum.Parse(typeof(Keys), sKey.Trim(), true);
                        makaron.Add(key);
                    }
                    catch
                    {

                    }
                }
                KeysUp(makaron);
            }
            if (IsKeyPushedDown(Keys.F17) && !btn7Held)
            {
                btn7Held= true;
                button7.BackColor = ColorTranslator.FromHtml("#144272");
                string[] keys = macro[6].Split(' ');
                List<Keys> makaron = new List<Keys>();
                foreach (string sKey in keys)
                {
                    try
                    {
                        Keys key = (Keys)Enum.Parse(typeof(Keys), sKey.Trim(), true);
                        makaron.Add(key);
                    }
                    catch
                    {

                    }
                }
                KeysDown(makaron);
            }
            else if (!IsKeyPushedDown(Keys.F17) && btn7Held)
            {
                btn7Held= false;
                button7.BackColor = ColorTranslator.FromHtml("#205295");
                string[] keys = macro[6].Split(' ');
                List<Keys> makaron = new List<Keys>();
                foreach (string sKey in keys)
                {
                    try
                    {
                        Keys key = (Keys)Enum.Parse(typeof(Keys), sKey.Trim(), true);
                        makaron.Add(key);
                    }
                    catch
                    {

                    }
                }
                KeysUp(makaron);
            }
            if (IsKeyPushedDown(Keys.F18) && !btn8Held)
            {
                btn8Held= true;
                button8.BackColor = ColorTranslator.FromHtml("#144272");
                string[] keys = macro[7].Split(' ');
                List<Keys> makaron = new List<Keys>();
                foreach (string sKey in keys)
                {
                    try
                    {
                        Keys key = (Keys)Enum.Parse(typeof(Keys), sKey.Trim(), true);
                        makaron.Add(key);
                    }
                    catch
                    {

                    }
                }
                KeysDown(makaron);
            }
            else if (!IsKeyPushedDown(Keys.F18) && btn8Held)
            {
                btn8Held= false;
                button8.BackColor = ColorTranslator.FromHtml("#205295");
                string[] keys = macro[7].Split(' ');
                List<Keys> makaron = new List<Keys>();
                foreach (string sKey in keys)
                {
                    try
                    {
                        Keys key = (Keys)Enum.Parse(typeof(Keys), sKey.Trim(), true);
                        makaron.Add(key);
                    }
                    catch
                    {

                    }
                }
                KeysUp(makaron);
            }
            if (IsKeyPushedDown(Keys.F19) && !btn9Held)
            {
                btn9Held= true;
                button9.BackColor = ColorTranslator.FromHtml("#144272");
                string[] keys = macro[8].Split(' ');
                List<Keys> makaron = new List<Keys>();
                foreach (string sKey in keys)
                {
                    try
                    {
                        Keys key = (Keys)Enum.Parse(typeof(Keys), sKey.Trim(), true);
                        makaron.Add(key);
                    }
                    catch
                    {

                    }
                }
                KeysDown(makaron);
            }
            else if (!IsKeyPushedDown(Keys.F19) && btn9Held)
            {
                btn9Held= false;
                button9.BackColor = ColorTranslator.FromHtml("#205295");
                string[] keys = macro[8].Split(' ');
                List<Keys> makaron = new List<Keys>();
                foreach (string sKey in keys)
                {
                    try
                    {
                        Keys key = (Keys)Enum.Parse(typeof(Keys), sKey.Trim(), true);
                        makaron.Add(key);
                    }
                    catch
                    {

                    }
                }
                KeysUp(makaron);
            }
        }
        
        private void button11_Click(object sender, EventArgs e)
        {
            if(recording == false)
            {
                button11.Text = "Cancel";
                recording = true;
                textBox1.Enabled = true;
                textBox1.Focus();
                textBox1.Text = "";
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;
            }
            else
            {
                button11.Text = "Record macro";
                recording = false;
                textBox1.Enabled = false;
                textBox1.Text = macro[selectedButton - 1];
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if(recording)
            {
                button11.Text = "Record macro";
                recording = false;
                textBox1.Enabled = false;
                macro[selectedButton - 1] = textBox1.Text;
                if (!File.Exists("macros.conf"))
                {
                    File.Create("macros.conf");
                }


                using (StreamWriter sw = new StreamWriter("macros.conf"))
                {
                    for(int i = 0; i < macro.Length; i++)
                    {
                        sw.WriteLine(macro[i]);
                    }
                }
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            selectedButton = 1;
            label1.Text = $"Selected Key: {selectedButton}";
            textBox1.Text = macro[selectedButton - 1];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            selectedButton = 2;
            label1.Text = $"Selected Key: {selectedButton}";
            textBox1.Text = macro[selectedButton - 1];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            selectedButton = 3;
            label1.Text = $"Selected Key: {selectedButton}";
            textBox1.Text = macro[selectedButton - 1];
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            selectedButton = 4;
            label1.Text = $"Selected Key: {selectedButton}";
            textBox1.Text = macro[selectedButton - 1];
        }

        private void button5_Click(object sender, EventArgs e)
        {
            selectedButton = 5;
            label1.Text = $"Selected Key: {selectedButton}";
            textBox1.Text = macro[selectedButton - 1];
        }

        private void button6_Click(object sender, EventArgs e)
        {
            selectedButton = 6;
            label1.Text = $"Selected Key: {selectedButton}";
            textBox1.Text = macro[selectedButton - 1];
        }

        private void button7_Click(object sender, EventArgs e)
        {
            selectedButton = 7;
            label1.Text = $"Selected Key: {selectedButton}";
            textBox1.Text = macro[selectedButton - 1];
        }

        private void button8_Click(object sender, EventArgs e)
        {
            selectedButton = 8;
            label1.Text = $"Selected Key: {selectedButton}";
            textBox1.Text = macro[selectedButton - 1];
        }

        private void button9_Click(object sender, EventArgs e)
        {
            selectedButton = 9;
            label1.Text = $"Selected Key: {selectedButton}";
            textBox1.Text = macro[selectedButton - 1];
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //if the form is minimized  
            //hide it from the task bar  
            //and show the system tray icon (represented by the NotifyIcon control)  
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.keys?redirectedfrom=MSDN&view=windowsdesktop-7.0#fields");
        }
    }
}
