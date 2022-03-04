using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using WindowsInput.Native;
using WindowsInput;
using KeyboardHookManager;
using Utilities;
using InputManager;





namespace LegoCode
{
    public partial class Form1 : Form
    {
        InputSimulator sim = new InputSimulator();
        globalKeyboardHook gkh = new globalKeyboardHook();

        public Form1()
        {
            InitializeComponent();
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();


        //----
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        public static extern IntPtr PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        /*
        public class MyProgram
		{
            [DllImport("user32.dll", CharSet = CharSet.Unicode)]
            public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
 
            [DllImport("user32.dll")]
            public static extern IntPtr PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
 
            public static void Keyboard()
            {
                IntPtr WindowName = FindWindow(null, "Battlefield 4");
                if (WindowName == IntPtr.Zero)
                {
                    MessageBox.Show("Game is not running."); return;
                }
 
                PostMessage(WindowName, 0x100, (IntPtr)Keys.W, IntPtr.Zero);
                System.Threading.Thread.Sleep(100);
                PostMessage(WindowName, 0x101, (IntPtr)Keys.W, IntPtr.Zero);
            }
        }
         */

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
            gkh.HookedKeys.Add(Keys.A);
            gkh.HookedKeys.Add(Keys.B);
            gkh.KeyDown += new KeyEventHandler(gkh_KeyDown);
            gkh.KeyUp += new KeyEventHandler(gkh_KeyUp);
            */
            }
        void gkh_KeyUp(object sender, KeyEventArgs e)
        {
            lstLog.Items.Add("Up\t" + e.KeyCode.ToString());
            e.Handled = true;
        }

        void gkh_KeyDown(object sender, KeyEventArgs e)
        {
            lstLog.Items.Add("Down\t" + e.KeyCode.ToString());
            e.Handled = true;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //var sKey = sim.Keyboard;


            //sim.Keyboard.KeyPress()
            //sim.SimulateKeyPress(VirtualKeyCode.SPACE);

            //cToCount("X");
            //sKey.Sleep(10000);
            Thread.Sleep(15000);
            label3.Text = "Running code now!";

            string[] codeArray = new string[] {
              "7VNLJT",
            //"VK3TP3"


            };

            //Thread.Sleep(20000);
            //label1.Text = "Started";
            

            foreach (var code in codeArray)
            {
                // Some games use arrows lol!
                Console.WriteLine("Printing letters in name: {0}", code);
                listBox1.Items.Add(code);
                foreach (var letter in code)
                {
                    //Console.WriteLine(letter);
                    cToCount(letter.ToString());
                    
                }
                Keyboard.KeyDown(Keys.Enter);
                Thread.Sleep(100);
                Keyboard.KeyUp(Keys.Enter);

            }
            //codeUp(1);
        }
        public void codeUp(int n)
        {
            
            Console.WriteLine("-------------");
            for (int i = 1; i <= n; i++)
            {      
                Console.WriteLine(i);

            }
            
        }
        public void gokeyUp(int count)
        {
            //SendKeys.Send("{UP}");
            for (int i = 1; i <= count; i++)
            {
                // Otherwise W
                Console.WriteLine("Keyup: " + i);
                
                Keyboard.KeyDown(Keys.Up);
                Thread.Sleep(100);
                Keyboard.KeyUp(Keys.Up);
                Thread.Sleep(100);



            }    
            Keyboard.KeyDown(Keys.Right);
            Thread.Sleep(100);
            Keyboard.KeyUp(Keys.Right);
            Thread.Sleep(100);


        }
        public void gokeyDown(int count)
        {
            for (int i = 1; i <= count; i++)
            {
                //S otherwise
                Console.WriteLine("Keydown: " + i);
                
                Keyboard.KeyDown(Keys.Down);
                Thread.Sleep(100);
                Keyboard.KeyUp(Keys.Down);
                Thread.Sleep(100);


            }
            
            Keyboard.KeyDown(Keys.Right);
            Thread.Sleep(100);
            Keyboard.KeyUp(Keys.Right);
            Thread.Sleep(100);

        }
        public void cToCount(string letter)
        {
            
            
            switch (letter)
            {
                case "0":
                    Console.WriteLine("-10");
                    gokeyDown(10);
                    break;
                case "1":
                    Console.WriteLine("-9");
                    gokeyDown(9);
                    break;
                case "2":
                    Console.WriteLine("-8");
                    gokeyDown(8);
                    break;
                case "3":
                    Console.WriteLine("-7");
                    gokeyDown(7);
                    break;
                case "4":
                    Console.WriteLine("-6");
                    gokeyDown(6);
                    break;
                case "5":
                    Console.WriteLine("-5");
                    gokeyDown(5);
                    break;
                case "6":
                    Console.WriteLine("-4");
                    gokeyDown(4);
                    break;
                case "7":
                    Console.WriteLine("-3");
                    gokeyDown(3);
                    break;
                case "8":
                    Console.WriteLine("-2");
                    gokeyDown(2);
                    break;
                case "9":
                    // Arrow Down
                    Console.WriteLine("-1");
                    gokeyDown(1);
                    break;
                case "A":
                    Console.WriteLine("0");
                    Keyboard.KeyDown(Keys.D);
                    Thread.Sleep(100);
                    Keyboard.KeyUp(Keys.D);
                    break;
                    // Arrow Up
                case "B":
                    Console.WriteLine("1");
                    gokeyUp(1);
                    break;
                case "C":
                    Console.WriteLine("2");
                    gokeyUp(2);
                    break;
                case "D":
                    Console.WriteLine("3");
                    gokeyUp(3);
                    break;
                case "E":
                    Console.WriteLine("4");
                    gokeyUp(4);
                    break;
                case "F":
                    Console.WriteLine("5");
                    gokeyUp(5);
                    break;
                case "G":
                    Console.WriteLine("6");
                    gokeyUp(6);
                    break;
                case "H":
                    Console.WriteLine("7");
                    gokeyUp(7);
                    break;
                case "I":
                    Console.WriteLine("8");
                    gokeyUp(8);
                    break;
                case "J":
                    Console.WriteLine("9");
                    gokeyUp(9);
                    break;
                case "K":
                    Console.WriteLine("10");
                    gokeyUp(10);
                    break;
                case "L":
                    Console.WriteLine("11");
                    gokeyUp(11);
                    break;
                case "M":
                    Console.WriteLine("12");
                    gokeyUp(12);
                    break;
                case "N":
                    Console.WriteLine("13");
                    gokeyUp(13);
                    break;
                case "O":
                    Console.WriteLine("14");
                    gokeyUp(14);
                    break;
                case "P":
                    Console.WriteLine("15");
                    gokeyUp(15);
                    break;
                case "Q":
                    Console.WriteLine("16");
                    gokeyUp(16);
                    break;
                case "R":
                    Console.WriteLine("17");
                    gokeyUp(17);
                    break;
                case "S":
                    Console.WriteLine("18");
                    gokeyUp(18);
                    break;
                case "T":
                    Console.WriteLine("19");
                    gokeyUp(19);
                    break;
                case "U":
                    Console.WriteLine("20");
                    gokeyUp(20);
                    break;
                case "V":
                    Console.WriteLine("21");
                    gokeyUp(21);
                    break;
                case "W":
                    Console.WriteLine("22");
                    gokeyUp(22);
                    break;
                case "X":
                    Console.WriteLine("23");
                    gokeyUp(23);
                    break;
                case "Y":
                    Console.WriteLine("23");
                    gokeyUp(24);
                    break;







            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0) {
                listBox1.Items.Add(textBox1.Text);
            }
           
        }
    }
}
