using System;
using System.Windows.Forms;
using lib;
using Models;
using System.Drawing;

namespace Telas
{
    public class CategoriaView : Form
    {
        private System.ComponentModel.IContainer components = null;

        ListView listView;
        public CategoriaView()
        {

            listView = new Campos.FieldListView(25, 25, 450, 400);
			listView.View = View.Details;
			/*foreach(Categoria item in CategoriaController.VisualizarCategoria())
            {
                ListViewItem list = new ListViewItem(item.Id + "");
                list.SubItems.Add(item.Nome);	
                listView.Items.AddRange(new ListViewItem[]{list});
            }*/
			listView.Columns.Add("Id", -2, HorizontalAlignment.Left);
    		listView.Columns.Add("Nome", -2, HorizontalAlignment.Left);
			listView.FullRowSelect = true;
			listView.GridLines = true;
			listView.AllowColumnReorder = true;
			listView.Sorting = SortOrder.Ascending;

            this.Controls.Add(this.listView);

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 500);
            this.Text = "Categoria";
        }
    }

}