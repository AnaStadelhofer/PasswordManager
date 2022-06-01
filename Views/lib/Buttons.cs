using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telas;

namespace lib
{
    public class Buttons : Form
    {
        public Buttons()
        {}
        public void btnVoltarClick(object sender, EventArgs e)
        {
            this.Close();
        }  

    }
}