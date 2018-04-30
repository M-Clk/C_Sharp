using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Zamanlayici
{
    public partial class frmSayac : Form
    {
        public frmSayac()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            saat = 1;
            dakika = 5;
            saniye = 30;
            //tmrSayac.Start();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        int saniye=0,dakika=0,saat=0,milisaniye=0;
        int yıl, ay, hafta, gün = 0;

        private void button2_Click(object sender, EventArgs e)
        {
            tmrSayac.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tmrSayac.Start();
        }

        string iniyıl, iniay, inihafta;
        private void tmrSayac_Tick(object sender, EventArgs e)
        {
            Azalt();   
        }
        void Azalt() {
            if (yıl == 0 && ay == 0 && hafta == 0 && gün == 0 && saat == 0 && saniye == 0 && dakika == 0 && milisaniye == 0)
            {
                tmrSayac.Stop();
                toolStripStatusLabel1.Text = "Geri Sayımınız Bitti - " + DateTime.Now;
                return;

            }
            if (milisaniye==0)
            {
                //milisaniye = 100;
                //Bunu artırmak zamanda sürtünmeye sebep oluyor.
                milisaniye = 1;
                if (saniye == 0)
                {
                    saniye = 60;
                    if (dakika == 0)
                    {
                        dakika = 60;
                        if (saat == 0)
                        {
                            saat = 24;
                            if(gün == 0)
                            {
                                gün = 365;
                                
                                if (hafta == 0) {
                                    hafta = gün % 52;
                                
                                if (ay == 0)
                                {
                                    ay = 12;
                                    if (yıl == 0)
                                    {
                                       // yıl = 99;
                                       //asır - century
                                    }
                                    yıl--;
                                }
                                ay--;
                              }
                                hafta--;
                            }
                            gün--;
                            gün = gün % 7;
                        }
                        saat--;

                    }
                    dakika--;

                }
                saniye--;

            }
            milisaniye--;
            


            /*
            if (milisaniye == 0)
            {
                milisaniye = 0;
                if (saniye == 60)
                {
                    dakika++;
                    saniye = 0;
                    if (dakika % 60 == 0)
                    {
                        saat++;
                        dakika = 0;
                    }
                }
                saniye--;
            }
            milisaniye++;
            lblSaat.Text = saat.ToString("D2") + ":" + dakika.ToString("D2") + ":" + saniye.ToString("D2") + "." + milisaniye.ToString("D2");
            */

            lblSaat.Text = gün.ToString("D1") + ":" + saat.ToString("D2") + ":" + dakika.ToString("D2") + ":" + saniye.ToString("D2") + "." + milisaniye.ToString("D2");
        }
        void Arttir()
        {
            if (milisaniye == 99)
            {
                milisaniye = 0;
                if (saniye == 60)
                {
                    dakika++;
                    saniye = 0;
                    if (dakika % 60 == 0)
                    {
                        saat++;
                        dakika = 0;
                    }
                }
                saniye++;
            }
            milisaniye++;
            lblSaat.Text = saat.ToString("D2") + ":" + dakika.ToString("D2") + ":" + saniye.ToString("D2") + "." + milisaniye.ToString("D2");
        }
    }
}
