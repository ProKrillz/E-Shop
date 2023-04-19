using DataLayer.Entities;

namespace ServiceLayer.I_R
{
    public interface IOrdre : IBase<Ordre>
    {
        List<Payment> GetAllPayments();
        List<Delivery> GetDeliveries();
        /// <summary>
        /// Create ordre (dosent work)
        /// </summary>
        /// <param name="ordre"></param>
        /// <returns></returns>
        Task CreateOrdreAsync(Ordre ordre);
        /// <summary>
        /// Update ordre (Dont know how)
        /// </summary>
        /// <param name="ordre"></param>
        /// <returns></returns>
        Task UpdateOrdreAsync(Ordre ordre);
        /// <summary>
        /// Delete ordre from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteOrdreByIdAsync(int id);
        /// <summary>
        /// Get ordre by ordreId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Ordre> GetOrdreByIdAsync(int id);
    }
}
