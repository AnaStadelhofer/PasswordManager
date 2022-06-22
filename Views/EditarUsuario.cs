using System;
using System.Windows.Forms;
using lib;
using Models;
using Controllers;
using System.Drawing;

namespace Telas
{
    public class EditarUsuario : Form
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
        int Id;
        Form parent;

        public EditarUsuario(Form parent, int Id)
        {
            this.parent = parent;
            this.Id = Id;
            Usuario usuario = Models.Usuario.GetUsuario(Id);
            // Componentes em tela

            this.lblNome = new Campos.LabelField("Nome:", 70, 40);
            this.txtNome = new Campos.TextBoxField(70, 70, 200, 200);
            this.txtNome.Text = usuario.Nome;
            
            this.lblEmail = new Campos.LabelField("Email:", 70, 120);
            this.txtEmail = new Campos.TextBoxField(70, 150, 200, 200);
            this.txtEmail.Text = usuario.Email;

            this.lblSenha = new Campos.LabelField("Senha:", 70, 200);
            this.txtSenha = new Campos.TextBoxField(70, 230, 200, 200);
            this.txtSenha.PasswordChar = '*';

            btnVoltar = new Campos.ButtonField("Voltar", 50, 300, 100, 30);
			btnVoltar.Click += new EventHandler(this.btnVoltarClick);

            btnInsert = new Campos.ButtonField("Confirmar", 200, 300, 100, 30);
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
            this.Text = "Editar Usuário";
        }

        // Ações das funções

        public void btnVoltarClick(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        } 

        public void btnInsertClick(object sender, EventArgs e)
        {
            try 
            {
                UsuarioCtrl.UpdateUsuario(Id, this.txtNome.Text, this.txtEmail.Text, this.txtSenha.Text);
                this.Hide();
                UsuarioView UsuarioViews = new UsuarioView(this);
                UsuarioViews.ShowDialog();
                this.parent.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            
        }   
        
    }

}