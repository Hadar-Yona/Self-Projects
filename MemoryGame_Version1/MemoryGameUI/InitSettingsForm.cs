using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1
{
    public partial class InitSettingsForm : Form
    {
        private bool m_AgainstFriend = true;
        private int m_MaxColSize = 6;
        private int m_MaxRowSize = 6;
        private int m_MinColSize = 4;
        private int m_MinRowSize = 4;

        public InitSettingsForm()
        {
            InitializeComponent();
            boardSizeButton.Text = m_RowSize + " x " + m_ColSize;
        }

        private void m_AgainstFriendButton_Click(object sender, EventArgs e)
        {
            if (m_AgainstFriend)
            {
                againstFriendButton.Text = "Against Computer";
                secondPlayerNameTextBox.Text = null;
                secondPlayerNameTextBox.Enabled = true;
                m_AgainstFriend = false;
            }
            else
            {
                againstFriendButton.Text = "Against a Friend";
                secondPlayerNameTextBox.Text = " - computer - ";
                secondPlayerNameTextBox.Enabled = false;
                m_AgainstFriend = true;
            }       
        }

        private void m_BoardSizeButton_Click(object sender, EventArgs e)
        {
                if (m_ColSize < m_MaxColSize)
                {
                    m_ColSize++;

                    if (m_ColSize % 2 != 0 && m_RowSize % 2 != 0)
                    {
                        m_ColSize++;
                    }
                }
                else if (m_ColSize == m_MaxColSize && m_RowSize == m_MaxRowSize)
                {
                    m_RowSize = m_MinRowSize;
                    m_ColSize = m_MinColSize;
                }
                else
                {
                    m_RowSize++;
                    m_ColSize = m_MinColSize;
                }

                boardSizeButton.Text = m_RowSize + " x " + m_ColSize;
                boardSizeButton.Size = new System.Drawing.Size(60 + 10 * m_RowSize, 60 + 10 * m_ColSize);
        }

        private void m_StartButton_Click(object sender, EventArgs e)
        {
            string firstPlayerName = firstPlayerNameTextBox.Text;
            string secondPlayerName = secondPlayerNameTextBox.Text;     
            MemoryGameForm game = new MemoryGameForm(m_RowSize, m_ColSize, firstPlayerName, secondPlayerName);
            game.ShowDialog();

            if(game.DialogResult == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;             
            }

            this.Close();
        }
    }
}