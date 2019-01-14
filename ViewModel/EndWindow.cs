using Model.Reversi;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class EndWindow
    {
        public ToEndCommand commandend { get; set; }
        public OptionsViewModel optionsModel { get; set; }
        public String winner { get; set; }
        public ReversiBoard bord { get; set; }
        public BoardViewModel spel { get; set; }
        

        public EndWindow(OptionsViewModel optionsModel, BoardViewModel viewmodel)
        {
            this.optionsModel = optionsModel;
            this.commandend = new ToEndCommand(optionsModel, viewmodel);
            this.winner = viewmodel.getWinner();
            this.spel = viewmodel;
            Debug.WriteLine(spel);
            this.bord = viewmodel.bord;
            Debug.WriteLine(bord);




        }

       
        
    }
}
