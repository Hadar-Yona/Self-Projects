using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1
{
    class Program
    {
        public static void Main()
        {
            InitSettingsForm newGame = new InitSettingsForm();
            newGame.ShowDialog();
        }
    }
}
