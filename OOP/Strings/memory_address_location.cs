// rode 'dotnet run' dentro do diretório OOP/Strings
using System.Runtime.CompilerServices;

int x = 10; // 0xDA009E080000000A
x = 11; // 0xCA009E080000000B
int y = x; // 0xB0000000B
y = 10; // 0xB0000000A
IntPtr endereco = Unsafe.As<int, IntPtr>(ref y);

Console.WriteLine($"0x{endereco.ToInt64():X}");