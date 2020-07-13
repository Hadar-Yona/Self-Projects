using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameLogic
{
    public class Matrix               
    {
        private Cell[,] m_Board;
        private int m_NumOfCells;
        private int m_RowLength;
        private int m_ColLength;
        private int m_NumOfOpenCells;
        public event Action<Matrix> m_BoardIsAllOpenDelegate;

        public Matrix(int i_NumOfRows, int i_NumOfColumns)
        {
            m_RowLength = i_NumOfRows;
            m_ColLength = i_NumOfColumns;
            m_NumOfCells = i_NumOfRows * i_NumOfColumns;
            m_NumOfOpenCells = 0;
            m_Board = new Cell[i_NumOfRows, i_NumOfColumns];

            for (int i = 0; i < i_NumOfRows; i++)
            {
              for(int j = 0; j < i_NumOfColumns; j++)
                {
                    m_Board[i, j] = new Cell(new Tuple<int, int>(i, j));                    
                }
            }           

            RandomBoard();
        }

        private void DoWhenCardHasOpened(Cell i_CellWhichOpened)
        {
            m_NumOfOpenCells++;
            if(m_NumOfOpenCells == this.NumOfCells)
            {
                m_BoardIsAllOpenDelegate.Invoke(this);
            }
        }

        public Cell[,] Board
        {
            get
            {
                return m_Board;
            }
        }

        internal int RowLength
        {
            get
            {
                return m_RowLength;
            }
        }

        internal int ColLength
        {
            get
            {
                return m_ColLength;
            }
        }


        public int NumOfCells
        {
            get
            {
                return m_NumOfCells;
            }
        }

        public void RandomBoard()
        {
            int amountOfLetter = this.m_NumOfCells / 2;
            Array arr = Enum.GetValues(typeof(eCardLetter));
            int[] cardLettersCounter = new int[amountOfLetter]; 
            Random rnd = new Random();
            int nextLetter = 0;

            for (int i = 0; i < this.m_RowLength; i++)
            {
                for (int j = 0 ;  j < this.m_ColLength; j++)
                {
                    nextLetter = rnd.Next(0, amountOfLetter);
                    while (cardLettersCounter[nextLetter] == 2)
                    {
                        nextLetter = rnd.Next(0, amountOfLetter);
                    }
                    cardLettersCounter[nextLetter]++;
                    Card card = new Card((eCardLetter)arr.GetValue(nextLetter));
                    this.m_Board[i, j].HoldsCard = card;
                    card.CardLocation = m_Board[i, j];
                    this.m_Board[i, j].HoldsCard.m_OnCardOpenDelegate += DoWhenCardHasOpened;
                } 
            }
        }

        private List<Cell> toList()
        {
            List<Cell> cellsAsList = new List<Cell>();
            foreach (Cell cell in m_Board)
            {
                cellsAsList.Add(cell);
            }

            return cellsAsList;
        }

        //choose card for the computer moves
        internal Cell RandomCell()
        {
            List<Cell> closedCards = this.toList().FindAll(cell => !cell.HoldsCard.Open);

            Random rnd = new Random();
            int randomCell = rnd.Next(0, closedCards.Count);
            Cell currChoice = closedCards[randomCell];

            return currChoice;
        }
    }
}
