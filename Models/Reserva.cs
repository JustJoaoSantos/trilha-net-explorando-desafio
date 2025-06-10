namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (Suite.Capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
                Console.WriteLine("Cadastro realizado com sucesso");
            }
            else
            {
                throw new Exception("Capacidade da Suite se encontra sendo menor que quantidade requisitada de hospedes.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            if (suite.Capacidade > 0 && suite.TipoSuite != null && suite.ValorDiaria > 0)
            {
                Suite = suite;
                Console.WriteLine("Registro de Suite Realizado com sucesso");
            }
            else
            {
                throw new Exception("Um ou mais Campos possuem valores invalidos");
            }
            
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count;
        }

        public void ListarHospedes()
        {
            if (Hospedes == null)
            {
                Console.WriteLine("Nao foi Cadastrado nenhum hospede");
                return;
            }

            Console.Clear();
            Console.WriteLine("=====================================");
            Console.WriteLine("=============HOSPEDES================");
            Console.WriteLine("=====================================");
            Console.WriteLine($"Quantidade Total de Hospedes: {ObterQuantidadeHospedes()}");
            Console.WriteLine("-------------------------------------");

            for (int i = 0; i < Hospedes.Count; i++)
            {

                Console.WriteLine($"Hospede N°{i + 1}: {Hospedes[i].NomeCompleto}");

            }
            Console.WriteLine("=====================================");
        }

        public decimal CalcularValorDiaria()
        {
            decimal valor = DiasReservados * Suite.ValorDiaria;

            if (DiasReservados >= 10)
            {
                Console.WriteLine("Chegou aqui");
                valor = valor - (valor * (10M / 100M));
            }

            return valor;
        }
    }
}