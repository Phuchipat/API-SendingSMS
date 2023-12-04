using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Collections.Specialized;
using System.IO;
using MetroFramework;
namespace SMS
{
    public partial class Form1 : Form
    {
        public string apiKey {get; set;}
        public string numbers {get; set;}
        public string message {get; set;}
        public string sender {get; set;}
        public string result;
        
        public Form1()
        {
            InitializeComponent();
        }
  
        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            apiKey = materialSingleLineTextField1.Text;
            numbers = materialSingleLineTextField3.Text;
            message = bunifuCustomTextbox1.Text;
            sender = materialSingleLineTextField2.Text;

            string url = "https://api.txtlocal.com/send/?apikey=" + apiKey + "&numbers=" + numbers + "&message=" + message + "&sender=" + sender;
            StreamWriter myWriter = null;
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);

            objRequest.Method = "POST";
            objRequest.ContentLength = Encoding.UTF8.GetByteCount(url);
            objRequest.ContentType = "application/x-www-form-urlencoded";
            try
            {
                myWriter = new StreamWriter(objRequest.GetRequestStream());
                myWriter.Write(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show(null, "the error is" + ex, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            finally
            {
                myWriter.Close();
            }

            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
            {
                result = sr.ReadToEnd();
                sr.Close();
            }
            MetroFramework.MetroMessageBox.Show(this, "Successfully Sent!", "Message has been Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
            materialSingleLineTextField1.Text = String.Empty;
            materialSingleLineTextField2.Text = String.Empty;
            materialSingleLineTextField3.Text = String.Empty;
            bunifuCustomTextbox1.Text = String.Empty;
        }  
        }
    }

