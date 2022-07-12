using System.Configuration;
using System.Diagnostics;

namespace WinCountdown
{
    public partial class FormCountdown : Form
    {
        private Stopwatch stopWatch = new Stopwatch();
        private TimeSpan initialTime = TimeSpan.FromSeconds(5);

        public FormCountdown()
        {
            InitializeComponent();
        }

        private void FormCountdown_Load(object sender, EventArgs e)
        {
            SetInBottomRightCorner();
            SetInitialTime();
            UpdateCountdownLabel();

            stopWatch.Start();
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            UpdateCountdownLabel();
            
            if (labelCountdown.Text == "00:00:00" || labelCountdown.Text == "00:00")
            {
                stopWatch.Stop();
                timer.Stop();
                BlinkBeepAndExit();
            }
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
            TimeSpan elapsed = initialTime - stopWatch.Elapsed;
            string timeFormat = (initialTime.Hours > 0)? @"hh\:mm\:ss" : @"mm\:ss";
            labelCountdown.Text = elapsed.ToString(timeFormat);
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

            Application.Exit();
        }
    }
}