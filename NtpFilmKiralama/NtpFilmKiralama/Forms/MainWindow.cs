using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NtpFilmKiralama.Forms
{
    public partial class MainWindow : Form
    {
        private List<Film> filmListesi;
        private List<rentedfilm> rentedfilmListesi;
        public MainWindow()
        {
            InitializeComponent();
            filmListesi = new List<Film>();
            rentedfilmListesi = new List<rentedfilm>();
            loadDataRentedFilm();
            loadDataFilm();
            UpdateFilmDataFile();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filmAdı = textBox4.Text;
            decimal kiralamabedeli = Convert.ToDecimal(textBox3.Text);

            Film film = new Film(filmListesi.Count+1 , filmAdı , kiralamabedeli);
            filmListesi.Add(film);
            dataGridView1.Rows.Add(film.Id , film.Name,film.Price);

            ExportFilmList();
            MessageBox.Show("Film Başarıyla Eklendi");
        }

        private void RentingButton_Click(object sender, EventArgs e)
        {
            string isim = textBox1.Text;
            string soyad = textBox2.Text;

            string seçilenFilm = Convert.ToString(dataGridView1.SelectedRows[0].Cells["NameMovie"].Value);

            DateTime kiralamaTarihi = dateTimePicker1.Value;
            int kalangün = Convert.ToInt32(textBox5.Text);

            decimal kiralamaBedeli = 0;
            if (dataGridView1.SelectedRows[0].DataBoundItem != null)
            {
                kiralamaBedeli = ((Film)dataGridView1.SelectedRows[0].DataBoundItem).Price;
            }
            decimal ödenecek_Tutar = kalangün * kiralamaBedeli;

            rentedfilm rentedfilm = new rentedfilm(rentedfilmListesi.Count + 1, seçilenFilm, kiralamaTarihi, kalangün, ödenecek_Tutar);
            rentedfilmListesi.Add(rentedfilm);

            dataGridView2.Rows.Add(rentedfilm.FilmId, rentedfilm.Name, rentedfilm.RentedDate, rentedfilm.RentingDays, rentedfilm.Price);

            if (dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
            }

            ExportRentedFilmList();
        }



        public void ExportRentedFilmList()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\DOSYA\kiralamaVerisi.txt", false))
                {
                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            writer.Write(cell.Value?.ToString() + "\t"); 
                        }
                        writer.WriteLine(""); 
                    }
                }

                MessageBox.Show("Başarıyla veriler kaydedildi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }

        public void ExportFilmList()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\DOSYA\filmverisi.txt", true))
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            writer.Write(cell.Value?.ToString() + "\t");
                        }
                        writer.WriteLine("");
                    }
                }

                MessageBox.Show("Başarıyla veriler kaydedildi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }

        private void UpdateFilmDataFile()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\DOSYA\filmverisi.txt"))
                {
                    foreach (Film film in filmListesi)
                    {
                        writer.WriteLine($"{film.Id}\t{film.Name}\t{film.Price}");
                    }
                }

                MessageBox.Show("Film verileri güncellendi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }

        public void loadDataRentedFilm()
        {
            string[] lines = File.ReadAllLines(@"C:\DOSYA\kiralamaVerisi.txt");
            string[] values;

            for(int i=0;i<lines.Length; i++)
            {
                values = lines[i].ToString().Split('\t');
                string[] row = new string[values.Length];
                for(int j = 0; j < values.Length; j++)
                {
                    row[j] = values[j].Trim();
                }
                dataGridView2.Rows.Add(row);
            }
        }
        public void loadDataFilm()
        {
            string[] lines = File.ReadAllLines(@"C:\DOSYA\filmverisi.txt");
            string[] values;

            for (int i = 0; i < lines.Length; i++)
            {
                values = lines[i].ToString().Split('\t');
                string[] row = new string[values.Length];
                for (int j = 0; j < values.Length; j++)
                {
                    row[j] = values[j].Trim();
                }
                dataGridView1.Rows.Add(row);
            }
        }

    }
}
