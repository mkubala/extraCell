using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using extraCell.formula;

namespace extraCell.view
{
    public partial class DostepneFunkcje : Form
    {
        public DostepneFunkcje()
        {
            InitializeComponent();
        }

        private void DostepneFunkcje_Load(object sender, EventArgs e)
        {
            
            Type[] types = Assembly.GetExecutingAssembly().GetTypes().Where(t => String.Equals(t.Namespace, "extraCell.formula.functions", StringComparison.Ordinal)).ToArray();
            
            foreach(Type type in types)
            {
                listaFunkcjiBox.Items.Add(type.Name);
            }
            
            listaFunkcjiBox.SelectedIndex = 0;
        }

        private void listaFunkcjiBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Type p = System.Type.GetType("extraCell.formula.functions." + listaFunkcjiBox.SelectedItem);
            IFunction function =  (IFunction)Activator.CreateInstance(p);

            StringBuilder exampleList = new StringBuilder();

            foreach (string example in function.getExamples())
            {
                exampleList.Append("=");
                exampleList.Append(example);
                exampleList.AppendLine();
            }

            przykladyLabel.Text = exampleList.ToString();

            opisLabel.Text = function.getHelp();
        }
    }
}
