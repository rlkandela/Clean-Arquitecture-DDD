namespace CleanArquitecture.Domain.Common
{
    public abstract class BaseDomainModel
    {
        public int Id { get; set; }

        #region Creation Data
        public DateTime? DateCreated { get; set; }

        public string? CreatedBy { get; set; }
        #endregion

        #region Modification Data
        public DateTime? DateModified { get; set; }

        public string? ModifiedBy { get; set; }
        #endregion
    }
}
