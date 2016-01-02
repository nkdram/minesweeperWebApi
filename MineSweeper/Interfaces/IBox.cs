using MineSweeper.Lib;
using System;

namespace MineSweeper.Interfaces
{
    public interface IBox
    {
        // Status of Box
        bool Opened { get;  }
        bool isFlagged { get; set; }
        bool hasMine { get;  }

        //Position of Box
        Position Position { get;  }
        //Type of Box
        MineSweeper.Lib.Enumerations.BoxType BoxType { get;  }
        
        //AdjacentMine Count
        int AdjacentMines { get;  }

        
        void Create(Position position,MineSweeper.Lib.Enumerations.BoxType boxtype);
        void Open();
        void ToggleFlag();
    }
}
