using AcheralSA.Entidades;
using AutoMapper;



namespace AcheralSA.LogicaDeNegocio.Utilidades
{
    public class EmpleadoProfile : Profile
    {
        public EmpleadoProfile()
        {
            CreateMap<Empleado, Empleado>()
                .ForMember(dest => dest.Cuil, opt => opt.Ignore());
        }
    }
}
