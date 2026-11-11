# Sistema de Gestión de Biblioteca (ADSO) - Consola en C#

Este proyecto consiste en un prototipo funcional y simulado de un Sistema de Gestión de Biblioteca desarrollado en C# (.NET) para la consola. Su diseño aplica estándares de arquitectura modular, navegación estructurada, validaciones numéricas estrictas y control de versiones bajo la metodología Git Flow.

---

## Características del Sistema

El sistema cuenta con 5 módulos principales simulados por consola y una sección de salida con confirmación de guardado:

* **1. Módulo de Libros**:
  * Registro de libros con ISBN, Título, Categoría y Año de publicación.
  * Submenú de listados (Todos los libros, Disponibles y Prestados).
  * Consulta de detalle por código/ISBN.
  * Submenú de actualización (Editar título, editar autor, editar año/categoría).
  * Eliminación con simulación de verificación de préstamos activos.

* **2. Módulo de Usuarios**:
  * Registro de usuarios con documento/ID, nombre y contacto.
  * Listado de usuarios registrados.
  * Detalle de usuario por documento.
  * Submenú de actualización (Nombre, contacto y alternado de estado Activo/Inactivo).
  * Eliminación segura (valida que no tenga préstamos pendientes).

* **3. Módulo de Préstamos**:
  * Creación de préstamo incorporando el nombre y documento del usuario, con simulación de validaciones (existencia del libro, estado activo del usuario, sin sanciones).
  * Submenú de listados (Todos, Activos y Cerrados/Devueltos).
  * Detalle de préstamo por ID.
  * Registro de devolución con cambio de estado de libro a 'Disponible'.
  * Eliminación de historial de préstamo.

* **4. Módulo de Búsquedas y Reportes**:
  * Búsqueda de libros por múltiples criterios (título, autor, ISBN o categoría).
  * Búsqueda de usuarios por nombre o documento.
  * Submenú de reportes (Préstamos por usuario, por libro, vencidos y resumen general).

* **5. Módulo de Guardar / Cargar (Persistencia)**:
  * Simulación de serialización y almacenamiento de colecciones a disco.
  * Carga simulada de archivos.
  * Reinicio de datos con confirmación explícita (S/N).

* **6. Flujo de Salida**:
  * Confirmación explícita antes de cerrar la aplicación para guardar datos pendientes (S/N).

---

## Arquitectura y Estructura del Proyecto

El código fuente está organizado bajo una arquitectura modular desacoplada en directorios independientes:

```text
BibliotecaElCarlitos/
└── Bioblioteca/
    ├── Menus/
    │   ├── MenuLibros.cs
    │   ├── MenuPersistencia.cs
    │   ├── MenuPrestamos.cs
    │   ├── MenuReportes.cs
    │   └── MenuUsuarios.cs
    ├── models/
    │   ├── EstadoPrestamo.cs
    │   ├── Libros.cs
    │   ├── Prestamo.cs
    │   └── Usuario.cs
    ├── Testing/
    │   └── PooTesting.cs
    ├── Program.cs
    └── Bioblioteca.csproj
```

1. **Separación de Responsabilidades**:
   * Los modelos de dominio (`Libro`, `Usuario`, `Prestamo`, `EstadoPrestamo`) residen en `models/`, bajo el namespace `BibliotecaElCarlitos.models`.
   * La lógica de interfaz de consola reside en `Menus/`, bajo el namespace `BibliotecaElCarlitos.Menus`.
   * Las pruebas de POO residen en `Testing/`.
   * `Program.cs` solo contiene el punto de entrada, la demostración de objetos y el menú principal.

2. **Menús como clases `public static`**:
   Cada módulo expone un único punto de entrada (`ShowBooksMenu()`, `ShowUsersMenu()`, `ShowLoansMenu()`, `ShowSearchReportsMenu()`, `ShowPersistenceMenu()`) y mantiene sus métodos auxiliares como `private static`. Esto evita código monolítico en `Main()`.

3. **Navegación Jerárquica `do-while`**:
   Cada menú y submenú funciona dentro de su propio bucle de control, permitiendo retornar al menú padre ingresando la opción `0`.

4. **Validaciones anti-cuelgue (`TryParse`)**:
   Para prevenir excepciones no controladas como `FormatException` u `OverflowException`, todas las lecturas de menú utilizan `byte.TryParse`. Si el usuario ingresa texto, símbolos o un número fuera de rango, el sistema muestra "Opción inválida" y solicita el reintento.

---

## Estrategia de Ramificación (Git Flow)

Para mantener un historial limpio y modular, se implementó el flujo de trabajo Git Flow:

* **`main`**: Rama de producción con la versión estable y lista para entrega.
* **`develop`**: Rama base para la integración de todas las funcionalidades desarrolladas.
* **`feature/*`**: Ramas independientes creadas a partir de `develop` para construir cada módulo específico y luego fusionarlas (`git merge`).

---

## Historial Detallado de Ramas, Funciones e Integración

Cada rama `feature/*` contuvo un conjunto de funciones específicas para garantizar la modularidad del código antes de realizar el merge hacia `develop`.

> **Nota:** en las ramas originales las funciones se desarrollaron dentro de `Program.cs`. Posteriormente se refactorizaron a la estructura modular actual: cada módulo pasó a su propio archivo en `Menus/` y los modelos a `models/`.

