using System;
using System.Windows.Forms;
using lib;
using Models;
using Controllers;
using System.Drawing;

namespace Telas
{
    public class CadastrarSenha : Form
    {
        private System.ComponentModel.IContainer components = null;
        Form parent;
        Button btnVoltar;
        Button btnInsert;
        Label lblNome;
        Label lblCategoria;
        Label lblUrl;
        Label lblUser;
        Label lblProcedimento;
        Label lblTags;

        public CadastrarSenha(Form parent)
        {
            this.parent = parent;

            this.lblNome = new Campos.LabelField("Nome:", 50, 50);

            this.lblCategoria = new Campos.LabelField("Categoria:", 50, 150);

            this.lblUrl = new Campos.LabelField("Url:", 50, 250);

            this.lblUser = new Campos.LabelField("Usuário:", 50, 350);

            this.lblProcedimento = new Campos.LabelField("Procedimento:", 50, 450);

            this.lblTags = new Campos.LabelField("Tags:", 50, 550);

            btnVoltar = new Campos.ButtonField("Voltar", 50, 750, 100, 30);
			btnVoltar.Click += new EventHandler(this.btnVoltarClick);

            btnInsert = new Campos.ButtonField("Confirmar", 150, 750, 100, 30);
			btnInsert.Click += new EventHandler(this.btnInsertClick);

            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblProcedimento);
            this.Controls.Add(this.lblTags);

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 800);
            this.Text = "Cadastrar Senha";
        }

        public void btnVoltarClick(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }

        public void btnInsertClick(object sender, EventArgs e)
        {
        } 
    }
}