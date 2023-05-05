using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

// TODO 
/*
Dark souls gmv warriors, minecraft parody problem
*/ 

namespace YTDownloader
{
    public partial class Form1 : Form
    {
        OpenFileDialog openFileDialog;
        List<YoutubeExplode.Search.VideoSearchResult> foundVideos = new List<YoutubeExplode.Search.VideoSearchResult>();
        static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        bool blockButtons = false;
        bool done = false;
        EventHandler ev;

        int findCommunicat = 1;
        int downloadCommunicat = 2;
        string downloadPath = "Download/";
        string logPath = "Log/";

        int lang = 0; // 0 - eng, 1 - pl
        string[,] communicats = {
            {"Searching", "Downloading", "Downloaded", "Can't download. Error!!!!", "See log file", "Downloaded all", "Can't download ", " item/items" },
            {"Szukanie","Pobieranie", "Pobrano", "Nie można pobrać. Błąd!!!!", "Zobasz plik log", "Pobrano wszystko", "Nie można pobrać ", " pliku/plików"  }
        };


        public Form1()
        {
            InitializeComponent();
            label1.Text = "";
            button8.Enabled = false;
            openFileDialog = new OpenFileDialog();

            // Create folders if they doesn't exist
            DirectoryInfo di;
            di = Directory.CreateDirectory("Download"); 
            di = Directory.CreateDirectory("Log");
        }

        private static void TimerRaised(Object myObject, EventArgs myEventArgs, Label label1, Form1 form1) // Timer for cleaning label1
        {
            
            myTimer.Stop();
            myTimer.Tick -= form1.ev;
            label1.Text = "";
            //form1.EndEvent();
        }

        private static void WaitTimer(Object myObject, EventArgs myEventArgs, int waitType, Label label1, bool done, Form1 form1) // Timer for blocking all buttons and show communicat until videos is found or downloaded
        {
            if(form1.blockButtons == false) // Block all necessari buttons
            {
                form1.ButtonsState(false);
                form1.blockButtons = true;
            }

            label1.ForeColor = Color.Yellow;
            switch (waitType)
            {
                case 1: // Find videos
                    {
                        if (!label1.Text.Contains(form1.communicats[form1.lang, 0]) || label1.Text.Length > (form1.communicats[form1.lang, 0] + "...").Length - 1) // Searching
                        {
                            label1.Text = form1.communicats[form1.lang,0]; 
                        }
                        else if (label1.Text.Contains(form1.communicats[form1.lang, 0]))
                        {
                            label1.Text += ".";
                        }
                        break;
                    }
                    
                case 2: // Download videos
                    {
                        if (!label1.Text.Contains(form1.communicats[form1.lang, 1]) || label1.Text.Length > (form1.communicats[form1.lang, 1] + "...").Length - 1) // Downloading
                    {
                        label1.Text = form1.communicats[form1.lang, 1];
                    }
                    else if (label1.Text.Contains(form1.communicats[form1.lang, 1]))
                    {
                        label1.Text += ".";
                    }
                    break;
                    }
                    
            }

            if (done == true) // If task id completed
            {
                form1.blockButtons = false;
                form1.ButtonsState(true);

                myTimer.Stop();
                //form1.EndEvent();
                myTimer.Tick -= form1.ev;
                label1.Text = "";
            }

        }
   
        private void ClearCommunicatAfterTime(int time) // Clear label1 after some time, time in sec
        {
            ev = new EventHandler((sender, e) => TimerRaised(sender, e, label1, this)); // Set timer for comunnicat
            myTimer.Tick += ev;
            myTimer.Interval = time * 1000;
            myTimer.Start();
        }

        private void RaiseCommunicat(int communicatType) // Set communicats and block all buttons 
        {
            ev = new EventHandler((sender, e) => WaitTimer(sender, e, communicatType, label1, done, this)); // Set timer for blocking buttons and deal with communicat
            myTimer.Tick += ev;
            myTimer.Interval = 1000;
            myTimer.Start();
        }

        public void ButtonsState(bool state) // Block all necessari buttons
        {
            Button[] buttons = { button1, button4, button5, button6 };
            foreach(Button button in buttons)
            {
                button.Enabled = state;
            }
        }

        public void EndEvent()
        {
            label1.Text = "";
            myTimer.Tick -= ev;
        }

        private async Task<bool> DownloadVideo(YoutubeExplode.Search.VideoSearchResult searchResult) // Download passed video
        {
            try
            {
                var youtubeClient = new YoutubeClient();
                var streamManifest = await youtubeClient.Videos.Streams.GetManifestAsync(searchResult.Id);
                var streamInfo = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();
                await youtubeClient.Videos.Streams.DownloadAsync(streamInfo, downloadPath + searchResult.Title + ".mp3");
                return true;
            }
            catch(Exception e)
            {
                string error = "";
                if (e is YoutubeExplode.Exceptions.VideoUnplayableException) error = "Can't play video";
                else if (e is YoutubeExplode.Exceptions.VideoUnavailableException) error = "Videos is unavaiable";
                else error = "Unnown error";

                StreamWriter sw = File.AppendText(logPath + "log " + DateTime.Now.Day + " " + DateTime.Now.Month + " " + DateTime.Now.Year + ".txt");
                sw.WriteLine("Can't download: " + searchResult.Title + "; Because: " + error);
                sw.Close();
                return false;
            }
            
        }

