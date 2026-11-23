using System;

namespace BibliotecaElCarlitos.Menus
{
    internal static class Consola
    {
        public static void Pausa()
        {
            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey(true);
        }

        public static void Titulo(string texto)
        {
            Console.Clear();
            Console.WriteLine(texto);
            Console.WriteLine(new string('-', 45));
        }

        public static string LeerTexto(string prompt, bool obligatorio = true)
        {
            while (true)
            {
                Console.Write(prompt);
                string texto = (Console.ReadLine() ?? "").Trim();
                if (texto.Length > 0 || !obligatorio) return texto;
                Console.WriteLine("  El valor no puede estar vacío.");
            }
        }

        // Si "opcional" es true y se deja vacío, devuelve null (conservar valor actual).
        public static ushort? LeerAnio(string prompt, bool opcional = false)
        {
            while (true)
            {
                Console.Write(prompt);
                string texto = (Console.ReadLine() ?? "").Trim();
                if (opcional && texto.Length == 0) return null;
                if (ushort.TryParse(texto, out ushort anio) && anio > 0 && anio <= DateTime.Now.Year)
                    return anio;
                Console.WriteLine($"  Año inválido (1 - {DateTime.Now.Year}).");
            }
        }

        public static bool Confirmar(string mensaje)
        {
            Console.Write($"{mensaje} (s/n): ");
            return (Console.ReadLine() ?? "").Trim().ToLower() == "s";
        }
    }
}
