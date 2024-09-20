using System;

class Program
{
    static void Main()
    {
        // Arreglo de contadores para cada rango de salario
        int[] contadores = new int[9];

        // Ventas brutas semanales para cada vendedor
        int[] ventasBrutas = { 3000, 2500, 4000, 5500, 6500, 7500, 8500, 9500, 10500, 11500 };

        // Procesa cada vendedor y su salario
        foreach (int venta in ventasBrutas)
        {
            // Calcula el salario según la comisión del 9% sobre las ventas
            int salario = (int)(200 + (venta * 0.09));

            // Determina el rango de salario correspondiente
            int rango = GetRango(salario);

            // Si el rango es válido, incrementa el contador para ese rango
            if (rango >= 0 && rango < contadores.Length)
            {
                contadores[rango]++;
            }
        }

        // Imprime los resultados en un formato tabular claro
        Console.WriteLine("***********************************************");
        Console.WriteLine(" Número de vendedores en cada rango de salario ");
        Console.WriteLine("***********************************************");
        Console.WriteLine(" Rango de salario     | Número de vendedores  ");
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine(" 1. $200-$299         | " + contadores[0]);
        Console.WriteLine(" 2. $300-$399         | " + contadores[1]);
        Console.WriteLine(" 3. $400-$499         | " + contadores[2]);
        Console.WriteLine(" 4. $500-$599         | " + contadores[3]);
        Console.WriteLine(" 5. $600-$699         | " + contadores[4]);
        Console.WriteLine(" 6. $700-$799         | " + contadores[5]);
        Console.WriteLine(" 7. $800-$899         | " + contadores[6]);
        Console.WriteLine(" 8. $900-$999         | " + contadores[7]);
        Console.WriteLine(" 9. $1000 o superior  | " + contadores[8]);
        Console.WriteLine("***********************************************");
    }

    // Método para determinar el rango de salario basado en el salario calculado
    static int GetRango(int salario)
    {
        if (salario >= 200 && salario <= 299) return 0;
        else if (salario >= 300 && salario <= 399) return 1;
        else if (salario >= 400 && salario <= 499) return 2;
        else if (salario >= 500 && salario <= 599) return 3;
        else if (salario >= 600 && salario <= 699) return 4;
        else if (salario >= 700 && salario <= 799) return 5;
        else if (salario >= 800 && salario <= 899) return 6;
        else if (salario >= 900 && salario <= 999) return 7;
        else if (salario >= 1000) return 8;
        else return -1; // Valor inválido (nunca debería ocurrir con los datos actuales)
    }
}

