using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using Color = System.Drawing.Color;
using Font = System.Drawing.Font;

namespace TextDocument
{
    public partial class NotePad : Form
    {
        private Zoom zoom;
        public NotePad()
        {
            InitializeComponent();
            zoom = new Zoom();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e, MessageBoxButtons messageBoxButtons)
        {
          
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string info = "";
            int k = info.Length;
            if (textBox1.Text.Length > k)
            {
                const string message = "Do you want to save";
                const string caption = "Info";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    // cancel the closure of the form.
                    MessageBox.Show("Open document Now");
                    open1();
                }
                else
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Text Document(*.txt)|*.txt|All Files(*.*)|*.*";
                    saveFileDialog.ShowDialog();
                    StreamWriter SaveFile = new StreamWriter(saveFileDialog.FileName);
                    SaveFile.WriteLine(textBox1.Text);
                    SaveFile.Close();

                    MessageBox.Show("Saved Now Open Document");
                    open1();

                }
            }
            else
                open1();
              
        }
       public void open1()
        {
            openFileDialog1.ShowDialog();
            StreamReader OpenFile = new StreamReader(openFileDialog1.FileName);
            textBox1.Text = OpenFile.ReadToEnd();
            OpenFile.Close();
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
           
            StreamWriter a=new StreamWriter(Application.StartupPath + "\\form\\" + "custdetails.txt");
            a.WriteLine(textBox1+" ");
            a.Close();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string info = "k";
            int k = info.Length;
            if (k> textBox1.Text.Length)
            {
                MessageBox.Show("Please write any thing to save", "Info", MessageBoxButtons.OKCancel);
            }
            else
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text Document(*.txt)|*.txt|All Files(*.*)|*.*";
                saveFileDialog.ShowDialog();
                StreamWriter SaveFile = new StreamWriter(saveFileDialog.FileName);
                SaveFile.WriteLine(textBox1.Text);
                SaveFile.Close();
                textBox1.Clear();
            }
        }
    
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string info = "";
            int k = info.Length;
            if (textBox1.Text.Length > k)
            {
                const string message = "Do you want to save";
                const string caption = "Info";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    // cancel the closure of the form.
                    textBox1.Clear();
                }
                else
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Text Document(*.txt)|*.txt|All Files(*.*)|*.*";
                    saveFileDialog.ShowDialog();
                    StreamWriter SaveFile = new StreamWriter(saveFileDialog.FileName);
                    SaveFile.WriteLine(textBox1.Text);
                    SaveFile.Close();
                    textBox1.Clear();
                }
            }

            else
                textBox1.Clear();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("Please write Firs to print", "Info", MessageBoxButtons.OKCancel);
            }
            else
            {
                printPreviewDialog1.Document = printDocument1;
                if (printDialog1.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.Print();
                }
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(textBox1.Text, textBox1.Font, Brushes.Black, 12, 10);
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("Please write Firs to preview", "Info", MessageBoxButtons.OKCancel);
            }
            else
            {
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.ShowDialog();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
             textBox1.Redo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }

        private void deleteAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectedText = "";
        }

      /*  private void fontsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }*/

        /*private void highlightTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }*/
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 0)
            {
                MessageBox.Show("Please write First to search", "Info", MessageBoxButtons.OKCancel);
            }
            else
            {
                if (CountStringOccurrences(textBox1.Text, textBox2.Text) > 0)
                {
                    MessageBox.Show("Found 1 or multiple matches");
                }
                else
                {
                    MessageBox.Show("Didn't found match...");
                }
                textBox2.Text = "";
                const string message = "Do you want to Search more";
                const string caption = "Info";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    // cancel the closure of the form.
                    button1.Visible = false;
                    textBox2.Visible = false;
                }
                else
                {

                }
            }
        }
        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {

           
            if(textBox1.Text.Length==0)
            {
                MessageBox.Show("Empty Notepad", "Info", MessageBoxButtons.OKCancel);
            }
            else
            {
                button1.Visible = true;
                textBox2.Visible = true;
            }
        }

        public static int CountStringOccurrences(string text, string pattern)
        {
            // Loop through all instances of the string 'text'.
            int count = 0;
            int i = 0;
            while ((i = text.IndexOf(pattern, i)) != -1)
            {
                i += pattern.Length;
                count++;
            }
            return count;
        }

        private void dateTTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime d=DateTime.Now;
            MessageBox.Show("Date and time is" + d + " ", "Date&Time", MessageBoxButtons.OKCancel);
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            textBox1.SelectionFont = new Font(fontDialog1.Font.FontFamily, fontDialog1.Font.Size, fontDialog1.Font.Style);
        }

        private void highlightTextToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox1.SelectionBackColor = Color.Yellow;
        }

        private void wordWrapeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wordWrapeToolStripMenuItem.Checked == true)
            {
                wordWrapeToolStripMenuItem.Checked = false;
                textBox1.WordWrap = false;
            }
            else
            {
                wordWrapeToolStripMenuItem.Checked = true;
                textBox1.WordWrap = true;
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog c = new ColorDialog();
            if(c.ShowDialog() == DialogResult.OK)
            {
                textBox1.ForeColor = c.Color;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string detail = "Notepad is a generic text editor included with all versions of Microsoft Windows that lets you create, open, and read plaintext files with a . txt file extension. If the file contains special formatting or is not a plaintext file, it cannot be read in Notepad";
            MessageBox.Show(" " + detail, "About", MessageBoxButtons.OK);
        }

        private void upperCaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
          textBox1.Text=textBox1.Text.ToUpper();

        }

        private void lowerCaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.ToLower();
        }

    

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float currentSize;
            currentSize = textBox1.Font.Size;
            currentSize += 2.0F;
            textBox1.Font = new Font(textBox1.Font.Name, currentSize,
            textBox1.Font.Style, textBox1.Font.Unit);
        }

        private void zommOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float currentSize;
            currentSize = textBox1.Font.Size;
            currentSize -= 2.0F;
            textBox1.Font = new Font(textBox1.Font.Name, currentSize,
            textBox1.Font.Style, textBox1.Font.Unit);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           /* float currentsizeM;
            currentsizeM = textBox1.Font.Size;*/
        }

  

        private void defaultZoomToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            float currentSize=8.0f;
           
            textBox1.Font = new Font(textBox1.Font.Name, currentSize,
            textBox1.Font.Style, textBox1.Font.Unit);
        }

        private void textBox1_MouseHover(object sender, EventArgs e)
        {
            int count = textBox1.Lines.Count();
           // MessageBox.Show("Lines are: " + count);
            /*    string strtext = textBox1.Text;
                strtext = strtext.Replace('\r', '\n').Trim();
               int rslt = 0;
                foreach (string s in strtext.Split('\n'))
                    rslt++;
    */
            string strInput = default(string);
            strInput = textBox1.Text;
            string[] strSplit = null;
            strSplit = strInput.Split(' ');
            int a = int.Parse("" + strSplit.Length);
            
            toolStripStatusLabel1.Text = "Write something";
            //int name1 =textBox1.Text.Length;
            toolStripStatusLabel2.Text = (a + count - 1).ToString();
        }

        
        

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Running";
        }

        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.Black;
            textBox1.ForeColor = Color.White;
        }

        private void toolStripStatusLabel4_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.White;
            textBox1.ForeColor = Color.Black;
        }

        private void wordCountToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int count=textBox1.Lines.Count();
            MessageBox.Show("Lines are: " + count);
            /*    string strtext = textBox1.Text;
                strtext = strtext.Replace('\r', '\n').Trim();
               int rslt = 0;
                foreach (string s in strtext.Split('\n'))
                    rslt++;
    */
            string strInput = default(string);
            strInput = textBox1.Text;
            string[] strSplit = null;
            strSplit = strInput.Split(' ');
            int a = int.Parse(""+strSplit.Length);
            MessageBox.Show("Number of words: " + (a+count-1));
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

        }
    }
}
