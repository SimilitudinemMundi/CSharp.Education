using System;
using System.ComponentModel.Design;
using System.Net.Security;
class TicTacToe
{
    static void Main()
    {
        while (true)
        {
            Console.Write("| start / exit |   type: ");
            string input = Console.ReadLine();
            if (input == "start") Game();
            if (input == "exit") break;
        }
    }

    static bool IsWinCombination(string[] cells)
    {
        while (true)
        {
            if (cells[0] == cells[1] && cells[1] == cells[2])
            {
                return true;
            }
            if (cells[0] == cells[3] && cells[3] == cells[6])
            {
                return true;
            }
            if (cells[0] == cells[4] && cells[4] == cells[8])
            {
                return true;
            }
            if (cells[1] == cells[4] && cells[4] == cells[7])
            {
                return true;
            }
            if (cells[2] == cells[5] && cells[5] == cells[8])
            {
                return true;
            }
            if (cells[2] == cells[4] && cells[4] == cells[6])
            {
                return true;
            }
            if (cells[3] == cells[4] && cells[4] == cells[5])
            {
                return true;
            }
            if (cells[6] == cells[7] && cells[7] == cells[8])
            {
                return true;
            }
            return false;
        }
    }

    static void Draw(string[] cells)
    {
        const string line = "-------------";
        Console.WriteLine(line);
        Console.WriteLine($"| {cells[0]} | {cells[1]} | {cells[2]} |");
        Console.WriteLine(line);
        Console.WriteLine($"| {cells[3]} | {cells[4]} | {cells[5]} |");
        Console.WriteLine(line);
        Console.WriteLine($"| {cells[6]} | {cells[7]} | {cells[8]} |");
        Console.WriteLine(line);
    }

    static void Game()
    {
        const string plr1 = "Игрок 1", plr2 = "Игрок 2";
        string[] players = {plr1, plr2};
        int currentPlayerIndex = 1;
        string[] cells = ["1", "2", "3", "4", "5", "6", "7", "8", "9"];
        int[] memory = [];
        Console.WriteLine("Добро пожаловать в игру Крестики-Нолики!");

        while (IsWinCombination(cells) == false && memory.Length < 9)
        {
            currentPlayerIndex = (currentPlayerIndex + 1) % players.Length;
            Draw(cells);
            string currentPlayer = players[currentPlayerIndex];
            Console.WriteLine($"Ход {currentPlayer}");
            switch (currentPlayer)
            {
                case plr1:
                    {
                        while (true)
                        {
                            Console.Write("В какую клетку хотите поставить 'O'? -> ");
                            string str = Console.ReadLine();
                            int num = int.Parse(str);
                            int target = num - 1;

                            if (memory.Contains(target) == false)
                            {
                                cells[target] = "O";
                                Array.Resize(ref memory, memory.Length + 1);
                                memory[memory.Length - 1] = target;
                                break;
                            }
                            else Console.WriteLine("Клетка занята!");
                        }
                        break;
                    }

                case plr2:
                    {
                        while (true)
                        {
                            Console.Write("В какую клетку хотите поставить 'X'? -> ");
                            string str = Console.ReadLine();
                            int num = int.Parse(str);
                            int target = num - 1;

                            if (memory.Contains(target) == false)
                            {
                                cells[target] = "X";
                                Array.Resize(ref memory, memory.Length + 1);
                                memory[memory.Length - 1] = target;
                                break;
                            }
                            else Console.WriteLine("Клетка занята!");
                        }
                        break;
                    }
            }
            Console.WriteLine();
        }
        if (memory.Length == 9 && IsWinCombination(cells) == false)
        {
            Console.WriteLine("Ничья!");
            Draw(cells);
        }
        else Console.WriteLine($"Победил {players[currentPlayerIndex]}. Поздравляем!");
    }

}
