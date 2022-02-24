using CleanArquitecture.Domain.Common;

namespace CleanArquitecture.Domain
{
    public class Actor : BaseDomainModel
    {
        public string? Nombre { get; set; }

        public string? Apellido { get; set; }
    }
}
