﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pindorama.Models
{
    public class Imagem
    {
        [Key]
        public int Id { get; set; }

        public string LinkImagem { get; set; }

        public int GameId { get; set; }

        public Game Game { get; set; }
    }
}
