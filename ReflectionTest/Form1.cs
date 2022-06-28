using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace ReflectionTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       private static Dictionary<string, string> GetProp(object model)
        {

            Dictionary<string, string> RefProperty = new Dictionary<string, string>();
            foreach (var propInfo in model.GetType().GetProperties())
            {
                RefProperty.Add(propInfo.Name, propInfo.GetValue(model).ToString());                
            }
            return RefProperty;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Student stu = new Student { Name = "saeed", Family = "rahgooy", Age = 43, StudentID = 1 };
            var prop = GetProp(stu);
            List<string> propName = new List<string>();
            List<string> propValue = new List<string>();
            foreach (KeyValuePair<string,string> item in prop)
            {
                propName.Add(item.Key);
                propValue.Add(item.Value);
            }
            listBox1.DataSource = propName;            
            listBox2.DataSource = propValue;            
        }
    }
}
