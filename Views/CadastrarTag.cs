using System;
using System.Windows.Forms;
using lib;
using Models;
using Controllers;
using System.Drawing;

namespace Telas
{
    public class CadastrarTag : Form
    {
        private System.ComponentModel.IContainer components = null;

        TextBox txtDescricao;
        Label lblDescricao;
        Button btnVoltar;
        Button btnInsert;

        public CadastrarTag()
        {

            this.lblDescricao = new Campos.LabelField("Descrição:", 50, 80);
            this.txtDescricao = new Campos.TextBoxField(50, 120, 200, 200);

            btnVoltar = new Campos.ButtonField("Voltar", 50, 250, 100, 30);
			btnVoltar.Click += new EventHandler(this.btnVoltarClick);

            btnInsert = new Campos.ButtonField("Confirmar", 150, 250, 100, 30);
			btnInsert.Click += new EventHandler(this.btnInsertClick);

            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnInsert);

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Text = "Cadastrar Tag";
        }

        public void btnVoltarClick(object sender, EventArgs e)
        {
            this.Close();
        } 

        public void btnInsertClick(object sender, EventArgs e)
        {
            TagCtrl.InsertTag(this.txtDescricao.Text);
            this.Close();
        }  
        
    }

}