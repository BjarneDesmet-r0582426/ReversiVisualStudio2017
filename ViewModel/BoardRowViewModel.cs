using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.Reversi;

namespace ViewModel
{
    public class BoardRowViewModel
    {
        public List<BoardSquareViewModel> Squares { get; set; }
        

        public BoardRowViewModel(ReversiGame spel)
        {
            this.Squares = new List<BoardSquareViewModel>();
            for (var i = 0; i < spel.Board.Width; i++)  
            {
                Squares.Add(new BoardSquareViewModel());
            }
          


            
           


        }

       
    }

   
}
