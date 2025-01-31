﻿using Amoba.Interfaces;

namespace Amoba.Classes
{
    public record class ConsolePlayer : IPlayer
    {
        public PlayerColor Color { get; init; }
        public PlayerType Type { get; init; }
        public ConsolePlayer(PlayerColor color)
        {
            Type = PlayerType.REAL;
            Color = color;
        }
        public ConsolePlayer() : this(PlayerColor.WHITE) { }
        public IBoardCell GetMove(IBoard<char> board, IBoardCell? prevMove)
        {
            var coordinate = new Coordinate(-1, -1);
            bool isValidMove = false;
            while ((coordinate.Y == -1 || coordinate.X == -1) && !isValidMove)
            {
                Console.WriteLine("Row: ");
                var inputRowIndex = Console.ReadLine();
                if (!int.TryParse(inputRowIndex, out int tmpRowIndex) || tmpRowIndex <= 0)
                {
                    Console.WriteLine($"{inputRowIndex} is not a valid row index!");
                    continue;
                }
                else
                {
                    coordinate.Y = tmpRowIndex - 1;
                }

                Console.WriteLine("Column: ");
                var inputColIndex = Console.ReadLine();
                Console.WriteLine();
                if (!int.TryParse(inputColIndex, out int tmpColIndex) || tmpColIndex <= 0)
                {
                    Console.WriteLine($"{inputColIndex} is not a valid column index!");
                    continue;
                }
                else
                {
                    coordinate.X = tmpColIndex - 1;
                }

                isValidMove = GameEngine.IsMoveValid(new BoardCell(coordinate.X, coordinate.Y, GameEngine.ColorToValue(Color)), board);
                if (!isValidMove)
                {
                    Console.WriteLine($"Row: {tmpRowIndex}, Column: {tmpColIndex} is not a valid move!");
                }
            }
            return new BoardCell(coordinate.X, coordinate.Y, GameEngine.ColorToValue(Color));
        }
    }
}
