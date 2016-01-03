using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using MineSweeper.Lib;
using System.Web.Script.Serialization;

namespace MineSweeperWeb.Templates
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string getMines(string difficulty)
        {
            var difficultyLevel = MineSweeper.Lib.Enumerations.Difficulty.Easy;
            switch (difficulty)
            {
                case "2":
                    difficultyLevel = MineSweeper.Lib.Enumerations.Difficulty.Medium;
                    break;
                case "3":
                    difficultyLevel = MineSweeper.Lib.Enumerations.Difficulty.Hard;
                    break;
                case "4":
                    difficultyLevel = MineSweeper.Lib.Enumerations.Difficulty.VeryHard;
                    break;
            }

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Grid grid = new Grid(difficultyLevel);
            var json = serializer.Serialize(grid);
            return json;

        }
    }
}