﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicos
{
    public class InserirVendaDTO
    {
        public int Id { get; set; }

        public string Valor { get; set; }

        public int CodigoLivro { get; set; }

        public int CodigoFuncionario { get; set; }

    }
}
