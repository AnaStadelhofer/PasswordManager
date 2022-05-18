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
        Form parent;
        ListView listView;
        Button btnVoltar;
        Button btnInsert;
        Button btnDelete;
        Button btnUpdate;
        public TagView(Form parent)
        {

            this.parent = parent;

            btnVoltar = new Campos.ButtonField("Voltar", 25, 450, 100, 30);
			btnVoltar.Click += new EventHandler(this.btnVoltarClick);

            btnInsert = new Campos.ButtonField("Cadastrar", 130, 450, 100, 30);
			btnInsert.Click += new EventHandler(this.btnInsertClick);

            btnDelete = new Campos.ButtonField("Deletar", 235, 450, 100, 30);
			btnDelete.Click += new EventHandler(this.btnDeleteClick);

            btnUpdate = new Campos.ButtonField("Editar", 345, 450, 100, 30);
            btnUpdate.Click += new EventHandler(this.btnUpdateClick);

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
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
        
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 500);
            this.Text = "Tag";
        }

        // Funções dos botões
        public void btnVoltarClick(object sender, EventArgs e)
        {
            this.Hide();
            Menu Menus = new Menu(this);
            Menus.ShowDialog();
        }  

        public void btnDeleteClick(object sender, EventArgs e)
        {
        
            DialogResult result = MessageBox.Show("Deseja realmente deletar?", "Confirmar", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                try
                {            
                    if (listView.SelectedItems.Count > 0) 
                    {
                        ListViewItem li = listView.SelectedItems[0];
                        MessageBox.Show("O item de id " + li.Text + " foi deletado com sucesso", "Deletado" );
                        TagCtrl.DeleteTags(Convert.ToInt32(li.Text));
                    }                   
                }
                catch(Exception)
                {
                    MessageBox.Show("Erro ao deletar", "Erro");
                }
            }
        }   

        public void btnUpdateClick(object sender, EventArgs e)
        {
            try
            {            
                if (listView.SelectedItems.Count > 0) 
                {
                    ListViewItem li = listView.SelectedItems[0];
                    EditarTag editTag = new EditarTag(this, Convert.ToInt32(li.Text));
                    this.Hide();
                    editTag.ShowDialog();

                }  
                else
                {
                    MessageBox.Show("Selecione uma tag para editar", "Erro");
                }                 
            }
            catch(Exception)
            {
                MessageBox.Show("Selecione uma tag para editar", "Erro");
            }
            
        } 
        
        public void btnInsertClick(object sender, EventArgs e)
        {
            this.Hide();
            CadastrarTag CadastrarTags = new CadastrarTag(this);
            CadastrarTags.ShowDialog();
        }   

    }

}