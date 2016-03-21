using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.IO;
namespace Rss
{
    public partial class Form1 : Form
    {
        List<Student> stus = new List<Student>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            using (StreamReader sr = new StreamReader("stus_log.txt"))
            {
                while (!sr.EndOfStream)
                {
                    stus.Add(new Student(sr.ReadLine(), sr.ReadLine(), sr.ReadLine()));
                }
                reload();
            }
        }

        private void reload()
        {
            //从泛型读
            
            listView1.Items.Clear();
            foreach (Student s in stus)
            {
                ListViewItem lvi = new ListViewItem(s.Name);
                lvi.SubItems.Add(s.Type);
                lvi.SubItems.Add(s.Num);
                listView1.Items.Add(lvi);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            stus.Add(new Student(textBox1.Text, textBox2.Text, textBox3.Text));
            /*修改了stus后文件清空再写入*/
            SaveToTxt();
            reload();
            textBox3.Clear();
            textBox1.Clear();
            textBox2.Clear();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaveToTxt();
            MessageBox.Show("SAVED");
        }

        private void SaveToTxt()
        {
            FileStream fs = new FileStream("stus_log.txt",FileMode.Truncate,FileAccess.Write);
            fs.Close();
            StreamWriter sw = new StreamWriter("stus_log.txt");
            //sw.Write("写入");
            foreach (Student s in stus)
            {
                sw.WriteLine(s.Name);
                sw.WriteLine(s.Type);
                sw.WriteLine(s.Num);
            }
            sw.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //获取选中行
            int index = listView1.SelectedItems[0].Index;
            try
            {
            stus.Remove(stus[index]);
            SaveToTxt();
            reload();
            }
            catch (Exception)
            {
                Console.WriteLine("删除失败");
                throw;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (StreamReader sr = new StreamReader("stus_log.txt"))
            {
                int count = 0;
                while (!sr.EndOfStream)
                {
                    sr.ReadLine();
                    count++;
                }
                string m = string.Format("数据共有{0}个", count / 3);
                MessageBox.Show(m);
            }
        }
    }
}
