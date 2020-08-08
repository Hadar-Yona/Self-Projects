using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameLogic
{
    public class Card
    {
        private eCardLetter m_Letter;
        private bool m_Open;
        private Cell m_CardLocation;
        public event Action<Cell> m_OnCardOpenDelegate;

        public Card(eCardLetter i_CardLetter)
        {
            this.m_Letter = i_CardLetter;
            this.m_Open = false;
        }

        public eCardLetter Letter
        {
            get
            {
                return m_Letter;
            }
           
        }

        public bool Open
        {
            get
            {
                return m_Open;
            }
            set
            {
                m_Open = value;
            }
        }

        public Cell CardLocation
        {
            get
            {
                return m_CardLocation;
            }
            set
            {
                m_CardLocation = value;
            }
        }

        public static bool CompareCards(Card i_FirstCard, Card i_SecondCard, Player i_Player)
        {
            bool flag = false;

            if (i_FirstCard.m_Letter == i_SecondCard.m_Letter)
            {
                i_FirstCard.OpenCard();
                i_SecondCard.OpenCard();
                i_Player.UpdateScore(i_Player);
                flag = true;
            }
            else
            {
               
            }

            return flag;
        }

        public void OpenCard()
        {
            this.Open = true;
            this.m_OnCardOpenDelegate.Invoke(this.CardLocation);
        }
    }
}
