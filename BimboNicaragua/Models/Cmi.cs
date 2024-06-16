using System;
using System.Collections.Generic;

namespace BimboNicaragua.Models
{
    public partial class Cmi
    {
        public Cmi()
        {
            Objetivos = new HashSet<Objetivo>();
        }

        public int CmiId { get; set; }
        public string Descripcion { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Periodo { get; set; } = null!;

        public virtual ICollection<Objetivo> Objetivos { get; set; }
    }
}
