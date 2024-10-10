
namespace sqlbackup
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.TBServer = new DevExpress.XtraEditors.TextEdit();
            this.CBsql = new DevExpress.XtraEditors.ComboBoxEdit();
            this.TBUsername = new DevExpress.XtraEditors.TextEdit();
            this.TBPassworld = new DevExpress.XtraEditors.TextEdit();
            this.CBDatabase = new DevExpress.XtraEditors.ComboBoxEdit();
            this.BtnConnection = new DevExpress.XtraEditors.SimpleButton();
            this.BtnnBackup = new DevExpress.XtraEditors.SimpleButton();
            this.btnEditKlasorYolu = new DevExpress.XtraEditors.ButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.TBServer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CBsql.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBUsername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBPassworld.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CBDatabase.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditKlasorYolu.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // TBServer
            // 
            this.TBServer.Location = new System.Drawing.Point(105, 84);
            this.TBServer.Name = "TBServer";
            this.TBServer.Size = new System.Drawing.Size(195, 20);
            this.TBServer.TabIndex = 0;
            // 
            // CBsql
            // 
            this.CBsql.Location = new System.Drawing.Point(105, 39);
            this.CBsql.Name = "CBsql";
            this.CBsql.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CBsql.Properties.Items.AddRange(new object[] {
            "Mssql",
            "Mysql",
            "Posgresql"});
            this.CBsql.Size = new System.Drawing.Size(195, 20);
            this.CBsql.TabIndex = 1;
            // 
            // TBUsername
            // 
            this.TBUsername.Location = new System.Drawing.Point(105, 131);
            this.TBUsername.Name = "TBUsername";
            this.TBUsername.Size = new System.Drawing.Size(195, 20);
            this.TBUsername.TabIndex = 2;
            // 
            // TBPassworld
            // 
            this.TBPassworld.Location = new System.Drawing.Point(105, 172);
            this.TBPassworld.Name = "TBPassworld";
            this.TBPassworld.Size = new System.Drawing.Size(195, 20);
            this.TBPassworld.TabIndex = 3;
            // 
            // CBDatabase
            // 
            this.CBDatabase.Location = new System.Drawing.Point(53, 316);
            this.CBDatabase.Name = "CBDatabase";
            this.CBDatabase.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CBDatabase.Size = new System.Drawing.Size(299, 20);
            this.CBDatabase.TabIndex = 4;
            // 
            // BtnConnection
            // 
            this.BtnConnection.Location = new System.Drawing.Point(111, 224);
            this.BtnConnection.Name = "BtnConnection";
            this.BtnConnection.Size = new System.Drawing.Size(188, 37);
            this.BtnConnection.TabIndex = 6;
            this.BtnConnection.Text = "Bağlantıyı Test Et";
            this.BtnConnection.Click += new System.EventHandler(this.BtnConnection_Click);
            // 
            // BtnnBackup
            // 
            this.BtnnBackup.Location = new System.Drawing.Point(111, 413);
            this.BtnnBackup.Name = "BtnnBackup";
            this.BtnnBackup.Size = new System.Drawing.Size(188, 37);
            this.BtnnBackup.TabIndex = 7;
            this.BtnnBackup.Text = "Yedekle";
            this.BtnnBackup.Click += new System.EventHandler(this.BtnnBackup_Click);
            // 
            // btnEditKlasorYolu
            // 
            this.btnEditKlasorYolu.Location = new System.Drawing.Point(53, 354);
            this.btnEditKlasorYolu.Name = "btnEditKlasorYolu";
            this.btnEditKlasorYolu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnEditKlasorYolu.Properties.NullValuePromptShowForEmptyValue = true;
            this.btnEditKlasorYolu.Size = new System.Drawing.Size(299, 20);
            this.btnEditKlasorYolu.TabIndex = 8;
            this.btnEditKlasorYolu.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnEditKlasorYolu_ButtonClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 519);
            this.Controls.Add(this.CBsql);
            this.Controls.Add(this.btnEditKlasorYolu);
            this.Controls.Add(this.BtnConnection);
            this.Controls.Add(this.BtnnBackup);
            this.Controls.Add(this.TBUsername);
            this.Controls.Add(this.CBDatabase);
            this.Controls.Add(this.TBServer);
            this.Controls.Add(this.TBPassworld);
            this.MinimumSize = new System.Drawing.Size(374, 558);
            this.Name = "Form1";
            this.Text = "Sql Yedekle";
            ((System.ComponentModel.ISupportInitialize)(this.TBServer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CBsql.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBUsername.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBPassworld.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CBDatabase.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditKlasorYolu.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit TBServer;
        private DevExpress.XtraEditors.ComboBoxEdit CBsql;
        private DevExpress.XtraEditors.TextEdit TBUsername;
        private DevExpress.XtraEditors.TextEdit TBPassworld;
        private DevExpress.XtraEditors.ComboBoxEdit CBDatabase;
        private DevExpress.XtraEditors.SimpleButton BtnConnection;
        private DevExpress.XtraEditors.SimpleButton BtnnBackup;
        private DevExpress.XtraEditors.ButtonEdit btnEditKlasorYolu;
    }
}

