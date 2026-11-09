using System;
using BibliotecaElCarlitos.models;

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

    // --- 1. MENÚ DE LIBROS ---
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
                        RegisterBook();
                        break;
                    case 2:
                        ShowListBooksMenu();
                        break;
                    case 3:
                        ViewBookDetail();
                        break;
                    case 4:
                        UpdateBookMenu();
                        break;
                    case 5:
                        DeleteBook();
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

    static void RegisterBook()
    {
        Console.Clear();
        Console.WriteLine("1.1) Registrar Libro");

        Console.WriteLine("Ingrese el Titulo del libro que desea agregar");
        string TituloLibro = Console.ReadLine()!;

        Console.WriteLine("Ingrese el Autor del libro que desea agregar");
        string Autor = Console.ReadLine()!;

        Console.WriteLine("Ingrese la Categoria del libro que desea agregar");
        string CategoriaLibro = Console.ReadLine()!;

        Console.WriteLine("Ingrese el Año de Publicacion del libro que desea agregar");
        ushort AnioPublicacion = ushort.Parse(Console.ReadLine()!);

        Libro nuevoLibro = new Libro(TituloLibro, Autor, CategoriaLibro, AnioPublicacion);

        Console.WriteLine("\n(EXITO) Libro instanciado y creado mediante POO");
        Console.WriteLine($"\nResumen corto: {nuevoLibro.ResumenCorto()}");
        Console.WriteLine($"\nDetalle completo: {nuevoLibro.DetalleCompleto()}");

        Pausa();
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
                        ListBooksAll();
                        break;
                    case 2:
                        ListBooksAvailable();
                        break;
                    case 3:
                        ListBooksBorrowed();
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

    static void ListBooksAll()
    {
        Console.Clear();
        Console.WriteLine("--- 1.2.1 Listado de Todos los Libros ---");
        Console.WriteLine("(SIMULACIÓN) 1. ISBN: 101 | Título: Cien Años de Soledad | Autor: Gabriel García Márquez | Estado: Disponible");
        Console.WriteLine("(SIMULACIÓN) 2. ISBN: 102 | Título: El Principito | Autor: Antoine de Saint-Exupéry | Estado: Prestado");
        Pausa();
    }

    static void ListBooksAvailable()
    {
        Console.Clear();
        Console.WriteLine("--- 1.2.2 Listado de Libros Disponibles ---");
        Console.WriteLine("(SIMULACIÓN) 1. ISBN: 101 | Título: Cien Años de Soledad | Autor: Gabriel García Márquez | Estado: Disponible");
        Pausa();
    }

    static void ListBooksBorrowed()
    {
        Console.Clear();
        Console.WriteLine("--- 1.2.3 Listado de Libros Prestados ---");
        Console.WriteLine("(SIMULACIÓN) 1. ISBN: 102 | Título: El Principito | Autor: Antoine de Saint-Exupéry | Estado: Prestado");
        Pausa();
    }

    static void ViewBookDetail()
    {
        Console.Clear();
        Console.WriteLine("--- 1.3 Ver Detalle de Libro ---");
        Console.Write("Ingrese ID / ISBN del libro a consultar: ");
        string id = Console.ReadLine()!;

        Console.WriteLine($"\n(SIMULACIÓN) Detalle del libro con ID/ISBN '{id}':");
        Console.WriteLine("Título: Cien Años de Soledad");
        Console.WriteLine("Autor: Gabriel García Márquez");
        Console.WriteLine("Categoría: Novela");
        Console.WriteLine("Año: 1967");
        Console.WriteLine("Estado: Disponible");
        Pausa();
    }

    static void UpdateBookMenu()
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
                        EditBookTitle();
                        break;
                    case 2:
                        EditBookAuthor();
                        break;
                    case 3:
                        EditBookYearCategory();
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

    static void EditBookTitle()
    {
        Console.Clear();
        Console.WriteLine("--- 1.4.1 Editar Título de Libro ---");
        Console.Write("Ingrese ID/ISBN del libro: ");
        string id = Console.ReadLine()!;

        Console.Write("Ingrese el Nuevo Título: ");
        string nuevoTitulo = Console.ReadLine()!;

        Console.WriteLine($"\n(SIMULACIÓN) El título del libro '{id}' fue actualizado a: '{nuevoTitulo}'.");
        Pausa();
    }

    static void EditBookAuthor()
    {
        Console.Clear();
        Console.WriteLine("--- 1.4.2 Editar Autor de Libro ---");
        Console.Write("Ingrese ID/ISBN del libro: ");
        string id = Console.ReadLine()!;

        Console.Write("Ingrese el Nuevo Autor: ");
        string nuevoAutor = Console.ReadLine()!;

        Console.WriteLine($"\n(SIMULACIÓN) El autor del libro '{id}' fue actualizado a: '{nuevoAutor}'.");
        Pausa();
    }

    static void EditBookYearCategory()
    {
        Console.Clear();
        Console.WriteLine("--- 1.4.3 Editar Año / Categoría ---");
        Console.Write("Ingrese ID/ISBN del libro: ");
        string id = Console.ReadLine()!;

        Console.Write("Ingrese la Nueva Categoría: ");
        string nuevaCat = Console.ReadLine()!;

        Console.Write("Ingrese el Nuevo Año: ");
        string nuevoAnio = Console.ReadLine()!;

        Console.WriteLine($"\n(SIMULACIÓN) Categoría ({nuevaCat}) y Año ({nuevoAnio}) del libro '{id}' actualizados con éxito.");
        Pausa();
    }

    static void DeleteBook()
    {
        Console.Clear();
        Console.WriteLine("--- 1.5 Eliminar Libro ---");
        Console.Write("Ingrese ID/ISBN del libro a eliminar: ");
        string id = Console.ReadLine()!;

        Console.WriteLine($"\n(SIMULACIÓN) Validando si el libro '{id}' está prestado...");
        Console.WriteLine("(SIMULACIÓN) El libro no se encuentra prestado. ¡Eliminado exitosamente!");
        Pausa();
    }

    // --- 2. MENÚ DE USUARIOS ---
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
                        RegisterUser();
                        break;
                    case 2:
                        ListUsers();
                        break;
                    case 3:
                        ViewUserDetail();
                        break;
                    case 4:
                        UpdateUserMenu();
                        break;
                    case 5:
                        DeleteUser();
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

    static void RegisterUser()
    {
        Console.Clear();
        Console.WriteLine("--- 2.1 Registrar Usuario ---");

        Console.Write("Ingrese el Documento / ID del usuario: ");
        string documento = Console.ReadLine()!;

        Console.Write("Ingrese el Nombre completo del usuario: ");
        string nombre = Console.ReadLine()!;

        Console.Write("Ingrese el Contacto (Teléfono/Correo): ");
        string contacto = Console.ReadLine()!;

        Console.WriteLine($"\n(SIMULACIÓN) Usuario registrado exitosamente:");
        Console.WriteLine($"Documento: {documento} | Nombre: {nombre} | Contacto: {contacto} | Estado: Activo");
        Pausa();
    }

    static void ListUsers()
    {
        Console.Clear();
        Console.WriteLine("--- 2.2 Listado de Usuarios ---");
        Console.WriteLine("(SIMULACIÓN) 1. Doc: 100123 | Nombre: Carlos Pérez | Contacto: 3001234567 | Estado: Activo");
        Console.WriteLine("(SIMULACIÓN) 2. Doc: 100456 | Nombre: María Gómez | Contacto: 3119876543 | Estado: Activo");
        Pausa();
    }

    static void ViewUserDetail()
    {
        Console.Clear();
        Console.WriteLine("--- 2.3 Ver Detalle de Usuario ---");
        Console.Write("Ingrese el Documento / ID a consultar: ");
        string documento = Console.ReadLine()!;

        Console.WriteLine($"\n(SIMULACIÓN) Detalle del usuario con Documento '{documento}':");
        Console.WriteLine("Nombre: Carlos Pérez");
        Console.WriteLine("Contacto: 3001234567");
        Console.WriteLine("Estado: Activo");
        Console.WriteLine("Préstamos activos: 1");
        Pausa();
    }

    static void UpdateUserMenu()
    {
        byte opcionActualizarUsuario;

        do
        {
            Console.Clear();
            Console.WriteLine("2.4) Menú Actualizar Usuario");
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
                        EditUserName();
                        break;
                    case 2:
                        EditUserContact();
                        break;
                    case 3:
                        ToggleUserActiveStatus();
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

    static void EditUserName()
    {
        Console.Clear();
        Console.WriteLine("--- 2.4.1 Editar Nombre de Usuario ---");
        Console.Write("Ingrese Documento del usuario: ");
        string documento = Console.ReadLine()!;

        Console.Write("Ingrese el Nuevo Nombre: ");
        string nuevoNombre = Console.ReadLine()!;

        Console.WriteLine($"\n(SIMULACIÓN) El nombre del usuario '{documento}' fue actualizado a: '{nuevoNombre}'.");
        Pausa();
    }

    static void EditUserContact()
    {
        Console.Clear();
        Console.WriteLine("--- 2.4.2 Editar Contacto de Usuario ---");
        Console.Write("Ingrese Documento del usuario: ");
        string documento = Console.ReadLine()!;

        Console.Write("Ingrese el Nuevo Contacto: ");
        string nuevoContacto = Console.ReadLine()!;

        Console.WriteLine($"\n(SIMULACIÓN) El contacto del usuario '{documento}' fue actualizado a: '{nuevoContacto}'.");
        Pausa();
    }

    static void ToggleUserActiveStatus()
    {
        Console.Clear();
        Console.WriteLine("--- 2.4.3 Activar / Desactivar Usuario ---");
        Console.Write("Ingrese Documento del usuario: ");
        string documento = Console.ReadLine()!;

        Console.WriteLine($"\n(SIMULACIÓN) Estado del usuario '{documento}' cambiado exitosamente (Invertido: Activo <-> Inactivo).");
        Pausa();
    }

    static void DeleteUser()
    {
        Console.Clear();
        Console.WriteLine("--- 2.5 Eliminar Usuario ---");
        Console.Write("Ingrese Documento del usuario a eliminar: ");
        string documento = Console.ReadLine()!;

        Console.WriteLine($"\n(SIMULACIÓN) Validando si el usuario '{documento}' tiene préstamos activos...");
        Console.WriteLine("(SIMULACIÓN) El usuario no tiene préstamos activos. ¡Eliminado exitosamente!");
        Pausa();
    }

    // --- 3. MENÚ DE PRÉSTAMOS ---
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
                        CreateLoan();
                        break;
                    case 2:
                        ShowListLoansMenu();
                        break;
                    case 3:
                        ViewLoanDetail();
                        break;
                    case 4:
                        RegisterReturn();
                        break;
                    case 5:
                        DeleteLoan();
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

    static void CreateLoan()
    {
        Console.Clear();
        Console.WriteLine("--- 3.1 Crear Préstamo ---");

        Console.Write("Ingrese ID del Libro a prestar: ");
        string idLibro = Console.ReadLine()!;

        Console.Write("Ingrese Documento del Usuario solicitante: ");
        string docUsuario = Console.ReadLine()!;

        Console.WriteLine("\n(SIMULACIÓN) Ejecutando validaciones del sistema:");
        Console.WriteLine("- Validando que el libro exista y esté disponible...");
        Console.WriteLine("- Validando que el usuario esté activo...");
        Console.WriteLine("- Validando que el usuario no tenga préstamos vencidos...");

        Console.WriteLine($"\n(SIMULACIÓN) ¡Préstamo creado con éxito para el usuario '{docUsuario}' con el libro '{idLibro}'!");
        Pausa();
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
                        ListLoansAll();
                        break;
                    case 2:
                        ListLoansActive();
                        break;
                    case 3:
                        ListLoansClosed();
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

    static void ListLoansAll()
    {
        Console.Clear();
        Console.WriteLine("--- 3.2.1 Listado de Todos los Préstamos ---");
        Console.WriteLine("(SIMULACIÓN) Préstamo #501 | Libro: 101 | Usuario: 100123 | Estado: Activo");
        Console.WriteLine("(SIMULACIÓN) Préstamo #500 | Libro: 102 | Usuario: 100456 | Estado: Devuelto");
        Pausa();
    }

    static void ListLoansActive()
    {
        Console.Clear();
        Console.WriteLine("--- 3.2.2 Listado de Préstamos Activos ---");
        Console.WriteLine("(SIMULACIÓN) Préstamo #501 | Libro: 101 | Usuario: 100123 | Estado: Activo");
        Pausa();
    }

    static void ListLoansClosed()
    {
        Console.Clear();
        Console.WriteLine("--- 3.2.3 Listado de Préstamos Cerrados (Devueltos) ---");
        Console.WriteLine("(SIMULACIÓN) Préstamo #500 | Libro: 102 | Usuario: 100456 | Estado: Devuelto");
        Pausa();
    }

    static void ViewLoanDetail()
    {
        Console.Clear();
        Console.WriteLine("--- 3.3 Ver Detalle de Préstamo ---");
        Console.Write("Ingrese ID del Préstamo a consultar: ");
        string idPrestamo = Console.ReadLine()!;

        Console.WriteLine($"\n(SIMULACIÓN) Detalle del préstamo ID '{idPrestamo}':");
        Console.WriteLine("Libro: Cien Años de Soledad (ISBN: 101)");
        Console.WriteLine("Usuario: Carlos Pérez (Doc: 100123)");
        Console.WriteLine("Fecha de Préstamo: 2026-03-01");
        Console.WriteLine("Fecha de Devolución estimada: 2026-03-15");
        Console.WriteLine("Estado: Activo");
        Pausa();
    }

    static void RegisterReturn()
    {
        Console.Clear();
        Console.WriteLine("--- 3.4 Registrar Devolución de Préstamo ---");
        Console.Write("Ingrese ID del Préstamo a devolver: ");
        string idPrestamo = Console.ReadLine()!;

        Console.WriteLine($"\n(SIMULACIÓN) Procesando devolución del préstamo ID '{idPrestamo}'...");
        Console.WriteLine("(SIMULACIÓN) Préstamo marcado como 'Cerrado/Devuelto'.");
        Console.WriteLine("(SIMULACIÓN) El libro asociado ha cambiado su estado a 'Disponible'.");
        Pausa();
    }

    static void DeleteLoan()
    {
        Console.Clear();
        Console.WriteLine("--- 3.5 Eliminar Préstamo ---");
        Console.Write("Ingrese ID del Préstamo a eliminar del registro: ");
        string idPrestamo = Console.ReadLine()!;

        Console.WriteLine($"\n(SIMULACIÓN) Validando que el préstamo ID '{idPrestamo}' esté cerrado y auditado...");
        Console.WriteLine("(SIMULACIÓN) Registro de préstamo eliminado exitosamente del historial de consola.");
        Pausa();
    }

    // --- 4. MENÚ DE BÚSQUEDAS Y REPORTES ---
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
                        SearchBook();
                        break;
                    case 2:
                        SearchUser();
                        break;
                    case 3:
                        ReportsMenu();
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

    static void SearchBook()
    {
        Console.Clear();
        Console.WriteLine("--- 4.1 Buscar Libro ---");
        Console.Write("Ingrese criterio de búsqueda (Título, Autor, ID/ISBN o Categoría): ");
        string criterio = Console.ReadLine()!;

        Console.WriteLine($"\n(SIMULACIÓN) Buscando coincidencias para '{criterio}'...");
        Console.WriteLine("(SIMULACIÓN) Resultado encontrado:");
        Console.WriteLine("- ISBN: 101 | Título: Cien Años de Soledad | Autor: Gabriel García Márquez | Cat: Novela | Estado: Disponible");
        Pausa();
    }

    static void SearchUser()
    {
        Console.Clear();
        Console.WriteLine("--- 4.2 Buscar Usuario ---");
        Console.Write("Ingrese criterio de búsqueda (Nombre o Documento/ID): ");
        string criterio = Console.ReadLine()!;

        Console.WriteLine($"\n(SIMULACIÓN) Buscando coincidencias para '{criterio}'...");
        Console.WriteLine("(SIMULACIÓN) Resultado encontrado:");
        Console.WriteLine("- Doc: 100123 | Nombre: Carlos Pérez | Contacto: 3001234567 | Estado: Activo");
        Pausa();
    }

    static void ReportsMenu()
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
                        ReportByUser();
                        break;
                    case 2:
                        ReportByBook();
                        break;
                    case 3:
                        ReportOverdue();
                        break;
                    case 4:
                        ReportSummary();
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

    static void ReportByUser()
    {
        Console.Clear();
        Console.WriteLine("--- Reporte: Préstamos por Usuario ---");
        Console.Write("Ingrese documento del usuario: ");
        string doc = Console.ReadLine()!;

        Console.WriteLine($"\n(SIMULACIÓN) Generando historial de préstamos para el usuario '{doc}':");
        Console.WriteLine("- Préstamo #501 | Libro: Cien Años de Soledad | Fecha: 2026-03-01 | Estado: Activo");
        Pausa();
    }

    static void ReportByBook()
    {
        Console.Clear();
        Console.WriteLine("--- Reporte: Préstamos por Libro ---");
        Console.Write("Ingrese ISBN o ID del libro: ");
        string isbn = Console.ReadLine()!;

        Console.WriteLine($"\n(SIMULACIÓN) Generando historial de circulación para el libro '{isbn}':");
        Console.WriteLine("- Veces prestado en total: 4");
        Console.WriteLine("- Último prestatario: Carlos Pérez (Doc: 100123)");
        Pausa();
    }

    static void ReportOverdue()
    {
        Console.Clear();
        Console.WriteLine("--- Reporte: Préstamos Vencidos ---");
        Console.WriteLine("(SIMULACIÓN) Buscando préstamos cuya fecha límite ya expiró...");
        Console.WriteLine("(SIMULACIÓN) Se encontraron 0 préstamos vencidos actualmente.");
        Pausa();
    }

    static void ReportSummary()
    {
        Console.Clear();
        Console.WriteLine("--- Reporte: Resumen General del Sistema ---");
        Console.WriteLine("(SIMULACIÓN) Estadísticas actuales de la biblioteca:");
        Console.WriteLine("- Total de libros registrados: 15");
        Console.WriteLine("- Libros disponibles: 12");
        Console.WriteLine("- Libros prestados: 3");
        Console.WriteLine("- Total de usuarios activos: 8");
        Console.WriteLine("- Préstamos activos totales: 3");
        Pausa();
    }

    // --- 5. MENÚ DE GUARDAR / CARGAR DATOS ---
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
                        SaveData();
                        break;
                    case 2:
                        LoadData();
                        break;
                    case 3:
                        ResetData();
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

    static void SaveData()
    {
        Console.Clear();
        Console.WriteLine("--- 5.1 Guardar Datos ---");
        Console.WriteLine("(SIMULACIÓN) Serializando colecciones de libros, usuarios y préstamos...");
        Console.WriteLine("(SIMULACIÓN) Guardando información en archivos de texto/JSON simulados...");
        Console.WriteLine("(SIMULACIÓN) ¡Datos guardados exitosamente en disco!");
        Pausa();
    }

    static void LoadData()
    {
        Console.Clear();
        Console.WriteLine("--- 5.2 Cargar Datos ---");
        Console.WriteLine("(SIMULACIÓN) Leyendo archivos de almacenamiento simulados...");
        Console.WriteLine("(SIMULACIÓN) Cargando registros de libros, usuarios y préstamos...");
        Console.WriteLine("(SIMULACIÓN) ¡Datos cargados exitosamente al sistema!");
        Pausa();
    }

    static void ResetData()
    {
        Console.Clear();
        Console.WriteLine("--- 5.3 Reiniciar Datos ---");
        Console.Write("¿Está seguro de que desea reiniciar y vaciar todos los datos? (S/N): ");
        string respuesta = Console.ReadLine()!.Trim().ToUpper();

        if (respuesta == "S")
        {
            Console.WriteLine("\n(SIMULACIÓN) Limpiando memorias, colecciones y registros...");
            Console.WriteLine("(SIMULACIÓN) Datos reiniciados correctamente.");
        }
        else
        {
            Console.WriteLine("\nOperación cancelada.");
        }
        Pausa();
    }

    // --- 6. FLUJO DE SALIDA ---
    static void ConfirmExitAndSave()
    {
        Console.Clear();
        Console.WriteLine("--- 6. Salir del Sistema ---");
        Console.Write("¿Desea guardar antes de salir? (S/N): ");
        string respuesta = Console.ReadLine()!.Trim().ToUpper();

        if (respuesta == "S")
        {
            Console.WriteLine("\n(SIMULACIÓN) Guardando datos pendientes...");
            Console.WriteLine("(SIMULACIÓN) Datos guardados con éxito.");
        }

        Console.WriteLine("\nSaliendo del sistema. ¡Hasta pronto!");
    }

    static void Pausa()
    {
        Console.WriteLine("\nPresiona cualquier tecla para continuar");
        Console.ReadKey();
    }
}