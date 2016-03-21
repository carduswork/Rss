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
            stus.Add(new Student("你", "小米", "110"));
            stus.Add(new Student("他", "魅族", "119"));
            stus.Add(new Student("我", "华为", "120"));
            reload();

        }

        private void reload()
        {
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
            stus.Add(new Student(textBox1.Text,textBox2.Text,textBox3.Text));
            reload();
            textBox3.Clear();
            textBox1.Clear();
            textBox2.Clear();
        }
    }
}
