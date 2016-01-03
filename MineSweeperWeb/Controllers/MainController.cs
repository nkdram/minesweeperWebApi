//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;

//using System.Web.Http;

//namespace MineSweeperWeb.App_Code.Controller
//{
//    public class MainController : ApiController
//    {
//        [Route("mines/{difficulty}")]
//        [HttpGet]
//        public MineSweeper.Lib.Grid GetGrids(string difficulty)
//        {

//            var difficultyLevel = MineSweeper.Lib.Enumerations.Difficulty.Easy;
//            switch (difficulty)
//            {
//                case "2":
//                    difficultyLevel = MineSweeper.Lib.Enumerations.Difficulty.Medium;
//                    break;
//                case "3":
//                    difficultyLevel = MineSweeper.Lib.Enumerations.Difficulty.Hard;
//                    break;
//                case "4":
//                    difficultyLevel = MineSweeper.Lib.Enumerations.Difficulty.VeryHard;
//                    break;
//            }
//            MineSweeper.Lib.Grid grid = new MineSweeper.Lib.Grid(difficultyLevel);
//            return grid;
//        }
//    }
//}