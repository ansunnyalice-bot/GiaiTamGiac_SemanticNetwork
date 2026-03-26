using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace demo
{
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
        }
        ObservableCollection<BangQuanHe> dsQuanHe = new();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dsQuanHe = new ObservableCollection<BangQuanHe>
         {
                   new BangQuanHe { YeuTo = "Góc A" },
                   new BangQuanHe { YeuTo = "Góc B" },
                   new BangQuanHe { YeuTo = "Góc C" },
                   new BangQuanHe { YeuTo = "Cạnh a" },
                   new BangQuanHe { YeuTo = "Cạnh b" },
                   new BangQuanHe { YeuTo = "Cạnh c" },
                   new BangQuanHe { YeuTo = "Nữa chu vi" },
                   new BangQuanHe { YeuTo = "Diện tích" },
                   new BangQuanHe { YeuTo = "Chiều cao hA" },
                   new BangQuanHe { YeuTo = "Chiều cao hB" },
                   new BangQuanHe { YeuTo = "Chiều cao hC" },
                   new BangQuanHe { YeuTo = "r" },
                   new BangQuanHe { YeuTo = "R" }
         };
            dg_quan_he.ItemsSource = dsQuanHe;
        }

        public class BangQuanHe
        {
            public string YeuTo { get; set; } = "";
            public int CT1 { get; set; }
            public int CT2 { get; set; }
            public int CT3 { get; set; }
            public int CT4 { get; set; }
            public int CT5 { get; set; }
            public int CT6 { get; set; }
            public int CT7 { get; set; }
            public int CT8 { get; set; }
            public int CT9 { get; set; }
            public int CT10 { get; set; }
            public int CT11 { get; set; }
            public int CT12 { get; set; }
            public int CT13 { get; set; }
            public int CT14 { get; set; }
            public int CT15 { get; set; }
            public int CT16 { get; set; }
            public int CT17 { get; set; }
            public int CT18 { get; set; }
            public int CT19 { get; set; }
            public int CT20 { get; set; }
        }
        void CapNhatDong(int index)
        {
            for (int j = 0; j < 20; j++)
            {
                if (maTran[index, j] == -1)
                {
                    typeof(BangQuanHe)
                        .GetProperty("CT" + (j + 1))
                        .SetValue(dsQuanHe[index], -1);
                }
            }
        }
        private void btn_tinh_Click(object sender, RoutedEventArgs e)
        {
            
            bool coA = !string.IsNullOrWhiteSpace(txt_A.Text);
            bool coB = !string.IsNullOrWhiteSpace(txt_B.Text);
            bool coC = !string.IsNullOrWhiteSpace(txt_C.Text);
            bool coa = !string.IsNullOrWhiteSpace(txt_canh_a.Text);
            bool cob = !string.IsNullOrWhiteSpace(txt_canh_b.Text);
            bool coc = !string.IsNullOrWhiteSpace(txt_canh_c.Text);
            bool coha = !string.IsNullOrWhiteSpace(txt_ha.Text);
            bool cohb = !string.IsNullOrWhiteSpace(txt_hb.Text);
            bool cohc = !string.IsNullOrWhiteSpace(txt_hc.Text);


            if (!coA && !coB && !coC && !coa && !cob && !coc && !coha && !cohb && !cohc)
            {
                MessageBox.Show("Vui lòng nhập các thông số của tam giác trước khi tính!",
                                "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            
            foreach (var row in dsQuanHe)
            {
                for (int j = 1; j <= 20; j++)
                {
                    typeof(BangQuanHe).GetProperty("CT" + j).SetValue(row, 0);
                }
            }
            if (coA) CapNhatDong(0);
            if (coB) CapNhatDong(1);
            if (coC) CapNhatDong(2);
            if (coa) CapNhatDong(3);
            if (cob) CapNhatDong(4);
            if (coc) CapNhatDong(5);
            if (coha) CapNhatDong(8);
            if (cohb) CapNhatDong(9);
            if (cohc) CapNhatDong(10);

            
            double a, b, c;
            double.TryParse(txt_canh_a.Text, out a);
            double.TryParse(txt_canh_b.Text, out b);
            double.TryParse(txt_canh_c.Text, out c);

            int index = combo.SelectedIndex;

            
            if (coa && cob && coc)
            {
                if (a + b <= c || a + c <= b || b + c <= a || a <= 0 || b <= 0 || c <= 0)
                {
                    MessageBox.Show("Ba cạnh a, b, c vừa nhập không tạo thành một tam giác hợp lệ!\n(Tổng 2 cạnh phải lớn hơn cạnh còn lại)",
                                    "Lỗi hình học", MessageBoxButton.OK, MessageBoxImage.Error);
                    txt_ketqua.Text = "Không phải tam giác";
                    return; 
                }
                double p = (a + b + c) / 2;
                double S = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

                if (index == 0) // Nửa chu vi
                {
                    txt_ketqua.Text = p.ToString("0.##");
                    CapNhatDong(6);
                }
                else if (index == 1) // Diện tích
                {
                    txt_ketqua.Text = S.ToString("0.##");
                    CapNhatDong(7);
                }
                else if (index == 2) // r
                {
                    txt_ketqua.Text = (S / p).ToString("0.##");
                    CapNhatDong(11); // Dòng r
                    CapNhatDong(6);  // p
                    CapNhatDong(7);  // S
                }
                else if (index == 3) // R
                {
                    txt_ketqua.Text = ((a * b * c) / (4 * S)).ToString("0.##");
                    CapNhatDong(12); // Dòng R
                    CapNhatDong(7);  // S
                }
               
                else if (index == 4) 
                {
                    txt_ketqua.Text = (2 * S / a).ToString("0.##");
                    CapNhatDong(8);
                }
            }
            else
            {
                MessageBox.Show("Để tính toán các giá trị này, bạn cần nhập đủ 3 cạnh a, b, c!",
                                "Thiếu dữ liệu", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            
            dg_quan_he.ItemsSource = null;
            dg_quan_he.ItemsSource = dsQuanHe;
        }

        private void btn_thong_tin_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
          "PHẦN MỀM GIẢI TAM GIÁC\n\n" +
          "Đồ án: Trí tuệ nhân tạo\n" +
          "Nhóm: 2\n" +
          "Chức năng: Giải bài toán tam giác bằng mạng ngữ nghĩa",
          "Information",
           MessageBoxButton.OK,
           MessageBoxImage.Information
            );

        }

        private void btn_tro_giup_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
            "HƯỚNG DẪN SỬ DỤNG:\n\n" +
         "1. Nhập dữ liệu của tam giác\n" +
         "2. Chọn giá trị cần tính\n" +
         "3. Nhấn nút 'Tính'\n" +
         "4. Xem kết quả hiển thị",
         "Help",
        MessageBoxButton.OK,
         MessageBoxImage.Information
        );

        }

        private void btn_thoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); 
        }
        int[,] maTran = new int[13, 20]
{
    //A
    { -1,-1,0,0,-1,0,-1,0,-1,0,0,0,0,0,0,0,0,0,0,-1 },
    //B
    { -1,0,-1,0,0,-1,-1,-1,0,0,0,0,0,0,0,0,0,-1,0,0 },
    //C
    { -1,0,0,-1,0,0,0,-1,0,0,0,-1,0,0,0,0,0,0,-1,0 },
    //a
    { 0,-1,-1,-1,-1,-1,-1,0,-1,-1,-1,-1,-1,0,0,-1,0,0,-1,0 },
    //b
    { 0,-1,-1,-1,-1,-1,-1,-1,0,-1,-1,-1,0,-1,0,-1,0,0,0,-1 },
    //c
    { 0,-1,-1,-1,-1,-1,0,-1,0,-1,-1,0,0,0,-1,-1,0,-1,0,0 },
    //p
    { 0,0,0,0,0,0,0,0,0,-1,-1,0,0,0,0,0,-1,0,0,0 },
    //S
    { 0,0,0,0,0,0,0,0,0,0,-1,-1,-1,-1,-1,-1,-1,0,0,0 },
    //hA
    { 0,0,0,0,0,0,0,0,0,0,0,0,-1,0,0,0,0,-1,0,0 },
    //hB
    { 0,0,0,0,0,0,0,0,0,0,0,0,0,-1,0,0,0,0,-1,0 },
    //hC
    { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,0,0,0,0,-1 },
    // r
    { 0,0,0,0,0,0,0,0,-1,0,0,0,0,0,0,-1,0,0,0,0 },
    // R
    { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,0,0,0 }
};
    }
}