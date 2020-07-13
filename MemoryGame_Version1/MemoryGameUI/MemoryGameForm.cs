using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using gameLogic;

namespace Project1
{
    public partial class MemoryGameForm : Form
    {
        private Matrix m_GameBoard;
        private Button cardInCell;
        private int m_Rows;
        private int m_Columns;
        private Player m_FirstPlayer;
        private Player m_SecondPlayer;
        private List<Button> m_PlayersChoice;
        private List<Button> m_OpenCards;

        public Matrix GameBoard
        {
            get
            {
                return m_GameBoard;
            }
            set
            {
                m_GameBoard = value;
            }
        }

        public Button CardInCell
        {
            get
            {
                return cardInCell;
            }
            set
            {
                cardInCell = value;
            }    
        }

        public int Rows
        {
            get
            {
                return m_Rows;
            }
            set
            {
                m_Rows = value;
            }
        }

        public int Columns
        {
            get
            {
                return m_Columns;
            }
            set
            {
                m_Columns = value;
            }
        }

        public Player FirstPlayer
        {
            get
            {
                return m_FirstPlayer;
            }
            set
            {
                m_FirstPlayer = value;
            }
        }

        public Player SecondPlayer
        {
            get
            {
                return m_SecondPlayer;
            }
            set
            {
                m_SecondPlayer = value;
            }
        }

        public List<Button> PlayersChoice
        {
            get
            {
                return m_PlayersChoice;
            }
            set
            {
                m_PlayersChoice = value;
            }
        }

        public List<Button> OpenCards
        {
            get
            {
                return m_OpenCards;
            }
            set
            {
                m_OpenCards = value;
            }
        }

        public MemoryGameForm(int i_Rows, int i_Columns, string i_FirstName, string i_SecondName)
        {
            InitializeComponent();
            newPlayers(i_FirstName, i_SecondName);
            PlayersChoice = new List<Button>();
            OpenCards = new List<Button>();
            Rows = i_Rows;
            Columns = i_Columns;
            newBoard();
        }

