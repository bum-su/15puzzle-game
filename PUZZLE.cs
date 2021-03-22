using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUZZLE
{
    class PUZZLE
    {
        public enum Direction
        {
            Left,
            Right,
            Up,
            Down
        }


        int[,] gameTable = new int[4, 4];
        int Move_c = 0;
        public int row = 0;
        public int col = 0;

        // 초기화 함수
        public void init()
        {
            int count = 1;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    gameTable[i, j] = count;
                    count++;
                }
            }
            gameTable[3, 3] = 0;
        }

        // 출력 함수
        public void Draw()
        {
            Console.SetCursorPosition(0, 0);

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write("[{0, 3}]", gameTable[i, j]);
                }
                Console.Write("\n");
            }
        }

        // 0이 있는 위치를 찾는 함수
        public void FindZero()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (gameTable[i, j] == 0)
                    {
                        row = i;
                        col = j;
                        return;
                    }
                }
            }
        }

        // 0의 위치를 기준으로 랜덤하게 수를 섞는 함수
        public void Shuffle()
        {
            Random r = new Random();

            for(int i = 0; i < 100; i++)
            {
                int dir = r.Next() % 4;
                int temp = 0;

                FindZero();

                switch((Direction)dir)
                {
                    case Direction.Left:
                        if (col == 0)continue;
                        temp = gameTable[row, col - 1];
                        gameTable[row, col - 1] = gameTable[row, col];
                        gameTable[row, col] = temp;
                        break;

                    case Direction.Right:
                        if (col == 3) continue;
                        temp = gameTable[row, col + 1];
                        gameTable[row, col + 1] = gameTable[row, col];
                        gameTable[row, col] = temp;
                        break;

                    case Direction.Up:
                        if (row == 0) continue;
                        temp = gameTable[row - 1, col];
                        gameTable[row - 1, col] = gameTable[row, col];
                        gameTable[row, col] = temp;
                        break;

                    case Direction.Down:
                        if (row == 3) continue;
                        temp = gameTable[row + 1, col];
                        gameTable[row + 1, col] = gameTable[row, col];
                        gameTable[row, col] = temp;
                        break;
                }
            }


            //Random r = new Random((int)DateTime.Now.Ticks);

            //int zeroPosition = r.Next() % 9;

            //int count = 1;

            //int[] board = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0};

            //board[zeroPosition] = 1;


            //while(count < 9)
            //{

            //}

        }

        public void Move_Count()
        {
            Move_c++;
        }

        // 키를 입력받아 게임을 진행하는 함수
        public void input()
        {
            if (Console.KeyAvailable)
            {
                FindZero();

                ConsoleKeyInfo info = Console.ReadKey();

                int temp = 0;
                switch (info.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (col == 0)
                            return;
                        temp = gameTable[row, col - 1];
                        gameTable[row, col - 1] = gameTable[row, col];
                        gameTable[row, col] = temp;
                        Move_Count();
                        break;
                    case ConsoleKey.RightArrow:
                        if (col == 3)
                            return;
                        temp = gameTable[row, col + 1];
                        gameTable[row, col + 1] = gameTable[row, col];
                        gameTable[row, col] = temp;
                        Move_Count();
                        break;
                    case ConsoleKey.UpArrow:
                        if (row == 0)
                            return;
                        temp = gameTable[row - 1, col];
                        gameTable[row - 1, col] = gameTable[row, col];
                        gameTable[row, col] = temp;
                        Move_Count();
                        break;
                    case ConsoleKey.DownArrow:
                        if (row == 3)
                            return;
                        temp = gameTable[row + 1, col];
                        gameTable[row + 1, col] = gameTable[row, col];
                        gameTable[row, col] = temp;
                        Move_Count();
                        break;
                }
            }
        }

        // 게임이 클리어 되었는지 체크하는 함수
        public bool isClear()
        {
            int count = 1;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if(gameTable[i, j] == count)
                        count++;
                }
            }

            if (count == 16 && gameTable[3, 3] == 0)
                return true;

            return false;
        }

        public void Run()
        {
            init();
            Shuffle();
            while(true)
            {
                input();
                Draw();
                bool clear = isClear();

                if (clear)
                {
                    Console.WriteLine("게임을 클리어 하였습니다.");
                    Console.WriteLine("움직인 횟수는 {0}번 입니다.", Move_c);
                    break;
                }
            }
        }
    }
}
