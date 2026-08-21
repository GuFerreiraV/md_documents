namespace OOP.Encapsulation
{
public class Base { 
    protected internal int value = 0;
}

public class AcessoTeste { 
    public void TestarAcesso() { 
        var baseObject = new Base();
        baseObject.value = 10; // OK: Acesso permitido dentro do mesmo assembly 
    } 
}

public class Derivada : Base { 
    static void Main(string[] args) { 
     var baseObject = new Base();
    var derivadaObject = new Derivada();

    // Error: value pode ser acessado apenas dentro da classe derivada ou no mesmo assembly
    baseObject.value = 20; 
    
    // OK: Acesso permitido dentro da classe derivada
    derivadaObject.value = 30; 
    }
}
}