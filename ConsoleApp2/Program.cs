using System;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s1 = new Saludo1() { Texto = "Hola Mundo !!!" };
            Console.WriteLine(s1.Texto);
            Cambiar(s1);
            Console.WriteLine(s1.Texto);

            Console.WriteLine("================================================");

            var s2 = new Saludo2() { Texto = "Hola Mundo !!!" };
            Console.WriteLine(s2.Texto);
            Cambiar(s2);
            Console.WriteLine(s2.Texto);

            Console.WriteLine("================================================");

            Console.WriteLine(s2.Texto);
            Cambiar2(ref s2);
            Console.WriteLine(s2.Texto);

        }

        static void Cambiar(dynamic obj)
        {
            obj.Texto = obj.Texto.ToUpper();
        }

        static void Cambiar2(ref Saludo2 obj)
        {
            obj.Texto = obj.Texto.ToUpper();
        }
    }

    /// <summary>
    /// Objeto de tipo Referencia
    /// </summary>
    public class Saludo1
    { 
        public string Texto { get; set; }
    }

    /// <summary>
    /// Objeto de tipo Valor
    /// </summary>
    public struct Saludo2
    {
        public string Texto { get; set; }
    }
}
