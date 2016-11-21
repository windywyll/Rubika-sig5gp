﻿using CardBattle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardBattle
{
    public class TournamentOrganiser
    {
        private readonly List<IPlayer> _players;
        private readonly CardDealer _dealer;
        private List<int> _scores;
        public IEnumerable<int> Scores
        {
            get
            {
                return _scores.AsEnumerable();
            }
        }

        public int HandSize { get; set; }

        public int GamesNumber { get; set; }

        private int PlayersCount
        {
            get
            {
                return _players.Count;
            }
        }

        public TournamentOrganiser(IEnumerable<IPlayer> players, CardDealer dealer)
        {
            _players = players.ToList();
            _dealer = dealer;

            _scores = new List<int>(players.Select(p => 0));

            HandSize = 5;
            GamesNumber = 100;
        }

        public void PlayTournament()
        {
            for (var i = 0; i < PlayersCount; i++)
            {
                _players[i].Initialize(PlayersCount, i);
            }

            for (var i = 0; i < GamesNumber; i++)
            {
                PlayGame();
            }

            var winnerIndex = _scores.IndexOf(_scores.Max());
            var winner = _players[winnerIndex];

            Console.WriteLine("Player " + winner.Name + " from " + winner.Author + " at position " + winnerIndex + " won the tournament.");
    }

        public void PlayGame()
        {
            var game = new Game(_dealer, _players, HandSize);

            var winnerIndex = game.PlayGame();

            _scores[winnerIndex]++;

            var winner = _players[winnerIndex];
            Console.WriteLine("Player " + winner.Name + " from " + winner.Author + " at position " + winnerIndex + " won the game.");
        }
    }
}
