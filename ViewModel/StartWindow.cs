using Model.Reversi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class StartWindow
        

    {
        public String playerNameOne { get; set; }
        public String playerNameTwo { get; set; }
        public ReversiBoard bord { get; set; }
        public int height { get; set; }
        public int width { get; set; }            

                

        private OptionsViewModel viewModel { get; set; }
        public ToGameCommand command { get; set; }


        public StartWindow(OptionsViewModel viewModel)
        {
            this.viewModel = viewModel;
            this.command = new ToGameCommand(viewModel, this);

            // bord = ReversiBoard.CreateInitialState


            var bord = new BoardViewModel();
            bord.playerNameOne = playerNameOne;
            bord.playerNameTwo = playerNameTwo;
            bord.height = height;
            bord.width = width;
                

        }

    }
}
