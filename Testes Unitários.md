# Testes Unitários

## Sumário

[Fundamentos](##Fundamentos)
[Estruturas](#Estruturas)
[Tipos de testes](#Tiposdetestes)
[Mocks e Isolamento](#Mocks)

## Fundamentos

---
## Estruturas
### Padrão AAA
- **Arrange (Organizar)**: Setup do ambiente de testes, criação de objetos, variáveis e instâncias de classes que serão testadas.
- **Act (Agir)**: Aonde o método que estamos testando será executado. 
- **Assert (Asserir)**: Parte final do teste em que comparamos o que esperamos que aconteça com o resultado real da execução do método de teste.

---
## Tipos de testes
### `[Fact]`
O atributo `[Fact]` serve para indicar que um método é um **teste unitário** que **não recebe parâmetros** e que deve **sempre** **retornar um valor verdadeiro**, independente do cenário externo. 
#### Exemplo
- Abaixo queremos provar que o resultado da soma, a partir do método `somar()`, da classe `Calculadora`, é **5**.
```csharp
// Criando teste unitário invariante.

// class a ser testada
public class Calculadora
{
    public int somar(int a, int b)
    {
        return a + b;
    }
}

// classe de teste
public class UnitTest1
{
    [Fact]
    public void Test1()
    {
    // Arrange
    var calc = new Calculadora();
    int a = 2;
    int b = 3;
    int expectedResult = 5; 

    // Act
    int result = calc.somar(a, b);
    
    // Assert
    Assert.Equal(expectedResult, result);
    }
}
```
### `[Theory]`
O atributo `[Theory]` é utilizado para criar **testes unitários parametrizados**, permitindo executar o mesmo código de teste múltiplas vezes com diferentes conjuntos de dados de entrada. 
#### Exemplo
```csharp
// class a ser testada
public class Calculadora
{
    public int somar(int a, int b)
    {
        return a + b;
    }
}
// A notação InlineData é usado para já definir valor estáticos para testes.
[Theory]
[InlineData(2, 3, 5)]
[InlineData(-1, -1, -2)]
[InlineData(0, 5, 5)]
public void Test1(int a, int b, int expectedResult)
{
   // Arrange
   var calc = new Calculadora();
   // Act
   int result = calc.somar(a, b);
   // Assert
   Assert.Equal(expectedResult, result);
}
```
## Mocks e Isolamento
Mocks são objetos simulados que imitam o comportamento de dependências reais (Banco e Apis). usamos mocks para isolar certos comportamentos.
> O framework **Moq** é famoso na linguagem C# para tal objetivo. 
#### Exemplo
```csharp
public interface ILoggerService
{
    void Logar(string message);
}

public class Calculadora
{
    private readonly ILoggerService _logger;
    public Calculadora (ILoggerService logger)
    {
        _logger = logger;
    }
    public int somar(int a, int b)
    {
        int result = a + b;
        _logger.Logar($"Soma: {a} + {b} = {result}");
        return result;
    }
}

[Fact]
public void Test1()
{
    // Arrange
    ILoggerService logger = new Mock<ILoggerService>().Object;
    var calc = new Calculadora(logger);
    int a = 2;
    int b = 3;
    int expectedResult = 5; 
    // Act
    int result = calc.somar(a, b);
    // Assert
    Assert.Equal(expectedResult, result);
}
```
---
##### Referências
- [Unit Testing in C#](https://docs.educationsmediagroup.com/unit-testing-csharp)