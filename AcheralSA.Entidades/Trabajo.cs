using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcheralSA.Entidades
{
    public class Trabajo
    {
        public int IdTrabajo {  get; set; }
        public int Jornal {  get; set; } //Cuantas horas
        public string Sector {  get; set; } //pregado, secadero, etc
        public string Condicion { get; set; } //temporal, permanente, contratado
        public bool Rotativo { get; set; }

    }
}
