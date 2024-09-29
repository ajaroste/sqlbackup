
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
           
            InitializeComponent();
        }
      
        private void BtnConnection_Click(object sender, EventArgs e)
        {
            SQL = (SqlEnum)CBsql.SelectedIndex;

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
            
            if (!connection)
            {
                XtraMessageBox.Show("Sunucu Bağlantısı Sağlanmamış !");
            }
            else if (string.IsNullOrEmpty(CBDatabase.Text)) 
            {

                XtraMessageBox.Show("Database Seçimi Yapılmamış !");

            }
            else if (string.IsNullOrEmpty(btnEditKlasorYolu.Text)) 
            {

                XtraMessageBox.Show("Yedek Yolu Belirlenmemiş !");
            }
            else
            {
                var a = SqlBackupManager.SqlBackup(SQL,btnEditKlasorYolu.Text,CBDatabase.Text ,TBServer.Text, TBUsername.Text, TBPassworld.Text);
                XtraMessageBox.Show(a);
            }







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
