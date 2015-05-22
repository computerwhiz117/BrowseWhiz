using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrowseWhiz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// This function is called when the exit menu item is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This program was made by Carlos Sanchez and ComputerWhiz, LLC.");
        }

        /// <summary>
        /// On the click of this button the web control will display the page requested (by URL)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            NavigatetoPage();
        }
        /// <summary>
        /// This is the core function that will perform all navigation and post processing
        /// </summary>
        private void NavigatetoPage()
        {
            button1.Enabled = false;
            textBox1.Enabled = false;
            webBrowser1.Navigate(textBox1.Text);
            toolStripStatusLabel1.Text = "Loading Webpage";
        }
        /// <summary>
        /// This function will fire every single time a key is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if the keystroke was enter than do something
            if (e.KeyChar == (char)ConsoleKey.Enter )
            {
                //NavigatetoPage();
                button1_Click(null, null);
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            button1.Enabled = true;
            textBox1.Enabled = true;
            toolStripStatusLabel1.Text = "Loading Complete";
        }

        //Navigates webBrowser1 to the next page in history.
        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        //Disabls the Forward button at the end of navigation history.
        private void webBrowser1_CanGoForwardChanged(object sender, EventArgs e)
        {
            button2.Enabled = webBrowser1.CanGoForward;
        }

        //Navigates webBrowser1 to the previous page in the history.
        private void button3_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        //Disables the back button at the beginning of the navigation history.
        private void webBrowser1_CanGoBackChanged(object sender, EventArgs e)
        {
            button3.Enabled = webBrowser1.CanGoBack;
        }

        //Halts the current navigation and any soundds or animation on
        //the page
        private void button4_Click(object sender, EventArgs e)
        {
            webBrowser1.Stop();
        }

        //Reloads the current page.
        private void button5_Click(object sender, EventArgs e)
        {
            //Skip refresh if about:blank is loaded to avoid removing
            //content specified by the DocumentText property.
            if(!webBrowser1.Url.Equals("about:blank"))
            {
                webBrowser1.Refresh();
            }
        }


    }
}
