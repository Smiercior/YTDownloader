using System;
using System.Windows.Forms;
using YTDownloader;
using System.Drawing;

namespace YTDownloader_Communicats
{

    internal class Communicats
    {
        Label label1;
        static EventHandler ev;
        static System.Windows.Forms.Timer myTimer;
        public bool done = false;
        static string[,] communicats;
        static int lang;
        static bool blockButtons = false;
        static Form1 form1;

        public Communicats(Label l1, string[,] com, int l, Form1 f1)
        {
            label1 = l1;
            myTimer = new System.Windows.Forms.Timer();
            communicats = com;
            lang = l;
            form1 = f1;
        }

        private static void TimerRaised(Object myObject, EventArgs myEventArgs, Label label1) // Timer for cleaning label1
        {
            myTimer.Stop();
            myTimer.Tick -= ev;
            label1.Text = "";
        }

        private static void WaitTimer(Object myObject, EventArgs myEventArgs, int waitType, Label label1, bool done) // Timer for blocking all buttons and show communicat until videos is found or downloaded
        {
            if (blockButtons == false) // Block all necessari buttons
            {
                form1.ButtonsState(false);
                blockButtons = true;
            }

            label1.ForeColor = Color.Yellow;
            switch (waitType)
            {
                case 1: // Find videos
                    {
                        if (!label1.Text.Contains(communicats[lang, 0]) || label1.Text.Length > (communicats[lang, 0] + "...").Length - 1) // Searching
                        {
                            label1.Text = communicats[lang, 0];
                        }
                        else if (label1.Text.Contains(communicats[lang, 0]))
                        {
                            label1.Text += ".";
                        }
                        break;
                    }

                case 2: // Download videos
                    {
                        if (!label1.Text.Contains(communicats[lang, 1]) || label1.Text.Length > (communicats[lang, 1] + "...").Length - 1) // Downloading
                        {
                            label1.Text = communicats[lang, 1];
                        }
                        else if (label1.Text.Contains(communicats[lang, 1]))
                        {
                            label1.Text += ".";
                        }
                        break;
                    }

            }

            if (done == true) // If task id completed
            {
                blockButtons = false;
                form1.ButtonsState(true);

                myTimer.Stop();
                myTimer.Tick -= ev;
                label1.Text = "";
            }

        }
        public void EndEvent()
        {
            label1.Text = "";
            myTimer.Tick -= ev;
        }

        public void ClearCommunicatAfterTime(int time) // Clear label1 after some time, time in sec
        {
            ev = new EventHandler((sender, e) => TimerRaised(sender, e, label1)); // Set timer for comunnicat
            myTimer.Tick += ev;
            myTimer.Interval = time * 1000;
            myTimer.Start();
        }

        public void RaiseCommunicat(int communicatType) // Set communicats and block all buttons 
        {
            ev = new EventHandler((sender, e) => WaitTimer(sender, e, communicatType, label1, done)); // Set timer for blocking buttons and deal with communicat
            myTimer.Tick += ev;
            myTimer.Interval = 1000;
            myTimer.Start();
        }
    }
}
