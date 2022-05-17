using System;
using System.Windows.Forms;
using lib;
using Models;
using Controllers;
using System.Drawing;

namespace Telas
{
    public class EditarCategoria : Form
    {
        private System.ComponentModel.IContainer components = null;
        Form parent;
        int Id;
        TextBox txtNome;
        TextBox txtDescricao;
        Label lblNome;
        Label lblDescricao;
        Button btnVoltar;
        Button btnInsert;

        public EditarCategoria(Form parent, int Id)
        {
            this.parent = parent;
            this.Id = Id;
            Categoria categoria = Models.Categoria.GetCategoria(Id);

            this.lblNome = new Campos.LabelField("Nome:", 70, 40);
            this.txtNome = new Campos.TextBoxField(70, 80, 200, 200);
            this.txtNome.Text = categoria.Nome;

            this.lblDescricao = new Campos.LabelField("Descrição:", 70, 120);
            this.txtDescricao = new Campos.TextBoxField(70, 160, 200, 200);
            this.txtDescricao.Text = categoria.Descricao;

            btnVoltar = new Campos.ButtonField("Voltar", 50, 300, 100, 30);
			btnVoltar.Click += new EventHandler(this.btnVoltarClick);

            btnInsert = new Campos.ButtonField("Confirmar", 200, 300, 100, 30);
			btnInsert.Click += new EventHandler(this.btnInsertClick);

            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnInsert);

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 350);
            this.Text = "Editar Categoria";
        }

        public void btnVoltarClick(object sender, EventArgs e)
        {
            this.Hide();
            CategoriaView CategoriaViews = new CategoriaView(this);
            CategoriaViews.ShowDialog();
            this.parent.Close();
        } 

        public void btnInsertClick(object sender, EventArgs e)
        {
            CategoriaCtrl.UpdateCategoria(Id, this.txtNome.Text, this.txtDescricao.Text);
            CategoriaView categoriaViews = new CategoriaView(this);
            this.Hide();
            categoriaViews.ShowDialog();
            this.parent.Close();
        }  
        
    }

}