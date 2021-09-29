﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIO.Series.Web
{
    public class SerieModel
    {
        public int Id { get; set; }
        public Genero Genero { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int Ano { get; set; }
        public bool Excluido { get; set; }


        public SerieModel() { }

        public SerieModel(Serie serie)
        {
            Id = serie.retornaId();
            Genero = serie.RetornaGenero();
            Titulo = serie.retornaTitulo();
            Descricao = serie.RetornaDescricao();
            Ano = serie.RetornaAno();
            Excluido = serie.RetornaExcluido();
        }

        public Serie ToSerie()
        {
            return new Serie(Id, Genero, Titulo, Descricao, Ano);
        }
        

    }
}