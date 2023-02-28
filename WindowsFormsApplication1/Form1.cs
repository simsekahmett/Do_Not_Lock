using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IWshRuntimeLibrary;
using System.Runtime.InteropServices;
using File = System.IO.File;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        //dirName = C:\Users\USERNAME\AppData\Roaming\Do_Not_Lock
        public String dirName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Do_Not_Lock";

        public Form1()
        {
            InitializeComponent();
        }

        //importing user32.dll for sending key command to machine
        //Key.Send function is not preventing machine to not locked
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);
        const uint KEYEVENTF_KEYUP = 0x2;

         
        //Creating shortcut to startup directory
        private void CreateShortcut()
        {
             string link = Environment.GetFolderPath( Environment.SpecialFolder.Startup ) 
                            + Path.DirectorySeparatorChar + Application.ProductName + ".lnk";
            var shell = new WshShell();
            var shortcut = shell.CreateShortcut( link ) as IWshShortcut;
            shortcut.TargetPath = Application.ExecutablePath;
            shortcut.WorkingDirectory = Application.StartupPath;
            //shortcut...
            shortcut.Save();
        }

        //check the startup setting from C:\Users\USERNAME\AppData\Roaming\Do_Not_Lock\settings.txt
        private void checkStartup()
        {
            string[] startupCheck = System.IO.File.ReadAllLines(dirName + "\\settings.txt");
            if(startupCheck[0] == "true")
            {
                checkBox1.Checked = true;
            }
            if(startupCheck[0] == "false")
            {
                checkBox1.Checked = false;
            }
        }

        //Create folder for Do_Not_Lock save file
        public void createFolder()
        {
            //Check that the directory exists or not
            if (!Directory.Exists(dirName))
            {
                Directory.CreateDirectory(dirName); //if not, create it
                using (System.IO.StreamWriter setting = new System.IO.StreamWriter(dirName + "\\settings.txt", true))
                {
                    //set startup setting to true default
                    setting.WriteLine("true");
                    setting.Close();
                }
            }
                

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            createFolder();
            CreateShortcut();
            checkStartup();
        }

        //minimize the form to system tray
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(500);
                this.Hide();
            }

            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible = false;
            }
        }

        //double click on notification will show the form
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        bool check = false;
        private void button1_Click(object sender, EventArgs e)
        {
            //if Do_Not_Lock is activated;
            if(check == false)
            {
                button1.Text = "Activated";
                groupBox1.Text = "\"Do_Not_Lock\" is active";
                notifyIcon1.Text = "\"Do_Not_Lock\" is active";
                timer1.Enabled = true;
				timer1_Tick(sender, e);
                check = true;
            }
            //if Do_Not_Lock is not activated;
            else
            {
                button1.Text = "Activate";
                groupBox1.Text = "\"Do_Not_Lock\" is not active";
                notifyIcon1.Text = "\"Do_Not_Lock\" is not active";
                timer1.Enabled = false;
                check = false;
            }
        }
        
        //Run on startup setting checkbox
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
                //if checked, it will run on startup automatically
                if (checkBox1.Checked == true)
                {
                    //this setting is saved in text file
                    //if checkbox is checked, it will write "true" to text file
                    System.IO.File.Delete(dirName + "\\settings.txt");
                    using (System.IO.StreamWriter setting = new System.IO.StreamWriter(dirName + "\\settings.txt", true))
                        setting.WriteLine("true");
                }
                else
                {
                    //if checkbox is not checked, it will write "false" to text file
                    System.IO.File.Delete(dirName + "\\settings.txt");
                    using (System.IO.StreamWriter setting = new System.IO.StreamWriter(dirName + "\\settings.txt", true))
                        setting.WriteLine("false");
                }

        }

        //timer tick function
        private void timer1_Tick(object sender, EventArgs e)
        {
            //send NumLock key to machine for twice,
            //It is just sending key press twice so that you'll not feel anything
            keybd_event((byte)Keys.NumLock, 0, 0, 0);
            keybd_event((byte)Keys.NumLock, 0, KEYEVENTF_KEYUP, 0);
            keybd_event((byte)Keys.NumLock, 0, 0, 0);
            keybd_event((byte)Keys.NumLock, 0, KEYEVENTF_KEYUP, 0);
        }
    }
}