        internal void newBoard()
        {
            this.Size = new Size(Columns * 80 + (Columns + 1) * 10 + 15, Rows * 80 + (Rows + 1) * 10 + 140);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            GameBoard = new Matrix(Rows, Columns);
            GameBoard.m_BoardIsAllOpenDelegate += DoWhenAllCardsAreOpen;
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    CardInCell = new Button();
                    CardInCell.Name = "Cell_" + i + j;
                    CardInCell.Size = new Size(80, 80);
                    CardInCell.Location = new Point((80 * j) + (10 * (j + 1)), (80 * i) + (10 * (i + 1)));
                    CardInCell.Tag = GameBoard.Board[i, j];                  
                    CardInCell.TabStop = false;
                    CardInCell.TabIndex = 0;
                    CardInCell.Click += CardClicked;
                    CardInCell.FlatStyle = FlatStyle.Flat;
                    Controls.Add(CardInCell);
                }
            }
        }

        private void DoWhenAllCardsAreOpen(Matrix obj)
        {
            endOfGame();
        }

        internal void newPlayers(string i_FirstName, string i_SecondName)
        {
            FirstPlayer = new Player(i_FirstName, false, true);
            SecondPlayer = new Player(i_SecondName, i_SecondName == "- computer -" ? true : false, false);
            FirstPlayer.m_ScoreDelegate += setScorLables;
            FirstPlayer.m_TurnDelegate += setCurrentTurnLable;
            SecondPlayer.m_ScoreDelegate += setScorLables;
            SecondPlayer.m_TurnDelegate += setCurrentTurnLable;
            setCurrentTurnLable(FirstPlayer);
            InitScorLables();
        }        

        private void InitScorLables()
        {
            setScorLables(FirstPlayer);
            setScorLables(SecondPlayer);
        }

        internal void setCurrentTurnLable(Player i_PlayersTurn)
        {
            currentPlayerLabel.Text = "Current Player: " + i_PlayersTurn.Name;
            currentPlayerLabel.BackColor = FirstPlayer.Turn ? firstPlayerLabel.BackColor : secondPlayerLabel.BackColor;
            currentPlayerLabel.AutoSize = true;
            currentPlayerLabel.Font = new Font("Ariel", 11);
            currentPlayerLabel.Refresh();
        }

        internal void setScorLables(Player i_PlayerToUpdate)
        {
            string updatedScore = i_PlayerToUpdate.Name + ": " + i_PlayerToUpdate.Score + " Pairs";
            if(i_PlayerToUpdate == FirstPlayer)
            {
                firstPlayerLabel.Text = updatedScore;
                firstPlayerLabel.AutoSize = true;
                firstPlayerLabel.Font = new Font("Ariel", 11);
                firstPlayerLabel.Refresh();
            }
            else
            {
                secondPlayerLabel.Text = updatedScore;
                secondPlayerLabel.AutoSize = true;
                secondPlayerLabel.Font = new Font("Ariel", 11);
                secondPlayerLabel.Refresh();
            }
        }

        private void CardClicked(object sender, EventArgs e)
        {
            CheckClickedCard(sender);           
        }

        private void CheckClickedCard(object sender)
        {
            Button card = (sender as Button);
            card.Enabled = false;
            card.Text = (card.Tag as Cell).HoldsCard.Letter + "";
            card.Font = new Font("Ariel", 14);
            card.BackColor = FirstPlayer.Turn ? firstPlayerLabel.BackColor : secondPlayerLabel.BackColor;
            card.Refresh();
            UpdateGameFlow(card);
        }

        private void UpdateGameFlow(Button i_PictureBox)
        {
            PlayersChoice.Add(i_PictureBox);
            if (PlayersChoice.Count == 2)
            {
                foreach (Control card in Controls)
                {
                    if (card.Name.Contains("Cell"))
                    {
                        card.Enabled = false;
                    }
                }

                Button firstCard = PlayersChoice[0];
                Button secondCard = PlayersChoice[1];
                System.Threading.Thread.Sleep(2000);
                checkPair(firstCard, secondCard);
            }
        }

        private void checkPair(Button i_FirstCard, Button i_SecondCard)
        {
            if (!Card.CompareCards((i_FirstCard.Tag as Cell).HoldsCard, (i_SecondCard.Tag as Cell).HoldsCard, FirstPlayer.Turn ? FirstPlayer : SecondPlayer))
            {
                i_FirstCard.Text = "";
                i_FirstCard.BackColor = Color.FromArgb(255, 240, 240, 240);
                i_SecondCard.Text = "";
                i_SecondCard.BackColor = Color.FromArgb(255, 240, 240, 240);
                i_FirstCard.Refresh();
                i_SecondCard.Refresh();
                FirstPlayer.Turn = !FirstPlayer.Turn;
                SecondPlayer.Turn = !SecondPlayer.Turn;
            }
            else
            {
                firstPlayerLabel.Refresh();
                secondPlayerLabel.Refresh();
                OpenCards.Add(i_FirstCard);
                OpenCards.Add(i_SecondCard);
            }

            PlayersChoice.Clear();

            if (SecondPlayer.Turn && SecondPlayer.IsComputer)
            {
                foreach (Control button in Controls)
                {
                    if (button.Name.Contains("Cell"))
                    {
                        button.Enabled = false;
                    }
                }

                computersTurn();
            }
            else
            {
                foreach (Control button in Controls)
                {
                    if (button.Name.Contains("Cell"))
                    {
                        if (!(button.Tag as Cell).HoldsCard.Open)
                        {
                            button.Enabled = true;
                        }
                    }
                }
            }
        }

        private void computersTurn()
        {
            Tuple<Card, Card> computerCards = SecondPlayer.ComputersMove(GameBoard);
            Tuple<int, int> firstIndexes = computerCards.Item1.CardLocation.getCellIndexes();
            Tuple<int, int> secondIndexes = computerCards.Item2.CardLocation.getCellIndexes();
            Button firstButton = (Button)this.Controls.Find("Cell_" + firstIndexes.Item1 + firstIndexes.Item2, false).First();
            Button secondButton = (Button)this.Controls.Find("Cell_" + secondIndexes.Item1 + secondIndexes.Item2, false).First();
            firstButton.Text = (firstButton.Tag as Cell).HoldsCard.Letter + "";
            firstButton.BackColor = FirstPlayer.Turn ? firstPlayerLabel.BackColor : secondPlayerLabel.BackColor;
            firstButton.Font = new Font("Ariel", 14);
            secondButton.Text = (secondButton.Tag as Cell).HoldsCard.Letter + "";
            secondButton.BackColor = firstButton.BackColor;
            secondButton.Font = new Font("Ariel", 14);
            firstButton.Refresh();
            System.Threading.Thread.Sleep(1000);
            secondButton.Refresh();
            System.Threading.Thread.Sleep(2000);
            checkPair(firstButton, secondButton);
        }

        private void endOfGame()
        {
            string winner = FirstPlayer.Name;
            DialogResult messageBoxResult;

            if (FirstPlayer.Score < SecondPlayer.Score)
            {
                winner = SecondPlayer.Name;
            }
            else if (FirstPlayer.Score == SecondPlayer.Score)
            {
                winner = "Tie";
            }

            if (winner == "Tie")
            {
                messageBoxResult = MessageBox.Show("There is a Tie!" + Environment.NewLine + "Would you like to play another game?", "Game Over", MessageBoxButtons.YesNo);
            }
            else
            {
                messageBoxResult = MessageBox.Show(winner + " is the winner!" + Environment.NewLine + "Would you like to play another game?", "Game Over", MessageBoxButtons.YesNo);
            }

            if (messageBoxResult == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.OK;
                this.Hide();
                Program.Main();
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
                Application.Exit();
            }

            this.Close();
        }
    }
}
