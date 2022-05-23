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

        Form parent;
        ListView listView;
        Button btnVoltar;
        Button btnInsert;
        Button btnDelete;
        Button btnUpdate;

        public UsuarioView(Form parent)
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
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 500);
            this.Text = "Usuario";
        }

        // Funções dos botões
        public void btnVoltarClick(object sender, EventArgs e)
        {
            this.Hide();
            Menu Menus = new Menu(this);
            Menus.ShowDialog();
        } 

        public void btnUpdateClick(object sender, EventArgs e)
        {
            try
            {            
                if (listView.SelectedItems.Count > 0) 
                {
                    ListViewItem li = listView.SelectedItems[0];
                    EditarUsuario editUsuario = new EditarUsuario(this, Convert.ToInt32(li.Text));
                    this.Hide();
                    editUsuario.ShowDialog();
                    this.parent.Close();

                }  
                else
                {
                    MessageBox.Show("Selecione um usuário para editar", "Erro");
                }                 
            }
            catch(Exception)
            {
                MessageBox.Show("Selecione um usuário para editar", "Erro");
            } 
        }

        public void btnInsertClick(object sender, EventArgs e)
        {
            CadastrarUsuário CadastrarUsuários = new CadastrarUsuário(this);
            this.Hide();
            CadastrarUsuários.ShowDialog();
            this.parent.Close();
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
                        UsuarioCtrl.DeleteUsuarios(Convert.ToInt32(li.Text));
                        UsuarioView usuarioView = new UsuarioView(this);
                        this.Hide();
                        usuarioView.ShowDialog();
                        this.parent.Close();
                        
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