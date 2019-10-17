using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EslestirmeOyun
{
    public partial class Form1 : Form
    {

        Image[] ImageArray =
        {
            Properties.Resources.c,
            Properties.Resources.c_,
            Properties.Resources.c__,
            Properties.Resources.java,
            Properties.Resources.js,
            Properties.Resources.php_logo,
            Properties.Resources.python,
            Properties.Resources.react
        };

        Image questionMark = Properties.Resources.quest;

        int[] ImageNo =
        {
            0,0,1,1,2,2,3,3,4,4,5,5,6,6,7,7
        };

        PictureBox firstBox;
        int FirstImageNo,GameControl;
        string Ad;

        int RowNo = 0;
        public Form1()
        {
            InitializeComponent();

           
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns[0].Visible = false;




        }

        private void BtnStart_Click(object sender, EventArgs e)
        {

            RowNo = dataGridView1.Rows.Add();

            if (txtAd.Text != "")
            {
                
                Ad = txtAd.Text;
                GameControl = 0;
                btnStart.Enabled = false;

                pictureBox1.Image = questionMark;
                pictureBox2.Image = questionMark;
                pictureBox3.Image = questionMark;
                pictureBox4.Image = questionMark;
                pictureBox5.Image = questionMark;
                pictureBox6.Image = questionMark;
                pictureBox7.Image = questionMark;
                pictureBox8.Image = questionMark;
                pictureBox9.Image = questionMark;
                pictureBox10.Image = questionMark;
                pictureBox11.Image = questionMark;
                pictureBox12.Image = questionMark;
                pictureBox13.Image = questionMark;
                pictureBox14.Image = questionMark;
                pictureBox15.Image = questionMark;
                pictureBox16.Image = questionMark;

                pictureBox1.Visible = true;
                pictureBox2.Visible = true;
                pictureBox3.Visible = true;
                pictureBox4.Visible = true;
                pictureBox5.Visible = true;
                pictureBox6.Visible = true;
                pictureBox7.Visible = true;
                pictureBox8.Visible = true;
                pictureBox9.Visible = true;
                pictureBox10.Visible = true;
                pictureBox11.Visible = true;
                pictureBox12.Visible = true;
                pictureBox13.Visible = true;
                pictureBox14.Visible = true;
                pictureBox15.Visible = true;
                pictureBox16.Visible = true;



                Random rndNumber = new Random();

                // Resimleri karıştır

                for (int i = 0; i < 16; i++)
                {
                    int no = rndNumber.Next(16);
                    int bridge = ImageNo[i];
                    ImageNo[i] = ImageNo[no];
                    ImageNo[no] = bridge;
                }

            }
            else
            {
                MessageBox.Show("Adınızı girmeyi unuttunuz...");
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox Pbox = (PictureBox)sender;
            int boxNo = Convert.ToInt32(Pbox.Name.Substring(10)) - 1;
            int indexNo = ImageNo[boxNo];
            Pbox.Image = ImageArray[indexNo];
            Pbox.Refresh();

            if (firstBox == null)
            {
                firstBox = Pbox;
                FirstImageNo = indexNo;
            }
            else
            {
                Thread.Sleep(500);
                if (FirstImageNo == indexNo)
                {
                    firstBox.Visible = false;
                    Pbox.Visible = false;
                    int Score = Convert.ToInt32(lblPoint.Text);
                    Score = Score + 50;
                    GameControl++;
                    lblPoint.Text = Score.ToString();
                    if(GameControl == 8)
                    {
                        MessageBox.Show(""+ Score + "  Puan kazanarak oyunu tamamladınız...","TEBRİKLER " + Ad);
                        btnStart.Enabled = true;

                        dataGridView1.Rows[RowNo].Cells[0].Value = RowNo;
                        dataGridView1.Rows[RowNo].Cells[1].Value = Ad;
                        dataGridView1.Rows[RowNo].Cells[2].Value = Score;

                        //reset score
                        Score = 100;
                        lblPoint.Text = Convert.ToString(Score);

                        //yüksek skor tablosu satır artır
                        RowNo++;
                    }
                }
                else
                {
                    firstBox.Image = questionMark;
                    Pbox.Image = questionMark;
                    int Score = Convert.ToInt32(lblPoint.Text);
                    Score = Score - 10;
                    lblPoint.Text = Score.ToString();
                }
                firstBox = null;

            }
        }

        
    }
}
