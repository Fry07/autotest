using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = 0;
            string st = "";
            try
            {
                //string[] dirs = Directory.GetFiles(@"C:\TestRun\new_test\TestBed", "*.PrjScr", SearchOption.AllDirectories);
                string[] dirs = Directory.GetFiles(textBox1.Text.ToString(), "*.PrjScr", SearchOption.AllDirectories);

                foreach (string dir in dirs)
                {
                    st += Path.GetFileName(dir).Split('.')[0] + "\n";
                    count++;
                }
            }
            catch (Exception ex)
            {
                st += ("The process failed: {0}" + ex.ToString());
            }
            st += "\nTotal count: " + count;
            richTextBox1.Text = st.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (StreamReader str = new StreamReader(textBox2.Text.ToString(), Encoding.Default))
            {
                string txtFile = str.ReadToEnd();

                richTextBox1.Text = GetText(txtFile);
                
            }
        }
        public string GetText(string str)
        {
            string res = null;
            int count = 0;
            Regex pattern =
                new Regex(@"\[(?<val>.*?)\]",
                    RegexOptions.Compiled |
                    RegexOptions.Singleline);

            foreach (Match m in pattern.Matches(str))
                if (m.Success)
                {
                    res += (m.Groups["val"].Value) + "\n";
                    count++;
                }
            res += "\nTotal count: " + count;
            return res;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string a = textBox3.Text.ToString();
            string b = textBox4.Text.ToString();            
            int count = 0;

            var mas1 = File.ReadAllLines(textBox3.Text.ToString()).ToArray();
            var mas2 = File.ReadAllLines(textBox4.Text.ToString()).ToArray();

            List<string> keywords2 = mas1.Except(mas2).ToList<string>();

            richTextBox1.Text = "Files that are present in " + GetFileName(a) + " and are absent in " + GetFileName(b) + ":\n\n";                  
            
            foreach (string s in keywords2)
            {
                richTextBox1.Text += s + "\n";
                count++;
            }
            richTextBox1.Text += "\nTotal count: "+ count;
        }

        private string GetFileName(string Path)
        {
            string newVal = null;
            for (int i = Path.Length - 1; i > 0; i--)
            {
                if (Path[i] == '/')
                {
                    break;
                }
                newVal += Path[i];
            }
            var tt = newVal.ToCharArray();
            Array.Reverse(tt);
            return new string(tt);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string tmp = null;
            tmp = textBox3.Text.ToString();
            textBox3.Text = textBox4.Text.ToString();
            textBox4.Text = tmp;
        }
    }
}
    