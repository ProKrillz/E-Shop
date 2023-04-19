﻿using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace ServiceLayer.I_R
{
    public class RepositoryOrdre : RepositroyBase<Ordre>, IOrdre
    {
        readonly EfCoreContext _coreContext;
        public RepositoryOrdre(EfCoreContext context) : base(context)
            => _coreContext = context;

        public List<Payment> GetAllPayments()
        {
            return _coreContext.Payment.ToList();
        }
        public List<Delivery> GetDeliveries()
        {
            return _coreContext.Delivery.ToList();
        }
        public async Task CreateOrdreAsync(Ordre ordre)
        {
            await _coreContext.Ordre.AddAsync(ordre);
            _coreContext.SaveChanges();
        }
        public async Task UpdateOrdreAsync(Ordre ordre)
        {
            await _coreContext.Ordre.AddAsync(ordre);
            _coreContext.SaveChanges();
        }
        public async Task DeleteOrdreByIdAsync(int id)
            => await _coreContext.Ordre.Where(o => o.OrdreId == id).ExecuteDeleteAsync();
        
        public async Task<Ordre> GetOrdreByIdAsync(int id)
            => await _coreContext.Ordre.Where(o => o.OrdreId == id).FirstOrDefaultAsync();
    }
}