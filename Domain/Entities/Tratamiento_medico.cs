
namespace Domain.Entities;

    public class Tratamiento_medico : BaseEntity
    {
        public string Id_cita { get; set; }
        public Cita Cita {get;set;}

        public string Id_medicamento { get; set; }
        public Medicamento Medicamento {get;set;}
        public double Dosis { get; set; }
        
        public DateTime Fecha_administracion { get; set; }
        public string Observacion { get; set; }

    }
