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
using System.Net;
using System.Web;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;
using YoutubeExplode.Search;
using YTDownloader_Communicats;


// TODO 
/*
Dark souls gmv warriors, minecraft parody problem
*/ 

namespace YTDownloader
{
    public partial class Form1 : Form
    {
        OpenFileDialog openFileDialog;
        List<VideoSearchResult> foundVideos = new List<VideoSearchResult>();
        Communicats communicatsManager;
        YTDownloader ytDownloader1;
        YTDownloader ytDownloader2;
        YTDownloader ytDownloader3;
        static object foundListBoxLockObject;
        static object logRichTextBoxLockObject;
        int noCommunicat = 0;
        int findCommunicat = 1;
        int downloadCommunicat = 2;
        string downloadPath = "Download/";
        string logPath = "Log/";

        public int lang = 0; // 0 - eng, 1 - pl
        public string[,] communicats = {
            {"Searching", "Downloading", "Downloaded", "Can't download. Error!!!!", "See log file", "Downloaded all", "Can't download ", " item/items" },
            {"Szukanie","Pobieranie", "Pobrano", "Nie można pobrać. Błąd!!!!", "Zobasz plik log", "Pobrano wszystko", "Nie można pobrać ", " pliku/plików"  }
        };

        public Form1()
        {
            InitializeComponent();
            SetBasicValues();
            CheckFiles();
            communicatsManager = new Communicats(label1, communicats, lang, this);
            openFileDialog = new OpenFileDialog();      
            foundListBoxLockObject = new object();
            logRichTextBoxLockObject = new object();
        }

        void SetBasicValues()
        {
            label1.Text = "";
            engLangBtn.Enabled = false;
            t1StopBtn.Enabled = false;
            t2StopBtn.Enabled = false;
            t3StopBtn.Enabled = false;
            ytDownloader1 = null;
            ytDownloader2 = null;
            ytDownloader3 = null;
        }

        void CheckFiles()
        {
            DirectoryInfo di;
            di = Directory.CreateDirectory("Download");
            di = Directory.CreateDirectory("Log");
        }

        void PopulateSelectNames(string name = "")
        {
            t1SelectName.Items.Clear();
            t2SelectName.Items.Clear();
            t3SelectName.Items.Clear();
            if(name != "t1" && t1SelectName.Enabled) t1SelectName.Text = "";
            if(name != "t2" && t2SelectName.Enabled) t2SelectName.Text = "";
            if(name != "t3" && t3SelectName.Enabled) t3SelectName.Text = "";

            foreach (var video in foundVideos)
            {
                t1SelectName.Items.Add(video.Title);
                t2SelectName.Items.Add(video.Title);
                t3SelectName.Items.Add(video.Title);
            }
        }
        
        void UpdateFoundList()
        {
            lock(foundListBoxLockObject)
            {
                foundListBox.Items.Clear();
                foreach (var foundVideo in foundVideos)
                {
                    foundListBox.Items.Add(foundVideo.Title.ToString());
                }
            }    
        }

        public void ButtonsState(bool state) // Block all necessari buttons
        {
            Button[] buttons = { searchBtn, clearFoundBtn };
            foreach(Button button in buttons)
            {
                button.Enabled = state;
            }
        }

