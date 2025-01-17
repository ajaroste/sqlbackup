﻿
using DevExpress.XtraEditors;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using sqlbackup.Enums;
using sqlbackup.Manager;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using static Google.Apis.Drive.v3.DriveService;

namespace sqlbackup
{
    public partial class Form1 : Form
    {
        private DriveService _driveService;
        public SqlEnum SQL;
        public bool connection;
        public Form1()
        {

            InitializeComponent();
            //Authenticate();
        }

        private void BtnConnection_Click(object sender, EventArgs e)
        {
            SQL = (SqlEnum)CBsql.SelectedIndex;

            CBDatabase.Properties.Items.Clear();

            var x = SqlConnector.SqlConnection(SQL, TBServer.Text, TBUsername.Text, TBPassworld.Text);


            if (x.Databases.Count != 0)
            {
                foreach (var item in x.Databases)
                {
                    CBDatabase.Properties.Items.Add(item);
                }
                XtraMessageBox.Show("Bağlantı Başarılı !");
            }
            else
            {
                XtraMessageBox.Show(x.Errors);
            }



        }

        private void BtnnBackup_Click(object sender, EventArgs e)
        {

            if (SqlConnector.SqlConnection(SQL, TBServer.Text, TBUsername.Text, TBPassworld.Text) == null)
            {
                XtraMessageBox.Show("Sunucu Bağlantısı Sağlanmamış veya Bağlantı kopmuş !");
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
                var a = SqlBackupManager.SqlBackup(SQL, btnEditKlasorYolu.Text, CBDatabase.Text, TBServer.Text, TBUsername.Text, TBPassworld.Text);
                if (a == "1")
                {
                    if (XtraMessageBox.Show($"Veritabanı {CBDatabase.Text} başarıyla yedeklendi. Dosya Konumunu açmak istermisiniz ?", "Uyarı", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {

                        Process.Start("explorer.exe", btnEditKlasorYolu.Text);

                    }
                }
                else
                {
                    XtraMessageBox.Show(a);
                }


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
