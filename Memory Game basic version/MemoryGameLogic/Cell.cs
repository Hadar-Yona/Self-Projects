using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameLogic
{
    public class Cell
    {
        private readonly int m_Row;
        private readonly int m_Column;
        private Card m_HoldsCard;

        public Cell(Tuple<int, int> i_CellLocation)
        {
            this.m_Row = i_CellLocation.Item1;
            this.m_Column = i_CellLocation.Item2;
        }

        public Card HoldsCard
        {
            get
            {
                return m_HoldsCard;
            }
            set
            {
                m_HoldsCard = value;
            }
        }

        public Tuple<int, int> GetCellIndexes()
        {
            int cellRow = this.m_Row;
            int cellColumn = this.m_Column;

            return new Tuple<int, int>(cellRow, cellColumn);
        }
    }
}
