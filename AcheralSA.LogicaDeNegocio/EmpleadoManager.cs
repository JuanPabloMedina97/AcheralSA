using AcheralSA.Entidades;
using AutoMapper;

namespace AcheralSA.LogicaDeNegocio
{
    public class EmpleadoManager
    {

        List<Empleado> _empleados;
        ValidarEmpleado validarEmpleado = new ValidarEmpleado();
        private readonly IMapper _mapper;

        public EmpleadoManager(IMapper mapper) //la simulacion de la bd despues se la pasa a la capa de acceso a datos, esto es una prueba
        {
            _empleados = new List<Empleado>();
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));//iniciamos _mapper
        }


        //metodo para agregar al empleado
        public void AltaEmpleado(Empleado empleado)
        {
            validarEmpleado.Validar(empleado);
            _empleados.Add(empleado);
        }

        //metodo para modificar empleado

        public void ModificarEmpleado(int legajo, Empleado empleadoModificado)
        {
            var empleadoExistente = _empleados.FirstOrDefault(e => e.NumeroLegajo == legajo);
            if (empleadoExistente != null)
            {
                _mapper.Map(empleadoModificado, empleadoExistente); //mapea los valores nuevos
            }
            else
            {
                throw new Exception("Empleado no encontrado");
            }

        }

        //metodo para eliminar empelado

        public void BajaEmpleado(int legajo)
        {
            var empleado = ListarEmpleadoLegajo(legajo);
            if (empleado != null)
            {
                _empleados.Remove(empleado);
            }
        }


        //metodo para obtener empleados
        public List<Empleado> ListarEmpleados()
        {
            return _empleados;
        }

        //metodo para obtener el empleado por su legajo
        public Empleado ListarEmpleadoLegajo(int legajo)
        {
            var empleado = _empleados.FirstOrDefault(e => e.NumeroLegajo == legajo);

            if (empleado == null)
                throw new Exception($"No se encontró un empleado con el legajo {legajo}.");

            return empleado;
        }




    }
}