        private async Task<List<YoutubeExplode.Search.VideoSearchResult>> FindVideos(List<string>searchVideos) // Search for all videos from searchVideos
        {
            List<YoutubeExplode.Search.VideoSearchResult> foundVideos = new List<YoutubeExplode.Search.VideoSearchResult>();
            var youtubeClient = new YoutubeClient();

            foreach (string searchVideo in searchVideos) 
            {
                var serachResults = youtubeClient.Search.GetVideosAsync(searchVideo);
                await foreach (var serachResult in serachResults) // If loop find video
                {
                    foundVideos.Add(serachResult);
                    break;
                }
            }

            return foundVideos;
        }

        private async void button1_Click(object sender, EventArgs e) // Download selected
        {
            if(listBox2.SelectedIndex >= 0)
            {
                var serachResult = foundVideos[listBox2.SelectedIndex];
                done = false;
                RaiseCommunicat(downloadCommunicat);
                bool state = await DownloadVideo(serachResult);
                done = true;
                //EndEvent();

                foundVideos.Remove(serachResult);
                listBox2.Items.Remove(listBox2.SelectedItem);
                if (state == true)
                {
                    label1.ForeColor = Color.Green;
                    label1.Text = communicats[lang,2];
                }
                else if (state == false)
                {
                    label1.ForeColor = Color.Red;
                    label1.Text = communicats[lang, 3] + Environment.NewLine + communicats[lang, 4];
                }
                ClearCommunicatAfterTime(2);
            }
            
        }

        private async void button5_Click(object sender, EventArgs e) // Download all
        {
            int errors = 0;
            done = false;
            RaiseCommunicat(downloadCommunicat);
            foreach(var searchResult in foundVideos)
            {
                bool state = await DownloadVideo(searchResult);
                listBox2.Items.RemoveAt(0);
                if (state == false) errors += 1;
            }
            done = true;
            //EndEvent();

            foundVideos.Clear();
            if (errors == 0)
            {
                label1.ForeColor = Color.Green;
                label1.Text = communicats[lang, 5];
            }
            else
            {
                label1.ForeColor = Color.Red;
                label1.Text = communicats[lang, 6] + errors.ToString() + communicats[lang, 7];
            }
            ClearCommunicatAfterTime(2);

        }

        private void button2_Click(object sender, EventArgs e) // Add button
        {
            if(textBox1.Text != "")
            {
                listBox1.Items.Add(textBox1.Text);
                textBox1.Text = "";
            }
            
        }

        private void button3_Click(object sender, EventArgs e) // Del button
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private async void button4_Click(object sender, EventArgs e) // Find button
        {
            List<string> searchVideos = new List<string>();
            foreach(string item in listBox1.Items) // Add all search videos to list
            {
                searchVideos.Add(item);
            }

            done = false;
            RaiseCommunicat(findCommunicat);
            foundVideos = await FindVideos(searchVideos); // Get list of all found videos
            done = true;
            //EndEvent();

            listBox1.Items.Clear(); // Clear searchVideos list, after finding it on youtube
            foreach(var foundVideo in foundVideos) // Add all foundVideos to listbox2
            {
                listBox2.Items.Add(foundVideo.Title.ToString());
            }

        }

        private void button6_Click(object sender, EventArgs e) // Clear button
        {
            listBox2.Items.Clear();
            pictureBox1.Image = Resource1.noImage;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e) // Someone selected video, show thubnail of it
        {
            try
            {
                pictureBox1.ImageLocation = foundVideos[listBox2.SelectedIndex].Thumbnails[0].Url;
            }
            catch
            {
                pictureBox1.ImageLocation = null;
            }

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.button2.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void button7_Click(object sender, EventArgs e) // Polish language
        {

            button7.Enabled = false;
            button8.Enabled = true;

            label2.Text = "Do wyszukania";
            label3.Text = "Znalezione";

            button1.Text = "Pobierz zaznaczony";
            button2.Text = "Dod";
            button3.Text = "Usu";
            button4.Text = "Szukaj";
            button5.Text = "Pobierz wszystkie";
            button6.Text = "Wyczyść";
            button9.Text = "Plik";
            lang = 1;
        }

        private void button8_Click(object sender, EventArgs e) // English language
        {
            button8.Enabled = false;
            button7.Enabled = true;

            label2.Text = "Wanted";
            label3.Text = "Found";

            button1.Text = "Download selected";
            button2.Text = "Add";
            button3.Text = "Del";
            button4.Text = "Search";
            button5.Text = "Download all";
            button6.Text = "Clear";
            button9.Text = "File";
            lang = 0; 
        }

        private void button9_Click(object sender, EventArgs e) // Upload file button
        {
            openFileDialog.FileOk += UploadFile;
            openFileDialog.ShowDialog();
        }

        private void UploadFile(object sender, EventArgs e) // Handle file upload
        {
            FileStream fs = File.OpenRead(openFileDialog.FileName);
            using(StreamReader sr = new StreamReader(fs))
            {
                string musicTitle = "";
                while((musicTitle = sr.ReadLine()) != null)
                {
                    if(musicTitle != "") listBox1.Items.Add(musicTitle);
                }
            }
            fs.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    
}
