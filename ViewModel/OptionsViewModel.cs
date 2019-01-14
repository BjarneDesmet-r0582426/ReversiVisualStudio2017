using Model.Reversi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace ViewModel
{
    public class OptionsViewModel : INotifyPropertyChanged
    {
        public OptionsViewModel()
        {
            var bordview = new BoardViewModel(ReversiBoard.CreateInitialState(6, 6),this); // hetzelfde spel wordt hier gebruikt, we gaan dezelfde bordview gebruiken om onze gegevens uit te halen
            this.OptionPanes = new List<object> {
                new OptionsCategory(new StartWindow(this)),
                new OptionsCategory(bordview),//Maakt bord aan
            };
            this.SelectedOptionPane = OptionPanes.First();
        }

        public List<object> OptionPanes { get; private set; }
        public object SelectedOptionPane
        {
            get
            {
                return _selectedOptionPane;
            }
            set
            {
                _selectedOptionPane = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedOptionPane)));
            }
        }
        private object _selectedOptionPane;

        public event PropertyChangedEventHandler PropertyChanged;

        public class OptionsCategory
        {
            public OptionsCategory(object vm)
            {
                this.ViewModel = vm;
               
            }
            public object ViewModel { get; private set; }
            public string Name { get; private set; }
            public override string ToString()
            {
                return Name;
            }
        }
    }
}
