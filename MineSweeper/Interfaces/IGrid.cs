using MineSweeper.Lib;
using System;
using System.Collections.Generic;

namespace MineSweeper.Interfaces
{
    interface IGrid
    {
        IList<Box> Boxes { get; }
        MineSweeper.Lib.Enumerations.Difficulty Difficulty { get; }
        IList<Box> GetBoxes();
        void LoadBoxes();
        //void AddItem(IBox box);
        //void RemoveItem(Position position);
    }
}
