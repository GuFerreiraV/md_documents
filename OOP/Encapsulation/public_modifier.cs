using static System.Console;
namespace OOP.Encapsulation{ 

// Medindo a área de um retângulo com modificador de acesso public
public class Retangulo { 
    public double comprimento;
    public double largura;
    public double area() { 
        return comprimento * largura;
    }
    public void exibir() { 
        Console.WriteLine("Área do retângulo\n");
        Console.WriteLine($"Comprimento: {comprimento}");
        Console.WriteLine($"Largura: {largura}");
        Console.WriteLine($"Área: {area()}");
    }
}
public class public_modifier { 
    static void Main(string[] args) { 
        Retangulo r = new Retangulo();
        r.comprimento = 10;
        r.largura = 5;
        r.exibir();
        ReadLine();
    }
}
}