using System;

class Program
{
    static void Main()
    {
        ShowMainMenu();
    }

    static void ShowMainMenu()
    {
        sbyte opcionMenu;

        do
        {
            Console.Clear();

            Console.WriteLine("Menu Principal");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("1. Libros");
            Console.WriteLine("2. Usuarios");
            Console.WriteLine("3. Préstamos");
            Console.WriteLine("4. Búsquedas y reportes");
            Console.WriteLine("5. Guardar / Cargar datos");
            Console.WriteLine("6. Salir");
            Console.WriteLine("-----------------------------");
            Console.Write("Selecciona una opción (1-6): ");

            if (sbyte.TryParse(Console.ReadLine(), out opcionMenu))
            {
                switch (opcionMenu)
                {
                    case 1:
                        ShowBooksMenu();
                        break;
                    case 2:
                        ShowUsersMenu();
                        break;
                    case 3:
                        ShowLoansMenu();
                        break;
                    case 4:
                        ShowSearchReportsMenu();
                        break;
                    case 5:
                        ShowPersistenceMenu();
                        break;
                    case 6:
                        ConfirmExitAndSave();
                        break;
                    default:
                        Console.WriteLine("\nOpción no válida. Intenta de nuevo.");
                        Pausa();
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nOpcion invalida: Debes ingresar un numero");
                Pausa();
                opcionMenu = 0;
            }
        } while (opcionMenu != 6);
    }

    // --- MENÚ DE LIBROS ---
    static void ShowBooksMenu()
    {
        byte opcionLibro;

        do
        {
            Console.Clear();

            Console.WriteLine("1) Menú de Libros");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("1. Registrar libro");
            Console.WriteLine("2. Listar libros");
            Console.WriteLine("3. Ver detalle de libro (por ID/ISBN)");
            Console.WriteLine("4. Actualizar libro");
            Console.WriteLine("5. Eliminar libro");
            Console.WriteLine("0. Volver al menú principal");
            Console.WriteLine("-----------------------------");
            Console.Write("Selecciona una opción (0-5): ");

            if (byte.TryParse(Console.ReadLine(), out opcionLibro))
            {
                switch (opcionLibro)
                {
                    case 1:
                        Console.WriteLine("\nHas seleccionado: Registrar libro");
                        Pausa();
                        break;
                    case 2:
                        ShowListBooksMenu();
                        break;
                    case 3:
                        Console.WriteLine("\nHas seleccionado: Ver detalle de libro");
                        Pausa();
                        break;
                    case 4:
                        ShowUpdateBookMenu();
                        break;
                    case 5:
                        Console.WriteLine("\nHas seleccionado: Eliminar libro");
                        Pausa();
                        break;
                    case 0:
                        Console.WriteLine("\nVolviendo al menú principal...");
                        break;
                    default:
                        Console.WriteLine("\nOpción no válida. Intenta de nuevo.");
                        Pausa();
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nOpcion invalida: Debes ingresar un numero");
                Pausa();
                opcionLibro = 99;
            }
        } while (opcionLibro != 0);
    }

    static void ShowListBooksMenu()
    {
        byte opcionListarLibros;

        do
        {
            Console.Clear();
            Console.WriteLine("1.2) Listar Libros");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("1. Listar todos");
            Console.WriteLine("2. Listar disponibles");
            Console.WriteLine("3. Listar prestados");
            Console.WriteLine("0. Volver al menú de libros");
            Console.WriteLine("-----------------------------");
            Console.Write("Selecciona una opción (0-3): ");

            if (byte.TryParse(Console.ReadLine(), out opcionListarLibros))
            {
                switch (opcionListarLibros)
                {
                    case 1:
                        Console.WriteLine("\nListando todos los libros...");
                        Pausa();
                        break;
                    case 2:
                        Console.WriteLine("\nListando libros disponibles...");
                        Pausa();
                        break;
                    case 3:
                        Console.WriteLine("\nListando libros prestados...");
                        Pausa();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("\nOpción no válida.");
                        Pausa();
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nOpción inválida.");
                Pausa();
                opcionListarLibros = 99;
            }
        } while (opcionListarLibros != 0);
    }

    static void ShowUpdateBookMenu()
    {
        byte opcionActualizarLibro;

        do
        {
            Console.Clear();
            Console.WriteLine("1.4) Actualizar Libro");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("1. Editar título");
            Console.WriteLine("2. Editar autor");
            Console.WriteLine("3. Editar año / categoría");
            Console.WriteLine("0. Volver al menú de libros");
            Console.WriteLine("-----------------------------");
            Console.Write("Selecciona una opción (0-3): ");

            if (byte.TryParse(Console.ReadLine(), out opcionActualizarLibro))
            {
                switch (opcionActualizarLibro)
                {
                    case 1:
                        Console.WriteLine("\nEditando título del libro...");
                        Pausa();
                        break;
                    case 2:
                        Console.WriteLine("\nEditando autor del libro...");
                        Pausa();
                        break;
                    case 3:
                        Console.WriteLine("\nEditando año / categoría del libro...");
                        Pausa();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("\nOpción no válida.");
                        Pausa();
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nOpción inválida.");
                Pausa();
                opcionActualizarLibro = 99;
            }
        } while (opcionActualizarLibro != 0);
    }

    // --- MENÚ DE USUARIOS ---
    static void ShowUsersMenu()
    {
        byte opcionUsuario;

        do
        {
            Console.Clear();

            Console.WriteLine("2) Menú de Usuarios");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("1. Registrar usuario");
            Console.WriteLine("2. Listar usuarios");
            Console.WriteLine("3. Ver detalle de usuario (por ID/documento)");
            Console.WriteLine("4. Actualizar usuario");
            Console.WriteLine("5. Eliminar usuario");
            Console.WriteLine("0. Volver al menú principal");
            Console.WriteLine("-----------------------------");
            Console.Write("Selecciona una opción (0-5): ");

            if (byte.TryParse(Console.ReadLine(), out opcionUsuario))
            {
                switch (opcionUsuario)
                {
                    case 1:
                        Console.WriteLine("\nHas seleccionado: Registrar usuario");
                        Pausa();
                        break;
                    case 2:
                        Console.WriteLine("\nHas seleccionado: Listar usuarios");
                        Pausa();
                        break;
                    case 3:
                        Console.WriteLine("\nHas seleccionado: Ver detalle de usuario");
                        Pausa();
                        break;
                    case 4:
                        ShowUpdateUserMenu();
                        break;
                    case 5:
                        Console.WriteLine("\nHas seleccionado: Eliminar usuario");
                        Pausa();
                        break;
                    case 0:
                        Console.WriteLine("\nVolviendo al menú principal...");
                        break;
                    default:
                        Console.WriteLine("\nOpción no válida. Intenta de nuevo.");
                        Pausa();
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nOpcion invalida: Debes ingresar un numero");
                Pausa();
                opcionUsuario = 99;
            }
        } while (opcionUsuario != 0);
    }

    static void ShowUpdateUserMenu()
    {
        byte opcionActualizarUsuario;

        do
        {
            Console.Clear();
            Console.WriteLine("2.4) Actualizar Usuario");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("1. Editar nombre");
            Console.WriteLine("2. Editar contacto");
            Console.WriteLine("3. Activar / desactivar");
            Console.WriteLine("0. Volver al menú de usuarios");
            Console.WriteLine("-----------------------------");
            Console.Write("Selecciona una opción (0-3): ");

            if (byte.TryParse(Console.ReadLine(), out opcionActualizarUsuario))
            {
                switch (opcionActualizarUsuario)
                {
                    case 1:
                        Console.WriteLine("\nEditando nombre del usuario...");
                        Pausa();
                        break;
                    case 2:
                        Console.WriteLine("\nEditando contacto del usuario...");
                        Pausa();
                        break;
                    case 3:
                        Console.WriteLine("\nCambiando estado (Activo/Inactivo)...");
                        Pausa();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("\nOpción no válida.");
                        Pausa();
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nOpción inválida.");
                Pausa();
                opcionActualizarUsuario = 99;
            }
        } while (opcionActualizarUsuario != 0);
    }

    // --- MENÚ DE PRÉSTAMOS ---
    static void ShowLoansMenu()
    {
        byte opcionPrestamo;

        do
        {
            Console.Clear();

            Console.WriteLine("3) Menú de Préstamos");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("1. Crear préstamo");
            Console.WriteLine("2. Listar préstamos");
            Console.WriteLine("3. Ver detalle de préstamo (por ID)");
            Console.WriteLine("4. Registrar devolución");
            Console.WriteLine("5. Eliminar préstamo");
            Console.WriteLine("0. Volver al menú principal");
            Console.WriteLine("-----------------------------");
            Console.Write("Selecciona una opción (0-5): ");

            if (byte.TryParse(Console.ReadLine(), out opcionPrestamo))
            {
                switch (opcionPrestamo)
                {
                    case 1:
                        Console.WriteLine("\nHas seleccionado: Crear préstamo");
                        Pausa();
                        break;
                    case 2:
                        ShowListLoansMenu();
                        break;
                    case 3:
                        Console.WriteLine("\nHas seleccionado: Ver detalle de préstamo");
                        Pausa();
                        break;
                    case 4:
                        Console.WriteLine("\nHas seleccionado: Registrar devolución");
                        Pausa();
                        break;
                    case 5:
                        Console.WriteLine("\nHas seleccionado: Eliminar préstamo");
                        Pausa();
                        break;
                    case 0:
                        Console.WriteLine("\nVolviendo al menú principal...");
                        break;
                    default:
                        Console.WriteLine("\nOpción no válida. Intenta de nuevo.");
                        Pausa();
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nOpcion invalida: Debes ingresar un numero");
                Pausa();
                opcionPrestamo = 99;
            }
        } while (opcionPrestamo != 0);
    }

    static void ShowListLoansMenu()
    {
        byte opcionListarPrestamos;

        do
        {
            Console.Clear();
            Console.WriteLine("3.2) Listar Préstamos");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("1. Todos");
            Console.WriteLine("2. Activos");
            Console.WriteLine("3. Cerrados (devueltos)");
            Console.WriteLine("0. Volver al menú de préstamos");
            Console.WriteLine("-----------------------------");
            Console.Write("Selecciona una opción (0-3): ");

            if (byte.TryParse(Console.ReadLine(), out opcionListarPrestamos))
            {
                switch (opcionListarPrestamos)
                {
                    case 1:
                        Console.WriteLine("\nListando todos los préstamos...");
                        Pausa();
                        break;
                    case 2:
                        Console.WriteLine("\nListando préstamos activos...");
                        Pausa();
                        break;
                    case 3:
                        Console.WriteLine("\nListando préstamos cerrados...");
                        Pausa();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("\nOpción no válida.");
                        Pausa();
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nOpción inválida.");
                Pausa();
                opcionListarPrestamos = 99;
            }
        } while (opcionListarPrestamos != 0);
    }

    // --- MENÚ DE BÚSQUEDAS Y REPORTES ---
    static void ShowSearchReportsMenu()
    {
        byte opcionBusquedaReporte;

        do
        {
            Console.Clear();

            Console.WriteLine("4) Menú de Búsquedas y Reportes");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("1. Buscar libro (por título, autor, ID/ISBN, categoría)");
            Console.WriteLine("2. Buscar usuario (por nombre, ID/documento)");
            Console.WriteLine("3. Reportes");
            Console.WriteLine("0. Volver al menú principal");
            Console.WriteLine("-----------------------------");
            Console.Write("Selecciona una opción (0-3): ");

            if (byte.TryParse(Console.ReadLine(), out opcionBusquedaReporte))
            {
                switch (opcionBusquedaReporte)
                {
                    case 1:
                        Console.WriteLine("\nHas seleccionado: Buscar libro");
                        Pausa();
                        break;
                    case 2:
                        Console.WriteLine("\nHas seleccionado: Buscar usuario");
                        Pausa();
                        break;
                    case 3:
                        ShowReportsMenu();
                        break;
                    case 0:
                        Console.WriteLine("\nVolviendo al menú principal...");
                        break;
                    default:
                        Console.WriteLine("\nOpción no válida. Intenta de nuevo.");
                        Pausa();
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nOpcion invalida: Debes ingresar un numero");
                Pausa();
                opcionBusquedaReporte = 99;
            }
        } while (opcionBusquedaReporte != 0);
    }

    static void ShowReportsMenu()
    {
        byte opcionReportes;

        do
        {
            Console.Clear();
            Console.WriteLine("4.3) Menú de Reportes");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("1. Préstamos por usuario");
            Console.WriteLine("2. Préstamos por libro");
            Console.WriteLine("3. Préstamos vencidos");
            Console.WriteLine("4. Resumen general (total libros / disponibles / prestados)");
            Console.WriteLine("0. Volver al menú de búsquedas y reportes");
            Console.WriteLine("-----------------------------");
            Console.Write("Selecciona una opción (0-4): ");

            if (byte.TryParse(Console.ReadLine(), out opcionReportes))
            {
                switch (opcionReportes)
                {
                    case 1:
                        Console.WriteLine("\nGenerando reporte de préstamos por usuario...");
                        Pausa();
                        break;
                    case 2:
                        Console.WriteLine("\nGenerando reporte de préstamos por libro...");
                        Pausa();
                        break;
                    case 3:
                        Console.WriteLine("\nGenerando reporte de préstamos vencidos...");
                        Pausa();
                        break;
                    case 4:
                        Console.WriteLine("\nGenerando resumen general...");
                        Pausa();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("\nOpción no válida.");
                        Pausa();
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nOpción inválida.");
                Pausa();
                opcionReportes = 99;
            }
        } while (opcionReportes != 0);
    }

    // --- MENÚ DE GUARDAR / CARGAR DATOS ---
    static void ShowPersistenceMenu()
    {
        byte opcionPersistencia;

        do
        {
            Console.Clear();

            Console.WriteLine("5) Menú de Guardar / Cargar Datos");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("1. Guardar datos (libros, usuarios, préstamos)");
            Console.WriteLine("2. Cargar datos");
            Console.WriteLine("3. Reiniciar datos (vaciar todo)");
            Console.WriteLine("0. Volver al menú principal");
            Console.WriteLine("-----------------------------");
            Console.Write("Selecciona una opción (0-3): ");

            if (byte.TryParse(Console.ReadLine(), out opcionPersistencia))
            {
                switch (opcionPersistencia)
                {
                    case 1:
                        Console.WriteLine("\nGuardando datos...");
                        Pausa();
                        break;
                    case 2:
                        Console.WriteLine("\nCargando datos...");
                        Pausa();
                        break;
                    case 3:
                        ConfirmResetData();
                        break;
                    case 0:
                        Console.WriteLine("\nVolviendo al menú principal...");
                        break;
                    default:
                        Console.WriteLine("\nOpción no válida. Intenta de nuevo.");
                        Pausa();
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nOpcion invalida: Debes ingresar un numero");
                Pausa();
                opcionPersistencia = 99;
            }
        } while (opcionPersistencia != 0);
    }

    static void ConfirmResetData()
    {
        Console.WriteLine("\n¿Está seguro de que desea reiniciar y vaciar todos los datos? (S/N): ");
        string respuesta = Console.ReadLine()!.Trim().ToUpper();

        if (respuesta == "S")
        {
            Console.WriteLine("\nDatos reiniciados correctamente.");
        }
        else
        {
            Console.WriteLine("\nOperación cancelada.");
        }
        Pausa();
    }

    static void ConfirmExitAndSave()
    {
        Console.WriteLine("\n¿Desea guardar antes de salir? (S/N): ");
        string respuesta = Console.ReadLine()!.Trim().ToUpper();

        if (respuesta == "S")
        {
            Console.WriteLine("Guardando datos...");
        }

        Console.WriteLine("Saliendo del sistema...");
    }

    static void Pausa()
    {
        Console.WriteLine("\nPresiona cualquier tecla para continuar");
        Console.ReadKey();
    }
}