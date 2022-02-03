using ConsoleApp3.Models;
using System;
using System.Linq;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ModelNorthwind context = new ModelNorthwind();

            /////////////////////////////////////////////////////////////////////////
            // Eliminar información
            /////////////////////////////////////////////////////////////////////////

            // 1. Posición en el registro
            var delRegion = (from r in context.Regions
                            where r.RegionID == 10
                            select r).FirstOrDefault();

            Console.WriteLine(context.Entry(delRegion).State);

            // 2. Eliminar el registro de la colección
            context.Regions.Remove(delRegion);

            Console.WriteLine(context.Entry(delRegion).State);

            // 3. Grabar cambios en la base de datos
            context.SaveChanges();

            Console.ReadKey();


            /////////////////////////////////////////////////////////////////////////
            // Modificar información
            /////////////////////////////////////////////////////////////////////////

            // 1. Instanciar el objeto que vamos a insertar
            Region region2 = new Region();
            region2.RegionID = 10;
            region2.RegionDescription = "Este de España";

            context.Entry(region2).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

            Console.ReadKey();

            /////////////////////////////////////////////////////////////////////////

            // 1. Posición en el registro
            var miRegion = (from r in context.Regions
                           where r.RegionID == 10
                           select r).FirstOrDefault();

            Console.WriteLine(context.Entry(miRegion).State);

            // 2. Cambio valores de sus propiedades
            miRegion.RegionDescription = "Sur de España";
            Console.WriteLine(context.Entry(miRegion).State);

            // 3. Grabar cambios en la base de datos
            context.SaveChanges();

            Console.ReadKey();

            /////////////////////////////////////////////////////////////////////////
            //Insertar información
            /////////////////////////////////////////////////////////////////////////

            // 1. Instanciar el objeto que vamos a insertar
            Region region = new Region();
            region.RegionID = 10;
            region.RegionDescription = "Norte de España";

            // 2. Añadir el objeto a la colección
            context.Regions.Add(region);

            // 3. Grabar cambios en la base de datos
            context.SaveChanges();



            /////////////////////////////////////////////////////////////////////////
            // Leer información
            /////////////////////////////////////////////////////////////////////////

            var resultado = context.Employees
                .Where(r => r.Country == "USA")
                .OrderBy(r => r.LastName)
                .ThenBy(r => r.FirstName)
                .Select(r => r)
                .ToList();

            var resultado1 = (from r in context.Employees
                             where r.Country == "USA"
                             orderby r.LastName, r.FirstName
                             select r).ToList();

            foreach (var item in resultado1) Console.WriteLine($"{item.EmployeeID} {item.LastName} {item.FirstName}");
        }
    }
}
