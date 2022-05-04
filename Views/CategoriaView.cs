using System;
using System.Windows.Forms;
using lib;
using Models;
using Controllers;
using System.Drawing;

namespace Telas
{
    public class CategoriaView : Form
    {
        private System.ComponentModel.IContainer components = null;

        ListView listView;
        Button btnVoltar;
        Button btnInsert;
        Button btnDelete;
        public CategoriaView()
        {

            btnVoltar = new Campos.ButtonField("Voltar", 25, 450, 100, 30);
			btnVoltar.Click += new EventHandler(this.btnVoltarClick);
            
            btnInsert = new Campos.ButtonField("Cadastrar", 130, 450, 100, 30);
			btnInsert.Click += new EventHandler(this.btnInsertClick);

            btnDelete = new Campos.ButtonField("Deletar", 235, 450, 100, 30);
			btnDelete.Click += new EventHandler(this.btnDeleteClick);

            listView = new Campos.FieldListView(25, 25, 450, 400);
			listView.View = View.Details;
			foreach(Categoria item in CategoriaCtrl.VisualizarCategoria())
            {
                ListViewItem list = new ListViewItem(item.Id + "");
                list.SubItems.Add(item.Nome);	
                list.SubItems.Add(item.Descricao);
                listView.Items.AddRange(new ListViewItem[]{list});
            }
			listView.Columns.Add("Id", -2, HorizontalAlignment.Left);
    		listView.Columns.Add("Nome", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Descrição", -2, HorizontalAlignment.Left);
			listView.FullRowSelect = true;
			listView.GridLines = true;
			listView.AllowColumnReorder = true;
			listView.Sorting = SortOrder.Ascending;

            this.Controls.Add(this.listView);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnDelete);

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 500);
            this.Text = "Categoria";
        }

        public void btnVoltarClick(object sender, EventArgs e)
        {
            this.Close();
        }  

        public void btnInsertClick(object sender, EventArgs e)
        {
            CadastrarCategoria cadastrarCategoria = new CadastrarCategoria();
            cadastrarCategoria.ShowDialog();
        } 

        public void btnDeleteClick(object sender, EventArgs e)
        {
        
            DialogResult result = MessageBox.Show("Deseja realmente deletar?", "Confirmar", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                try
                {            
                    if (listView.SelectedItems.Count > 0) {
                        ListViewItem li = listView.SelectedItems[0];
                        MessageBox.Show("O item de id " + li.Text + " foi deletado com sucesso", "Deletado" );
                        CategoriaCtrl.DeleteCategorias(Convert.ToInt32(li.Text));
                    }                   
                }
                catch(Exception)
                {
                    MessageBox.Show("Erro ao deletar", "Erro");
                }
            }
        }
        
    }

}