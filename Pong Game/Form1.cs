using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pong_Game
{
    public partial class pong : Form
    {
        //int cpuDirection = 5;
        int ballXCoordinate = 5;
        int ballYCoordinate = 5;
        int playerScore = 0;
        int cpuScore = 0;
        int bottomBoundary;
        int centerPoint;
        int xMidpoint;
        int yMidpoint;
        bool playerDetectedUp;
        bool playerDetectedDown;
        bool cpuDetectedUp;
        bool cpuDetectedDown;
        //int spaceBarClicked = 0;
        
        public pong()
        {
            InitializeComponent();
            bottomBoundary = ClientSize.Height - player1.Height;
            xMidpoint = ClientSize.Width / 2;
            yMidpoint = ClientSize.Height / 2;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pongTimer_Tick(object sender, EventArgs e)
        {
            Random newBallSpot = new Random();
            int newSpot = newBallSpot.Next(100, ClientSize.Height - 100);
            pongBall.Top -= ballYCoordinate;
            pongBall.Left -= ballXCoordinate;
            //cpuPlayer.Top += cpuDirection;
            //if(cpuPlayer.Top < 0 || cpuPlayer.Top > bottomBoundary) { cpuDirection = -cpuDirection; }
            if (pongBall.Left < 0)
            {
                pongBall.Left = xMidpoint;
                pongBall.Top = newSpot;
                ballYCoordinate = -ballXCoordinate;
                cpuScore++;
                cpuScoreLabel.Text = cpuScore.ToString();
            }
            if(pongBall.Left + pongBall.Width > ClientSize.Width)
            {
                pongBall.Left = xMidpoint;
                pongBall.Top = newSpot;
                ballYCoordinate = -ballXCoordinate;
                playerScore++;
                playerScoreLabel.Text = playerScore.ToString();
            }
            if(pongBall.Top < 0 || pongBall.Top + pongBall.Height > ClientSize.Height) { ballYCoordinate = -ballYCoordinate; }
            if(pongBall.Bounds.IntersectsWith(player1.Bounds) || pongBall.Bounds.IntersectsWith(cpuPlayer.Bounds)) 
            {
                ballXCoordinate = -ballXCoordinate;
            }
            if(playerDetectedUp == true && player1.Top > 0) { player1.Top -= 10; }
            if(playerDetectedDown == true && player1.Top < bottomBoundary) { player1.Top += 10; }
            if (cpuDetectedUp == true && cpuPlayer.Top > 0) { cpuPlayer.Top -= 10; }
            if (cpuDetectedDown == true && cpuPlayer.Top < bottomBoundary) { cpuPlayer.Top += 10; }
            if (playerScore >= 10) { pongTimer.Stop(); }
        }

        private void pong_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) { playerDetectedUp = false; }
            if (e.KeyCode == Keys.S) { playerDetectedDown = false ; }
            if (e.KeyCode == Keys.Up) { cpuDetectedUp = false; }
            if (e.KeyCode == Keys.Down) { cpuDetectedDown = false; }
        }

        private void pong_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.W) { playerDetectedUp = true; }
            if (e.KeyCode == Keys.S) { playerDetectedDown = true; }
            if (e.KeyCode == Keys.Up) { cpuDetectedUp = true; }
            if (e.KeyCode == Keys.Down) { cpuDetectedDown = true; }
            //if (e.KeyCode == Keys.Space)
            //{
                //pongTimer.Stop();
            //}
            //else
            //{
               // pongTimer.Start();
            //}
            //spaceBarClicked++;
        }

       
    }
}
