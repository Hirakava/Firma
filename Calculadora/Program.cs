using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    class Program
    {     

        static void Main(string[] args)
        {
            

            int NovoCal=1;

            while (NovoCal == 1)
            {
                double num1, num2;
                Inicio:
                Console.WriteLine("");
                Console.WriteLine("Digite primeiro valor e pressione <ENTER>");
                
                while (!Double.TryParse(Console.ReadLine(), out num1))
                {
                    Console.WriteLine("");
                    Console.WriteLine("Valor Invalido");
                    Console.WriteLine("");
                    goto Inicio;                    
                }
                
                {                    
                    Segundo:
                    Console.WriteLine("");
                    Console.WriteLine("Digite segundo valor e pressione <ENTER>");
                    while (!Double.TryParse(Console.ReadLine(), out num2))
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Valor Invalido");
                        Console.WriteLine("");
                        goto Segundo;
                    }
                }                         
                          
               
                Console.WriteLine("");
                Console.WriteLine("Digite a Operação Desejada e pressione <ENTER>");
                Console.WriteLine("");
                Console.WriteLine("\ta...............Adição");
                Console.WriteLine("\ts...............Subtração");
                Console.WriteLine("\tm...............Multiplicação");
                Console.WriteLine("\td...............Divisão");
                Console.WriteLine("\tc...............Cancelar");
                Console.WriteLine("");


                switch (Console.ReadLine())
                {
                    case "a":
                        Console.WriteLine("");
                        Console.WriteLine($" Resultado: {num1} + {num2} = " + (num1 + num2));
                        break;
                    case "s":
                        Console.WriteLine("");
                        Console.WriteLine($" Resultado: {num1} - {num2} = " + (num1 - num2));
                        break;
                    case "m":
                        Console.WriteLine("");
                        Console.WriteLine($" Resultado: {num1} * {num2} = " + (num1 * num2));
                        break;
                    case "d":
                        Console.WriteLine("");
                        Console.WriteLine($" Resultado: {num1} / {num2} = " + (num1 / num2));
                        if (num1 == 0 || num2==0)
                        {
                            Console.WriteLine("Digite valor diferente de Zero: ");
                            goto Inicio;
                        }
                        break;
                    case "c":
                        Console.WriteLine("");
                        Console.WriteLine(" Operação Cancelada.");
                        break;

                }


                Console.WriteLine("");
                Console.WriteLine(" Permanecer na  Calculadora ? ( 1 - SIM | 2 - NÃO )");                
                Console.WriteLine("");
                NovoCal = int.Parse(Console.ReadLine());
                Console.Clear();
                //Console.ReadKey();
            }
        }
    }
}