        public void UpdateUIElements(string name, string action)
        {
            switch(name)
            {
                case "t1":
                    switch (action)
                    {
                        case "startDownload":
                            t1SelectName.Enabled = false;
                            t1StartBtn.Enabled = false;
                            t1StopBtn.Enabled = true;
                            break;
                        case "stopDownload":
                            t1SelectName?.Invoke((MethodInvoker)(() => t1SelectName.Enabled = true));
                            t1SelectName?.Invoke((MethodInvoker)(() => t1SelectName.Text = ""));
                            t1StartBtn?.Invoke((MethodInvoker)(() => t1StartBtn.Enabled = true));
                            t1StopBtn?.Invoke((MethodInvoker)(() => t1StopBtn.Enabled = false));
                            break;
                    }
                    break;
                case "t2":
                    switch (action)
                    {
                        case "startDownload":
                            t2SelectName.Enabled = false;
                            t2StartBtn.Enabled = false;
                            t2StopBtn.Enabled = true;
                            break;
                        case "stopDownload":
                            t2SelectName?.Invoke((MethodInvoker)(() => t2SelectName.Enabled = true));
                            t2SelectName?.Invoke((MethodInvoker)(() => t2SelectName.Text = ""));
                            t2StartBtn?.Invoke((MethodInvoker)(() => t2StartBtn.Enabled = true));
                            t2StopBtn?.Invoke((MethodInvoker)(() => t2StopBtn.Enabled = false));
                            break;
                    }
                    break;
                case "t3":
                    switch (action)
                    {
                        case "startDownload":
                            t3SelectName.Enabled = false;
                            t3StartBtn.Enabled = false;
                            t3StopBtn.Enabled = true;
                            break;
                        case "stopDownload":
                            t3SelectName?.Invoke((MethodInvoker)(() => t3SelectName.Enabled = true));
                            t3SelectName?.Invoke((MethodInvoker)(() => t3SelectName.Text = ""));
                            t3StartBtn?.Invoke((MethodInvoker)(() => t3StartBtn.Enabled = true));
                            t3StopBtn?.Invoke((MethodInvoker)(() => t3StopBtn.Enabled = false));
                            break;
                    }
                    break;
            }
        }
   
        public void AddLogEntry(string context, string state)
        {
            lock(logRichTextBoxLockObject)
            {
                logRichTextBox.Invoke((MethodInvoker)(() =>
                {
                    logRichTextBox.SelectionStart = 0;
                    logRichTextBox.SelectionLength = 0;
                    switch (state)
                    {
                        case "success":
                            logRichTextBox.SelectionColor = Color.Green;
                            break;
                        case "error":
                            logRichTextBox.SelectionColor = Color.Red;
                            break;
                        default:
                            logRichTextBox.SelectionColor = Color.White;
                            break;
                    }
                    logRichTextBox.SelectedText = $" {context}\n";
                }));
            }  
        }

        private async Task<List<VideoSearchResult>> FindVideos(List<string>searchVideos) // Search for all videos from searchVideos
        {
            List<VideoSearchResult> foundVideos = new List<VideoSearchResult>();
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

        private void addBtn_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                wantedListBox.Items.Add(textBox1.Text);
                textBox1.Text = "";
            }
            
        }

        private void delBtn_Click(object sender, EventArgs e) // Del button
        {
            wantedListBox.Items.Remove(wantedListBox.SelectedItem);
        }

        private async void searchBtn_Click(object sender, EventArgs e)
        {
            List<string> searchVideos = new List<string>();
            foreach(string item in wantedListBox.Items) // Add all search videos to list
            {
                searchVideos.Add(item);
            }

            communicatsManager.done = false;
            communicatsManager.RaiseCommunicat(findCommunicat);
            foundVideos = await FindVideos(searchVideos); // Get list of all found videos
            communicatsManager.done = true;
            wantedListBox.Items.Clear(); // Clear searchVideos list, after finding it on youtube
            PopulateSelectNames();
            UpdateFoundList();
        }

