namespace OOP.Encapsulation { 
    namespace GatewayPagamento { 
        public class ProcessarPagamento { 
        public void Processar(decimal valor, string cartaoCriptografado) { 
            // Lógica para processar o pagamento
            var validador = new ValidadorInterno();
            if(validador.ValidarCartao(cartaoCriptografado)){ 
                decimal taxa = CalculadoraTaxas.Calcular(valor);
                decimal valorFinal = valor + taxa;
                Console.WriteLine($"Pagamento processado com sucesso! Valor final: {valorFinal}");
            }
        }

        // classe interna
        internal class ValidadorInterno { 
            internal bool ValidarCartao(string token) { 
                Console.WriteLine("Descriptografando token em ambiente seguro...");
                return token.StartsWith("TOKEN_");
            }
        }
        // outra classe interna
        internal static class CalculadoraTaxas { 
            internal static decimal Calcular(decimal valor) { 
                // Regra de negócio interna da empresa de cartões
                return valor * 0.25m; // 25% de taxa
            }
        }
        } 
    }
    
    namespace LojaVirtual { 
        using GatewayPagamento;
        public class Checkout { 
            static void Main(string[] args) { 
                var processador = new ProcessarPagamento();
                processador.Processar(100.00m, "TOKEN_123456"); // OK
                
                // Erro: 'ProcessarPagamento.CalculadoraTaxas' é inacessível devido ao seu nível de proteção
                // decimal taxa = ProcessarPagamento.CalculadoraTaxas.Calcular(100.00m); 
        }
        }
    }
}
