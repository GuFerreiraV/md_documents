namespace OOP.Encapsulation { 
    public class Maquina { 
        protected string model = "X001";
        protected int serial_number = 123; 
    }

    public class Computador : Maquina {
        var baseObejct = new Maquina();
        var derivadaObject = new Computador();
        
        // Erro: 'Maquina.serial_number' é inacessível devido ao seu nível de proteção
        baseObject.serial_number = 456; 
 
        // OK
        derivadaObject.serial_nu = 456;
    }
}