using System;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {           
            try
            {
                Demo3();

                Console.WriteLine("¿ Desea contionuar ? Si/No");
                string r = Console.ReadLine();

                if (r.ToLower() == "si" || r.ToLower() == "no") Console.WriteLine($"La respuesta es {r}");
                else
                {
                    throw new Exception($"La respuesta {r} no es valida");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }

        static void Demo1()
        {
            // Las excepciones se producen:
            //  - cuando el código no se puede ejecutar
            //  - cuando se ejecuta un throw

            // Genera una excepción por código que no se puede ejecutar
            int a = 0;
            int b = 10;
            int c = b / a;

            // Genera una excepción a partir de un objeto Exception o su derivadas
            throw new Exception("Excepción creada por el programador.");
        }

        static void Demo2()
        {
            try
            {
                int a = 0;
                int b = 10;
                int c = b / a;
            }
            catch (Exception e)
            {
                Console.WriteLine("Excepción controlada desde el método Demo2");
                Console.WriteLine($"Error Demo2: {e.Message}");
            }
        }

        static void Demo3()
        {
            try
            {
                int a = 0;
                int b = 10;
                int c = b / a;
            }
            catch (Exception e)
            {
                Console.WriteLine("Excepción controlada desde el método Principal");
                throw e;
            }
        }
    }
}
