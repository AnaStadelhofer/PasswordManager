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
    public class Campos : Form
    {
        public Campos()
        {}
        
        public class LabelFieldTam : Label
        {
            public LabelFieldTam(string Text, int x, int y, int Z, int W)
            {
                this.Text = Text;
                this.Location = new Point(x, y);
                this.Size = new Size(Z, W);
            }
        }

        public class LabelField : Label
        {
            public LabelField(string Text, int x, int y)
            {
                this.Text = Text;
                this.Location = new Point(x, y);
            }
        }

        public class ButtonField : Button
        {
            public ButtonField(string Text, int x, int y, int Z, int W)
            {
                this.Text = Text;
                this.Location = new Point(x, y);
                this.Size = new Size(Z, W);
                this.BackColor = Color.White;
            }
        }

        public class TextBoxField : TextBox
        {
            public TextBoxField(int x, int y, int Z, int W)
            {
                this.Location = new Point(x, y);
                this.Size = new Size(Z, W);
            }
        } 

        public class FieldListView : ListView
        {
            public FieldListView(int x, int y, int Z, int W)
            {
                this.Location = new Point(x, y);
                this.Size = new Size(Z, W);
            }
        }
        
    }
}