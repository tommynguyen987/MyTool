using System;
using System.Web.UI.HtmlControls;

namespace MyUtility.Data.News
{
    public class Rongbay
    {
        public static void PostRequest(System.Windows.Forms.WebBrowser wbr, System.Windows.Forms.Timer timer)
        {
            var url = "http://vietid.net/OauthServerV2/RegisterV2?app_key=07234206219b51690a3bc234115a34f2&clearsession=1&oauth_token=";
            wbr.Url = new Uri(url);
            wbr.ScriptErrorsSuppressed = true;
            wbr.DocumentCompleted += wbr_DocumentCompleted_PostRequest;            
            //timer.Enabled = true;
            //timer.Start();
        }

        private static void AccountConfirm(System.Windows.Forms.WebBrowser wbr)
        {
            var url = "https://accounts.google.com/ServiceLogin?service=mail&continue=https://mail.google.com/mail/&hl=vi";
            wbr.Url = new Uri(url);
            wbr.ScriptErrorsSuppressed = true;
            wbr.DocumentCompleted += wbr_DocumentCompleted_AccountConfirm;            
        }

        private static void RedirectActiveLink(System.Windows.Forms.WebBrowser wbr)
        {               
            System.Text.StringBuilder scriptCode = new System.Text.StringBuilder();
            scriptCode.Append("function ExecuteJS(){");
            scriptCode.Append("    alert('hello');");
            scriptCode.Append("    $('.Cp .xS .y6').each(function(){");
            scriptCode.Append("        alert('111');");
            scriptCode.Append("        var t = $(this).children(\"span:first-child\").html();");
            scriptCode.Append("        if(t.indexOf(\"Kích hoạt tài khoản VietID\") != -1){");
            scriptCode.Append("            alert('2222');");
            scriptCode.Append("            $('.aqw').click(function(){");
            scriptCode.Append("                alert('333');");
            scriptCode.Append("            });");
            scriptCode.Append("        }");
            scriptCode.Append("    });");
            scriptCode.Append("}");

            //wbr.Document.InvokeScript("eval", new Object[] { scriptCode.ToString() });
            wbr.Document.InvokeScript("execScript", new Object[] { scriptCode.ToString(), "JavaScript" });
            wbr.Document.InvokeScript("ExecuteJS");                
            
        }

        private static void wbr_DocumentCompleted_AccountConfirm(object sender, System.Windows.Forms.WebBrowserDocumentCompletedEventArgs e)
        {
            System.Windows.Forms.WebBrowser wbr = sender as System.Windows.Forms.WebBrowser;
            try
            {
                if (wbr.ReadyState == System.Windows.Forms.WebBrowserReadyState.Complete)
                {
                    System.Windows.Forms.HtmlElement form = wbr.Document.GetElementById("gaia_loginform");
                    if (form != null)
                    {
                        wbr.Document.GetElementById("Email").SetAttribute("value", UserInfo.Email = "buitran986@gmail.com");
                        wbr.Document.GetElementById("Passwd").SetAttribute("value", UserInfo.Password = "yeuem1234567890");
                        form.InvokeMember("submit");                        
                    }

                    if (wbr.Url.AbsoluteUri.IndexOf("/#inbox") != -1)
                    {
                        RedirectActiveLink(wbr);
                        wbr.DocumentCompleted -= wbr_DocumentCompleted_AccountConfirm;
                        Login();
                    }
                }                
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error!" + System.Environment.NewLine + ex.Message);
            }
        }

        private static void Login()
        {

        }

        private static string Get8CharacterRandomString()
        {
            return System.IO.Path.GetRandomFileName().Replace(".", "").Substring(0, 8);
            //return Guid.NewGuid().ToString().Substring(0, 8);
        }

        public static string GetRandomAlphaNumeric()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);

            return finalString;
        }

        private static string GetUniqueKey(int maxSize)
        {
            char[] chars = new char[62];
            chars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            byte[] data = new byte[1];
            using (System.Security.Cryptography.RNGCryptoServiceProvider crypto = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                crypto.GetNonZeroBytes(data);
                data = new byte[maxSize];
                crypto.GetNonZeroBytes(data);
            }
            System.Text.StringBuilder result = new System.Text.StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }

        private static string GetEmail()
        {
            //return GetUniqueKey(8) + "@gmail.com";
            return Get8CharacterRandomString() + "@gmail.com";
            //return GetRandomAlphaNumeric() + "@gmail.com";
        }

        private static void wbr_DocumentCompleted_PostRequest(object sender, System.Windows.Forms.WebBrowserDocumentCompletedEventArgs e)
        {
            System.Windows.Forms.WebBrowser wbr = sender as System.Windows.Forms.WebBrowser;
            try
            {
                if (wbr.ReadyState == System.Windows.Forms.WebBrowserReadyState.Complete)
                {
                    System.Windows.Forms.HtmlElement form = wbr.Document.GetElementById("show_connect");
                    if (form != null)
                    {
                        wbr.Document.GetElementById("email").SetAttribute("value", GetEmail());//UserInfo.Email = "buitran986@gmail.com");
                        wbr.Document.GetElementById("password").SetAttribute("value", UserInfo.Password = "12345678");
                        wbr.Document.GetElementById("confirm_password").SetAttribute("value", "12345678");
                        wbr.Document.GetElementById("full_name").SetAttribute("value", UserInfo.Fullname = "tester");
                        form.InvokeMember("submit");

                        wbr.DocumentCompleted -= wbr_DocumentCompleted_PostRequest;

                        AccountConfirm(wbr);
                    }                    
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error!" + System.Environment.NewLine + ex.Message);
            }
        }      

        public static void RefreshNews(System.Windows.Forms.WebBrowser wbr)
        {
            int sumPostedNews = GetSumPostedNews(wbr);
            for (int i = 0; i < sumPostedNews; i++)
            {
                string codeString1 = String.Format("$('input[id=checkbox_ttv[" + i + "]]').val();");
                object value1 = wbr.Document.InvokeScript("eval", new[] { codeString1 });
                string[] arg = { value1.ToString() };
                wbr.Document.InvokeScript("ntv_quan_tri_lam_moi_1_ttv", arg);
                wbr.Refresh();
            }            
        }

        static int GetSumPostedNews(System.Windows.Forms.WebBrowser wbr)
        {
            int sumPostedNews;
            string codeString = String.Format("$('#tong_so_ttv_da_dang').val();");
            object value = wbr.Document.InvokeScript("eval", new[] { codeString });

            if (int.TryParse(value.ToString(), out sumPostedNews))
            {
                return sumPostedNews;
            }
            return 0;
        }
    }    
}
