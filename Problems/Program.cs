using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the problem number (e.g., 001, 002):");
        string input = Console.ReadLine(); // User input for the problem number

        // Dynamically generate the class name
        string className = "Problem" + input;

        try
        {
            // Get the class type from the current assembly
            Type? type = Type.GetType(className);

            if (type != null)
            {
                // Get the Solve method from the class
                var method = type.GetMethod("Solve");

                if (method != null)
                {
                    // Execute the method
                    method.Invoke(null, null);
                }
                else
                {
                    Console.WriteLine($"The Solve method is missing in {className}.");
                }
            }
            else
            {
                Console.WriteLine($"Class {className} not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
