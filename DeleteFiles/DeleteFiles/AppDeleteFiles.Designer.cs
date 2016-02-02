namespace DeleteFiles
{
    partial class AppDeleteFiles
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppDeleteFiles));
            this.lblFormat = new System.Windows.Forms.Label();
            this.txtExtension = new System.Windows.Forms.TextBox();
            this.btnHandle = new System.Windows.Forms.Button();
            this.lblFolder = new System.Windows.Forms.Label();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.chkDelAll = new System.Windows.Forms.CheckBox();
            this.lblDiscoverFile = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lblFromFolder = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblFormat
            // 
            this.lblFormat.AutoSize = true;
            this.lblFormat.Location = new System.Drawing.Point(13, 22);
            this.lblFormat.Name = "lblFormat";
            this.lblFormat.Size = new System.Drawing.Size(99, 14);
            this.lblFormat.TabIndex = 0;
            this.lblFormat.Text = "Nhập định dạng file";
            // 
            // txtExtension
            // 
            this.txtExtension.Location = new System.Drawing.Point(118, 19);
            this.txtExtension.Name = "txtExtension";
            this.txtExtension.Size = new System.Drawing.Size(160, 20);
            this.txtExtension.TabIndex = 1;
            this.txtExtension.Text = "Ví dụ: vvv, txt, rar, exe, ...";
            this.txtExtension.Click += new System.EventHandler(this.txtExtension_Click);
            this.txtExtension.Leave += new System.EventHandler(this.txtExtension_Leave);
            // 
            // btnHandle
            // 
            this.btnHandle.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHandle.Location = new System.Drawing.Point(136, 114);
            this.btnHandle.Name = "btnHandle";
            this.btnHandle.Size = new System.Drawing.Size(125, 23);
            this.btnHandle.TabIndex = 2;
            this.btnHandle.Text = "Thực Hiện";
            this.btnHandle.UseVisualStyleBackColor = true;
            this.btnHandle.Click += new System.EventHandler(this.btnHandle_Click);
            // 
            // lblFolder
            // 
            this.lblFolder.AutoSize = true;
            this.lblFolder.Location = new System.Drawing.Point(13, 53);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Size = new System.Drawing.Size(94, 14);
            this.lblFolder.TabIndex = 3;
            this.lblFolder.Text = "Thư mục chứa file";
            // 
            // txtFolder
            // 
            this.txtFolder.Location = new System.Drawing.Point(118, 50);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.ReadOnly = true;
            this.txtFolder.Size = new System.Drawing.Size(160, 20);
            this.txtFolder.TabIndex = 4;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(294, 49);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Duyệt";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // chkDelAll
            // 
            this.chkDelAll.AutoSize = true;
            this.chkDelAll.Location = new System.Drawing.Point(17, 84);
            this.chkDelAll.Name = "chkDelAll";
            this.chkDelAll.Size = new System.Drawing.Size(101, 18);
            this.chkDelAll.TabIndex = 5;
            this.chkDelAll.Text = "Toàn bộ ổ cứng";
            this.chkDelAll.UseVisualStyleBackColor = true;
            this.chkDelAll.CheckedChanged += new System.EventHandler(this.chkDelAll_CheckedChanged);
            // 
            // lblDiscoverFile
            // 
            this.lblDiscoverFile.AutoSize = true;
            this.lblDiscoverFile.Location = new System.Drawing.Point(14, 113);
            this.lblDiscoverFile.Margin = new System.Windows.Forms.Padding(3, 0, 10, 0);
            this.lblDiscoverFile.Name = "lblDiscoverFile";
            this.lblDiscoverFile.Size = new System.Drawing.Size(96, 14);
            this.lblDiscoverFile.TabIndex = 6;
            this.lblDiscoverFile.Text = "Discovering files...";
            // 
            // lblFromFolder
            // 
            this.lblFromFolder.AutoSize = true;
            this.lblFromFolder.Location = new System.Drawing.Point(14, 132);
            this.lblFromFolder.Margin = new System.Windows.Forms.Padding(3, 0, 10, 0);
            this.lblFromFolder.Name = "lblFromFolder";
            this.lblFromFolder.Size = new System.Drawing.Size(68, 14);
            this.lblFromFolder.TabIndex = 6;
            this.lblFromFolder.Text = "From folder: ";
            // 
            // AppDeleteFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 159);
            this.Controls.Add(this.lblFromFolder);
            this.Controls.Add(this.lblDiscoverFile);
            this.Controls.Add(this.chkDelAll);
            this.Controls.Add(this.txtFolder);
            this.Controls.Add(this.lblFolder);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btnHandle);
            this.Controls.Add(this.txtExtension);
            this.Controls.Add(this.lblFormat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AppDeleteFiles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Delete Files";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFormat;
        private System.Windows.Forms.TextBox txtExtension;
        private System.Windows.Forms.Button btnHandle;
        private System.Windows.Forms.Label lblFolder;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.CheckBox chkDelAll;
        private System.Windows.Forms.Label lblDiscoverFile;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label lblFromFolder;
    }
}

