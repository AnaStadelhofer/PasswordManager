using System;
using System.Windows.Forms;
using lib;
using Models;
using System.Drawing;

namespace Telas
{
    public class Menu : Form
    {
        Form parent;
        private System.ComponentModel.IContainer components = null;

        Label lblTitle;
        Button btnCategoria;
        Button btnTags;
        Button btnSenha;
        Button btnUsuario;
        Button btnSair;
        public Menu(Form parent)
        {
            this.parent = parent;
            this.BackColor = Color.FromArgb(179, 193, 220);

            this.lblTitle = new Campos.LabelFieldTam($"Bem vindo(a) " + Usuario.UsuarioAuth.Nome + " !", 100, 15, 150, 30);

            this.btnCategoria = new Campos.ButtonField("Categoria", 100, 50, 100, 30);
			btnCategoria.Click += new EventHandler(this.btnCategoriaClick);

            this.btnTags = new Campos.ButtonField("Tags", 100, 90, 100, 30);
			btnTags.Click += new EventHandler(this.btnTagClick);

            this.btnSenha = new Campos.ButtonField("Senhas", 100, 130, 100, 30);
			btnSenha.Click += new EventHandler(this.btnSenhaClick);

            this.btnUsuario = new Campos.ButtonField("Usuário", 100, 170, 100, 30);
			btnUsuario.Click += new EventHandler(this.btnUsuarioClick);

            this.btnSair = new Campos.ButtonField("Sair", 100, 210, 100, 30);
			this.btnSair.Click += new EventHandler(this.btnSairClick);

            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnCategoria);
            this.Controls.Add(this.btnTags);
            this.Controls.Add(this.btnSenha);
            this.Controls.Add(this.btnUsuario);
            this.Controls.Add(this.btnSair);

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Text = "Menu";
        }

        public void btnSairClick(object sender, EventArgs e)
        {
            Application.Exit();
        }  

        public void btnCategoriaClick(object sender, EventArgs e)
        {
            this.Hide();
            CategoriaView CategoriaViews = new CategoriaView(this);
            CategoriaViews.ShowDialog();
            this.parent.Close();
        }

        public void btnSenhaClick(object sender, EventArgs e)
        {
            this.Hide();
            SenhaView SenhaViews = new SenhaView();
            SenhaViews.ShowDialog();
            this.parent.Close();
        }   

        public void btnUsuarioClick(object sender, EventArgs e)
        {
            this.Hide();
            UsuarioView UsuarioViews = new UsuarioView(this);
            UsuarioViews.ShowDialog();
            this.parent.Close();
        } 

        public void btnTagClick(object sender, EventArgs e)
        {
            this.Hide();
            TagView TagViews = new TagView(this);
            TagViews.ShowDialog();
            this.parent.Close();
        } 

    }

}