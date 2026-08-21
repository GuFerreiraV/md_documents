namespace OOP.Encapsulation { 

    public class Retangulo { 
        private double comprimento;
        private double largura;

        public double Comprimento { 
            get { return comprimento; }
            set { if(value < 0) { 
                throw new ArgumentException("Valor de comprimento não pode ser menor do que zero.");
            }else{
                comprimento = value;
            }}
        }
        public double Largura { 
            get { return largura; }
            set { if(value < 0) { 
                throw new ArgumentException("Valor de largura não pode ser menor do que zero.");
            }else{
                largura = value;
            }}
        }
        public double area() { 
            return comprimento * largura;
        }
    }
    public class getters_and_setters { 
        static void Main(string[] args) {
            var r = new Retangulo();
            try{
                Console.Write("Informe o comprimento do retângulo: ");
                r.Comprimento = Convert.ToDouble(Console.ReadLine());
                Console.Write("Informe a largura do retângulo: ");
                r.Largura = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine($"Área do retângulo: {r.area()}");
            }catch(ArgumentException e){
                Console.WriteLine(e.Message);
            }
        }
    }

}