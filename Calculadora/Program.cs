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
            PrintMenuPrincipal();
            Console.ReadLine();
        }

        public static void PrintMenuPrincipal()
        {

            int opcion=0;
            bool salir = false;

            do
            {
                Console.WriteLine("Bienvenid@ a la calculadora de Pipo.");
                Console.WriteLine("1-. Modo manual.");
                Console.WriteLine("2-. Modo automático.");
                Console.WriteLine("0-. Salir.");

                Console.WriteLine("Escriba la opción a elegir:");

                try
                {
                    opcion = int.Parse(Console.ReadLine());

                    switch (opcion)
                    {
                        case 0:
                            Console.WriteLine("Adios!");
                            salir = true;
                            break;

                        case 1:
                            ModoManual();
                            break;

                        case 2:
                            ModoAutomatico();
                            break;

                        default:
                            Console.WriteLine("Debe seleccionar una opción");
                            break;

                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine("La opción escrita debe ser un número.");
                }
              

            } while (salir == false);

            
        }

        public static void ModoManual()
        {

            Console.WriteLine("¿Qué operación se va a hacer (+, -, /, *)?");
            string tipoOperacion = Console.ReadLine();
            double solucion = 0;

            if(tipoOperacion == "+" || tipoOperacion == "-" || tipoOperacion == "/" || tipoOperacion == "*")
            {
                string primerValor = "";
                string segundoValor = "";

                double numeroUno = 0;
                double numeroDos = 0;

                Console.WriteLine("Escriba el primer valor.");
                primerValor = Console.ReadLine();

                if(!(double.Parse(primerValor).GetType() == typeof(double)))
                {
                    Console.WriteLine("El primer valor debe ser un número.");
                    ModoManual();
                }
                else
                {
                    numeroUno = double.Parse(primerValor);
                }

                Console.WriteLine("Escriba el segundo valor.");
                segundoValor = Console.ReadLine();

                if (!(double.Parse(segundoValor).GetType() == typeof(double)))
                {
                    Console.WriteLine("El segundo valor debe ser un número.");
                    ModoManual();
                }
                else
                {
                    numeroDos = double.Parse(segundoValor);
                }

                switch (tipoOperacion)
                {
                    case "+":
                        solucion = Suma(numeroUno, numeroDos);
                        Console.WriteLine($"La suma de {numeroUno} y {numeroDos} es {solucion}\n");
                        break;

                    case "-":
                        solucion = Resta(numeroUno, numeroDos);
                        Console.WriteLine($"La resta de {numeroUno} y {numeroDos} es {solucion}\n");
                        break;

                    case "/":
                        solucion = Division(numeroUno, numeroDos);
                        Console.WriteLine($"La división de {numeroUno} y {numeroDos} es {solucion}\n");
                        break;

                    case "*":
                        solucion = Multiplicacion(numeroUno, numeroDos);
                        Console.WriteLine($"La multiplicación de {numeroUno} y {numeroDos} es {solucion}\n");
                        break;

                    default:
                        Console.WriteLine("Debe seleccionar una opción");
                        break;
                }

            }
            else
            {
                Console.WriteLine("Debe elegir un tipo de operación válido.");
                ModoManual();
            }

        }

        public static void ModoAutomatico()
        {
            Console.WriteLine("Escriba la operación a realizar. Valores permtidos(+, -, /, *, ^)");
            string operacion = Console.ReadLine();

            int indiceOperador = 0;
            char operador = ' ';
            for(int i = 0; i < operacion.Length; i++)
            {
                char caracter = operacion[i];
                if(caracter == '+' || caracter == '-' || caracter == '/' || caracter == '*' || caracter == '^' )
                {
                    indiceOperador = i;
                    operador = caracter;
                    break;
                }
            }

            string operando1 = operacion.Substring(0, indiceOperador).Trim();
            string operando2 = operacion.Substring(indiceOperador + 1).Trim();

            double numero1 = Convert.ToDouble(operando1);
            double numero2 = Convert.ToDouble(operando2);

            double solucion = 0;
            switch (operador)
            {
                case '+':
                    solucion = Suma(numero1, numero2);
                    break;
                case '-':
                    solucion = Resta(numero1, numero2);
                    break;
                case '*':
                    solucion = Multiplicacion(numero1, numero2);
                    break;
                case '/':
                    solucion = Division(numero1, numero2);
                    break;
                case '^':
                    solucion = Potencia(numero1, numero2);
                    break;
                default:
                    Console.WriteLine("Operación no reconocida.");
                    break;
            }

            Console.WriteLine("El resultado es: " + solucion);
        }

        public static double Potencia(double numero1, double numero2)
        {
            double solucion = 1;
            for (int i = 0; i < numero2; i++)
            {
                solucion *= numero1;
            }
            return solucion;
        }

        public static double Suma(double num1, double num2)
        {
            double solucion = num1 + num2;
            return solucion;
        }

        public static double Resta(double num1, double num2)
        {
            double solucion = num1 - num2;
            return solucion;
        }

        public static double Division(double num1, double num2)
        {
            double solucion = num1 / num2;
            return solucion;
        }

        public static double Multiplicacion(double num1, double num2)
        {
            double solucion = num1 * num2;
            return solucion;
        }

    }


}
