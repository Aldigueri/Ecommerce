﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models
{
    public class Categoria
    {
        public Categoria()
        {

        }

        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome da categoria é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Descrição da categoria é obrigatório.")]
        public string Descricao { get; set; }

        public virtual IList<Produto> Produtos { get; set; }

      
    }
}