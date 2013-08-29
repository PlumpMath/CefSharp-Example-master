using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CefSharp.WinForms;
using CefSharp;

namespace Test
{
    public partial class Form1 : Form
    {
        WebView webView;
        string _str;

        public Form1()
        {
            InitializeComponent();
        }

//        protected void OnElementClicked(object sender, EventArgs args)
//        {
//            HtmlElement el = sender as HtmlElement;
//            string id = el.GetAttribute("id");

//            string elType = el.GetAttribute("type");
//            string elName = el.GetAttribute("name");
//            string elValue = el.GetAttribute("value");
//            _str = "Clicked: " + elType + " " + elName + " " + elValue + "\r\n";

//            string msg = string.Format("{0}\n {1}, {2}, {3}",
//                id
//, elType
//, elName
//, elValue);



//            MessageBox.Show(msg);
//        }


        public void Test(String message)
        {
            MessageBox.Show(message, "client code");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //webBrowser1.Document.InvokeScript("test",
            //    new String[] { "called from client code" });
        }

        private void whatSizeIsThatBut()
        {
            string str = string.Format("button height{0} width{1}", this.button1.Size.Height, this.button1.Size.Width);
            str = string.Format("loc X({0}) Y({1})", button1.Location.X, button1.Location.Y);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string fn = @"C:\FxM\Dev\New folder\myhtml\App_Data\HTMLPage1.htm";

            //C:\FxM\Dev\New folder\myhtml\App_Data
            string appDir = System.IO.Directory.GetCurrentDirectory() + "\\App_Data"+"\\";
            fn = appDir + "HTMLPage1.htm";
            
            string uri = "file://" + fn;
            //this.webBrowser1.Url = new System.Uri(uri, System.UriKind.Absolute);


            //webView = new WebView("http://www.google.com", new BrowserSettings());
            webView = new WebView(uri, new BrowserSettings());

            whatSizeIsThatBut();
            // button1.Location.X, button1.Location.Y
            // FM 8/28/13 webView.Top = button1.Location.Y;
            webView.Top = button1.Location.Y + button1.Height;
            webView.Left = button1.Location.X;
            //webView.Size = new Size(333, 444);
            webView.Size = new Size(button1.Width, 444);
            //webView.Size = button1.Size;
            
            
// FM begin
            webView.RegisterJsObject("bob", new MyJSBindObj.MyJSBindObj());
// FM end

            webView.PropertyChanged += new PropertyChangedEventHandler(webView_PropertyChanged);

            // fm begin
            //this.webView.PreviewKeyDown += new PreviewKeyDownEventHandler(this.webView_PreviewKeyDown);
           // fm end
            //webView.Dock = DockStyle.Fill;
            //webView.Size = new Size(333,444);
            
            webView.ContentsHeight  = (this.ClientSize.Height - webView.Height) / 2;

            this.Controls.Add(webView);
        }

        private void webView_PreviewKeyDown(object sender, EventArgs e)
        {
            ;
        }

        
        // Get all propertys from https://github.com/chillitom/CefSharp/blob/master/CefSharp/BrowserCore.h
        void webView_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            BrowserCore core = (BrowserCore)sender;
            switch (e.PropertyName)
            {
                case "IsBrowserInitialized":
                    //core.IsBrowserInitialized
                    break;
                case "Title":
                    //core.Title
                    break;
                case "Address":
                    //core.Address
                    break;
                case "CanGoBack":
                    //core.CanGoBack
                    break;
                case "CanGoForward":
                    //core.CanGoForward;
                    break;
                case "IsLoading":
                    //core.IsLoading
                    break;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();

            string appDir = System.IO.Directory.GetCurrentDirectory() + "\\App_Data" + "\\";
            dialog.InitialDirectory = appDir;
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string uri = dialog.FileName;
                
                //this.webBrowser1.Navigate(uri);
                this.webView.Load(uri);
            }


        }
    }
}
