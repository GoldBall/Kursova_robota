using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        // загрузка алгоритму з файла
        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStr = null;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStr = openFileDialog1.OpenFile()) != null)
                {
                    StreamReader myRead = new StreamReader(myStr);
                    string[] str;
                    int num = 0;
                    try
                    {
                        string[] str1 = myRead.ReadToEnd().Split('\n');
                        num = str1.Count();
                        dataGridView1.RowCount = num;
                        for (int i = 0; i < num; i++)
                        {
                            str = str1[i].Split(' ');
                            for (int j = 0; j < dataGridView1.ColumnCount; j++)
                            {
                                try
                                {
                                    dataGridView1.Rows[i].Cells[j].Value = str[j];
                                }
                                catch
                                {

                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        myRead.Close();
                    }
                }
            }
        }
        // вихід з програми
        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        //збереження алгоритма до файла
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    StreamWriter myWrite = new StreamWriter(myStream);
                    try
                    {
                        for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                        {
                            for (int j = 0; j < dataGridView1.ColumnCount; j++)
                            {
                                myWrite.Write(dataGridView1.Rows[i].Cells[j].Value.ToString() + " ");
                            }
                            myWrite.WriteLine();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        myWrite.Close();
                    }
                    myStream.Close();
                }
            }
        }
        //додавання алгоритму в таблицю
        private void button2_Click(object sender, EventArgs e)
        {
            string Znak = "->";
            string Stan1 = textBox2.Text;
            string Symvol1 = textBox3.Text;
            string Stan2 = textBox4.Text;
            string Symvol2 = textBox5.Text;
            string Napryamok = textBox6.Text;
            string age = textBox3.Text;
            dataGridView1.Rows.Add(Stan1, Symvol1, Znak, Stan2, Symvol2, Napryamok);
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }
        //видалення виділеного алгоритма
        private void button3_Click(object sender, EventArgs e)
        {
            int ind = dataGridView1.SelectedCells[0].RowIndex;
            dataGridView1.Rows.RemoveAt(ind);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView2.ColumnCount = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string porozhne = "^";
            string stan="s1";
            string slovo = null;
            string[] str1 = new string[100];
            // переведення вхідного слова
            for (int i = 0; i < dataGridView2.ColumnCount;i++ )
            {
                slovo =stan + dataGridView2.Rows[0].Cells[i].Value.ToString();
            }
            slovo = porozhne + slovo + porozhne;
            // виведення результату
            for (int i = 0; i < dataGridView1.RowCount-1; i++)
            {
                string s1 = dataGridView1.Rows[i].Cells[0].Value.ToString() + dataGridView1.Rows[i].Cells[1].Value.ToString();
                string s2 = dataGridView1.Rows[i].Cells[3].Value.ToString() + dataGridView1.Rows[i].Cells[4].Value.ToString();
                string s3 = dataGridView1.Rows[i].Cells[3].Value.ToString();
                Boolean d = slovo.Contains(s1);
                int index1 = slovo.IndexOf("s");
                int index2 = slovo.IndexOf(stan) - 1;
                char[] sd;
                string slovo2 = null;
                sd = slovo.ToCharArray();
                for (int ind = 0; ind < slovo.Length; ind++)
                {

                    slovo2 = sd[index1].ToString()+sd[index1+1];
                }
                    if (d == true)
                    {
                        string napryamok = dataGridView1.Rows[i].Cells[5].Value.ToString();
                        if (napryamok == "l")
                        {
                            for (int ind = 0; ind < slovo.Length; ind++)
                            {
                                slovo = sd[i].ToString();
                            }
                        }
                        if (napryamok == "r")
                        {
                            s2 = dataGridView1.Rows[i].Cells[4].Value.ToString() + dataGridView1.Rows[i].Cells[3].Value.ToString();
                        }
                        if (napryamok == "n")
                        {
                            s2 = dataGridView1.Rows[i].Cells[3].Value.ToString() + dataGridView1.Rows[i].Cells[4].Value.ToString();
                        }
                        slovo = slovo.Replace(s1, s2);
                    }
                listBox1.Items.Add(slovo2);
                listBox1.Items.Add(slovo);
            }
        }
        // занесення символа до слова
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
            {
                dataGridView2.ColumnCount = dataGridView2.ColumnCount + 1;
                dataGridView2.Rows[0].Cells[dataGridView2.ColumnCount - 1].Value = textBox1.Text;
                textBox1.Clear();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
    }
    }




