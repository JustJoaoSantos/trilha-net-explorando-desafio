using System.Diagnostics;
using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();

//Pessoa p1 = new Pessoa(nome: "Hóspede 1");
//Pessoa p2 = new Pessoa(nome: "Hóspede 2");

//hospedes.Add(p1);
//hospedes.Add(p2);

// Cria a suíte
//Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);

// Cria uma nova reserva, passando a suíte e os hóspedes
Reserva reserva = new Reserva();
//reserva.CadastrarSuite(suite);
//reserva.CadastrarHospedes(hospedes);

// Exibe a quantidade de hóspedes e o valor da diária
//Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
//Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");

//reserva.ListarHospedes();

bool exit = false;
while (!exit)
{
    Console.Clear();
    Console.WriteLine("=====================================");
    Console.WriteLine("===============MENU==================");
    Console.WriteLine("=====================================");

   
    Console.WriteLine("[1] Para Reservar uma Suite");
    Console.WriteLine("[2] Para Registrar um Hospede");
    Console.WriteLine("[3] Para Registrar os Dias da Reserva");
    Console.WriteLine("[4] Para Listar Hospedes na Reserva");
    Console.WriteLine("[5] Para Verificar o Valor Total da Diaria");
    Console.Write    ("[0] Para encerrar o Programa\n> ");

    switch (Console.ReadLine())
    {
        case "1":
            Console.Clear();
            Console.WriteLine("=====================================");
            Console.WriteLine("========= CADASTRO DE SUITE =========");
            Console.WriteLine("=====================================");

            Console.Write("Digite o Tipo:\n> ");
            string tipo = Console.ReadLine();

            Console.Write("Digite a Capacidade Desejada:\n> ");
            int capacidade = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o Valor diario Desejado:\n> ");
            decimal valorDiario = Convert.ToDecimal(Console.ReadLine());

            Suite suite = new Suite(tipo, capacidade, valorDiario);

            try
            {
                reserva.CadastrarSuite(suite);

            }
            catch (Exception ex)
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine(ex.Message);
                Console.WriteLine("----------------------------------");
            }

            break;

        case "2":
            Console.Clear();
            Console.WriteLine("=====================================");
            Console.WriteLine("======== CADASTRO DE HOSPEDE ========");
            Console.WriteLine("=====================================");

            Console.Write("Digite o Nome:\n> ");
            string nome = Console.ReadLine();

            Console.Write("Digite o Sobrenome:\n> ");
            string sobrenome = Console.ReadLine();

            hospedes.Add(new Pessoa(nome, sobrenome));

            try
            {
                reserva.CadastrarHospedes(hospedes);
            }
            catch (Exception ex)
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine(ex.Message);
                Console.WriteLine("----------------------------------");
            }
            break;

        case "3":
            Console.Clear();
            Console.WriteLine("=====================================");
            Console.WriteLine("======== CADASTRO DE RESERVA ========");
            Console.WriteLine("=====================================");

            Console.Write("Digite a Quantidades de dia a ser reservado:\n> ");
            int dias = Convert.ToInt32(Console.ReadLine());
            reserva.DiasReservados = dias;
            Console.WriteLine("Reserva realizada com sucesso");
            break;

        case "4":
            reserva.ListarHospedes();
            break;

        case "5":
            Console.Clear();
            Console.WriteLine("=====================================");
            Console.WriteLine("============ VALOR TOTAL ============");
            Console.WriteLine("=====================================");
           
            Console.WriteLine($" Valor Total: {reserva.CalcularValorDiaria():C}");

            Console.WriteLine("=====================================");

            break;
            
        case "0":
            Console.WriteLine("Encerrando Programa, Obrigado Pela Participacao!");
            exit = true;
            break;

        default:
            Console.WriteLine("Selecao invalida, Tente novamente");
            break;
    }
    
    Console.Write("\nDigite para continuar\n> ");
    Console.ReadLine();
}