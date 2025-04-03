using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "retotecnico.csv");
        

        if (!File.Exists(filePath))
        {
            Console.WriteLine("El archivo especificado no existe.");
            return;
        }

        List<Transaccion> transacciones = new List<Transaccion>();

        try
        {
            using (var reader = new StreamReader(filePath))
            {
                reader.ReadLine(); // Omitir encabezado
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    transacciones.Add(new Transaccion
                    {
                        Id = int.Parse(values[0]),
                        Tipo = values[1].Trim(),
                        Monto = decimal.Parse(values[2], CultureInfo.InvariantCulture)
                    });
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al leer el archivo: {ex.Message}");
            return;
        }

        // Calcular balance final
        decimal balanceFinal = transacciones.Where(t => t.Tipo == "Crédito").Sum(t => t.Monto)
                            - transacciones.Where(t => t.Tipo == "Débito").Sum(t => t.Monto);

        // Transacción de mayor monto
        var transaccionMayorMonto = transacciones.OrderByDescending(t => t.Monto).FirstOrDefault();

        // Conteo de transacciones por tipo
        int creditos = transacciones.Count(t => t.Tipo == "Crédito");
        int debitos = transacciones.Count(t => t.Tipo == "Débito");

        // Imprimir reporte
        Console.WriteLine("Reporte de Transacciones");
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine($"Balance Final: {balanceFinal:F2}");
        Console.WriteLine($"Transacción de Mayor Monto: ID {transaccionMayorMonto?.Id} - {transaccionMayorMonto?.Monto:F2}");
        Console.WriteLine($"Conteo de Transacciones: Crédito: {creditos} Débito: {debitos}");
    }
}

class Transaccion
{
    public int Id { get; set; }
    public string Tipo { get; set; }
    public decimal Monto { get; set; }
}
