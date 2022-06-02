using System;
using System.Collections.Generic;
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
        Label lblSenha;
        Label lblProcedimento;
        Label lblTags;
        TextBox txtNome;
        CheckedListBox checkedTags;
        TextBox txtUrl;
        TextBox txtUser;
        TextBox txtSenha;
        TextBox txtProcedimento;
        ComboBox cbCategoria;

        public CadastrarSenha(Form parent)
        {
            this.parent = parent;

            this.lblNome = new Campos.LabelField("Nome:", 25, 50);
            this.txtNome = new Campos.TextBoxField(25, 80, 250, 200);

            this.lblCategoria = new Campos.LabelField("Categoria:", 25, 130);
            
            IEnumerable<Categoria> categoria = CategoriaCtrl.VisualizarCategoria();
            this.cbCategoria = new Campos.ComboBoxField(25, 160, 250, 200);
			foreach (Categoria item in categoria)
			{
				cbCategoria.Items.Add(item);
			}
			cbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            
            this.lblUrl = new Campos.LabelField("Url:", 25, 210);
            this.txtUrl = new Campos.TextBoxField(25, 240, 250, 200);

            this.lblUser = new Campos.LabelField("Usuário:", 25, 290);
            this.txtUser = new Campos.TextBoxField(25, 320, 250, 200);

            this.lblSenha = new Campos.LabelField("Senha:", 25, 370);
            this.txtSenha = new Campos.TextBoxField(25, 400, 250, 200);

            this.lblProcedimento = new Campos.LabelField("Procedimento:", 25, 440);
            this.txtProcedimento = new Campos.TextBoxField(25, 470, 250, 200);

            this.lblTags = new Campos.LabelField("Tags:", 25, 520);
            checkedTags = new Campos.CheckedListBoxField(25, 550, 250, 200);
			foreach(Tag item in TagCtrl.VisualizarTag())
            {
                CheckedListBox checkedListBox = new CheckedListBox();
                checkedListBox.Items.Add(item.Descricao + "");
                checkedTags.Items.AddRange(checkedListBox.Items);
            }	
			
			checkedTags.CheckOnClick = true;


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
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.checkedTags);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.txtProcedimento);
            this.Controls.Add(this.cbCategoria);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.lblSenha);

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