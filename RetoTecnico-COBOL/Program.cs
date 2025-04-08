//librerias 
//System: funcionalidades básicas (como Console.WriteLine).
//System.Collections.Generic: para usar listas genéricas (List<T>).
//System.Globalization: para especificar el formato de números al parsear (como el punto decimal).
//System.IO: para manipular archivos (File, StreamReader, etc.).
//System.Linq: para usar funciones como Where, Sum, OrderByDescending, etc.
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
// Defines la clase principal "Program" y el método Main, que es el punto de entrada de la aplicación
class Program
{
    static void Main(string[] args)
    {
        //filepath(o más precisamente, la clase Path del espacio de nombres System.IO)
        //se refiere a una cadena de texto que representa la ubicación de un archivo o
        //directorio en el sistema de archivos,
        //Obtiene la ruta completa al archivo retotecnico.csv
        //que está en el mismo directorio donde se ejecuta el programa.
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "retotecnico.csv");

        //Verifica si el archivo existe. Si no, muestra un mensaje y termina el programa con return
        if (!File.Exists(filePath))
        {
            Console.WriteLine("El archivo especificado no existe.");
            return;
        }
            //Crea una lista para guardar todas las transacciones que se van a leer del archivo.(inicializacion)
        List<Transaccion> transacciones = new List<Transaccion>();
            //Este bloque indica que el código dentro de él lanzar podría ser una excepción. 
        try
        {
             //La palabra clave usingse utiliza para crear una instancia de un objeto
            //que implementa la interfaz IDisposable(como StreamReader) y, después
            //de que el bloque usingtermina, automáticamente llama al método Dispose()
            //para liberar los recursos.Cree una instancia de StreamReaderpara
            //leer caracteres de un archivo especificado por filePath.

            //El código asegura que el objeto reader(que representa el flujo de lectura del archivo)
            //se cierra automáticamente al final del bloque using, independientemente de si el código
            //dentro del tryse ejecuta correctamente o si ocurre una excepción. 
            using (var reader = new StreamReader(filePath))
            {

                //Salta la primera línea del archivo,
                //que normalmente contiene los nombres de las columnas (Id,Tipo,Monto).
                reader.ReadLine(); // Omitir encabezado


                 //Bucle que se ejecuta mientras no se haya llegado al final del archivo. Por cada línea:
                 //Lee la línea.
                 //La divide en partes usando ,como separador.
                while (!reader.EndOfStream) //indica si se ha llegado al final del flujo de datos (stream).
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');


                    //Crea una nueva instancia de Transaccion con los datos de la línea y la agrega a la lista:
                    transacciones.Add(new Transaccion
                    {
                        Id = int.Parse(values[0]),//convierte a entero
                        Tipo = values[1].Trim(),//elimina espacios en blanco
                        Monto = decimal.Parse(values[2], CultureInfo.InvariantCulture)
                        //CultureInfo.InvariantCulture asegura que la conversión se
                        //realiza utilizando el separador decimal global (punto) y
                        //no el de la cultura local del sistema.
                    });
                }
            }
        }
           //si ocurre un error al procesar el archivo(ejm format invalido)muestra el
           //error y termina
        catch (Exception ex)
        {
            Console.WriteLine($"Error al leer el archivo: {ex.Message}");
            return;
        }

        // Calcular balance final
        //suma todos los montos de transacciones tipo"Credito"
        //le resta la suma de los debito
        decimal balanceFinal = transacciones.Where(t => t.Tipo == "Crédito").Sum(t => t.Monto)
                            - transacciones.Where(t => t.Tipo == "Débito").Sum(t => t.Monto);

        // busca la Transacción de mayor monto
        var transaccionMayorMonto = transacciones.OrderByDescending(t => t.Monto).FirstOrDefault();

        // cuenta cuantas transacciones son de tipo credito y cuantas de debito
        int creditos = transacciones.Count(t => t.Tipo == "Crédito");
        int debitos = transacciones.Count(t => t.Tipo == "Débito");

        // Imprimir reporte
        //imprime transaccion con mayor monto y num.de creditos y debitos
        //f2 formatea los decimales a 2 cifras
        Console.WriteLine("Reporte de Transacciones");
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine($"Balance Final: {balanceFinal:F2}");
        Console.WriteLine($"Transacción de Mayor Monto: ID {transaccionMayorMonto?.Id} - {transaccionMayorMonto?.Monto:F2}");
        Console.WriteLine($"Conteo de Transacciones: Crédito: {creditos} Débito: {debitos}");
    }
}
        //define la clase transaccion con 3 propiedades
        //id:identificador de la tx
        //tipo:puede ser credito o debito
        //monto:valor monetario de la tx
class Transaccion
{    //get=obtener,set=asignar
    public int Id { get; set; }
    public string Tipo { get; set; }
    public decimal Monto { get; set; }
}
