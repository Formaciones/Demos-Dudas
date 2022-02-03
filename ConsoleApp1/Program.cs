using System;
using Universidad;
using Universidad.Admon;
using Escuela;
using Alumno = Escuela.Alumno;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numeros = new int[10];
            int[,] numeros2 = new int[10,5];
            int[,,] numeros3 = new int[10,5,8];

            numeros3[5,5,4] = 30;

            Alumno[] alumnos = {
                new Alumno() { nombre = "Julian", apellidos = "Sánchez", edad = 24 },
                new Alumno() { nombre = "Borja", apellidos = "Cabeza", edad = 24 },
                new Alumno() { nombre = "Carlos", apellidos = "Sanz", edad = 24 }
            };

            //FOR es un contador
            for (int i = 0; i < alumnos.Length; i++)
            {
                Console.WriteLine($"Alumno {i}: {alumnos[i].nombre} {alumnos[i].apellidos}");
            }


            //FOREACH recorre colecciones
            foreach (var item in alumnos)
            {
                Console.WriteLine($"{item.nombre} {item.apellidos}");
            }

            bool testing = true;
            int contador = 0;
            while (testing)
            {
                Console.WriteLine($"while - Alumno {contador}: {alumnos[contador].nombre} {alumnos[contador].apellidos}");
                contador++;
                if (contador == alumnos.Length) testing = false;
            }

            testing = true;
            contador = 0;

            do 
            {
                Console.WriteLine($"do-while: {contador}");
                contador++;
                if (contador == 11) testing = false;
            } while(testing);

            Console.ReadKey();

            ///////////////////////////////////////////////////////////

            Console.Clear();

            int a = 0;
            int b = 10;
            decimal c = 1000;
            int? d = 14;
            bool e = false;

            if (b == 10)
            {
                a = 100;
            }
            else
            {
                a = 0;
            }

            if (b == 10) a = 100;
            else a = 0;

            a = b == 10 ? 100 : 0;

            /////////////////////////////////////////////////
            

            if (a == b)
            {
                //Se ejecuta si a ES IGUAL a b
            }
            else if (a > c)
            { 
                //Se ejecuta cuando a ES MAYOR de c
            }
            else
            {
                //Se ejecuta si a NO ES IGUAL a b
            }

            if (a == b)
            {
                a = 1010;
            }
            else
            {
                b = 1010;
            }

            if (a == b) a = 1010;
            else b = 1010;

            if (e == true) a = 100;
            if (e) a = 100;

            if (e == false) a = 100;
            if (!e) a = 100;


            if (a == b && b < c)
            {
                a = 1010;
            }

            if (a == b || b < c)
            {
                a = 1010;
            }

            if (a == b && (b < c || c > a))
            {
                a = 1010;
            }


            Persona persona = new Persona();
            persona.Apellidos = "Cabeza";

            persona.Edad = 28;
            Console.WriteLine($"Edad: {persona.Edad}");

            Console.ReadKey();

            ///////////////////////////////////////////////////////////////////////////

            var calculos = new Calculos(20, 20);
            calculos.Suma();
            Console.WriteLine($"Resultado: {calculos.resultado}");

            calculos.numero1 = 10;
            calculos.numero2 = 14;
            calculos.Suma();
            Console.WriteLine($"Resultado: {calculos.resultado}");

            calculos.Suma(14, 26);
            Console.WriteLine($"Resultado: {calculos.resultado}");

            calculos.Suma(14);
            Console.WriteLine($"Resultado: {calculos.resultado}");

            //bool r1 = calculos.Suma("1400", "-52");
            Console.WriteLine($"Proceso OK: {calculos.Suma("1400", "-52")}");
            Console.WriteLine($"Resultado: {calculos.resultado}");
            Console.WriteLine(" ");

            //v1 es de tipo valor
            int v1 = 89;
            Console.WriteLine($"Valor V1: {v1}");
            calculos.Suma10(v1);
            Console.WriteLine($"Valor V1: {v1}");
            calculos.Suma10(ref v1);
            Console.WriteLine($"Valor V1: {v1}");
            Console.WriteLine(" ");

            //o1 y 02 de tipo valor
            int o1 = 0;
            int o2 = 0;

            v1 = 89;

            calculos.Suma20Resta20(v1);
            calculos.Suma20Resta20(v1, out o1, out o2);
            Console.WriteLine($"Resultado Suma 20: {o1}");
            Console.WriteLine($"Resultado Resta 20: {o2}");

            Console.ReadKey();


            /////////////////////////////////////////////////////////////

            int n1 = 10;
            int? n2 = null;

            n1 = (int)n2;
            n1 = Convert.ToInt32(n2);
            n1 = Convert.ToInt32(n2 == null ? 0 : n2);
            n1 = Convert.ToInt32(n2 ?? 0);


            ///////////////////////////////////////////////////////////

            //byte a = 100;
            //int b = 50;

            ////Implicita
            //b = a;
            //Console.WriteLine($"I -> A: {a.ToString()} - B: {b.ToString()}");

            //a = 100;
            //b = 50;

            ////Explicita
            //a = (byte)b;
            //Console.WriteLine($"E -> A: {a.ToString()} - B: {b.ToString()}");

            //a = 100;
            //b = 15550;

            //a = (byte)b;
            //Console.WriteLine($"E -> A: {a.ToString()} - B: {b.ToString()}");

            ////Objeto Convert
            //a = 100;
            //b = 50;
            //a = Convert.ToByte(b);
            //Console.WriteLine($"C -> A: {a.ToString()} - B: {b.ToString()}");

            ////b = 15550;
            ////a = Convert.ToByte(b);
            ////Console.WriteLine($"C -> A: {a.ToString()} - B: {b.ToString()}");

            ////Try
            //string numero = "50";
            //a = byte.Parse(numero);
            //Console.WriteLine($"P -> A: {a.ToString()}");

            ////string numero = "15550";
            ////a = byte.Parse(numero);
            ////Console.WriteLine($"P -> A: {a.ToString()}");

            //a = 100;
            //numero = "15550";
            //bool resultado = byte.TryParse(numero, out a);
            //Console.WriteLine($"T -> A: {a.ToString()} - Resultado: {resultado}");

            //Alumno a1 = new Alumno() { nombre = "Borja" };
            //Object a2 = new Alumno() { nombre = "Borja" };

            //Alumno a3 = (Alumno)a2;
            //a3.nombre = "Borja";

            //Console.WriteLine($"Nombre: {a1.nombre}");
            //Console.WriteLine($"Nombre: {((Alumno)a2).nombre}");

            //Console.ReadKey();

            ///////////////////////////////////////////////////////////////////


            Alumno alum = new Alumno() { nombre = "Borja" };
            Estudiante estud = new Estudiante() { nombre = "Borja" };

            Console.Clear();
            Console.WriteLine($"Alumno: {alum.nombre}");
            Tools.DemoChangeAlumno(alum);
            Console.WriteLine($"Alumno: {alum.nombre}" + Environment.NewLine);

            Console.WriteLine($"Estudiante: {estud.nombre}");
            Tools.DemoChangeEstudiante(estud);
            Console.WriteLine($"Estudiante: {estud.nombre}");

            Console.ReadKey();

            ////////////////////////////////////////////////////////////



            Alumno alumno = new Alumno();
            Director director = new Director();
            

            Alumno alumno1;                 //Inicializar variable opcional
            var alumno2 = new Alumno();     //Inicializar variable es obligatorio
            Alumno alumno3 = new Alumno();
            Object alumno4 = new Alumno();
            dynamic alumno5 = new Alumno();

            //Acceso a los miembros del objeto (variable nombre).
            //alumno1.nombre = "Borja";     //Falta instanciar
            alumno2.nombre = "Borja";
            alumno3.nombre = "Borja";
            //alumno4.nombre = "Borja";     //No permite el acceso a los miembros, salvo por conversión
            alumno5.nombre = "Borja";

            Tools.DemoTypeObject(alumno);
            Tools.DemoTypeObject(director);
            Tools.DemoTypeObject("hola");
            Tools.DemoTypeObject(10);
            Tools.DemoTypeObject(alumno4);
            Tools.DemoTypeObject(alumno5);


            Tools2.nombre = "Demo";
            Tools2.DemoTypeObject("Demo");

            Tools2 tools = new Tools2();
            tools.numero = 10;

            Console.ReadKey();
        }
    }

    public static class Tools
    {
        public static void DemoTypeObject(Object obj)
        {
            Console.WriteLine($"Tipo: {obj.GetType()}");
        }

        public static void DemoChangeAlumno(Alumno a)
        {
            a.nombre = "Adrian";
            Console.WriteLine($"Alumno > {a.nombre}");
        }

        public static void DemoChangeEstudiante(Estudiante a)
        {
            a.nombre = "Adrian";
            Console.WriteLine($"Estudiante > {a.nombre}");
        }
    }

    public class Tools2
    {
        public int numero = 0;

        public static string nombre = "";
        public static void DemoTypeObject(Object obj)
        {
            Console.WriteLine($"Tipo: {obj.GetType()}");
        }
    }

    public class Calculos
    {
        public int numero1;
        public int numero2;
        private int numero3;
        public int resultado;

        public void Suma()
        {
            resultado = numero1 + numero2;
        }
        public void Suma(int n1, int n2 = 500)
        {
            numero1 = n1;
            numero2 = n2;

            Suma();
        }
        public bool Suma(string n1, string n2)
        {
            numero1 = Convert.ToInt32(n1);
            numero2 = Convert.ToInt32(n2);

            Suma();

            return true;
        }

        public void Suma10(int numero)
        {
            numero = numero + 10;
            Console.WriteLine($"val - Suma 10: {numero}");
        }

        public void Suma10(ref int numero)
        {
            numero = numero + 10;
            Console.WriteLine($"ref - Suma 10: {numero}");
        }

        public void Suma20Resta20(int numero)
        {
            Console.WriteLine($"Suma 20: {numero + 20}");
            Console.WriteLine($"Resta 20: {numero - 20}");
        }

        public bool Suma20Resta20(int numero, out int resultadosuma, out int resultadoresta)
        {
            resultadosuma = numero + 20;
            resultadoresta = numero - 20;

            return true;
        }

        //Método constructor
        public Calculos()
        {
            numero1 = 0;
            numero2 = 0;
            numero3 = 0;
        }

        public Calculos(int numero1, int numero2)
        {
            this.numero1 = numero1;
            this.numero2 = numero2;
            this.numero3 = 0;
        }

        //Método destructor o finalizador
        ~Calculos()
        { 
           
        }
    }
}

namespace Escuela
{
    public class Alumno
    {
        public string nombre;
        public string apellidos;
        public int edad;

        public Alumno()
        {
            this.nombre = "";
            this.apellidos = "";
            this.edad = 0;
        }
    }
    public struct Estudiante
    {
        public string nombre;
        public string apellidos;
        public int edad;
    }
}

namespace Universidad
{
    namespace Admon
    {
        public partial class Secretario
        {
            public string nombre;
            public string apellidos;
            public int edad;
        }
    }
    public class Alumno
    {
        public string nombre;
        public string apellidos;
        public int edad;
    }
}

namespace Universidad.Admon
{
    public class Director
    {
        public string nombre;
        public string apellidos;
        public int edad;
    }
}

