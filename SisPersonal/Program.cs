using SisPersonal;
using System;

class Program
{
    static void Main(string[] args)
    {
   Empleado[] empleados = new Empleado[3];
    for (int i = 0; i < empleados.Length; i++)
        {
            empleados[i] = CrearEmpleado();
        }


        foreach (Empleado empleado in empleados)
        {
            Console.WriteLine($"Nombre: {empleado.Nombre}, Apellido: {empleado.Apellido}, Salario: {empleado.CalcularSalario()}");
        }

        double totalSalarios = CalcularTotalSalarios(empleados);
        Console.WriteLine($"El monto total de los salarios es: {totalSalarios}");

         Empleado proximoAJubilarse = EncontrarProximoAJubilarse(empleados);
        Console.WriteLine($"El empleado más próximo a jubilarse es: {proximoAJubilarse.Nombre} {proximoAJubilarse.Apellido}, con un salario de: {proximoAJubilarse.CalcularSalario()}");
    }

    
    static Empleado CrearEmpleado()
    {
        Console.Write("Ingrese el nombre del empleado: ");
        string nombre = Console.ReadLine();

        Console.Write("Ingrese el apellido del empleado: ");
        string apellido = Console.ReadLine();

        Console.Write("Ingrese el estado civil del empleado (C para casado, S para soltero): ");
        char estadoCivil = Char.Parse(Console.ReadLine());

        DateTime fechaNacimiento;
        while (true)
        {
            Console.Write("Ingrese la fecha de nacimiento del empleado (formato: dd/mm/yyyy): ");
            if (DateTime.TryParse(Console.ReadLine(), out fechaNacimiento))
            {
                break;
            }
            Console.WriteLine("Formato de fecha incorrecto. Por favor, intente de nuevo.");
        }

        DateTime fechaIngreso;
        while (true)
        {
            Console.Write("Ingrese la fecha de ingreso del empleado (formato: dd/mm/yyyy): ");
            if (DateTime.TryParse(Console.ReadLine(), out fechaIngreso))
            {
                break;
            }
            Console.WriteLine("Formato de fecha incorrecto. Por favor, intente de nuevo.");
        }

        double sueldoBasico;
        while (true)
        {
            Console.Write("Ingrese el sueldo básico del empleado: ");
            if (double.TryParse(Console.ReadLine(), out sueldoBasico))
            {
                break;
            }
            Console.WriteLine("Formato de sueldo incorrecto. Por favor, intente de nuevo.");
        }

        Cargos cargo;
        while (true)
        {
            Console.Write("Ingrese el cargo del empleado (0 para Auxiliar, 1 para Administrativo, 2 para Ingeniero, 3 para Especialista, 4 para Investigador): ");
            if (Enum.TryParse(Console.ReadLine(), out cargo))
            {
                break;
            }
            Console.WriteLine("Formato de cargo incorrecto. Por favor, intente de nuevo.");
        }

        return new Empleado(nombre, apellido, estadoCivil, fechaNacimiento, fechaIngreso, sueldoBasico, cargo);
    }

     static double CalcularTotalSalarios(Empleado[] empleados)
    {
        double total = 0;
        foreach (Empleado empleado in empleados)
        {
            total += empleado.CalcularSalario();
        }
        return total;
    }

    static Empleado EncontrarProximoAJubilarse(Empleado[] empleados)
    {
        Empleado proximoAJubilarse = empleados[0];

        foreach (Empleado empleado in empleados)
        {
            if (empleado.CalcularAñosParaJubilacion() < proximoAJubilarse.CalcularAñosParaJubilacion())
            {
                proximoAJubilarse = empleado;
            }
        }

        return proximoAJubilarse;
    }
}