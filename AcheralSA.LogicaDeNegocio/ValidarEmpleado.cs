using AcheralSA.Entidades;



namespace AcheralSA.LogicaDeNegocio
{
    public class ValidarEmpleado
    {

        public void Validar(Empleado empleado)
        {
            if (empleado == null)
                throw new ArgumentNullException(nameof(empleado), "El empleado no puede ser nulo.");

            if (string.IsNullOrWhiteSpace(empleado.Nombre))
                throw new ArgumentException("El nombre del empleado no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(empleado.Apellido))
                throw new ArgumentException("El apellido del empleado no puede estar vacío.");

            if (empleado.FechaNacimiento == default)
                throw new ArgumentException("La fecha de nacimiento es inválida.");

            if (CalcularEdad(empleado.FechaNacimiento) < 18)
                throw new ArgumentException("El empleado debe ser mayor de 18 años.");

            if (string.IsNullOrWhiteSpace(empleado.Cuil))
                throw new ArgumentException("El CUIL no puede estar vacío.");

            if (empleado.NumeroLegajo <= 0) //corregir no puede esta vacio
                throw new ArgumentException("El número de legajo no puede estar vacío.");

        }

        private int CalcularEdad(DateTime fechaNacimiento)
        {
            int edad = DateTime.Today.Year - fechaNacimiento.Year;
            if (fechaNacimiento.Date > DateTime.Today.AddYears(-edad))
                edad--;
            return edad;
        }

       
    }
}
