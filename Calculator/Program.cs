using System;

namespace Calculator
{
    class Calculator
    {
        public static double DoOperation(double num1, double num2, string op)
        {
            // Valor padrão não é um número que usamos em uma operação, como uma divisão, podendo resultar em erro
            double result = double.NaN;

            // Usar um switch para fazer o calculo
            switch(op)
            {
                case "a":
                    result = num1 + num2;
                    break;
                case "s":
                    result = num1 - num2;
                    break;
                case "m":
                    result = num1 * num2;
                    break;
                case "d":
                    // Pede ao usuário digitar um número diferente de zero
                    if(num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    break;
                    // Retorna texto com uma entrada de dados incorreta
                default:
                    break;
            }
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            // Display exibindo calculadora basica no console
            Console.WriteLine("------------------------");
            Console.WriteLine("CALCULADORA BÁSICA EM C#");
            Console.WriteLine("------------------------");

            while(!endApp)
            {
                string numInput1 = "";
                string numInput2 = "";
                double result = 0;

                // Pedir ao usuario para digitar valor
                Console.Write("Insira um número, e pressione <enter>: ");
                numInput1 = Console.ReadLine();

                double cleanNum1 = 0;
                while(!double.TryParse(numInput1, out cleanNum1))
                {
                    Console.Write("Essa não é uma entrada válida. Digite um número inteiro: ");
                    numInput1 = Console.ReadLine();
                }

                // Pedir ao usuario para digitar outro valor
                Console.Write("Insira um número, e pressione <enter>: ");
                numInput2 = Console.ReadLine();

                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2))
                {
                    Console.Write("Essa não é uma entrada válida. Digite um número inteiro: ");
                    numInput2 = Console.ReadLine();
                }

                // Pedir para o usuário escolher um operador
                Console.WriteLine("Escolha um operador abaixo:");
                Console.WriteLine("\ta - Adicionar");
                Console.WriteLine("\ts - Subtrair");
                Console.WriteLine("\tm - Multiplicar");
                Console.WriteLine("\td - Dividir");
                Console.Write("Sua escolha: ");

                string op = Console.ReadLine();

                try
                {
                    result = Calculator.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("Esse calculo irá resultar em um erro matemático.\n");
                    }
                    else Console.WriteLine("Seu resultado: {0:0.##}\n", result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Uma exceção ocorreu tentando calcular.\n - Detalhes: " + e.Message);
                }

                Console.WriteLine("---------------------------------\n");

                // Esperar o usuário digitar antes de fechar
                Console.Write("Pressione 'n' e <enter> para fechar o aplicativo, \n ou pressione qualquer tecla e <enter> para continuar: ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n");
            }
            return;
        }
    }
}
