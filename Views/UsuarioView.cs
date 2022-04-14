using System;
using System.Windows.Forms;
using lib;
using Models;
using Controllers;
using System.Drawing;

namespace Telas
{
    public class UsuarioView : Form
    {
        private System.ComponentModel.IContainer components = null;

        ListView listView;
        Button btnVoltar;
        Button btnInsert;
        public UsuarioView()
        {

            btnVoltar = new Campos.ButtonField("Voltar", 25, 450, 100, 30);
			btnVoltar.Click += new EventHandler(this.btnVoltarClick);
            
            btnInsert = new Campos.ButtonField("Cadastrar", 130, 450, 100, 30);

            listView = new Campos.FieldListView(25, 25, 450, 400);
			listView.View = View.Details;
			foreach(Usuario item in UsuarioCtrl.VisualizarUsuario())
            {
                ListViewItem list = new ListViewItem(item.Id + "");
                list.SubItems.Add(item.Nome);	
                list.SubItems.Add(item.Email);
                listView.Items.AddRange(new ListViewItem[]{list});
            }
			listView.Columns.Add("Id", -2, HorizontalAlignment.Left);
    		listView.Columns.Add("Nome", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Email", -2, HorizontalAlignment.Left);
			listView.FullRowSelect = true;
			listView.GridLines = true;
			listView.AllowColumnReorder = true;
			listView.Sorting = SortOrder.Ascending;

            this.Controls.Add(this.listView);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnInsert);

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 500);
            this.Text = "Usuario";
        }

        public void btnVoltarClick(object sender, EventArgs e)
        {
            this.Close();
        }  
        
    }

}