using DataStructures;
using Model.Reversi;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class ToGameCommand : ICommand
    {

        public OptionsViewModel viewModel { get; set; }
        public StartWindow startWindow { get; set; }
        

        public ToGameCommand(OptionsViewModel viewModel, StartWindow startWindow)
        {
            this.viewModel = viewModel;
            this.startWindow = startWindow;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter) // kan het uitgevoerd worden of niet, hier moeten voorwaarden in
        {

            return true;
        }

        public void Execute(object parameter) // wat er gebeurt wanneer men op de knop zelf klikt
        {
            BoardViewModel bvm;
            bvm = new BoardViewModel(ReversiBoard.CreateInitialState(6,6), viewModel);// waardes grote ingeven
            bvm.height = startWindow.height;
            bvm.width = startWindow.width;
            bvm = new BoardViewModel(ReversiBoard.CreateInitialState(bvm.width, bvm.height), viewModel);
            bvm.playerNameOne = startWindow.playerNameOne;
            bvm.playerNameTwo = startWindow.playerNameTwo;
            
            viewModel.SelectedOptionPane = new OptionsViewModel.OptionsCategory(bvm);
            System.Diagnostics.Debug.WriteLine(bvm.playerNameOne + " playerOne");
        }
    }
}
