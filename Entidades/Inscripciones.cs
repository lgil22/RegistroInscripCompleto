using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroP.Entidades
{
    public class Inscripciones
    {
        [Key]
        public int InscripcionId { get; set; }
        public DateTime Fecha { get; set; }
        public int PersonaId { get; set; }
        public String Comentarios { get; set; }
        public decimal Monto { get; set; }
        public decimal Balance { get; set; }

        public Inscripciones()
        {
            InscripcionId = 0;
            Fecha = DateTime.Now;
            PersonaId = 0;
            Comentarios = string.Empty;
            Monto = 0;
            Balance = 0;
        }

        public Inscripciones(int inscripcionId, DateTime fecha, int personaId, string comentarios, decimal monto,  decimal balance)
        {
            InscripcionId = inscripcionId;
            Fecha = fecha;
            PersonaId = personaId;
            Comentarios = comentarios;
            Monto = monto;
            Balance = balance;
        }

    }

}
