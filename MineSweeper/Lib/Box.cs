using MineSweeper.Interfaces;
using MineSweeper.Lib;
using MineSweeper.Lib.Enumerations;
using System;

namespace MineSweeper.Lib
{
    public class Box : IBox
    {

        public bool Opened { get; private set; }
        public bool isFlagged { get; set; }
        public bool hasMine
        {
            get
            {
                return this.BoxType.Equals(Enumerations.BoxType.Mine) ? true : false;
            }
        }

        public Position Position { get; private set; }
        public BoxType BoxType { get; private set; }

        [System.ComponentModel.DefaultValue(0)]
        public int AdjacentMines { get; private set; }

        public void Create(Position position, BoxType boxtype)
        {
            this.Position = position;
            this.BoxType = boxtype;
        }

        public void Open()
        {
            if (hasMine)
                throw new Exception("You Have Clicked a Mine !! ");
            else
                this.Opened = true;
        }

        public void SetMine()
        {
            this.BoxType = Enumerations.BoxType.Mine;
        }

        public void SetAdjacentMineCount(int mineCount)
        {
            this.AdjacentMines = mineCount;
        }

        public void ToggleFlag()
        {
            isFlagged = isFlagged ? false : true;
        }
    }
}
