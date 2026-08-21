namespace OOP.Encapsulation { 

public class Retangulo { 
    private double comprimento;
    private double largura;
    public double area() { 
        return comprimento * largura;
    }
    public void exibir() { 
        Console.WriteLine("Área do retângulo\n");
        Console.WriteLine($"Comprimento: {comprimento}");
        Console.WriteLine($"Largura: {largura}");
        Console.WriteLine($"Área: {area()}");
    } 
    public void InformarValores(){
        Console.Write("Informe o comprimento do retângulo: ");
        comprimento = Convert.ToDouble(Console.ReadLine());
        Console.Write("Informe a largura do retângulo: ");
        largura = Convert.ToDouble(Console.ReadLine());
    }     
}


public class private_modifier { 
    static void Main(string[] args) { 
        Retangulo r = new Retangulo();
        r.InformarValores();
        r.exibir();
        Console.ReadLine();
    }
}
} 

