using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class ToEndCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public OptionsViewModel viewModel { get; set; }
        public EndWindow endWindow { get; set; }
        new BoardViewModel BoardView { get; set; }


        public ToEndCommand(OptionsViewModel viewModel, BoardViewModel boardView)
        {
            this.viewModel = viewModel;
            this.BoardView = boardView;
        }





        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            BoardViewModel end;
            viewModel.SelectedOptionPane = new OptionsViewModel.OptionsCategory(new EndWindow(viewModel, BoardView));
        }
    }
}
