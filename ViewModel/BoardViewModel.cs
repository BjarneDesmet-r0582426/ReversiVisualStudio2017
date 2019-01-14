using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures;
using Model.Reversi;

using Microsoft.Practices.ServiceLocation;


using ViewModel.Interfaces;


namespace ViewModel
{
    public class BoardViewModel : Observable
    {
        public List<BoardRowViewModel> Rows { set; get; }
        public ReversiGame spel { set; get; }
        public ReversiBoard bord { set; get; }
        public PutStoneCommand Command { set; get; }
        public OptionsViewModel options { get; set; }
        private int _black;
        public string playerNameOne { get; set; }
        public string playerNameTwo { get; set; }
        public int height { get; set; }
        public int width { get; set; }
        public ToEndCommand commandend { get; set; }
        //public double Milliseconds { get; set; }
        
       



        public int black
           
        {
            get { return _black; }
            set { _black = value; OnPropertyChanged(nameof(black)); }
        }

        public int _white;
        public int white
        {
            get { return _white; }
            set { _white = value; OnPropertyChanged(nameof(white)); }



        }
        
        public Player _currentPlayer { get; set; }
        public Player currentPlayer
        {
            get { return _currentPlayer; }
            set    {
                
                _currentPlayer = value; OnPropertyChanged(nameof(currentPlayer)); }
           
        }

        
        public String _currentName { get; set; }
        public String currentName
        {
            get { return _currentName; }
            set {

                System.Diagnostics.Debug.WriteLine("testNAAM");
                
                _currentName = value; OnPropertyChanged(nameof(currentName));

            }
        }


        public String getCurrentName()
        {

            if (spel.IsGameOver == false)
            {
                if (spel.CurrentPlayer.ToString().Equals("W"))
                {
                   
                    return playerNameTwo;
                }

                else if (spel.CurrentPlayer.ToString().Equals("B"))
                {
                    return playerNameOne;
                }
                else
                {
                    return "No name found";
                }
            }
            return null;
        }

        public BoardViewModel(ReversiBoard board, OptionsViewModel options)
        
        {
            
            this.spel = new ReversiGame(board.Width, board.Height);
            this.Rows = new List<BoardRowViewModel>();
            
            this.bord = board;
            this.black = bord.CountStones(Player.BLACK);
            this.white = bord.CountStones(Player.WHITE);
            this.currentPlayer = spel.CurrentPlayer;
            this.options = options;

            //timer



            var timeService = ServiceLocator.Current.GetInstance<ITimeService>();
            _start = timeService.Now;

            _timer = ServiceLocator.Current.GetInstance<ITimerService>();
            _timer.Tick += Timer_Tick;
            _timer.Start(new TimeSpan(0, 0, 0, 0, 100));

            //this.Milliseconds = modelTimer.Milliseconds;

            for (var i = 0; i < board.Height; i++)
            {

                var rij = new BoardRowViewModel(spel);

            for (var j = 0; j < board.Width; j++)
            {

                 rij.Squares[j].speler = spel.Board[new Vector2D(j, i)]; //breedte hoogte, j breedte i hoogte
                    rij.Squares[j].Positie = new Vector2D(j, i); // nu is er aan elke square een juiste positie toegekend
                }
                Rows.Add(rij);
            }

            this.Command = new PutStoneCommand(this); // heeft een board nodig dus daarom de this we gaan deze direct meegeven
            this.commandend = new ToEndCommand(options, this);
        }

        public BoardViewModel()
        {
        }


        public void updateBord() // Elke kolom wordt geselecteerd en van elk element in de kolom wordt de rij geselecteerd
        {
            
            this.bord = spel.Board;
            this.black = bord.CountStones(Player.BLACK);
            this.white = bord.CountStones(Player.WHITE);
           // this.currentPlayer = spel.CurrentPlayer;
            this.currentName = this.getCurrentName();
            

            for (var i = 0; i < spel.Board.Height; i++)
            {
                for (var j = 0; j < spel.Board.Width; j++)
                {

                    Rows[i].Squares[j].speler = spel.Board[new Vector2D(j, i)]; //breedte hoogte, j breedte i hoogte
                }
               
            }
        }

        public String getWinner()
        {
            System.Diagnostics.Debug.WriteLine(spel, "spel 1 ");

            //if (spel.
            //    spel.IsGameOver == true)
            {
                if (bord.CountStones(Player.WHITE) > bord.CountStones(Player.BLACK))
                {
                    return playerNameTwo;
                }
                else if (bord.CountStones(Player.WHITE) < bord.CountStones(Player.BLACK))
                {
                    return playerNameOne;
                }

                return "draw";
            }
            return null;
        }




        private void Timer_Tick(ITimerService obj)
        {
            var timeService = ServiceLocator.Current.GetInstance<ITimeService>();
            var timePassed = timeService.Now - _start;
            Milliseconds = Math.Round(timePassed.TotalMilliseconds / 100) * 100; // round the number of ms to the nearest 100ms
        }




        public double Milliseconds
        {
            get
            {
                return _millisec;
            }
            private set
            {
                if (_millisec != value)
                {
                    _millisec = value;
                    OnPropertyChanged(nameof(Milliseconds));
                }
            }
        }
        private double _millisec;
        private DateTimeOffset _start;
        private ITimerService _timer;

        
    }


}

