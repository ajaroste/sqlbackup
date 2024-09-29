
using DevExpress.XtraEditors;
using sqlbackup.Enums;
using sqlbackup.Manager;
using System;
using System.Windows.Forms;


namespace sqlbackup
{
    public partial class Form1 : Form
    { 
        public SqlEnum SQL;
        public bool connection;
        public Form1()
        {
            SQL = (SqlEnum)CBsql.SelectedIndex;
            InitializeComponent();
        }
      
        private void BtnConnection_Click(object sender, EventArgs e)
        {
            CBDatabase.Properties.Items.Clear();
    
            var x = SqlConnector.SqlConnection(SQL, TBServer.Text, TBUsername.Text, TBPassworld.Text);

            if (x != null)
            {
                foreach (var item in x)
                {
                    CBDatabase.Properties.Items.Add(item);
                }
                connection = true;

            }
            else
            {
                XtraMessageBox.Show("Bağlantı Başarısız bro :)");
                connection = false;
            }
        }

        private void BtnnBackup_Click(object sender, EventArgs e)
        {
           








        }

        private void btnEditKlasorYolu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFolder = folderBrowserDialog.SelectedPath;
                btnEditKlasorYolu.Text = selectedFolder;
            }
        }
    }
}
