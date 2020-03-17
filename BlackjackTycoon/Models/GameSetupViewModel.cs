using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlackjackTycoon.Models
{
    public class GameSetupViewModel
    {
        [Required]
        [HiddenInput]
        public string GameName { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Playing Money")]
        public decimal PlayingMoney { get; set; }
    }
}
