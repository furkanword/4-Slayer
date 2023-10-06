namespace API.Helpers;

    public class Autorizacion
    {
        public enum Rols
        {
            Administrador,
            Gerente,
            Empleado
        }
        public const Rols Rol_PorDefecto = Rols.Empleado;
    }