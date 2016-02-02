using System.Windows.Forms;

namespace ChuongTrinhHoanViSo
{
    public partial class formHoanVi : Form
    {
        public formHoanVi()
        {
            InitializeComponent();            
        }
        int LENGHT;        
        int[] DanhDau;   //mang danh dau dinh duoc chon
        int[] Luu;
        int[] A;
        
        void DoiCho(int a, int b)
        {
            int t;
            t = a;
            a = b;
            b = t;
        }
        void HoanVi(int m, int []a, int step) 
        { 
            if(step == m-1) // den lua chon cuoi thi InMang 
                InMang(m, a); 
            else 
                for(int i = step; i < m; i++) 
                { 
                    DoiCho(a[step], a[i]); 
                    HoanVi(m, a, step + 1); 
                    DoiCho(a[step], a[i]);//Dong nay dai dien cho viec quay lui 
                } 
        }
        void hoanvi(int[] mang, int n, int k)
        {
            int j;

            if (k == 1)
            {
                InMang(n, mang);
            }
            else
                for (j = k - 1; j >= 0; j--)
                {
                    DoiCho(mang[k - 1], mang[j]);
                    hoanvi(mang, n, k - 1);
                    DoiCho(mang[j], mang[k - 1]);
                }
        }
        void InMang(int m, int []a) 
        {
            for (int i = 0; i < m; i++)
            {
                txtResults.Text += a[i];
            }
            txtResults.Text += " ";
        }
        /*Tao mang moi tu mot day so*/
        int[] CreateArray(string s)
        {
            int[] a;
            a = new int[LENGHT];
            int i = 0;
            foreach (char item in s)
            {
                a[i] = int.Parse(item.ToString());
                i++;
            }
            return a;
        }
        /*Khoi tao cac bien*/
        void Init()
        {
            LENGHT = txtNumStart.Text.Trim().Length;
            DanhDau = new int[LENGHT];
            A = new int[LENGHT];
            Luu = new int[LENGHT];
            for (int i = 0; i < LENGHT; i++)
            {
                /*Danh dau vi tri i chua chon*/
                DanhDau[i] = 0;
            }
        }
        /*Xuat ket qua ra man hinh*/
        void Out()
        {
            for (int i = 0; i < LENGHT; i++)
                txtResults.Text += Luu[i];
            txtResults.Text += "  ";
            Application.DoEvents();
            
        }
        /*Chinh hop khong lap*/
        void Try(int i)
        {
            if (i == LENGHT)
                Out();
            else
            {
                for (int j = 0; j < LENGHT; j++)
                    if (DanhDau[j] == 0)
                    {      //neu dinh j chua duoc chon
                        DanhDau[j] = 1;      //chon dinh j
                        Luu[i] = A[j];      //luu lai gia tri dinh duoc chon
                        Try(i + 1);      //tim dinh tiep theo
                        DanhDau[j] = 0;      //phuc hoi dinh j
                    }
            }
        }
        bool CheckValid()
        {
            bool isValid = true;
            string numStart = txtNumStart.Text.Trim();
            string numEnd = txtNumEnd.Text.Trim();
            if (numStart != "" && numEnd != "")
            {
                if (numStart.Length != numEnd.Length)
                {
                    isValid = false;
                    txtResults.Text = "Hai Dãy Số Phải Có Chiều Dài Bằng Nhau !!!";
                    txtResults.TextAlign = HorizontalAlignment.Center;
                    txtResults.ForeColor = System.Drawing.Color.Red;  
                }
                else if (int.Parse(numStart) > int.Parse(numEnd))
                {
                    isValid = false;
                    txtResults.Text = "Dãy Số Bắt Đầu Phải Nhỏ Hơn Kết Thúc !!!";
                    txtResults.TextAlign = HorizontalAlignment.Center;
                    txtResults.ForeColor = System.Drawing.Color.Red;  
                }
                else
                {
                    txtResults.TextAlign = HorizontalAlignment.Left;
                    txtResults.ForeColor = System.Drawing.Color.Black;
                }
            }
            else
            {
                isValid = false;
            }
            return isValid;
        }
        private void btnCalc_Click(object sender, System.EventArgs e)
        {
            txtResults.Clear();
            if (CheckValid())
            {
                int numStart = int.Parse(txtNumStart.Text); 
                int numEnd = int.Parse(txtNumEnd.Text);
                Init();                
                for (int i = numStart; i <= numEnd; i++)
                {
                    A = CreateArray(i.ToString());
                    Try(0);
                }
                MessageBox.Show("Hoàn Thành !","Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }            
        }
    }
}
