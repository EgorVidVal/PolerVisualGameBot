using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokerTest
{
    public partial class Form1 : Form
    {
        //Класс с перемещанной колодой
        static RandomMap rMap = new RandomMap();

        //Класс в который помещаем перемешанную колоду и извлекаем карты по ходу игры
        MapHandTable handTable = new MapHandTable(rMap.ReadyMapForGame());

        MapIntMapString convert = new MapIntMapString();

        Hod hod = new Hod();

        public Form1() => InitializeComponent();

        private void Rise_Click(object sender, EventArgs e)
        {
            hod.HodGamer = 3;
        }

        private void Check_Click(object sender, EventArgs e)
        {
            hod.HodGamer = 2;
        }

        private void Fold_Click(object sender, EventArgs e)
        {
            hod.HodGamer = 1;
        }

        private void Start_Click(object sender, EventArgs e)
        {
            hod.FactorialAsync((Count)hod.count);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
