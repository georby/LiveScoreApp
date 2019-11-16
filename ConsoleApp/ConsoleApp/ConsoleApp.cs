using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp
{
    public partial class ConsoleApp : Form
    {
        public ConsoleApp()
        {
            InitializeComponent();
        }

        private void BtnSendScores_Click(object sender, EventArgs e)
        {
            if (ValidConsoleDetails())
                SetScoreDetails(txtConsoleNumber.Text, txtScore.Text, cbStatus.SelectedItem.ToString(), txtPlayerName.Text);
        }

        private void SetScoreDetails(string consoleNumber, string score, string status, string playerName = "")
        {
            try
            {
                SendScoreToScoreboard(consoleNumber + "," + score + "," + playerName + "," + status).Wait();
                txtConsoleNumber.Enabled = false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private static async Task SendScoreToScoreboard(string consoleInput)
        {
            try
            {
                using (var pipe = new NamedPipeClientStream(".", "score-pipe", PipeDirection.Out, PipeOptions.Asynchronous))
                {
                    using (var stream = new StreamWriter(pipe))
                    {
                        pipe.Connect();
                        // write the message to the pipe stream 
                        await stream.WriteAsync(consoleInput);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error sending the score to Scoreboard.");
                MessageBox.Show(exception.Message);
            }
        }

        private void ConsoleApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtConsoleNumber.Text))
                SetScoreDetails(txtConsoleNumber.Text, txtScore.Text, "Idle", txtPlayerName.Text);
        }

        private bool ValidConsoleDetails()
        {
            if (string.IsNullOrEmpty(txtConsoleNumber.Text))
            {
                MessageBox.Show("Console number cannot be empty.");
                txtConsoleNumber.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtScore.Text))
            {
                MessageBox.Show("Score cannot be empty.");
                txtScore.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cbStatus.SelectedItem.ToString()))
            {
                MessageBox.Show("Console status is required.");
                cbStatus.Focus();
                return false;
            }
            return true;
        }
    }
}
