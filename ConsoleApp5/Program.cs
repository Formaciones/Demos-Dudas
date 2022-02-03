using System;
using System.Net.Http;
using System.Linq;
using Newtonsoft.Json;
using System.Text;

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Comunicación a través del protocolo HTTP (Microservicios APIRest)
            // Intercambio de mensaje con HEAD y BODY
            // Las HEADERS son un conjuento de KEY/VALUE    -> Content-Type (especifica el tipo del contenido del BODY)
            //                                                  * text/plain * text/json * text/xml * text/html
            //                                                  * application/json  * application/xml
            //                                                  * multipart/form-data * application/x-www-form-urlencoded

            // CRUD
            //      GET     -   Lectura     SELECT
            //      POST    -   Insertar    INSERT
            //      PUT     -   Modificar   UPDATE
            //      DELETE  -   Borrar      DELETE

            Get();
            
        }

        static void Delete()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://school.labs.com.es/api/");

            // DELETE: /students/61

            // 1. Llamada y recivimos el mensaje de respuesta
            var response = client.DeleteAsync("students/61").Result;

            // 2. Comprobamos que estado de las respuesta es NoContent = HTTP 203 o OK = HTTP 200
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                // 3. Leer el contenido del BODY
                string content = response.Content.ReadAsStringAsync().Result;

                // 4. Desealización del contenido, transformamos el JSON en Objetos
                var item = JsonConvert.DeserializeObject<dynamic>(content);
                Console.WriteLine($"Eliminado -> {item.id} {item.firstName} {item.lastName}");
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                // 3. Mostrar mensaje generico
                Console.WriteLine($"Registro eliminado correctamente.");
            }
            else Console.WriteLine($"Código de estado: {response.StatusCode}");
        }

        static void Put()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://school.labs.com.es/api/");

            //  PUT: /students/61

            // 1. Instanciar estudiante y asignar valores a sus propiedades
            //var student = new Student();
            var student = new { id = 61, firstName = "José Antonio", lastName = "Amarilla", dateOfBirth = "1989-01-01", classId = 2 };

            // 2. Preparar el BODY del mensaje
            var objJSON = JsonConvert.SerializeObject(student);
            var content = new StringContent(objJSON, Encoding.UTF8, "application/json");

            // 3. Llamada y recivimos el mensaje de respuesta
            var response = client.PutAsync("students/61", content).Result;

            // 4. Comprobamos que estado de las respuesta es NoContent = HTTP 204 o OK = HTTP 200
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                //El BODY no suele contener datos, pintamos un mensaje generico
                Console.WriteLine("Registro modificado correctamente.");
            }
            else Console.WriteLine($"Código de estado: {response.StatusCode}");
        }

        static void Post()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://school.labs.com.es/api/");

            //  POST: /students

            // 1. Instanciar estudiante y asignar valores a sus propiedades
            //var student = new Student();
            var student2 = new { id = 0, firstName = "José Luis", lastName = "Amarilla", dateOfBirth = "1989-01-01", classId = 2 };

            // 2. Preparar el BODY del mensaje
            var objJSON = JsonConvert.SerializeObject(student2);
            var content = new StringContent(objJSON, Encoding.UTF8, "application/json");

            // 3. Llamada y recivimos el mensaje de respuesta
            var response = client.PostAsync("students", content).Result;

            // 4. Comprobamos que estado de las respuesta es Created = HTTP 201 o OK = HTTP 200
            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                // 5. Leer el contenido del BODY
                string content2 = response.Content.ReadAsStringAsync().Result;

                // 6. Desealización del contenido, transformamos el JSON en Objetos
                var item = JsonConvert.DeserializeObject<dynamic>(content2);
                Console.WriteLine($"{item.id} {item.firstName} {item.lastName}");

            }
            else Console.WriteLine($"Código de estado: {response.StatusCode}");
        }

        static void Get()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://school.labs.com.es/api/");

            // GET: /students
            // GET: /students/1

            // 1. Llamada y recivimos el mensaje de respuesta
            var response = client.GetAsync("students").Result;

            // 2. Comprobamos que estado de las respuesta es OK = HTTP 200
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                // 3. Leer el contenido de HEAD, opcional
                Console.WriteLine($"Content-Type: {response.Content.Headers.ContentType.MediaType}");
                foreach (var item in response.Headers.ToList())
                {
                    Console.WriteLine($"{item.Key}: {item.Value.FirstOrDefault()}");
                }
                Console.WriteLine();

                // 4. Leer el contenido del BODY
                string content = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(content);
                Console.WriteLine();

                // 5. Desealización del contenido, transformamos el JSON en Objetos
                var students = JsonConvert.DeserializeObject<dynamic>(content);
                foreach (var student in students) Console.WriteLine($"{student.id} {student.firstName} {student.lastName}");

            }
            else Console.WriteLine($"Código de estado: {response.StatusCode}");
        }
    }
}
