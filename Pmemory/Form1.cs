using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

/*
    1-        Funcionamiento general: 4p

    2-        Diseño+  Música 2p

    3-        Uso de tiempo para Puntuación +     Fecha , hora actual +  Falta de errores  [3p]

    4-        Extras[1p] 
*/


namespace Pmemory
{
    public partial class Form1 : Form
    {
        //atributos

        SoundPlayer player;

        Image[] image;
        Button[] bt;
        
        Random random = new Random();
        List<int> randomList;
        //------------
        int buttonNumber = 0; //0, 1 (button) 2(Button)
        Button BT1, BT2;
        int index1, index2;
        int Nmax = 16;
        int contCorrect;
        int timer = 50;
        int counterTimer;
        int counterTimerPoints = 53;
        int counterTimerStart = 3;
        int score = 0;
        int secLeft;

        //builder
        public Form1()
        {
            InitializeComponent();
            initConfig();
        }

        private void initConfig()
        {
            timer1.Enabled = false;

            generte_randomNumbersNoDuplicte(0, Nmax);
            String name = "";
            image = new Image[]
            {
                Properties.Resources._01A,
                Properties.Resources._02A,
                Properties.Resources._03A,
                Properties.Resources._04A,
                Properties.Resources._05A,
                Properties.Resources._06A,
                Properties.Resources._07A,
                Properties.Resources._08A,

                Properties.Resources._01B,
                Properties.Resources._02B,
                Properties.Resources._03B,
                Properties.Resources._04B,
                Properties.Resources._05B,
                Properties.Resources._06B,
                Properties.Resources._07B,
                Properties.Resources._08B
            };

            bt = new Button[]
            {
                button1, button2, button3, button4, button5, button6, button7, button8,
                button9, button10, button11, button12, button13, button14, button15, button16
            };

            for ( int i=0; i<Nmax; i++)
            {
                if (i < 10)
                {
                    name = "0"; //0
                    name += i; //07
                }
                else
                {
                    name = ""; //0
                    name += i;
                }
                if (i < Nmax / 2) name += "A";
                else name += "B";

                bt[i].Name = name;
                bt[i].Image = Properties.Resources._00;
            }

            player = new SoundPlayer();
        }

        private void generte_randomNumbersNoDuplicte(int Nmin, int Nmax)
        {
            randomList = new List<int>();
           
            List<int> ordedList = Enumerable.Range(Nmin, Nmax).ToList();

            for (int i = 0; i<Nmax; i++)
            {
                int index = random.Next(0, ordedList.Count);
                randomList.Add(ordedList[index]);
                ordedList.RemoveAt(index);
            }

        }

        //metodos subprogramas
        
        
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            BT1.Image = Properties.Resources._00;
            BT2.Image = Properties.Resources._00;

            timer1.Enabled = false;
        }

