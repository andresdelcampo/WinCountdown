using System.Configuration;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WinCountdown
{
    public partial class FormCountdown : Form
    {
        private Stopwatch stopWatch = new Stopwatch();
        private TimeSpan initialTime = TimeSpan.FromSeconds(5);
        private TimeSpan pausedTimeRemaining = TimeSpan.Zero;
        private bool isPaused = false;
        private bool isRunning = false;
        private TimeSpan? lastShortcutTime = null;

        // P/Invoke for RegisterHotKey
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        // Modifiers
        private const uint MOD_ALT = 0x0001;

        // Hotkey IDs
        private const int HOTKEY_ALT_0 = 100;
        private const int HOTKEY_ALT_1 = 101;
        private const int HOTKEY_ALT_2 = 102;
        private const int HOTKEY_ALT_3 = 103;
        private const int HOTKEY_ALT_4 = 104;
        private const int HOTKEY_ALT_5 = 105;
        private const int HOTKEY_ALT_6 = 106;
        private const int HOTKEY_ALT_7 = 107;
        private const int HOTKEY_ALT_8 = 108;
        private const int HOTKEY_ALT_9 = 109;
        private const int HOTKEY_ALT_S = 110;
        private const int HOTKEY_ALT_PLUS = 111;
        private const int HOTKEY_ALT_MINUS = 112;
        private const int HOTKEY_ALT_R = 113;
        private const int HOTKEY_ALT_H = 114;

        public FormCountdown()
        {
            InitializeComponent();
        }

        private void FormCountdown_Load(object sender, EventArgs e)
        {
            SetInBottomRightCorner();
            SetInitialTime();
            UpdateCountdownLabel();
            RegisterHotkeys();
            InitializeTrayIcon();

            StartTimer();
        }

        private void InitializeTrayIcon()
        {
            // Try to load icon from file, otherwise use application icon
            try
            {
                if (File.Exists("Countdown.png"))
                {
                    using (var img = Image.FromFile("Countdown.png"))
                    {
                        notifyIcon.Icon = Icon.FromHandle(((Bitmap)img).GetHicon());
                    }
                }
                else
                {
                    notifyIcon.Icon = SystemIcons.Application;
                }
            }
            catch
            {
                notifyIcon.Icon = SystemIcons.Application;
            }

            UpdateTrayTooltip();
        }

        private void UpdateTrayTooltip()
        {
            string status = isPaused ? " (Paused)" : isRunning ? " (Running)" : " (Stopped)";
            notifyIcon.Text = $"WinCountdown: {labelCountdown.Text}{status}";
        }

        private void RegisterHotkeys()
        {
            // Register number keys 0-9 (Virtual key codes: 0x30-0x39)
            RegisterHotKey(this.Handle, HOTKEY_ALT_0, MOD_ALT, 0x30);
            RegisterHotKey(this.Handle, HOTKEY_ALT_1, MOD_ALT, 0x31);
            RegisterHotKey(this.Handle, HOTKEY_ALT_2, MOD_ALT, 0x32);
            RegisterHotKey(this.Handle, HOTKEY_ALT_3, MOD_ALT, 0x33);
            RegisterHotKey(this.Handle, HOTKEY_ALT_4, MOD_ALT, 0x34);
            RegisterHotKey(this.Handle, HOTKEY_ALT_5, MOD_ALT, 0x35);
            RegisterHotKey(this.Handle, HOTKEY_ALT_6, MOD_ALT, 0x36);
            RegisterHotKey(this.Handle, HOTKEY_ALT_7, MOD_ALT, 0x37);
            RegisterHotKey(this.Handle, HOTKEY_ALT_8, MOD_ALT, 0x38);
            RegisterHotKey(this.Handle, HOTKEY_ALT_9, MOD_ALT, 0x39);

            // Register control keys
            RegisterHotKey(this.Handle, HOTKEY_ALT_S, MOD_ALT, 0x53); // S
            RegisterHotKey(this.Handle, HOTKEY_ALT_PLUS, MOD_ALT, 0xBB); // Plus/Equal key
            RegisterHotKey(this.Handle, HOTKEY_ALT_MINUS, MOD_ALT, 0xBD); // Minus key
            RegisterHotKey(this.Handle, HOTKEY_ALT_R, MOD_ALT, 0x52); // R
            RegisterHotKey(this.Handle, HOTKEY_ALT_H, MOD_ALT, 0x48); // H
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;

            if (m.Msg == WM_HOTKEY)
            {
                int hotkeyId = m.WParam.ToInt32();
                HandleHotkey(hotkeyId);
            }

            base.WndProc(ref m);
        }

        private void HandleHotkey(int hotkeyId)
        {
            switch (hotkeyId)
            {
                case HOTKEY_ALT_0:
                    StartTimerWithMinutes(10);
                    break;
                case HOTKEY_ALT_1:
                    StartTimerWithMinutes(1);
                    break;
                case HOTKEY_ALT_2:
                    StartTimerWithMinutes(2);
                    break;
                case HOTKEY_ALT_3:
                    StartTimerWithMinutes(3);
                    break;
                case HOTKEY_ALT_4:
                    StartTimerWithMinutes(4);
                    break;
                case HOTKEY_ALT_5:
                    StartTimerWithMinutes(5);
                    break;
                case HOTKEY_ALT_6:
                    StartTimerWithMinutes(6);
                    break;
                case HOTKEY_ALT_7:
                    StartTimerWithMinutes(7);
                    break;
                case HOTKEY_ALT_8:
                    StartTimerWithMinutes(8);
                    break;
                case HOTKEY_ALT_9:
                    StartTimerWithMinutes(9);
                    break;
                case HOTKEY_ALT_S:
                    ToggleStartPauseResume();
                    break;
                case HOTKEY_ALT_PLUS:
                    AddMinutes(5);
                    break;
                case HOTKEY_ALT_MINUS:
                    SubtractMinutes(1);
                    break;
                case HOTKEY_ALT_R:
                    ResetTimer();
                    break;
                case HOTKEY_ALT_H:
                    HideWindow();
                    break;
            }
        }

        private void StartTimerWithMinutes(int minutes)
        {
            StopTimer();
            initialTime = TimeSpan.FromMinutes(minutes);
            initialTime = initialTime.Add(TimeSpan.FromSeconds(1));     // To see a full number of minutes when starts
            lastShortcutTime = initialTime; // Remember this shortcut time
            StartTimer();
            ShowWindow();
        }

        private void StartTimer()
        {
            stopWatch.Reset();
            stopWatch.Start();
            timer.Start();
            isRunning = true;
            isPaused = false;
            UpdateCountdownLabel();
        }

        private void StopTimer()
        {
            stopWatch.Stop();
            timer.Stop();
            isRunning = false;
            isPaused = false;
        }

        private void PauseTimer()
        {
            if (isRunning && !isPaused)
            {
                stopWatch.Stop();
                timer.Stop();
                pausedTimeRemaining = initialTime - stopWatch.Elapsed;
                isPaused = true;
            }
        }

        private void ResumeTimer()
        {
            if (isPaused)
            {
                initialTime = pausedTimeRemaining;
                stopWatch.Reset();
                stopWatch.Start();
                timer.Start();
                isPaused = false;
            }
        }

        private void ToggleStartPauseResume()
        {
            if (!isRunning)
            {
                StartTimer();
                ShowWindow();
            }
            else if (isPaused)
            {
                ResumeTimer();
            }
            else
            {
                PauseTimer();
            }
        }

        private void AddMinutes(int minutes)
        {
            if (isPaused)
            {
                pausedTimeRemaining = pausedTimeRemaining.Add(TimeSpan.FromMinutes(minutes));
                UpdateCountdownLabel();
            }
            else if (isRunning)
            {
                TimeSpan currentRemaining = initialTime - stopWatch.Elapsed;
                initialTime = currentRemaining.Add(TimeSpan.FromMinutes(minutes));
                stopWatch.Reset();
                stopWatch.Start();
                UpdateCountdownLabel();
            }
            ShowWindow();
        }

        private void SubtractMinutes(int minutes)
        {
            if (isPaused)
            {
                pausedTimeRemaining = pausedTimeRemaining.Subtract(TimeSpan.FromMinutes(minutes));
                if (pausedTimeRemaining < TimeSpan.Zero)
                    pausedTimeRemaining = TimeSpan.Zero;
                UpdateCountdownLabel();
            }
            else if (isRunning)
            {
                TimeSpan currentRemaining = initialTime - stopWatch.Elapsed;
                TimeSpan newRemaining = currentRemaining.Subtract(TimeSpan.FromMinutes(minutes));
                if (newRemaining < TimeSpan.Zero)
                    newRemaining = TimeSpan.Zero;

                initialTime = newRemaining;
                stopWatch.Reset();
                stopWatch.Start();
                UpdateCountdownLabel();
            }
            ShowWindow();
        }

        private void ResetTimer()
        {
            StopTimer();

            // If a shortcut was used, reset to that time; otherwise use config
            if (lastShortcutTime.HasValue)
            {
                initialTime = lastShortcutTime.Value;
            }
            else
            {
                SetInitialTime();
            }

            UpdateCountdownLabel();
            StartTimer();
            ShowWindow();
        }

        private void ShowWindow()
        {
            if (!this.Visible)
                this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void HideWindow()
        {
            this.Hide();
        }

        protected override void Dispose(bool disposing)
        {
            // Unregister hotkeys
            for (int i = HOTKEY_ALT_0; i <= HOTKEY_ALT_H; i++)
            {
                UnregisterHotKey(this.Handle, i);
            }

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            UpdateCountdownLabel();
            UpdateTrayTooltip();

            if (labelCountdown.Text == "00:00:00" || labelCountdown.Text == "00:00")
            {
                stopWatch.Stop();
                timer.Stop();
                BlinkBeepAndExit();
            }
        }

        // Tray icon event handlers
        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            if (this.Visible)
                HideWindow();
            else
                ShowWindow();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowWindow();
        }

        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideWindow();
        }

        private void startPauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleStartPauseResume();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetTimer();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SetInitialTime()
        {
            var appSettings = ConfigurationManager.AppSettings;
            int hours = int.Parse(appSettings["InitialHours"] ?? "0");
            int minutes = int.Parse(appSettings["InitialMinutes"] ?? "5");
            int seconds = int.Parse(appSettings["InitialSeconds"] ?? "0");

            initialTime = new TimeSpan(hours, minutes, seconds);
        }

        private void UpdateCountdownLabel()
        {
            TimeSpan timeToDisplay;

            if (isPaused)
            {
                timeToDisplay = pausedTimeRemaining;
            }
            else
            {
                timeToDisplay = initialTime - stopWatch.Elapsed;
            }

            // Prevent negative display
            if (timeToDisplay < TimeSpan.Zero)
                timeToDisplay = TimeSpan.Zero;

            string timeFormat = (timeToDisplay.Hours > 0) ? @"hh\:mm\:ss" : @"mm\:ss";
            labelCountdown.Text = timeToDisplay.ToString(timeFormat);
        }

        private void SetInBottomRightCorner()
        {
            Rectangle workingArea = Screen.GetWorkingArea(this);
            Location = new Point(workingArea.Right - Size.Width,
                                 workingArea.Bottom - Size.Height);
        }

        private async void BlinkBeepAndExit()
        {
            var appSettings = ConfigurationManager.AppSettings;
            int secondsOnZero = int.Parse(appSettings["SecondsOnZero"] ?? "30");
            bool beep = bool.Parse(appSettings["Beep"] ?? "false");

            // Give sometime to show 0 before blinking
            await Task.Delay(1000);

            for (int i=0; i<2*secondsOnZero; i++)
            {
                if (beep && i % 2 == 1)
                    Console.Beep(5000, 500);
                else
                    await Task.Delay(500);

                labelCountdown.Visible = (i % 2 == 1);
            }

            // Hide window instead of exiting
            labelCountdown.Visible = true;
            HideWindow();
        }
    }
}