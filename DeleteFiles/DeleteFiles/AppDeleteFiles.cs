namespace DeleteFiles
{
    public partial class AppDeleteFiles : System.Windows.Forms.Form
    {
        public AppDeleteFiles()
        {
            InitializeComponent();           
            lblDiscoverFile.Text = "";
            lblFromFolder.Text = "";            
        }
        
        const string EXAMPLE = "Ví dụ: vvv, txt, rar, exe, ...";
        string arrPath = "";       

        private void btnBrowse_Click(object sender, System.EventArgs e)
        {
            var result = folderBrowserDialog1.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                txtFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void chkDelAll_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkDelAll.Checked)
            {
                btnBrowse.Enabled = false;
                txtFolder.Text = "";
            }
            else
            {
                btnBrowse.Enabled = true;                
            }
        }

        private void btnHandle_Click(object sender, System.EventArgs e)
        {            
            if (txtExtension.Text.Trim() != "" || txtExtension.Text.Trim() != EXAMPLE)
            {                
                btnHandle.Hide();
                btnBrowse.Enabled = false;
                if (chkDelAll.Checked)
                {
                    var drives = System.IO.Directory.GetLogicalDrives();
                    foreach (string drive in drives)
                    {
                        DeleteFiles(drive);
                    }                    
                }
                else
                {
                    if (txtFolder.Text.Trim() != "")
                    {
                        DeleteFiles(txtFolder.Text);                        
                    }                    
                }                
                btnHandle.Show();
                btnBrowse.Enabled = true;
                lblDiscoverFile.Text = "";
                lblFromFolder.Text = "";
                txtExtension.Text = "";
                txtFolder.Text = "";                
                this.Text = "Delete Files";
            }
            else
            {
                txtExtension.Focus();
                txtExtension.Text = EXAMPLE;
            }
        }

        private void txtExtension_Click(object sender, System.EventArgs e)
        {
            if (txtExtension.Text == EXAMPLE)
            {
                txtExtension.Text = "";
            }
        }

        private void txtExtension_Leave(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(txtExtension.Text.Trim()))
            {
                txtExtension.Text = EXAMPLE;
            }
        }

        private void DeleteFiles(string sourceDir)
        {
            lblDiscoverFile.Text = "Discovering files...";
            System.Windows.Forms.Application.DoEvents();

            string[] arrFileName = GetFiles(sourceDir).Split(';');            

            long len = arrFileName.LongLength;
            if (len > 0)
            {
                try
                {
                    this.Text = "Delete Files (" + len + " files)";
                    System.Windows.Forms.Application.DoEvents();
                    foreach (var path in arrFileName)
                    {
                        if (!string.IsNullOrEmpty(path))
                        {
                            string fileName = path.Split('\\')[path.Split('\\').Length - 1];
                            lblDiscoverFile.Text = "Deleting file: " + fileName;
                            lblFromFolder.Text = "From folder: " + (path.Length > 50 ? path.Substring(0, 50) + "..." : path);
                            System.Windows.Forms.Application.DoEvents();
                            System.IO.FileInfo f = new System.IO.FileInfo(fileName);
                            if (IsFileLocked(f))
                            {
                                System.Windows.Forms.MessageBox.Show("File '" + fileName + "' đang được sử dụng. Tắt các tiến trình đang sử dụng file này trước khi xóa!", "Cảnh Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                            }
                            else
                            {
                                System.IO.File.Delete(fileName);                                
                            }
                        }
                    }
                    System.Windows.Forms.MessageBox.Show("Xóa file thành công!", "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                }
                catch (System.Exception)
                {
                    System.Windows.Forms.MessageBox.Show("Lỗi trong quá trình xóa file!", "Lỗi", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Không có file nào để xóa !", "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
        }

        private string GetFiles(string sourceDir)
        {
            //Add root files in this DIR to the list    
            if (CheckAccess(sourceDir))
            {
                var fileEntries = System.IO.Directory.GetFiles(sourceDir, "*." + txtExtension.Text.ToLower().Trim(), System.IO.SearchOption.TopDirectoryOnly);              

                foreach (string filename in fileEntries)
                {
                    arrPath += filename + ";";
                }

                //Loop the DIR's in the current DIR
                var subdirEntries = System.IO.Directory.GetDirectories(sourceDir);
                foreach (string subdir in subdirEntries)
                {
                    //Don't open Folder Redirects as this can end up in an infinate loop
                    if ((System.IO.File.GetAttributes(subdir) & System.IO.FileAttributes.ReparsePoint) != System.IO.FileAttributes.ReparsePoint)
                    {
                        //Run recursivly to follow this DIR tree                     
                        GetFiles(subdir);
                    }
                }
            }

            return arrPath;
        }

        private static bool CheckExist(string []Arr, string str)
        {
            foreach (var item in Arr)
            {
                if (item == str.Split('\\')[str.Split('\\').Length-1])
                {
                    return true;
                }
            }
            return false;
        }

        private static bool IsFileLocked(System.IO.FileInfo file)
        {
            System.IO.FileStream stream = null;
            try
            {
                stream = file.Open(System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.None);
            }
            catch (System.IO.IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            //file is not locked
            return false;
        }

        private static bool CheckFolderPermissions(string directoryPath, System.Security.AccessControl.FileSystemRights accessType)
        {
            bool hasAccess = true;
            try
            {
                System.Security.AccessControl.AuthorizationRuleCollection collection = System.IO.Directory.
                                            GetAccessControl(directoryPath)
                                            .GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount));
                foreach (System.Security.AccessControl.FileSystemAccessRule rule in collection)
                {
                    if ((rule.FileSystemRights & accessType) > 0)
                    {
                        return hasAccess;
                    }
                }

            }
            catch (System.Exception)
            {
                hasAccess = false;
            }
            return hasAccess;
        }

        private static bool CheckAccess(string path)
        {
            //get directory info
            System.IO.DirectoryInfo dr = new System.IO.DirectoryInfo(path);            
            try
            {
                //if GetDirectories works then is accessible
                dr.GetDirectories();                
                return true;
            }
            catch (System.Exception)
            {
                //if exception is not accesible
                return false;
            }
        }

        private static bool CanRead(string path)
        {
            var readAllow = false;
            var readDeny = false;
            try
            {
                var accessControlList = System.IO.Directory.GetAccessControl(path);
                if (accessControlList == null)
                    return false;
                var accessRules = accessControlList.GetAccessRules(true, true, typeof(System.Security.Principal.SecurityIdentifier));
                if (accessRules == null)
                    return false;

                foreach (System.Security.AccessControl.FileSystemAccessRule rule in accessRules)
                {
                    if ((System.Security.AccessControl.FileSystemRights.Read & rule.FileSystemRights) != System.Security.AccessControl.FileSystemRights.Read) continue;

                    if (rule.AccessControlType == System.Security.AccessControl.AccessControlType.Allow)
                        readAllow = true;
                    else if (rule.AccessControlType == System.Security.AccessControl.AccessControlType.Deny)
                        readDeny = true;
                }
            }
            catch (System.Exception)
            {
                return false;
            }            

            return readAllow && !readDeny;
        }
    }
}
