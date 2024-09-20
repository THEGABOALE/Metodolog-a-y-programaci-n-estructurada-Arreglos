using System;
namespace Arreglo3
{
    internal class Arreglo3
    {
        public static void Main(String[] args)
        {
            // Declaramos el arreglo 2D para almacenar las ventas (filas: productos, columnas: vendedores)
            double[,] ventas = new double[5, 4]; // 5 productos y 4 vendedores
            bool[,] ventaRegistrada = new bool[5, 4]; // Para verificar si ya se ha registrado una venta

            // Encabezado del programa
            Console.WriteLine("*************************************");
            Console.WriteLine("**     Sistema de Ventas Mensual   **");
            Console.WriteLine("*************************************\n");

            // Lectura de datos
            Console.WriteLine("Ingrese los datos de las ventas del mes pasado:");
            Console.WriteLine("(Ingrese -1 en cualquier momento para finalizar)\n");

            while (true)
            {
                // Obtener número del vendedor
                int vendedor = ObtenerNumeroValido("Ingrese el número del vendedor (1-4): ", 1, 4);
                if (vendedor == -1) break; // Salir si se ingresa -1

                // Obtener número del producto
                int producto = ObtenerNumeroValido("Ingrese el número del producto (1-5): ", 1, 5);
                if (producto == -1) break;

                // Verificar si ya se registró una venta para ese vendedor y producto
                if (ventaRegistrada[producto - 1, vendedor - 1])
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"⚠️ Ya se ha registrado una venta para el Vendedor {vendedor} y el Producto {producto}.");
                    Console.ResetColor();
                    continue; // Saltar a la siguiente iteración del bucle
                }

                // Obtener valor en dólares del producto vendido
                double monto = ObtenerMontoValido("Ingrese el monto total de las ventas para este producto: ");
                if (monto == -1) break;

                // Actualizar el total de ventas para el vendedor y el producto correspondiente
                ventas[producto - 1, vendedor - 1] += monto;

                // Marcar la venta como registrada
                ventaRegistrada[producto - 1, vendedor - 1] = true;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"✅ Venta registrada exitosamente: Vendedor {vendedor}, Producto {producto}, Monto: ${monto:F2}\n");
                Console.ResetColor();
            }

            // Mostrar los resultados en forma tabular
            Console.WriteLine("\n*************************************");
            Console.WriteLine("**     Resumen de Ventas Mensual    **");
            Console.WriteLine("*************************************\n");

            // Encabezados de la tabla
            Console.WriteLine("Producto\tVendedor 1\tVendedor 2\tVendedor 3\tVendedor 4\tTotal Producto");

            // Total por producto (suma de filas)
            double[] totalPorProducto = new double[5];

            // Total por vendedor (suma de columnas)
            double[] totalPorVendedor = new double[4];

            // Imprimir los datos por producto y vendedor
            for (int i = 0; i < 5; i++) // Iterar sobre productos (filas)
            {
                Console.Write($"Producto {i + 1}\t");

                for (int j = 0; j < 4; j++) // Iterar sobre vendedores (columnas)
                {
                    Console.Write($"{ventas[i, j]:F2}\t\t");
                    totalPorProducto[i] += ventas[i, j]; // Sumar las ventas por producto
                    totalPorVendedor[j] += ventas[i, j];  // Sumar las ventas por vendedor
                }

                // Imprimir el total de ventas por producto
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"{totalPorProducto[i]:F2}");
                Console.ResetColor();
            }

            // Imprimir el total por vendedor
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.Write("Total Vendedor\t");

            for (int j = 0; j < 4; j++)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"{totalPorVendedor[j]:F2}\t\t");
                Console.ResetColor();
            }

            Console.WriteLine("\n*************************************");
            Console.WriteLine("**   Fin del Resumen de Ventas      **");
            Console.WriteLine("*************************************");
        }

        // Función para obtener un número válido en el rango especificado
        static int ObtenerNumeroValido(string mensaje, int min, int max)
        {
            while (true)
            {
                Console.Write(mensaje);
                if (int.TryParse(Console.ReadLine(), out int resultado) && resultado >= min && resultado <= max)
                {
                    return resultado;
                }
                else if (resultado == -1)
                {
                    return -1; // Detener el ingreso de datos si se introduce -1
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Entrada no válida. Intente nuevamente.");
                Console.ResetColor();
            }
        }

        // Función para obtener una cantidad de ventas válida
        static double ObtenerMontoValido(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);
                if (double.TryParse(Console.ReadLine(), out double resultado) && resultado >= 0)
                {
                    return resultado;
                }
                else if (resultado == -1)
                {
                    return -1;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Entrada no válida. Por favor ingrese un número positivo.");
                Console.ResetColor();
            }
        }
    }
}