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

        ListView listView;
        Button btnVoltar;
        Button btnInsert;
        public UsuarioView()
        {

            // 

            btnVoltar = new Campos.ButtonField("Voltar", 25, 450, 100, 30);
			btnVoltar.Click += new EventHandler(this.btnVoltarClick);
            
            btnInsert = new Campos.ButtonField("Cadastrar", 130, 450, 100, 30);
            btnInsert.Click += new EventHandler(this.btnInsertClick);

            // Select dos registros


            this.Controls.Add(this.listView);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnInsert);

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 500);
            this.Text = "Usuario";
        }

        // Funções dos botões
        public void btnVoltarClick(object sender, EventArgs e)
        {
            this.Close();
        } 

        public void btnInsertClick(object sender, EventArgs e)
        {
            CadastrarUsuário CadastrarUsuários = new CadastrarUsuário();
            CadastrarUsuários.ShowDialog();
        }   
        
    }

}