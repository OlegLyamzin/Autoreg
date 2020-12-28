using Autoreg.SeleniumOperations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autoreg
{
    public partial class Form1 : Form
    {
        SeleniumManager manager;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new SeleniumManager(new OperationCreator()).GMailRegistration();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            manager = new SeleniumManager(new OperationCreator());
        }
    }
}
