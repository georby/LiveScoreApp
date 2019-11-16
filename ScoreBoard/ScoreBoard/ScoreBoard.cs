using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScoreBoard
{
    public partial class scoreboard : Form
    {
        DataTable dtGridSource;
        public scoreboard()
        {
            InitializeComponent();
            InitializeGridView();
            InitializeBackgroundWorker();
        }

        private void InitializeGridView()
        {
            dtGridSource = new DataTable();
            dtGridSource.Columns.Add("Console Number");
            dtGridSource.Columns.Add("Score");
            dtGridSource.Columns.Add("Player Name");
            dtGridSource.Columns.Add("Status");

            gridScoreBoard.DataSource = dtGridSource.AsDataView();

            gridScoreBoard.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridScoreBoard.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            gridScoreBoard.AllowUserToResizeColumns = true;
        }

        private void InitializeBackgroundWorker()
        {
            BackgroundWorker scoreUpdater = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };

            scoreUpdater.DoWork += ScoreUpdaterOnDoWork;
            //scoreUpdater.ProgressChanged += ScoreUpdaterOnProgressChanged;
            scoreUpdater.RunWorkerAsync();
        }

        private async void ScoreUpdaterOnDoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;
            while (!worker.CancellationPending)
            {
                try
                {
                    while (true)
                    {
                        using (var pipe = new NamedPipeServerStream("score-pipe", PipeDirection.In, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous))
                        {
                            // wait for the connection
                            await pipe.WaitForConnectionAsync();
                            using (var streamReader = new StreamReader(pipe))
                            {
                                // read the message from the stream - async
                                var message = await streamReader.ReadToEndAsync();
                                UpdateConsoleDetails(message);
                            }
                            if (pipe.IsConnected)
                            {
                                // must disconnect
                                Thread.Sleep(5000);
                                pipe.Disconnect();
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private void UpdateConsoleDetails(string consoleDetails)
        {
            var consoleInfo = consoleDetails.Split(',');
            Dictionary<string, string> consoleDetail = new Dictionary<string, string>();
            consoleDetail.Add("consoleNumber", consoleInfo[0]);
            consoleDetail.Add("score", consoleInfo[1]);
            consoleDetail.Add("playerName", consoleInfo[2]);
            consoleDetail.Add("status", consoleInfo[3]);

            Invoke(new Action(() => 
            {
                //var drScore = dtGridSource.AsEnumerable().FirstOrDefault(row => row.Field<string>("Console Number") == consoleDetail["consoleNumber"]);
                DataRow drScore = dtGridSource.Select("[Console Number]=" + consoleDetail["consoleNumber"]).FirstOrDefault();
                if (drScore == null)
                {
                    drScore = dtGridSource.NewRow();
                    drScore["Console Number"] = consoleDetail["consoleNumber"];
                    drScore["Score"] = consoleDetail["score"];
                    drScore["Player Name"] = consoleDetail["playerName"];
                    drScore["Status"] = consoleDetail["status"];
                    dtGridSource.Rows.Add(drScore);
                }
                else
                {
                    drScore["Score"] = consoleDetail["score"];
                    drScore["Player Name"] = consoleDetail["playerName"];
                    drScore["Status"] = consoleDetail["status"];
                }

                gridScoreBoard.DataSource = dtGridSource;
            }));
        }
    }
}
