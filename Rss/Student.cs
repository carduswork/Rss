using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rss
{
    class Student
    {
        private string name;
        private string type;
        private string num;

        public Student(string name,string type,string num)
        {
            this.name = name;
            this.type = type;
            this.num = num;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public string Num
        {
            get { return num; }
            set { num = value; }
        }
    }
}
