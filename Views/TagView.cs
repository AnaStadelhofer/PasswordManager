using System;
using System.Windows.Forms;
using lib;
using Models;
using Controllers;
using System.Drawing;

namespace Telas
{
    public class TagView : Form
    {
        private System.ComponentModel.IContainer components = null;

        ListView listView;
        Button btnVoltar;
        Button btnInsert;
        public TagView()
        {

            btnVoltar = new Campos.ButtonField("Voltar", 25, 450, 100, 30);
			btnVoltar.Click += new EventHandler(this.btnVoltarClick);

            btnInsert = new Campos.ButtonField("Cadastrar", 130, 450, 100, 30);
			btnInsert.Click += new EventHandler(this.btnInsertClick);

            // Select dos registros

            listView = new Campos.FieldListView(25, 25, 450, 400);
			listView.View = View.Details;
			foreach(Tag item in TagCtrl.VisualizarTag())
            {
                ListViewItem list = new ListViewItem(item.Id + "");
                list.SubItems.Add(item.Descricao);
                listView.Items.AddRange(new ListViewItem[]{list});
            }
			listView.Columns.Add("Id", -2, HorizontalAlignment.Left);
    		listView.Columns.Add("Descrição", -2, HorizontalAlignment.Left);
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
            this.Text = "Tag";
        }

        // Funções dos botões
        public void btnVoltarClick(object sender, EventArgs e)
        {
            this.Close();
        }   
        
        public void btnInsertClick(object sender, EventArgs e)
        {
            CadastrarTag CadastrarTags = new CadastrarTag();
            CadastrarTags.ShowDialog();
        }   

    }

}