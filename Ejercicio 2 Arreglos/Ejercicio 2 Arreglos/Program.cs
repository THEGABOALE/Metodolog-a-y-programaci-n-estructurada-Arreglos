using System;
namespace Arreglo2
{
    internal class Arreglo2
    {
        static void Main()
        {
            // Capacidad del avión: 10 asientos (5 de fumar y 5 de no fumar)
            bool[] smokingSeats = new bool[5];    // Asientos de fumar (1 a 5)
            bool[] nonsmokingSeats = new bool[5]; // Asientos de no fumar (6 a 10)

            // Mensaje de bienvenida al sistema de reservaciones
            Console.WriteLine("*********************************************");
            Console.WriteLine("*    Welcome to the Airline Reservation     *");
            Console.WriteLine("*********************************************\n");

            // Bucle principal del programa para realizar reservaciones
            while (true)
            {
                // Mostrar menú de opciones y solicitar una elección válida
                int choice = GetValidOption("\nPlease type 1 for 'smoking'\nPlease type 2 for 'nonsmoking'\nYour choice: ", 1, 2);
                int seatNumber = -1; // Inicializa el número de asiento como inválido

                // Si la elección es la sección de fumar
                if (choice == 1)
                {
                    // Intentar asignar un asiento en la sección de fumar
                    seatNumber = AssignSeat(smokingSeats, 1, 5);
                    if (seatNumber == -1) // Si no hay asientos disponibles
                    {
                        Console.WriteLine("\n>> Smoking section is full.");
                        // Preguntar si el usuario aceptaría un asiento en la sección de no fumar
                        if (GetYesOrNo("\nWould you like a non-smoking seat instead? (yes/no): "))
                        {
                            seatNumber = AssignSeat(nonsmokingSeats, 6, 10); // Intentar asignar un asiento en la sección de no fumar
                        }
                    }
                }
                // Si la elección es la sección de no fumar
                else if (choice == 2)
                {
                    // Intentar asignar un asiento en la sección de no fumar
                    seatNumber = AssignSeat(nonsmokingSeats, 6, 10);
                    if (seatNumber == -1) // Si no hay asientos disponibles
                    {
                        Console.WriteLine("\n>> Non-smoking section is full.");
                        // Preguntar si el usuario aceptaría un asiento en la sección de fumar
                        if (GetYesOrNo("\nWould you like a smoking seat instead? (yes/no): "))
                        {
                            seatNumber = AssignSeat(smokingSeats, 1, 5); // Intentar asignar un asiento en la sección de fumar
                        }
                    }
                }

                // Si se asigna un asiento exitosamente
                if (seatNumber != -1)
                {
                    // Mostrar pase de abordaje con el número de asiento asignado
                    Console.WriteLine("\n*********************************************");
                    Console.WriteLine($"* Your seat number is {seatNumber}.          *");
                    Console.WriteLine($"* Have a pleasant flight!                   *");
                    Console.WriteLine("*********************************************\n");
                }
                else
                {
                    // Si no hay asientos disponibles, indicar que el próximo vuelo sale en 3 horas
                    Console.WriteLine("\nNext flight leaves in 3 hours.\n");
                }

                // Preguntar si el usuario desea hacer otra reservación
                if (!GetYesOrNo("\nDo you want to make another reservation? (yes/no): "))
                {
                    break; // Salir del bucle si el usuario no quiere hacer otra reservación
                }
            }

            // Mensaje de despedida
            Console.WriteLine("\nThank you for using the Airline Reservation System. Goodbye!");
        }

        // Función para asignar un asiento en una sección dada
        // Recibe el arreglo de asientos (sección de fumar o no fumar) y los límites de los números de asiento
        static int AssignSeat(bool[] seats, int start, int end)
        {
            for (int i = 0; i < seats.Length; i++)
            {
                // Si el asiento está disponible (false), asignarlo
                if (!seats[i])
                {
                    seats[i] = true; // Marcar el asiento como ocupado
                    return start + i; // Retornar el número de asiento asignado
                }
            }
            return -1; // Retornar -1 si no hay asientos disponibles
        }

        // Función para obtener una opción válida del usuario
        // Pide un número entre un mínimo y un máximo (usado para elegir entre fumar y no fumar)
        static int GetValidOption(string message, int min, int max)
        {
            int option;
            while (true)
            {
                Console.Write(message); // Mostrar mensaje para solicitar la opción
                // Intentar convertir la entrada a un entero
                if (int.TryParse(Console.ReadLine(), out option) && option >= min && option <= max)
                {
                    return option; // Retornar la opción válida
                }
                Console.WriteLine($"\n>> Invalid input. Please enter a number between {min} and {max}.\n");
            }
        }

        // Función para obtener una respuesta sí o no del usuario
        // Se asegura que el usuario solo ingrese "yes" o "no"
        static bool GetYesOrNo(string message)
        {
            while (true)
            {
                Console.Write(message); // Mostrar mensaje para solicitar una respuesta
                string response = Console.ReadLine().ToLower(); // Leer la entrada en minúsculas
                if (response == "yes" || response == "y") // Si la respuesta es "yes" o "y"
                {
                    return true;
                }
                else if (response == "no" || response == "n") // Si la respuesta es "no" o "n"
                {
                    return false;
                }
                // Mostrar mensaje de error si la entrada no es válida
                Console.WriteLine("\n>> Invalid input. Please type 'yes' or 'no'.\n");
            }
        }
    }
}