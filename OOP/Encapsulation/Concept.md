# O que é Encapsulamento

> Encapsulamento é o princípio de controlar o acesso ao estado e aos detalhes internos de um objeto, expondo apenas as operações necessárias para utilizá-lo corretamente.

O encapsulamento fornece uma maneira de preservar a integridade do estado dos dados. Ao invés de definir campos públicos devemos definir campos de dados privados.

A classe bem encapsulada deve ocultar seus dados e os detalhes de implementação do mundo exterior. Isso é denominado programação caixa preta. Usando o encapsulamento, a implementação do método pode ser alterada pelo autor da classe sem quebrar qualquer código existente fazendo uso dela.

Um modificador de acesso define o escopo e a visibilidade de um membro da classe. A linguagem C# suporta os seguintes modificadores de acesso: 

- Public
- Private
- Protected
- Internal
- Protected Internal.

## Modificador de acesso Público
Este modificador permite que uma classe exponha suas variáveis de membros e funções de membros a outras funções e objetos. Qualquer membro público pode ser acessado de fora da classe.

Exemplo em: [Calculando a área de um retângulo](public_modifier.cs).

No exemplo acima, definimos as variáveis e os métodos da classe `Retangulo` como `public` (por padrão, no C#, variáveis são definidas como `private` e métodos como `internal`), logo, elas são acessíveis em todo o projeto.  

## Modificador de acesso Private
Se modificarmos o código exemplicado acima, como por exemplo, privando as variáveis comprimento e largura: 
```csharp
// Antes
public double comprimento;
public double largura;
// Depois
private double comprimento;
private double largura;
``` 
As variáveis não serão mais acessíveis a partir de outra classe, porém, conseguimos retornar os valores de ambas as variáveis a partir de um método público. Exemplo: [Usando modificadores privados](private_modifier.cs).
Essa implementação é mais robusta pois oculta o valor dos campos largura e comprimento permitindo que eles sejam acessados somente pelo método `InformaValores()`.

## Métodos de acesso
Podemos melhorar o código definindo duas propriedades públicas: `Comprimento` e `Largura` que permitem acessar o valor dos campos comprimento e largura.

Na definição das propriedades podemos incluir uma lógica não permitindo que valores menores que zero sejam incluídos, se isso ocorrer lançamos uma exceção.

Removemos também o método `Exibir()` da classe Retangulo que estava com a responsabilidade de exibir o resultado e usava para isso recursos da interface do usuário.

Métodos de acesso são importantes para validar dados antes de qualquer alteração, responsáveis por permitir que uma propriedade possa ser incrementada ou somente lida. **De forma geral eles especificam o nível de acesso de uma propriedade.**

Segue exemplo: [Introduzindo getters e setters](getters_and_setters.cs).

Outro exemplo mostra o uso de dois dos métodos, `get` e `set`, enquanto o `get` executa quando a propriedade é lida e é responsável por retornar um valor do mesmo tipo da propriedade, o `set` executa quando a propriedade recebe algum valor.
```csharp

public string Funcionario 
{ 
    get; 
    
    set { 
        if(!string.IsNullOrEmpty(value)){
            field = value;
        }
    }
} = "Animador de funeral"
```

## Modificador de acesso Protected
Este modificador permite que um membro(método, variável, propriedade,...) possa ser acessado apenas pela sua própria classe ou por classes herdadas (derivadas).

Podemos acessar um membro protegido de uma classe base em uma classe herdada somente se o acesso ocorrer por meio do tipo de classe herdada. Por exemplo: [Classe base e derivada](protected_modifier.cs)

## Modificador de acesso Internal
Este modificador restringe o membro de acesso dentro do mesmo assembly (projeto/DLL), independente de haver herança.
Exemplificaremos este modificador a partir do seguinte cenário: 
Nosso sistema possui dois projetos: 

`GatewayPagamento.dll (Biblioteca)`: Contém a lógica de comunicação financeira.

`LojaVirtual.exe (Console/Web App)`: O aplicativo principal que o cliente final interage.

No código de bilioteca usaremos o `internal` para garantir que o cálculo real da taxa e a descriptografia do cartão fiquem isolados, impedindo que o desenvolvedor do aplicativo web manipule ou quebre essas regras por acidente. 

Já no código do nosso aplicativo faremos a referência ao DLL. Veja o exemplo completo:
[Modificador internal](internal_modifier.cs)  

## Modificador de acesso Protected Internal
Este modificador permite você acessar membos internos à partir do assembly (projeto/dll) atual ou de classes derivadas.

Qualquer tipo dentro do assembly que contém pode acessar um membro interno protegido de uma classe base. Uma classe derivada localizada em outro assembly só poderá acessar o membro se o acesso ocorrer por meio de uma variável do tipo de classe derivada.

Exemplo em [Mesclando protected com internal](protected_internal_modifier.cs)  
