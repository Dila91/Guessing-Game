using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Guessing_Game.ViewModels
{
    public class GuessingViewModel
    {
        public GuessingViewModel()
        {
            Message = "";
            MaxAllowed = 6;
        }
        public int Guessed { get; set; }
        public string Message { get; set; }
        public int MaxAllowed { get; set; }
        public int Attempts { get; set; }
        public void CheckTheGuess(int guess, int? generated, int? attempts)
        {
            Attempts = (int)attempts;

            if (attempts <= MaxAllowed)
            {
             if (guess < generated)
                {
                    Message = "Go higher!";
                }
                else if (guess > generated)
                {
                    Message = "Go lower!";
                }
                else
                {
                    Message = "You guessed correctly! Congratulations! Reload the page to reset the values!";
                }
            }
            else
            {
                Message = "Too many attempts!";
            }
        }
    }
}
