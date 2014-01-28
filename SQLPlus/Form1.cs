using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SQLPlus
{
    public partial class Form1 : Form
    {
        DbClass db = new DbClass();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            frmLOGIN f1 = new frmLOGIN();
            sifresor:
            DialogResult dr = f1.ShowDialog();
            if (dr==DialogResult.OK)//OK
            {
                db.DataSource = f1.txtSUNUCU_ADI.Text;
                db.InitialCatalog ="master";
                db.UserId = f1.txtKULLANICI_ADI.Text;
                db.Password = f1.txtSIFRESI.Text;
                db.cnn.ConnectionString = db.CnnStr;//ekrandan alınan bağlantı bilgileri 
                                                    //var olan bağlantı nesnesinin bağlantı
                                                    //cümlesine aktarılıyor
                try
                {
                    db.cnn.Open();
                    //veritabanları bulunuyor....
                    DataTable vt=db.cnn.GetSchema("databases");
                    for (int i = 0; i < vt.Rows.Count; i++)
                    {
                        TreeNode tn = new TreeNode();
                        tn.Text = vt.Rows[i]["database_name"].ToString();
                        cmbVERITABANI.Items.Add(tn.Text);
                        //tabloları eklemeliyiz
                        db.cnn.ChangeDatabase(tn.Text);//database değiştiriliyor.
                        DataTable tablo = db.cnn.GetSchema("tables");
                        for (int j = 0; j < tablo.Rows.Count; j++)
                        {
                            TreeNode tn1 = new TreeNode();
                            tn1.Text = tablo.Rows[j]["table_name"].ToString();
                            tn.Nodes.Add(tn1);
                        }
                        tvVERITABANI.Nodes.Add(tn);
                    }
                    
                    cmbVERITABANI.SelectedItem = "EMAGAZA";
                }
                catch (Exception)
                {
                    MessageBox.Show("Kullanıcı adı veya şifresi yanlış veya Sunucu adı yanlış");
                    goto sifresor;
                    
                }
            }
            else //cancel
            {
                Application.Exit();
            }
        }

        private void cmbVERITABANI_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (db.cnn.State==ConnectionState.Closed)
            {
                db.cnn.Open();
            }
            db.cnn.ChangeDatabase(cmbVERITABANI.SelectedItem.ToString());
        }

        private void tvVERITABANI_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.Text = e.Node.FullPath;
            int yer = e.Node.FullPath.IndexOf(@"\");
            if (yer>0)
            {
                string vt = e.Node.FullPath.Substring(0, yer);
                cmbVERITABANI.SelectedItem = vt;
                string tablo = e.Node.FullPath.Substring(yer+1);
                txtSORGU.Text = "SELECT * FROM " + tablo;
                toolStripButton1.PerformClick();
            }
            else
            {
                string vt = e.Node.FullPath;
                cmbVERITABANI.SelectedItem = vt;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (txtSORGU.SelectionLength>0)
            {
                sql =txtSORGU.SelectedText;
            }
            else
            {
                sql = txtSORGU.Text;
            }
            if (sql.Trim()!="")
            {
                if (sql.StartsWith("SELECT"))
                {
                    try
                    {
                        DataTable dt = db.Fill(sql);
                        grdSONUC.DataSource = dt;
                        tabControl1.SelectedIndex = 0;
                        txtMESAJ.Text = "Komut başarıyla çalıştırıldı";
                    }
                    catch (Exception)
                    {
                        tabControl1.SelectedIndex = 1;
                        txtMESAJ.Text = "Komut başarısız";
                    }
                    
                }
                else
                {
                    try
                    {
                        db.ExecuteNonQuery(sql);
                        tabControl1.SelectedIndex = 1;
                        txtMESAJ.Text = "Komut başarıyla çalıştırıldı";
                    }
                    catch (Exception)
                    {

                        tabControl1.SelectedIndex = 1;
                        txtMESAJ.Text = "Komut başarısız";
                    }
                }
            }
        }
        DataRow dr;
        private void grdSONUC_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dt = grdSONUC.DataSource as DataTable;
            dr = dt.Rows[e.RowIndex];
        }

        Form f;
        private void grdSONUC_DoubleClick(object sender, EventArgs e)
        {
            DataTable dt = grdSONUC.DataSource as DataTable;
            f = new Form();
            int y = 10;
            int x = 10;
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                Label lbl = new Label();
                lbl.Text = dt.Columns[i].ColumnName;
                lbl.Name ="lbl"+ dt.Columns[i].ColumnName;
                lbl.Left = x;
                lbl.Top = y;
               
                f.Controls.Add(lbl);

                TextBox txt = new TextBox();
                txt.Name =dt.Columns[i].ColumnName;
                txt.Left = x+100;
                txt.Top = y;
                txt.Text = dr[dt.Columns[i].ColumnName].ToString();
                y = y + 25;
                f.Controls.Add(txt);
            }
            Button btn = new Button();
            btn.Text = "Kaydet";
            btn.Left = x;
            btn.Top = y;
            btn.Click += new EventHandler(btn_Click);
            f.Height = y + 100;
            f.Controls.Add(btn);
            f.ShowDialog();
        }

        void btn_Click(object sender, EventArgs e)
        {
            DataTable dt = grdSONUC.DataSource as DataTable;
            dr.BeginEdit();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                Control[] ctl = f.Controls.Find(dt.Columns[i].ColumnName, true);
                dr[dt.Columns[i].ColumnName] = ctl[0].Text;
            }
            dr.EndEdit();
            f.Close();
        }
    }
}
