using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// $G$ RUL-003 (-20) No submission report attached to the solution

// $G$ SFN-999 (-2) user can start the game without entering a nam
// $G$ SFN-999 (-5) board size button shape changes each time the user presses on it
// $G$ SFN-999 (-5) the color of the player should stay with the player and not change during the game

namespace Project1
{
    public class Program
    {
        public static void Main()
        {
            InitSettingsForm newGame = new InitSettingsForm();
            newGame.ShowDialog();
        }
    }
}
