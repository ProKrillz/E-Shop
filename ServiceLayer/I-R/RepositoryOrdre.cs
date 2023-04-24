using DataLayer;
using DataLayer.Entities;

namespace ServiceLayer.I_R;

public class RepositoryOrdre : RepositroyBase<Ordre>, IOrdre
{
    readonly EfCoreContext _coreContext;
    public RepositoryOrdre(EfCoreContext context) : base(context)
        => _coreContext = context;

    public List<Payment> GetAllPayments()       
        => _coreContext.Payment.ToList();
    
    public List<Delivery> GetDeliveries()      
        => _coreContext.Delivery.ToList();  
    
  
}