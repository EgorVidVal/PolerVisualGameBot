using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PokerTest
{
    class Hod
    {
        public int Who,bankBot,BankGamer,RateBot,RateGamer,BotHod,HodGamer,count;

        public async void FactorialAsync(Count count)
        {
            await Task.Run(() => HodGame(count));                  
        }

        public void HodGame(Count count)
        {  
            while(true)
            {
                Thread.Sleep(500);
                switch (count)
                {
                    case Count.Preflop:
                        GameStart();
                        break;
                    case Count.Flop:
                        GameStart();
                        break;
                    case Count.Tern:
                        GameStart();
                        break;
                    case Count.River:
                        GameStart();
                        break;
                }
            }
            
        }

        public void GameStart()
        {
            if (Who == (int)WhoGoes.gamer)
            {
                Console.WriteLine("Ходит игрок");
                GameRes(ref HodGamer, ref BotHod);
            }
            else if (Who == (int)WhoGoes.bot)
            {
                Console.WriteLine("Бот");
                Bot b = new Bot();

                BotHod = b.BotStart(HodGamer);
                GameRes(ref BotHod, ref HodGamer);
            }
        }
        //Ход игры
        public void GameRes(ref int gamerOne,ref int gamerTwo)
        {

            while (true)
            {
                Thread.Sleep(500);
               
                //Ожидание действие игрока
                if (gamerOne != 0)
                {
                    Console.WriteLine("Игрок сходил");
                    if (Who == 0)
                    {
                        Bot b = new Bot();
                        gamerTwo = b.BotStart(HodGamer);
                    }
                    Console.WriteLine("Решение бота {0}", BotHod);

                    if (BotHod != 0)
                    {
                        //Проверяем продожитсья ли игра после решения.
                        bool checking = GameHod(gamerOne, gamerTwo);
                        Console.WriteLine("Играем дальше");
                        if (checking == true)
                        {
                            Console.WriteLine("Все ок получилось");
                            //Складываем все ставки и добавляем в общие
                            //преходим на флоп
                            if (Who == 1) Who = 0; else Who = 1;
                            gamerOne = 0; gamerTwo = 0;
                             count++;
                            break;
                        }
                    }
                }
            }
        }

        //Ход игры, можно ли продолжать.
        public bool GameHod(int gamerOne,int gamerTwo)
        {
            if(gamerOne == (int)Dey.Check && gamerTwo == (int)Dey.Check)
            {
                return true;
            }
            if (gamerOne == (int)Dey.Check && gamerTwo == (int)Dey.Rise)
            {
                return false;
            }
            if (gamerOne == (int)Dey.Rise && gamerTwo == (int)Dey.Rise)
            {
                return false;
            }
            if (gamerOne == (int)Dey.Rise && gamerTwo == (int)Dey.Koll)
            {
                return false;
            }
            if (gamerOne == (int)Dey.Koll && gamerTwo == (int)Dey.Rise)
            {
                return true;
            }
            return false;
        }

    }

    enum Dey
    {
        Fold = 1,
        Check,
        Rise,
        Koll
    }

    enum Count
    {
        Preflop,
        Flop,
        Tern,
        River
    }
    enum WhoGoes
    {
        gamer,
        bot
    }
    
}