### 1. Rama `feature/books-menu`
Funciones integradas en esta rama (hoy en `Menus/MenuLibros.cs`):
* `ShowBooksMenu()`
* `RegisterBook()`
* `ShowListBooksMenu()`
* `ListBooksAll()`
* `ListBooksAvailable()`
* `ListBooksBorrowed()`
* `ViewBookDetail()`
* `UpdateBookMenu()`
* `EditBookTitle()`
* `EditBookAuthor()`
* `EditBookYearCategory()`
* `DeleteBook()`

Comandos Git ejecutados:
```bash
git checkout -b feature/books-menu
git add Program.cs
git commit -m "feat: implementar módulo de libros con submenús y simulación en consola"
git checkout develop
git pull origin develop
git merge feature/books-menu
git push origin develop
```

---

### 2. Rama `feature/users-menu`
Funciones integradas en esta rama (hoy en `Menus/MenuUsuarios.cs`):
* `ShowUsersMenu()`
* `RegisterUser()`
* `ListUsers()`
* `ViewUserDetail()`
* `UpdateUserMenu()`
* `EditUserName()`
* `EditUserContact()`
* `ToggleUserActiveStatus()`
* `DeleteUser()`

Comandos Git ejecutados:
```bash
git checkout -b feature/users-menu
git add Program.cs
git commit -m "feat: implementar módulo de usuarios con submenús y simulación en consola"
git checkout develop
git pull origin develop
git merge feature/users-menu
git push origin develop
```

---

### 3. Rama `feature/loans-menu`
Funciones integradas en esta rama (hoy en `Menus/MenuPrestamos.cs`):
* `ShowLoansMenu()`
* `CreateLoan()`
* `ShowListLoansMenu()`
* `ListLoansAll()`
* `ListLoansActive()`
* `ListLoansClosed()`
* `ViewLoanDetail()`
* `RegisterReturn()`
* `DeleteLoan()`

Comandos Git ejecutados:
```bash
git checkout -b feature/loans-menu
git add Program.cs
git commit -m "feat: implementar módulo de préstamos con submenús, validaciones y simulación en consola"
git checkout develop
git pull origin develop
git merge feature/loans-menu
git push origin develop
```

---

### 4. Rama `feature/search-reports-menu`
Funciones integradas en esta rama (hoy en `Menus/MenuReportes.cs`):
* `ShowSearchReportsMenu()`
* `SearchBook()`
* `SearchUser()`
* `ReportsMenu()`
* `ReportByUser()`
* `ReportByBook()`
* `ReportOverdue()`
* `ReportSummary()`

Comandos Git ejecutados:
```bash
git checkout -b feature/search-reports-menu
git add Program.cs
git commit -m "feat: implementar módulo de búsquedas y reportes con simulación en consola"
git checkout develop
git pull origin develop
git merge feature/search-reports-menu
git push origin develop
```

---

### 5. Rama `feature/persistence-menu`
Funciones integradas en esta rama (hoy en `Menus/MenuPersistencia.cs`):
* `ShowPersistenceMenu()`
* `SaveData()`
* `LoadData()`
* `ResetData()`

Comandos Git ejecutados:
```bash
git checkout -b feature/persistence-menu
git add Program.cs
git commit -m "feat: implementar módulo de guardar y cargar datos con simulación en consola"
git checkout develop
git pull origin develop
git merge feature/persistence-menu
git push origin develop
```

---

### 6. Rama `feature/exit-flow` y Cierre de Producción
Funciones integradas en esta rama:
* `ConfirmExitAndSave()`

Comandos Git ejecutados para la finalización e integración a `develop`:
```bash
git checkout -b feature/exit-flow
git add Program.cs
git commit -m "feat: implementar flujo de salida con confirmación de guardado"
git checkout develop
git pull origin develop
git merge feature/exit-flow
git push origin develop
```

---

## Guía de Instalación y Ejecución

### Requisitos previos

* .NET SDK 10.0 o superior instalado.
* Consola de comandos (PowerShell, Git Bash o CMD).

### Pasos para ejecutar

1. Clonar el repositorio y ubicarse en la rama de desarrollo:
   ```bash
   git clone <URL_DEL_REPOSITORIO>
   cd BibliotecaElCarlitos
   git checkout develop
   ```

2. Entrar a la carpeta del proyecto (donde está el archivo `.csproj`):
   ```bash
   cd Bioblioteca
   ```

3. Compilar y ejecutar la aplicación:
   ```bash
   dotnet run
   ```

---

## Validación de Evidencias de Aprendizaje (SENA)

| Criterio de Evidencia | Estado | Implementación en el Proyecto |
| --- | --- | --- |
| **Ramas `feature/*` creadas y fusionadas** | Cumplido | Ramas `feature/books-menu`, `users-menu`, `loans-menu`, `search-reports-menu`, `persistence-menu` y `exit-flow` integradas a `develop`. |
| **Historial de Commits Claro** | Cumplido | Mensajes con la convención `feat: ...` especificando la función agregada en cada paso, y commits de refactorización para la modularización. |
| **Ramas Base `develop`** | Cumplido | Estrategia de integración continua en `develop`. |
| **Modularización por Carpetas** | Cumplido | Separación limpia entre `models`, `Menus` y `Testing` con sus respectivos namespaces. |
| **Navegación completa a Submenús** | Cumplido | Arquitectura modular con invocación de métodos `public static` desde el menú principal. |
| **Opción de Retorno al Menú Anterior** | Cumplido | Opción `0` presente en todos los submenús operados por ciclos `do-while`. |
| **Confirmación de Acciones Sensibles** | Cumplido | Petición `(S/N)` en las funciones de reinicio y salida del sistema. |
| **Validación de Entradas (`TryParse`)** | Cumplido | Prevención de excepciones en consolas interactivas mediante `byte.TryParse` en todos los menús. |