        private void clearFoundBtn_Click(object sender, EventArgs e)
        {
            foundListBox.Items.Clear();
            pictureBox1.Image = Resource1.noImage;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e) // Someone selected video, show thubnail of it
        {
            try
            {
                pictureBox1.ImageLocation = foundVideos[foundListBox.SelectedIndex].Thumbnails[0].Url;
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
                this.addBtn.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void plLangBtn_Click(object sender, EventArgs e)
        {
            plLangBtn.Enabled = false;
            engLangBtn.Enabled = true;
            label2.Text = "Do wyszukania";
            label3.Text = "Znalezione";
            addBtn.Text = "Dod";
            delBtn.Text = "Usu";
            searchBtn.Text = "Szukaj";
            clearFoundBtn.Text = "Wyczyść";
            fileBtn.Text = "Plik";
            lang = 1;
        }

        private void engLangBtn_Click(object sender, EventArgs e)
        {
            engLangBtn.Enabled = false;
            plLangBtn.Enabled = true;
            label2.Text = "Wanted";
            label3.Text = "Found";
            addBtn.Text = "Add";
            delBtn.Text = "Del";
            searchBtn.Text = "Search";
            clearFoundBtn.Text = "Clear";
            fileBtn.Text = "File";
            lang = 0; 
        }

        private void fileBtn_Click(object sender, EventArgs e) // Upload file button
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
                    if(musicTitle != "") wantedListBox.Items.Add(musicTitle);
                }
            }
            fs.Close();
        }

        private void t1StartBtn_Click(object sender, EventArgs e)
        {
            string searchTitle = t1SelectName?.SelectedItem?.ToString();
            if (searchTitle != null)
            {
                VideoSearchResult videoSearch = foundVideos.FirstOrDefault((v) => v.Title == searchTitle);
                if (videoSearch != null)
                {
                    ytDownloader1 = new YTDownloader(videoSearch, t1PercentLabel, downloadPath, "t1");
                    ytDownloader1.StartDownloading();
                    ytDownloader1.DownloadCompleted += OnDownloadCompleted;
                    UpdateUIElements("t1", "startDownload");
                    foundVideos.Remove(videoSearch);
                    UpdateFoundList();
                    PopulateSelectNames("t1");
                }
                else
                {
                    AddLogEntry("Can't find such video [first select box]", "error");
                }
            }
            else
            {
                AddLogEntry("Please select video  to download [first select box]", "error");
            }
        }

        private void t1StopBtn_Click(object sender, EventArgs e)
        {
            if(ytDownloader1 != null)
            {
                ytDownloader1.StopDownloading();
                UpdateUIElements("t1", "stopDownload");
            }
        }

        private void t2StartBtn_Click(object sender, EventArgs e)
        {
            string searchTitle = t2SelectName?.SelectedItem?.ToString();
            if (searchTitle != null)
            {
                VideoSearchResult videoSearch = foundVideos.FirstOrDefault((v) => v.Title == searchTitle);
                if (videoSearch != null)
                {
                    ytDownloader2 = new YTDownloader(videoSearch, t2PercentLabel, downloadPath, "t2");
                    ytDownloader2.StartDownloading();
                    ytDownloader2.DownloadCompleted += OnDownloadCompleted;
                    UpdateUIElements("t2", "startDownload");
                    foundVideos.Remove(videoSearch);
                    UpdateFoundList();
                    PopulateSelectNames("t2");
                }
                else
                {
                    AddLogEntry("Can't find such video [second select box]", "error");
                }
            }
            else
            {
                AddLogEntry("Please select video  to download [second select box]", "error");
            }
        }

        private void t2StopBtn_Click(object sender, EventArgs e)
        {
            if (ytDownloader2 != null)
            {
                ytDownloader2.StopDownloading();
                UpdateUIElements("t2", "stopDownload");
            }
        }

        private void t3StartBtn_Click(object sender, EventArgs e)
        {
            string searchTitle = t3SelectName?.SelectedItem?.ToString();
            if (searchTitle != null)
            {
                VideoSearchResult videoSearch = foundVideos.FirstOrDefault((v) => v.Title == searchTitle);
                if (videoSearch != null)
                {
                    ytDownloader3 = new YTDownloader(videoSearch, t3PercentLabel, downloadPath, "t3");
                    ytDownloader3.StartDownloading();
                    ytDownloader3.DownloadCompleted += OnDownloadCompleted;
                    UpdateUIElements("t3", "startDownload");
                    foundVideos.Remove(videoSearch);
                    UpdateFoundList();
                    PopulateSelectNames("t3");
                }
                else
                {
                    AddLogEntry("Can't find such video [third select box]", "error");
                }
            }
            else
            {
                AddLogEntry("Please select video  to download [third select box]", "error");
            }
        }

        private void t3StopBtn_Click(object sender, EventArgs e)
        {
            if (ytDownloader3 != null)
            {
                ytDownloader3.StopDownloading();
                UpdateUIElements("t3", "stopDownload");
            }
        }

        private void OnDownloadCompleted(object sender, string videoTitle, string name)
        {
            UpdateUIElements(name, "stopDownload");
            AddLogEntry($"Video: {videoTitle} was downloaded", "success");
        }
    }
    
}
