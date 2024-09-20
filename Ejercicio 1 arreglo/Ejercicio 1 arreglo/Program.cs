using System;
namespace Arreglo1
{
    internal class Arreglo1
    {
        static void Main()
        {
            Random rand = new Random();
            int[] sumas = new int[13]; // Arreglo para contar las veces que aparece cada suma (índices 2 a 12)
            int tiradas = 36000;

            // Simular 36,000 tiradas de dos dados
            for (int i = 0; i < tiradas; i++)
            {
                int dado1 = rand.Next(1, 7); // Generar número entre 1 y 6 para el primer dado
                int dado2 = rand.Next(1, 7); // Generar número entre 1 y 6 para el segundo dado
                int suma = dado1 + dado2;
                sumas[suma]++;
            }

            // Imprimir resultados en formato tabular mejorado
            Console.WriteLine("Resultados de 36,000 tiradas de dos dados:");
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("{0,-6} | {1,-10} | {2,-10}", "Suma", "Frecuencia", "Porcentaje");
            Console.WriteLine(new string('-', 40));

            for (int i = 2; i <= 12; i++)
            {
                double porcentaje = (sumas[i] / (double)tiradas) * 100;
                Console.WriteLine("{0,-6} | {1,-10} | {2,-10:F2}%", i, sumas[i], porcentaje);
            }

            // Comprobar la frecuencia esperada para 7
            double porcentajeSiete = (sumas[7] / (double)tiradas) * 100;
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("El 7 apareció {0} veces, lo cual es un {1:F2}% de las tiradas.", sumas[7], porcentajeSiete);
            Console.WriteLine("Se esperaría que alrededor de una sexta parte (16.67%) de las tiradas fueran 7.");

            // Conclusión sobre la frecuencia
            Console.WriteLine(new string('-', 40));
            if (porcentajeSiete >= 15 && porcentajeSiete <= 20)
            {
                Console.WriteLine("La frecuencia del 7 es razonable.");
            }
            else
            {
                Console.WriteLine("La frecuencia del 7 es menor o mayor de lo esperado.");
            }
        }
    }
}