        //muestra la fecha y la hora
        private void timer2_Tick(object sender, EventArgs e)
        {
            labeHour.Text = DateTime.Now.ToLongDateString(); 
            labeDate.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        //cuentra atras para jugar
        private void timer3_Tick(object sender, EventArgs e)
        {
            counterTimer++;
            counterTimerPoints--;
            counterTimerStart--;
            labeTimer1m.Text = "TIMER: 00:00:50";

           if (counterTimerStart <= 0)
           {
                for (int i = 0; i < bt.Length; i++)
                {
                    bt[i].Enabled = true;
                }
           }

            //cuenta atras 3sec anter de empezar
            if (counterTimerStart > 0)
            {
                labeStartTimer.Text = counterTimerStart + "" ;
                if (counterTimerStart == 2) labeStartTimer.BackColor = Color.Orange;
                if (counterTimerStart == 1) labeStartTimer.BackColor = Color.Green;

            } else labeStartTimer.Visible = false;

            //si se acaba el tiempo
            if (counterTimer >= 53)
            {
                sound("5");
                timer3.Enabled = false;

                labeWinner.ForeColor = Color.Red;
                labeWinner.Visible = true;
                labeWinner.Text = "You lose";
                labePlayerScore.ForeColor = Color.Red;
                labePlayerScore.Text = "Your final score: 0";

                for (int i = 0; i < bt.Length; i++)
                {
                    bt[i].Enabled = false;
                }
            }
            //
            if (counterTimer >= 3) {

                secLeft = timer - counterTimer + 3;

                if (secLeft <= 5) labeTimer1m.ForeColor = Color.Red;

                if (secLeft < 10) labeTimer1m.Text = "TIMER: 00:00:0" + secLeft;
                else labeTimer1m.Text = "TIMER: 00:00:" + secLeft;
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (button != BT1)
            {

            
            string name = button.Name;
  
            name = name.Substring(0, name.Length - 1);

            int nImage = randomList[Convert.ToInt32(name)];
            button.Image = image[nImage];

            //------------------
            
            buttonNumber++;
                if (buttonNumber == 1)
                {
                    BT1 = button;
                    index1 = nImage;
                    BT1.Enabled = false;

                    sound("1");
                }

                else if (buttonNumber == 2)
                {
                    buttonNumber = 0;

                    BT2 = button;
                    index2 = nImage;

                    if (BT2 != BT1)
                    {
                        if (index1 % (Nmax / 2) != index2 % (Nmax / 2))
                        {
                            timer1.Enabled = true;
                            BT2.Enabled = false;
                            //incorrecto
                            sound("2");
                            BT1.Enabled = true;
                            BT2.Enabled = true;
                            score = score - 5;
                            if (score < 0)
                            {
                                labePlayerScore.ForeColor = Color.Red;
                                labePlayerScore.Text = "Your score: " + score;
                            }
                            else
                            {
                                labePlayerScore.ForeColor = Color.Black;
                                labePlayerScore.Text = "Your score: " + score;
                            }

                        }
                        else
                        {
                            //correcto
                            sound("3");
                            contCorrect++;
                            score = score + 10;

                            if (score < 0)
                            {
                                labePlayerScore.ForeColor = Color.Red;
                                labePlayerScore.Text = "Your score: " + score;
                            }
                            else
                            {
                                labePlayerScore.ForeColor = Color.Black;
                                labePlayerScore.Text = "Your score: " + score;
                            }

                            if (contCorrect == 8)
                            {
                                labelPlusPointsTime.ForeColor = Color.Green;
                                
                                labeWinner.Visible = true;
                                sound("4");
                                timer3.Enabled = false;
                                for (int i = 0; i < bt.Length; i++)
                                {
                                    bt[i].Enabled = false;
                                }
                                //MessageBox.Show(counterTimerPoints + "");
                                if (counterTimerPoints >= 20)
                                {
                                    score = score + 20; 
                                    labelPlusPointsTime.Text = "+ 20p";
                                }
                                if ((counterTimerPoints < 20) && (counterTimerPoints >= 10))
                                {
                                    score = score + 10; 
                                    labelPlusPointsTime.Text = "+ 10p";
                                }
                                if ((counterTimerPoints < 10) && (counterTimerPoints >= 5))
                                {
                                    score = score + 5; 
                                    labelPlusPointsTime.Text = "+ 5p";
                                }
                                if (counterTimerPoints < 5)
                                {
                                    labelPlusPointsTime.Text = "+ 0p"; 
                                    labelPlusPointsTime.ForeColor = Color.Red;
                                }

                                if (score < 0)
                                {
                                    labePlayerScore.ForeColor = Color.Red;
                                    labePlayerScore.Text = "Your final score: " + score;
                                }
                                else
                                {
                                    labePlayerScore.ForeColor = Color.Black;
                                    labePlayerScore.Text = "Your final score: " + score;
                                }
                            }
                            BT1.Enabled = false;
                            BT2.Enabled = false;
                        }
                    }
                    //BT1 == BT2
                    else
                    {

                    


                    // buttonNumber = 0;
                }
            }}
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer2.Enabled = true;
            timer3.Enabled = true;
            for (int i = 0; i < bt.Length; i++)
            {
                bt[i].Enabled = false;
            }

        }

        //Music
        private void sound(string s)
        {
            player.SoundLocation = @"sound\" + s + ".wav";
            player.Play();
        }
    }
}
