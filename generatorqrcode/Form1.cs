using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.QrCode;

namespace generatorqrcode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string textToEncode = richTextBox1.Text;

            if (!string.IsNullOrWhiteSpace(textToEncode))
            {
                BarcodeWriter barcodeWriter = new BarcodeWriter();
                barcodeWriter.Format = BarcodeFormat.QR_CODE;
                barcodeWriter.Options = new ZXing.Common.EncodingOptions
                {
                    Width = 500,
                    Height = 500,
                };

                pictureBox1.Image = barcodeWriter.Write(textToEncode);
            }
            else
            {
                MessageBox.Show("Текстовое поле пуст. Введите текст для генерации QR-кода.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PNG files (*.png)|*.png|All files (*.*)|*.*";
                saveFileDialog.Title = "Сохранить QR как...";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    pictureBox1.Image.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);

                    MessageBox.Show("Изображение сохранено успешно.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Нет изображения для сохранения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {

        }

        private void menuItem8_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://t.me/rivixal_official");

        }
    }
}
