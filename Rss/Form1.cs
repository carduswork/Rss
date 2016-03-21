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
            listView1.Items.Clear();
            listView1.Items.AddRange(stus);
        }
    }
}
