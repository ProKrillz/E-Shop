using DataLayer.Entities;

namespace ServiceLayer.I_R;

public interface IOrdre : IBase<Ordre>
{
    List<Payment> GetAllPayments();
    List<Delivery> GetDeliveries();

}
