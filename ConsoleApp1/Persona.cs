using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Persona
    {
        //Equivalente a una variable pública
        //Necesita de un variable privada
        //Y se puede simplificar mendiante: public string Nombre { get; set; }

        //Variable privada
        private string nombre;

        //Propiedad pública
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }


        //Equivalente a una variable pública
        //No necesita una variable privada
        public string Apellidos { get; set; }



        //Variable privada
        private int edad;

        //Propiedad pública
        public int Edad
        {
            get { return edad; }
            set 
            {
                if (value < 0) edad = 0;
                else if (value > 125) edad = 0;
                else edad = value; 
            }
        }

        //Los métodos son equivalentes al uso de propiedades
        //pero de una forma menos estándar y más compleja
        public int GetEdad()
        {
            return edad;
        }
        public void SetEdad(int edad)
        {
            if (edad < 0) this.edad = 0;
            else if (edad > 125) this.edad = 0;
            else this.edad = edad;
        }

        public Persona()
        {
            this.nombre = "";
            this.Apellidos = "";
            this.edad = 0;
        }
    }
}
