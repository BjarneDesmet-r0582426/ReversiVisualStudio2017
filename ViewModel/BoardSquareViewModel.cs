using DataStructures;
using Model.Reversi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class BoardSquareViewModel : Observable
    {
        private Player _speler; // Wanneer getters en setters andere methodes nodig hebben moet er een private variabele aangewezen worden
        public Player speler
        {
            get { return _speler; } // alles wordt opgeslagen in _speler, onrechtstreeks wordt _speler opgeroepen
            set { _speler = value; OnPropertyChanged(nameof(speler)); }
         }
            
    
        public Vector2D Positie { get; set; } // Slaat coordinaten op 

        public BoardSquareViewModel()
        {
                
        }
    }

    
}
