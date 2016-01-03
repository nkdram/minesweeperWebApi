using MineSweeper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MineSweeper.Lib
{
    public class Grid : IGrid
    {
        public IList<Box> Boxes { get; private set; }

        [System.ComponentModel.DefaultValue(MineSweeper.Lib.Enumerations.Difficulty.Easy)]
        public MineSweeper.Lib.Enumerations.Difficulty Difficulty { get; private set; }

        [System.ComponentModel.DefaultValue(0)]
        public int maxX { get; set; }
        [System.ComponentModel.DefaultValue(0)]
        public int maxY { get; set; }
        [System.ComponentModel.DefaultValue(0)]
        public int mineCount { get; set; }

        public IList<Box> GetBoxes()
        {
            return this.Boxes;
        }

        public Grid()
        {
            this.LoadBoxes();
        }

        public Grid(MineSweeper.Lib.Enumerations.Difficulty Difficulty = Enumerations.Difficulty.Easy)
        {
            this.Difficulty = Difficulty;
            this.LoadBoxes();
        }

        public void LoadBoxes()
        {
            switch (this.Difficulty)
            {
                case Enumerations.Difficulty.Easy:
                    BuildBoxes(3, 3, 3);
                    break;
                case Enumerations.Difficulty.Medium:
                    BuildBoxes(6, 6, 12);
                    break;
                case Enumerations.Difficulty.Hard:
                    BuildBoxes(10, 10, 40);
                    break;
                case Enumerations.Difficulty.VeryHard:
                    BuildBoxes(15, 15, 99);
                    break;
            }

        }

        private void BuildBoxes(int maxX, int maxY, int mineCount)
        {
            var Boxes = new List<Box>();
            this.maxX = maxX;
            this.maxY = maxY;
            this.mineCount = mineCount;

            //Random Places of mines
            List<int> positions = Enumerable.Range(0, maxX * maxY).ToList();
            string[] minePositions = new string[mineCount];
            var rnd = new Random();
            for (int i = 0; i < mineCount; i++)
            {
                int index = rnd.Next(positions.Count);
                int pos = positions[index];
                positions.RemoveAt(index);
                int x = pos % maxX, y = pos / maxY;
                minePositions[i] = x.ToString() + "," + y.ToString();
            }

            //Set mines in Grid
            for (int i = 0; i < maxX; i++)
            {
                var temp = new List<Box>();
                for (int j = 0; j < maxY; j++)
                {
                    var Box = new Box();
                    var position = new Position(i, j);
                    var adjacentMines = 0;
                    Box.Create(position, Enumerations.BoxType.Empty);
                    if (minePositions.Contains(i.ToString() + "," + j.ToString()))
                        Box.SetMine();

                    //Calculating Adjacent mines
                    for (int posX = (i - 1 < 0 ? 0 : i - 1); posX <= (i + 1 >= maxX ? (maxX - 1) : i + 1); posX++)
                        for (int posY = (j - 1 < 0 ? 0 : j - 1); posY <= (j + 1 >= maxY ? (maxY - 1) : j + 1); posY++)
                        {
                            if (!(posX == i && posY == j) && minePositions.Contains(posX.ToString() + "," + posY.ToString()))
                                adjacentMines++;
                        }
                    Box.SetAdjacentMineCount(adjacentMines);
                    temp.Add(Box);
                }
                Boxes.InsertRange(0, temp);                
            }
           
            this.Boxes = Boxes;
        }

    }
}
