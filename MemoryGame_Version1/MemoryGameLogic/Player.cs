using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace gameLogic
{
    public class Player
    {
        private string m_Name;
        private int m_Score;
        private bool m_IsComputer;      //if the game is against the computer it should be: Player.isComputer = true;
        private bool m_Turn;
        private Tuple<int, Char, Card>[] m_ComputerAI;
        private int m_NextOpenIndexInComAIArray;
        public event Action<Player> m_ScoreDelegate;
        public event Action<Player> m_TurnDelegate;

        public Player(string name, bool isComputer, bool turn)
        {
            this.m_Name = name;
            this.m_Score = 0;
            this.m_IsComputer = isComputer;
            this.m_Turn = turn;
            this.m_ComputerAI = new Tuple<int, char, Card>[24]; // added beyond hadars code (AI)
            this.m_NextOpenIndexInComAIArray = 0;
        }

        public string Name
        {
            get
            {
                return m_Name;
            }
            set
            {
                m_Name = value;
            }
        }

        public int Score
        {
            get
            {
                return m_Score;
            }
            set
            {
                m_Score = value;
            }
        }

        public bool IsComputer
        {
            get
            {
                return m_IsComputer;
            }
            set
            {
                m_IsComputer = value;
            }
        }

        public bool Turn
        {
            get
            {
                return m_Turn;
            }
            set
            {
                this.changeTurn(value);
            }
        }

        private void changeTurn(bool isMyTurn)
        {
            this.m_Turn = isMyTurn;
            if (isMyTurn)
            {
                this.NotifyAboutTurn();
            }
        }

        private void NotifyAboutTurn()
        {
            this.m_TurnDelegate.Invoke(this);
        }

        internal int NextOpenIndexInComAIArray
        {
            get
            {
                return m_NextOpenIndexInComAIArray;
            }
            set
            {
                m_NextOpenIndexInComAIArray = value;
            }
        }

        internal Tuple<int, Char, Card>[] ComputerAI
        {
            get
            {
                return m_ComputerAI;
            }
            set
            {
                m_ComputerAI = value;
            }
        }

        internal void UpdateScore(Player i_Player)
        {
            this.Score++;
            this.m_ScoreDelegate.Invoke(this);
        }

        public Tuple<Card, Card> ComputersMove(Matrix i_Board)
        {
            Cell firstCard = i_Board.RandomCell();
            Cell secondCard = i_Board.RandomCell();

            while(firstCard == secondCard)
            {
                secondCard = i_Board.RandomCell();
            }

            Tuple<Card, Card> computersCards = new Tuple<Card, Card>(firstCard.HoldsCard, secondCard.HoldsCard);
            return computersCards;
        }
    }
}