using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();
            if (!ValidarPlaca(placa))
            {
                Console.WriteLine($"A placa do veículo digitada ({placa}) é invalida");
                return;
            }

            veiculos.Add(FormatarPlaca(placa));

        }

        private string FormatarPlaca(string placa)
        {
            return placa.Replace("-", "").Trim().ToUpper(); ;
        }

        private bool ValidarPlaca(string placa)
        {
            if (string.IsNullOrWhiteSpace(placa)) { return false; }

            if (placa.Length > 8 || placa.Length < 6) { return false; }

            placa = placa.Replace("-", "").Trim();

            if (char.IsLetter(placa, 4))
            {

                Regex padraoMercosul = new Regex("[a-zA-Z]{3}[0-9]{1}[a-zA-Z]{1}[0-9]{2}");
                return padraoMercosul.IsMatch(placa);
            }

            Regex padraoNormal = new Regex("[a-zA-Z]{3}[0-9]{4}");
            return padraoNormal.IsMatch(placa);

        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // *IMPLEMENTE AQUI*
            string placa = FormatarPlaca(Console.ReadLine());

            // Verifica se o veículo existe
            if (!veiculos.Any(x => x == placa))
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                return;
            }

            Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

            // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
            // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
            // *IMPLEMENTE AQUI*
            int horas = Convert.ToInt32(Console.ReadLine());
            decimal valorTotal = precoInicial + (precoPorHora * horas);

            // TODO: Remover a placa digitada da lista de veículos
            // *IMPLEMENTE AQUI*

            veiculos.Remove(placa);

            Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: {valorTotal:C}");

        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (!veiculos.Any())
            {
                Console.WriteLine("Não há veículos estacionados.");
            }

            Console.WriteLine("Os veículos estacionados são:");

            foreach (var item in veiculos)
            {
                Console.WriteLine(item);
            }

        }
    }
}
