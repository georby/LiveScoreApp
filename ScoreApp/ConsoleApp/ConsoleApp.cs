using System;
using System.IO;
using System.IO.Pipes;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScoreApp
{
    public partial class ConsoleApp : Form
    {
        const string pipeName = "score-pipe";

        public ConsoleApp()
        {
            InitializeComponent();
        }

        private async void BtnSendScores_Click(object sender, EventArgs e)
        {
            await SetScoreDetails();
        }

        private async Task SetScoreDetails()
        {
            try
            {
                ScoreDetails score = new ScoreDetails()
                {
                    ConsoleNumber = txtConsoleNumber.Text,
                    ConsoleScore = txtScore.Text,
                    ConsolePlayerName = txtPlayerName.Text,
                    ConsoleStatus = cbStatus.SelectedIndex == -1 ? string.Empty : cbStatus.SelectedItem.ToString()
                };
                score.ValidConsoleDetails();
                await SendScoreToScoreboard(score.ScoreDetailsToString());
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private async Task SendScoreToScoreboard(string consoleInput)
        {
            try
            {
                using (NamedPipeClientStream pipe = new NamedPipeClientStream(".", pipeName, PipeDirection.Out, PipeOptions.Asynchronous))
                {
                    using (StreamWriter stream = new StreamWriter(pipe))
                    {
                        pipe.Connect(5000);
                        await stream.WriteAsync(consoleInput);
                    }
                };
                txtConsoleNumber.Enabled = false;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error sending the score to Scoreboard.");
                MessageBox.Show(exception.Message);
            }
        }

        private async void ConsoleApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtConsoleNumber.Text))
            {
                ScoreDetails score = new ScoreDetails()
                {
                    ConsoleNumber = txtConsoleNumber.Text,
                    ConsoleScore = txtScore.Text,
                    ConsolePlayerName = txtPlayerName.Text,
                    ConsoleStatus = cbStatus.SelectedIndex == -1 ? string.Empty : "Idle"
                };
                await SendScoreToScoreboard(score.ScoreDetailsToString());
            }
        }
    }

    class ScoreDetails
    {
        public string ConsoleNumber { get; set; }
        public string ConsoleScore { get; set; }
        public string ConsolePlayerName { get; set; }
        public string ConsoleStatus { get; set; }

        public bool ValidConsoleDetails()
        {
            if (string.IsNullOrEmpty(ConsoleNumber))
            {
                MessageBox.Show("Console number cannot be empty.");
                return false;
            }
            if (string.IsNullOrEmpty(ConsoleScore))
            {
                MessageBox.Show("Score cannot be empty.");
                return false;
            }
            if (string.IsNullOrEmpty(ConsoleStatus))
            {
                MessageBox.Show("Console status is required.");
                return false;
            }
            return true;
        }

        public string ScoreDetailsToString()
        {
            return ConsoleNumber + "," + ConsoleScore + "," + ConsolePlayerName + "," + ConsoleStatus;
        }
    }
}
