using DataStructures;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class PutStoneCommand : ICommand
    {
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

        public BoardViewModel Bord { get; set; }

        public PutStoneCommand(BoardViewModel bordview)
        {
            this.Bord = bordview;
        }

        public bool CanExecute(object parameter) // kan het uitgevoerd worden of niet, hier moeten voorwaarden in
        {
            
            return Bord.spel.IsValidMove((Vector2D)parameter); // casten naar vector2D en kijken of het een valid move is 
        }

        public void Execute(object parameter) // wat er gebeurt wanneer men op de knop zelf klikt
        {
            Debug.WriteLine("qsdklfjqsmfjdqsmkldf");
            Bord.spel = Bord.spel.PutStone((Vector2D)parameter);
            Bord.updateBord();   
        }
    }
}
