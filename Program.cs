using System;

class Program
{
    struct Libro
    {
        public int Codigo;
        public string Titulo;
        public string ISBN;
        public string Edicion;
        public string Autor;
    }

    static Libro[] biblioteca = new Libro[100];
    static int cantidadLibros = 0;

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Gestión de Libros");
            Console.WriteLine("1. Agregar un libro");
            Console.WriteLine("2. Mostrar listado de libros");
            Console.WriteLine("3. Buscar libro por código");
            Console.WriteLine("4. Editar información de un libro por código");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out int opcion))
            {
                Console.WriteLine("Opción no válida. Intente de nuevo.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    AgregarLibro();
                    break;
                case 2:
                    MostrarListadoDeLibros();
                    break;
                case 3:
                    BuscarLibroPorCodigo();
                    break;
                case 4:
                    EditarLibroPorCodigo();
                    break;
                case 5:
                    return;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }

    static void AgregarLibro()
    {
        if (cantidadLibros < biblioteca.Length)
        {
            Console.Write("Ingrese el código del libro: ");
            if (!int.TryParse(Console.ReadLine(), out int codigo))
            {
                Console.WriteLine("Código no válido.");
                return;
            }

            Console.Write("Ingrese el título del libro: ");
            string titulo = Console.ReadLine();

            Console.Write("Ingrese el ISBN del libro: ");
            string isbn = Console.ReadLine();

            Console.Write("Ingrese la edición del libro: ");
            string edicion = Console.ReadLine();

            Console.Write("Ingrese el autor del libro: ");
            string autor = Console.ReadLine();

            biblioteca[cantidadLibros].Codigo = codigo;
            biblioteca[cantidadLibros].Titulo = titulo;
            biblioteca[cantidadLibros].ISBN = isbn;
            biblioteca[cantidadLibros].Edicion = edicion;
            biblioteca[cantidadLibros].Autor = autor;

            cantidadLibros++;
            Console.WriteLine("Libro agregado exitosamente.");
        }
        else
        {
            Console.WriteLine("La biblioteca está llena. No se pueden agregar más libros.");
        }
    }

    static void MostrarListadoDeLibros()
    {
        if (cantidadLibros > 0)
        {
            Console.WriteLine("Listado de Libros:");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("| Código | Título           | ISBN          | Edición | Autor           |");
            Console.WriteLine("--------------------------------------------------");

            for (int i = 0; i < cantidadLibros; i++)
            {
                Console.WriteLine($"| {biblioteca[i].Codigo,7} | {biblioteca[i].Titulo,-17} | {biblioteca[i].ISBN,-13} | {biblioteca[i].Edicion,-8} | {biblioteca[i].Autor,-17} |");
            }

            Console.WriteLine("--------------------------------------------------");
        }
        else
        {
            Console.WriteLine("No hay libros en la biblioteca.");
        }
    }

    static void BuscarLibroPorCodigo()
    {
        Console.Write("Ingrese el código del libro que desea buscar: ");
        if (!int.TryParse(Console.ReadLine(), out int codigo))
        {
            Console.WriteLine("Código no válido.");
            return;
        }

        bool encontrado = false;
        for (int i = 0; i < cantidadLibros; i++)
        {
            if (biblioteca[i].Codigo == codigo)
            {
                Console.WriteLine("Libro encontrado:");
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("| Código | Título           | ISBN          | Edición | Autor           |");
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine($"| {biblioteca[i].Codigo,7} | {biblioteca[i].Titulo,-17} | {biblioteca[i].ISBN,-13} | {biblioteca[i].Edicion,-8} | {biblioteca[i].Autor,-17} |");
                Console.WriteLine("--------------------------------------------------");
                encontrado = true;
                break;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("Libro no encontrado.");
        }
    }

    static void EditarLibroPorCodigo()
    {
        Console.Write("Ingrese el código del libro que desea editar: ");
        if (!int.TryParse(Console.ReadLine(), out int codigo))
        {
            Console.WriteLine("Código no válido.");
            return;
        }

        bool encontrado = false;
        for (int i = 0; i < cantidadLibros; i++)
        {
            if (biblioteca[i].Codigo == codigo)
            {
                Console.WriteLine("Libro encontrado. Ingrese los nuevos datos:");
                Console.Write("Nuevo título: ");
                string nuevoTitulo = Console.ReadLine();

                Console.Write("Nuevo ISBN: ");
                string nuevoISBN = Console.ReadLine();

                Console.Write("Nueva edición: ");
                string nuevaEdicion = Console.ReadLine();

                Console.Write("Nuevo autor: ");
                string nuevoAutor = Console.ReadLine();

                biblioteca[i].Titulo = nuevoTitulo;
                biblioteca[i].ISBN = nuevoISBN;
                biblioteca[i].Edicion = nuevaEdicion;
                biblioteca[i].Autor = nuevoAutor;

                Console.WriteLine("Libro editado exitosamente.");
                encontrado = true;
                break;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("Libro no encontrado.");
        }
    }
}