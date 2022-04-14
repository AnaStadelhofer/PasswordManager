using System;
using System.Windows.Forms;
using lib;
using Models;
using Controllers;
using System.Drawing;

namespace Telas
{
    public class CadastrarUsuário : Form
    {
        private System.ComponentModel.IContainer components = null;

        TextBox txtNome;
        TextBox txtEmail;
        Label lblNome;
        Label lblEmail;
        Button btnVoltar;
        Button btnInsert;
        Label lblSenha;
        TextBox txtSenha;

        public CadastrarUsuário()
        {

            // Componentes em tela

            this.lblNome = new Campos.LabelField("Nome:", 70, 40);
            this.txtNome = new Campos.TextBoxField(70, 80, 200, 200);
            
            this.lblEmail = new Campos.LabelField("Email:", 70, 120);
            this.txtEmail = new Campos.TextBoxField(70, 160, 200, 200);

            this.lblSenha = new Campos.LabelField("Senha:", 70, 200);
            this.txtSenha = new Campos.TextBoxField(70, 240, 200, 200);
            this.txtSenha.PasswordChar = '*';

            btnVoltar = new Campos.ButtonField("Voltar", 50, 300, 100, 30);
			btnVoltar.Click += new EventHandler(this.btnVoltarClick);

            btnInsert = new Campos.ButtonField("Cadastrar", 180, 300, 100, 30);
			btnInsert.Click += new EventHandler(this.btnInsertClick);

            // Adicionando os componentes na tela

            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnInsert);

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 350);
            this.Text = "Cadastrar Usuário";
        }

        // Ações das funções

        public void btnVoltarClick(object sender, EventArgs e)
        {
            this.Close();
        } 

        public void btnInsertClick(object sender, EventArgs e)
        {
            try
            {
                UsuarioCtrl.InsertUsuario(this.txtNome.Text, this.txtEmail.Text, this.txtSenha.Text);
            }
            catch(Exception)
            {
                MessageBox.Show("Preencha todos os campos!", "Erro");
            }
            String Message = "Usuário cadastrado com sucesso!";
            String Title = "Operação feita!";
            MessageBox.Show(Message, Title);
            this.Close();
        }  
        
    }

}