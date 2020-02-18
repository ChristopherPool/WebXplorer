using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Webxplorer
{
    public partial class Form1 : Form
    {
        public static int totalBytes = 0;
        public Form1()
        {
            InitializeComponent();
            DefaultHome();
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Visible = false;
            toolStripProgressBar1.Visible = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Sets the default url to google when program opens
        private void DefaultHome()
        {
            webBrowser1.Navigate(searchBar.Text = "https://google.com");
        }

        // Core nav function - Disables the search function while loading is occuring
        private void Navfunct()
        {
            webBrowser1.Navigate(searchBar.Text);
            button1.Enabled = false;
            searchBar.Enabled = false;
            toolStripStatusLabel1.Text = "Loading";


            toolStripStatusLabel1.Visible = false;
            toolStripProgressBar1.Visible = true;
            totalBytes = 0;
            toolStripProgressBar1.Value = 0;

        }


        // On button click sends info to webbrowser 
        private void button1_Click(object sender, EventArgs e)
        {
            Navfunct();
        }

        // Allows enter key to be used to send url/textbox info to webbrowser object
        private void searchBar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)ConsoleKey.Enter)
            {
                button1_Click(null, null);
            }

            // Stops the system sound playing everytime enter is pressed
            if (e.KeyData.Equals(Keys.Enter))
            {
                e.SuppressKeyPress = true;
                Navfunct();
            }
        }


        private void versionInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Webxplorer Browser ver. 0.0.1. Test");
        }

        private void otherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Other Information:" + "\n" + "\n" + "Search Bar inputs to web browser everytime a character is input *Fixed*"
                + "\n" + "\n" + "Prevent search from occuring during ongoing search *Done* " );

        }
        // Makes the loading status bar work
        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            totalBytes++;
            if (totalBytes > 75)
            {
                totalBytes = totalBytes - 50;
            }
            toolStripProgressBar1.Value = totalBytes;

        }

        // When web browser is finished loading disbales progress bar visibility but keeps status label visible
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            int totalCount = 100 - toolStripProgressBar1.Value;
            toolStripProgressBar1.Value += totalCount;
            toolStripProgressBar1.Visible = false;
            toolStripStatusLabel1.Visible = true;
            toolStripStatusLabel1.Text = "Loaded";

            // Enables buttons to be used again after loading
            button1.Enabled = true;
            searchBar.Enabled = true;
            searchBar.Text = webBrowser1.Url.ToString();
        }

            private void button2_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DefaultHome();
        }
    }
}
