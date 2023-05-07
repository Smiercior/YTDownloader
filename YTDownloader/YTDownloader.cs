using System;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;
using YoutubeExplode.Search;

namespace YTDownloader
{
    internal class YTDownloader
    {
        Thread downloadingThread;
        VideoSearchResult searchResult;
        Label downloadLabel;
        CancellationTokenSource cancellationTokenSource;
        public delegate void DownloadCompletedEventHandler(object sender, string videoTitle, string name);
        public event DownloadCompletedEventHandler DownloadCompleted;
        string downloadPath;
        string name;

        public YTDownloader(VideoSearchResult sR, Label dL, string dP, string n)
        {
            searchResult = sR;
            downloadLabel = dL;
            downloadPath = dP;
            name = n;
            cancellationTokenSource = new CancellationTokenSource();
            downloadingThread = new Thread(async () =>
            {
                await DownloadVideo(cancellationTokenSource.Token);
            });
        }
          
        async Task<bool> DownloadVideo(CancellationToken cancellationToken)
        {
            try
            {
                // Download video
                var youtubeClient = new YoutubeClient();
                var streamManifest = await youtubeClient.Videos.Streams.GetManifestAsync(searchResult.Id);
                var streamInfo = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();
                var progress = new Progress<double>(percent =>
                {
                    // Update percent label
                    string formattedPercent = ((int)(percent * 100)).ToString();
                    downloadLabel.Invoke((MethodInvoker)(() => downloadLabel.Text = $"{formattedPercent}%"));
                });

                await youtubeClient.Videos.Streams.DownloadAsync(streamInfo, downloadPath + searchResult.Title + ".mp3", progress, cancellationToken);

                // Indicate that video was downloaded
                if(DownloadCompleted != null)
                {
                    DownloadCompleted.Invoke(this, searchResult.Title, name);
                }

                downloadLabel.Invoke((MethodInvoker)(() => downloadLabel.Text = "0%"));
                return true;
            }
            catch (OperationCanceledException)
            {
                downloadLabel.Invoke((MethodInvoker)(() => downloadLabel.Text = "0%"));
                return false;
            }
            catch (Exception ex)
            {
                return false;
                /*
                string error = "";
                if (e is YoutubeExplode.Exceptions.VideoUnplayableException) error = "Can't play video";
                else if (e is YoutubeExplode.Exceptions.VideoUnavailableException) error = "Videos is unavaiable";
                else error = "Unnown error";

                StreamWriter sw = File.AppendText(logPath + "log " + DateTime.Now.Day + " " + DateTime.Now.Month + " " + DateTime.Now.Year + ".txt");
                sw.WriteLine("Can't download: " + searchResult.Title + "; Because: " + error);
                sw.Close();
                return false;
                */
            }
        }

        public void StartDownloading()
        {
            downloadingThread.Start();  
        }

        public void StopDownloading()
        {
            cancellationTokenSource.Cancel();
        }
    }
}
