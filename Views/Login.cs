using System;
using System.Windows.Forms;
using lib;
using Models;
using System.Drawing;

namespace Telas
{
    public class Login : Form
    {
        private System.ComponentModel.IContainer components = null;
        Label lblUser;
        Label lblPassword;
        TextBox txtUser;
        TextBox txtPass;

        Button btnLogar;
        Button btnSair;
        public Login()
        {
            this.BackColor = Color.FromArgb(179, 193, 220);
            this.lblUser = new Campos.LabelField("Usuário", 120, 30);

            this.txtUser = new Campos.TextBoxField(50, 60, 200, 20);

            this.lblPassword = new Campos.LabelField("Senha", 120, 100);

            this.txtPass = new Campos.TextBoxField(50, 130, 200, 20);
            this.txtPass.PasswordChar = '*';

            btnLogar = new Campos.ButtonField("Logar", 50, 220, 100, 30);
			btnLogar.Click += new EventHandler(this.btnLogarClick);

			btnSair = new Campos.ButtonField("Sair", 150, 220, 100, 30);
			btnSair.Click += new EventHandler(this.btnSairClick);

            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.btnLogar);
            this.Controls.Add(this.btnSair);
            
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Text = "Login";
        }

        public void btnLogarClick(object sender, EventArgs e)
        {              
            try
            {
                Usuario.Auth(this.txtUser.Text, this.txtPass.Text);
                if (Usuario.UsuarioAuth != null) 
                {
                    Menu Menus = new Menu(this);
                    Menus.Show();
                    this.Hide(); 
                } 
            }
            catch (Exception err)
            {
                MessageBox.Show("Usuário ou senha inválido", "Erro");
            }
        }

        public void btnSairClick(object sender, EventArgs e)
        {
            this.Close();
        }  

    }

}
