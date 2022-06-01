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

        public CadastrarSenha(Form parent)
        {
            this.parent = parent;

            btnVoltar = new Campos.ButtonField("Voltar", 50, 250, 100, 30);
			btnVoltar.Click += new EventHandler(this.btnVoltarClick);

            btnInsert = new Campos.ButtonField("Confirmar", 150, 250, 100, 30);
			btnInsert.Click += new EventHandler(this.btnInsertClick);

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 300);
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