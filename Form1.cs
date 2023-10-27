using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

namespace _0101_час_іде
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        public static extern int SetWindowText(IntPtr hWnd, string text);

        private DateTime startTime;
        private System.Windows.Forms.Timer timer;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            startTime = DateTime.Now;

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += UpdateNotepadTitle;
            timer.Start();

        }

        private void UpdateNotepadTitle(object sender, EventArgs e)
        {
            IntPtr notepadHandle = FindWindow("Notepad", null);

            if (notepadHandle != IntPtr.Zero)
            {
                // Розраховуємо час, який пройшов з моменту запуску програми
                TimeSpan elapsedTime = DateTime.Now - startTime;

                // Оновлюємо заголовок вікна Блокнота з поточним часом
                SetWindowText(notepadHandle, $"Час роботи пограми: {elapsedTime.ToString(@"hh\:mm\:ss")}");
            }
        }
    }
}