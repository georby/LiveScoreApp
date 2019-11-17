using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace ScoreApp
{
    public partial class ScoreBoard : Form
    {
        public DataTable DtGridSource { get; set; }
        public BackgroundWorker BackgroundWorker { get; set; }

        const string pipeName = "score-pipe";
        const string scoreDataFileName = "ScoreBoardScores.xml";

        public ScoreBoard()
        {
            InitializeComponent();
            InitializeGridView();
            InitializeBackgroundWorker();
        }

        private void InitializeGridView()
        {
            if (File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, scoreDataFileName)))
            {
                using (DataSet DsXmlSource = new DataSet())
                {
                    DsXmlSource.ReadXml(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, scoreDataFileName));
                    if (DsXmlSource.Tables.Count > 0)
                    {
                        DtGridSource = DsXmlSource.Tables[0].Copy();
                    }
                }
            }
            else
            {
                DtGridSource = new DataTable();
                DtGridSource.Columns.Add("Console Number");
                DtGridSource.Columns.Add("Score");
                DtGridSource.Columns.Add("Player Name");
                DtGridSource.Columns.Add("Status"); 
            }

            gridScoreBoard.DataSource = DtGridSource.AsDataView();

            gridScoreBoard.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridScoreBoard.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            gridScoreBoard.AllowUserToResizeColumns = true;
        }

        private void InitializeBackgroundWorker()
        {
            BackgroundWorker = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };
            BackgroundWorker scoreUpdater = BackgroundWorker;

            scoreUpdater.DoWork += ScoreUpdaterOnDoWork;
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
                        using (NamedPipeServerStream pipe = new NamedPipeServerStream(pipeName, PipeDirection.In, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous))
                        {
                            await pipe.WaitForConnectionAsync();
                            using (StreamReader streamReader = new StreamReader(pipe))
                            {
                                var message = await streamReader.ReadToEndAsync();
                                UpdateConsoleDetails(message);
                            }
                            if (pipe.IsConnected)
                            {
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

            ScoreDetails score = new ScoreDetails();
            score.StringToScoreDetails(consoleDetails);

            Invoke(new Action(() =>
            {
                DataRow drScore = DtGridSource.Select("[Console Number]=" + score.ConsoleNumber).FirstOrDefault();
                if (drScore == null)
                {
                    drScore = DtGridSource.NewRow();
                    drScore["Console Number"] = score.ConsoleNumber;
                    drScore["Score"] = score.ConsoleScore;
                    drScore["Player Name"] = score.ConsolePlayerName;
                    drScore["Status"] = score.ConsoleStatus;
                    DtGridSource.Rows.Add(drScore);
                }
                else
                {
                    drScore["Score"] = score.ConsoleScore;
                    drScore["Player Name"] = score.ConsolePlayerName;
                    drScore["Status"] = score.ConsoleStatus;
                }
                gridScoreBoard.DataSource = DtGridSource;
            }));
        }

        private void ScoreBoard_FormClosing(object sender, FormClosingEventArgs e)
        {
            using(DataSet DsGridSource = new DataSet())
            {
                DsGridSource.Tables.Add(DtGridSource.Copy());
                DsGridSource.WriteXml(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, scoreDataFileName));
            }
            BackgroundWorker.Dispose();
            DtGridSource.Dispose();
        }
    }

    class ScoreDetails
    {
        public string ConsoleNumber { get; set; }
        public string ConsoleScore { get; set; }
        public string ConsolePlayerName { get; set; }
        public string ConsoleStatus { get; set; }

        public void StringToScoreDetails(string scoreDetail)
        {
            string[] consoleInfo = scoreDetail.Split(',');

            ConsoleNumber = consoleInfo[0];
            ConsoleScore = consoleInfo[1];
            ConsolePlayerName = consoleInfo[2];
            ConsoleStatus = consoleInfo[3];
        }
    }
}
