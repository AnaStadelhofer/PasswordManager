using System;
using System.Windows.Forms;
using lib;
using Models;
using Controllers;
using System.Drawing;

namespace Telas
{
    public class SenhaView : Form
    {
        private System.ComponentModel.IContainer components = null;
        ListView listView;
        Form parent;
        Button btnVoltar;
        Button btnInsert;

        public SenhaView(Form parent)
        {
            this.parent = parent;
            btnVoltar = new Campos.ButtonField("Voltar", 25, 450, 100, 30);
			btnVoltar.Click += new EventHandler(this.btnVoltarClick);

            btnInsert = new Campos.ButtonField("Cadastrar", 130, 450, 100, 30);
            btnInsert.Click += new EventHandler(this.btnInsertClick);

            // Select dos registros

            listView = new Campos.FieldListView(25, 25, 450, 400);
			listView.View = View.Details;
			foreach(Senha item in SenhaCtrl.VisualizarSenha())
            {
                ListViewItem list = new ListViewItem(item.Id + "");
                list.SubItems.Add(item.Nome);
                list.SubItems.Add(item.Categoria.Nome);
                list.SubItems.Add(item.Url);
                list.SubItems.Add(item.Usuario);
                list.SubItems.Add(item.SenhaEncrypt);
                list.SubItems.Add(item.Procedimento);
                listView.Items.AddRange(new ListViewItem[]{list});
            }
			listView.Columns.Add("Id", -2, HorizontalAlignment.Left);
    		listView.Columns.Add("Nome", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Categoria Id", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Url", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Usuario", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Senha Encrypt", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Procedimento", -2, HorizontalAlignment.Left);
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
            this.Text = "Senha";
        }

        // Funções dos botões
        public void btnVoltarClick(object sender, EventArgs e)
        {
            this.Hide();
            Menu Menus = new Menu(this);
            Menus.ShowDialog();
        }   

        public void btnInsertClick(object sender, EventArgs e)
        {
            CadastrarSenha CadastrarSenhas = new CadastrarSenha(this);
            this.Hide();
            CadastrarSenhas.ShowDialog();
            this.parent.Close();
        }
        
    }

}