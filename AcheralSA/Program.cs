// See https://aka.ms/new-console-template for more information


using AcheralSA.Entidades;
using AcheralSA.LogicaDeNegocio;
using AcheralSA.LogicaDeNegocio.Utilidades;
using AutoMapper;

//iniciamos el mapper manualmente - Averiguar sobre inyeccion de dependencias
var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<EmpleadoProfile>();
});
IMapper mapper = config.CreateMapper();
EmpleadoManager empleadoManager = new EmpleadoManager(mapper);

Empleado empleado = new Empleado
{
    Cuil = "1234",
    Apellido = "Medina",
    Edad = 27,
    FechaNacimiento = new DateTime(1997, 06, 10),
    IdEmpleado = 10,
    Nombre = "Juan Pablo",
    NumeroLegajo = 5030,
    ServicioMedico = new ServicioMedico
    {
        IdServicioMedico = 10
    },
    Trabajo = new Trabajo
    {
        IdTrabajo = 10,
        Condicion = "Permanente",
        Sector = "Sistemas",
        Jornal = 6,
        Rotativo = false,
    },
};

Empleado empleado2 = new Empleado
{
    Cuil = "1234",
    Apellido = "Medina",
    Edad = 27,
    FechaNacimiento = new DateTime(1997, 06, 10),
    IdEmpleado = 10,
    Nombre = "Juan Pablo",
    NumeroLegajo = 5030,
    ServicioMedico = new ServicioMedico
    {
        IdServicioMedico = 10
    },
    Trabajo = new Trabajo
    {
        IdTrabajo = 10,
        Condicion = "Permanente",
        Sector = "Sistemas",
        Jornal = 6,
        Rotativo = false,
    },
};





//aqui agregamos al empleado
try
{
    empleadoManager.AltaEmpleado(empleado);
    empleadoManager.AltaEmpleado(empleado2);
    Console.WriteLine("Empleado Agregado con exito");
}
catch(Exception ex)
{
    Console.WriteLine($"No se pudo agregar al empleado: {ex.Message}");
}


//mostrar lista de empleados

List<Empleado> empleados = empleadoManager.ListarEmpleados();

Console.WriteLine("\n Lista de empleados:");

foreach(var item in empleados)
{
    Console.WriteLine($"" +
        $"Nombre: {item.Nombre}, " +
        $"Apellido: {item.Apellido}, " +
        $"Legajo: {item.NumeroLegajo}, " +
        $"CUIL: {item.Cuil}, " +
        $"Edad: {item.Edad}, " +
        $"Fecha de Nacimiento: {item.FechaNacimiento}"
        );
}

//buscar empleado por legajo

try
{
    Empleado resultEmpleado = empleadoManager.ListarEmpleadoLegajo(5030);
    Console.WriteLine($"\nEmpleado encontrado: {resultEmpleado.Nombre} {resultEmpleado.Apellido}");
}catch(Exception ex)
{
    Console.WriteLine($"Error al buscar empleado: {ex.Message}");
}


//modificado un empleado
Console.WriteLine("Empleado modificado:");

//modificamos el empleado con automapper

Empleado empleadoModificado = new Empleado
{
    Cuil = "1232224",
    Apellido = "Gómez",
    Edad = 30,
    FechaNacimiento = new DateTime(1994, 06, 10),
    Nombre = "Juan Pablo",
    NumeroLegajo = 5030, // Mismo legajo para identificarlo
    ServicioMedico = new ServicioMedico { IdServicioMedico = 20 },
    Trabajo = new Trabajo { IdTrabajo = 15, Condicion = "Temporal", Sector = "IT", Jornal = 8, Rotativo = true }
};

try
{
    empleadoManager.ModificarEmpleado(5030, empleadoModificado);
    Console.WriteLine("Empleado modificado con éxito.");
    
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

Console.WriteLine("\nLista de empleados actualizada:");

foreach (var item in empleados)
{
    Console.WriteLine($"Nombre: {item.Nombre}, Apellido: {item.Apellido}, Legajo: {item.NumeroLegajo}, Cuil: {item.Cuil}");
}







