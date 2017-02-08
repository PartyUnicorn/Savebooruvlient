using System;
using System.Net;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
namespace savebooruclient
{
    /// <summary>
    /// Made by Vanilla
    /// </summary>
    public partial class MainWindow : Window
    {
        public int number1;
        public string tag;
        public string tag1;

        public string Speicherort = (@"C:\Users\" + Environment.UserName + @"\Pictures");
        public int menge;
        List<string> Link = new List<string>();
        List<string> id = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            textBox.Text = "neko";
            label1.Content = @"The pictures will be saved in "+Speicherort+"";
            label.Content = "";
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (radioButton.IsChecked == true)
            {
                ausgabesave();
            }
            if (radioButton1.IsChecked == true)
            {
                ausgabegel();
                
            }
        }

        private void speicherorteandern_Click(object sender, RoutedEventArgs e)
        {
            speichereandern.Visibility = Visibility.Visible;
            Speicherortspeichern.Visibility = Visibility.Visible;
        }

        private void button1_Click(object sender, RoutedEventArgs e) 
        {
            try
            {
                string user = Environment.UserName;
                System.IO.Directory.CreateDirectory(Speicherort);
                using (WebClient wc = new WebClient())
                wc.DownloadFile("http:" + Link[number1], Speicherort + id[number1]+".jpg");
                
            }
            catch (Exception)
            {
                label.Content = "Sorry, something went wrong: Please try again!";
                return;
            }
        }
        private void textBox_TextChanged(object sender, TextChangedEventArgs e){}
        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            System.IO.Directory.CreateDirectory(speichereandern.Text);
            //string _ueberpruefespeicherort = speichereandern.Text
            Speicherort = speichereandern.Text;
            label1.Content = @"The pictures will be saved in " + Speicherort + "";
            speichereandern.Visibility = Visibility.Hidden;
            Speicherortspeichern.Visibility = Visibility.Hidden;
        }
        private void ausgabegel()
        {
            try
            {
                if (textBox.Text == tag1)
                {
                    label.Content = "";
                    Random numbern1 = new Random();
                    number1 = numbern1.Next(0, menge);
                    image.Source = new BitmapImage(new Uri(@"http:" + Link[number1]));
                    tag1 = textBox.Text;

                    textBox1.Text = "http:" + Link[number1];
                }
                else
                {
                    label.Content = "";

                    Link.Clear();
                    id.Clear();



                    XmlDocument doc = new XmlDocument();
                    doc.Load(@"http://gelbooru.com/index.php?page=dapi&s=post&q=index&tags=" + textBox.Text + "&limit=50");
                    XmlElement root = doc.DocumentElement;
                    foreach (XmlNode daten in root.ChildNodes)
                    {
                        Link.Add(daten.Attributes["file_url"].InnerText);
                        id.Add(daten.Attributes["id"].InnerText);
                    }
                    menge = Link.Count;


                    Random number = new Random();
                    number1 = number.Next(0, menge);
                    image.Source = new BitmapImage(new Uri("http:" + Link[number1]));
                    tag1 = textBox.Text;
                    textBox1.Text = "http:" + Link[number1];

                }
            }

            catch (Exception)
            {
                label.Content = "Sorry, something went wrong: Please try again later";
                return;
            }
        }

        private void ausgabesave()
        {
            try
            {
                if (textBox.Text == tag)
                {
                    label.Content = "";
                    Random numbern1 = new Random();
                    number1 = numbern1.Next(0, menge);
                    image.Source = new BitmapImage(new Uri(@"http:" + Link[number1]));
                    tag = textBox.Text;
                   // label.Content = "if";
                    textBox1.Text = "http:" + Link[number1];
                }
                else
                {
                    label.Content = "";

                    Link.Clear();
                    id.Clear();



                    XmlDocument doc = new XmlDocument();
                    doc.Load(@"https://safebooru.org/index.php?page=dapi&s=post&q=index&tags=" + textBox.Text + "&limit=50");
                    XmlElement root = doc.DocumentElement;
                    foreach (XmlNode daten in root.ChildNodes)
                    {
                        Link.Add(daten.Attributes["file_url"].InnerText);
                        id.Add(daten.Attributes["id"].InnerText);
                    }
                    menge = Link.Count;
                   

                    Random number = new Random();
                    number1 = number.Next(0, menge);
                    image.Source = new BitmapImage(new Uri(@"http:" + Link[number1]));
                    tag = textBox.Text;
                    textBox1.Text = "http:" + Link[number1];
                }
            }



            catch (Exception)
            {
                label.Content = "Sorry, something went wrong: Please try again later";
                return;
            }
        }


    }
}
