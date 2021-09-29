using System;
using DIO.Series;

namespace DIO.Series.Console
{
    class Program
    {
        static SeriesRepositorio repositorio = new SeriesRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsusario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        System.Console.Clear();
                        break;
                    default:
                        throw new ArgumentException("Opção inválida");
                }
                opcaoUsuario = ObterOpcaoUsusario();
            }
        }

        private static void ListarSeries()
        {
            System.Console.WriteLine("Listando Séries");
            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                System.Console.WriteLine("Nenhuma série cadastrada");
                return;
            }

            foreach (var serie in lista)
            {
                if (!serie.RetornaExcluido())
                {
                    System.Console.WriteLine("#ID {0} : - {1}", serie.retornaId(), serie.retornaTitulo());
                }
            }
        }

        private static void InserirSerie()
        {
            System.Console.WriteLine("Inserir nova série ");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            System.Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(System.Console.ReadLine());

            System.Console.Write("Digite o título da série: ");
            string entradaTitulo = System.Console.ReadLine();

            System.Console.Write("Digite o ano de inicio da série: ");
            int entradaAno = int.Parse(System.Console.ReadLine());

            System.Console.Write("Digite a descrição da série: ");
            string entradaDescricao = System.Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.Insere(novaSerie);
            System.Console.Write("Serie adicionada com sucesso!");
        }

        private static void AtualizarSerie()
        {
            System.Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(System.Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            System.Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(System.Console.ReadLine());

            System.Console.Write("Digite o título da série: ");
            string entradaTitulo = System.Console.ReadLine();

            System.Console.Write("Digite o ano de inicio da série: ");
            int entradaAno = int.Parse(System.Console.ReadLine());

            System.Console.Write("Digite a descrição da série: ");
            string entradaDescricao = System.Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.Atualiza(indiceSerie, atualizaSerie);
            System.Console.Write("Serie atualizada com sucesso!");
        }

        private static void ExcluirSerie()
        {
            System.Console.WriteLine("Digite o id da série que deseja excluir: ");
            int indiceSerie = int.Parse(System.Console.ReadLine());
            repositorio.Exclui(indiceSerie);
        }

        private static void VisualizarSerie()
        {
            System.Console.WriteLine("Digite o id da série que deseja visualizar: ");
            int indiceSerie = int.Parse(System.Console.ReadLine());
            var serie = repositorio.retornaPorId(indiceSerie);
            System.Console.WriteLine(serie);
        }


        public static string ObterOpcaoUsusario()
        {
            System.Console.WriteLine("");
            System.Console.WriteLine("Bem vindo! ");
            System.Console.WriteLine("Digite a opção desejada:");
            System.Console.WriteLine("1 - Listar series");
            System.Console.WriteLine("2 - Adicionar serie");
            System.Console.WriteLine("3 - Atualizar serie");
            System.Console.WriteLine("4 - Remover serie");
            System.Console.WriteLine("5 - Visualizar serie");
            System.Console.WriteLine("C - Limpar Tela");
            System.Console.WriteLine("X - Sair");
            System.Console.WriteLine("");

            string opcaoUsuario = System.Console.ReadLine().ToUpper();
            System.Console.WriteLine("");
            return opcaoUsuario;
        }


    }
}
