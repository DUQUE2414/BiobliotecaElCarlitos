using System;
using BibliotecaElCarlitos.models;

namespace BibliotecaElCarlitos.Testing
{
public static class PooTesting
{
public static void EjecutarPruebasEvidencia()
{
Console.Clear();
Console.WriteLine("");
Console.WriteLine("DEMOSTRACIÓN DE OBJETOS Y MODELOS (POO)\n");

        // 1. Instanciación de Objetos (Libros)
        Libro libro1 = new Libro("Cien Años de Soledad", "Gabriel García Márquez", "Novela", 1967);
        Libro libro2 = new Libro("El Principito", "Antoine de Saint-Exupéry", "Infantil", 1943);

        // 2. Instanciación de Objetos (Usuarios)
        Usuario usuario1 = new Usuario("100123", "Carlos Pérez", "3001234567");
        Usuario usuario2 = new Usuario("100456", "María Gómez", "3119876543");

        // 3. Instanciación de Objetos (Préstamos)
        Prestamo prestamo1 = new Prestamo("P-001", libro1.Isbn, usuario1.Documento, usuario1.Nombre,DateTime.Now.AddDays(-10));

        //SECCIÓN 1: RESÚMENES CORTOS
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine(" 1. RESÚMENES CORTOS (MÉTODOS POO)");
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine($"[LIBRO 1]   : {libro1.ResumenCorto()}");
        Console.WriteLine($"[LIBRO 2]   : {libro2.ResumenCorto()}");
        Console.WriteLine($"[USUARIO 1] : {usuario1.ResumenCorto()}");
        Console.WriteLine($"[USUARIO 2] : {usuario2.ResumenCorto()}");
        Console.WriteLine($"[PRÉSTAMO 1]: {prestamo1.ResumenCorto()}\n");

        //DETALLES COMPLETOS Y VALIDACIONES
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine(" 2. DETALLES COMPLETOS Y VALIDACIONES ");
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine(libro1.DetalleCompleto());
        Console.WriteLine($"¿Disponible?: {libro1.EstaDisponible}\n");

        Console.WriteLine(usuario1.DetalleCompleto());
        Console.WriteLine($"¿Activo?: {usuario1.EstaActivo}\n");

        Console.WriteLine(prestamo1.DetalleCompleto());

        Console.WriteLine("\nPresione cualquier tecla para acceder al Menú Principal...");
        Console.ReadKey();
    }
}


}