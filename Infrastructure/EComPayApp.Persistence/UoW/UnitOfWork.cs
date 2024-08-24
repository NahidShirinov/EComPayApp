using EComPayApp.Application.Interfaces.Repositories;
using EComPayApp.Application.Interfaces.Repositories.IUnitOfWork;
using EComPayApp.Persistence.Contexts;
using EComPayApp.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Persistence.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EComPayAppDbContext _context;

        public UnitOfWork(EComPayAppDbContext eComPayAppDbContext)
        {
            _context = eComPayAppDbContext;

        }


        private readonly AddressReadRepository addressReadRepository;
        private readonly  AddressWriteRepository addressWriteRepository;
       
        public IProductReadRepository ProductReads => throw new NotImplementedException();

        public IProductWriteRepository ProductWrites => throw new NotImplementedException();

        public ICustomerReadRepository CustomerReads => throw new NotImplementedException();

        public ICustomerWriteRepository CustomerWrites => throw new NotImplementedException();

        public IBranchReadRepository BranchReads => throw new NotImplementedException();

        public IBranchWriteRepository BranchWrites => throw new NotImplementedException();

        public IPaymentReadRepository paymentReadRepository => throw new NotImplementedException();

        public IPaymentWriteRepository paymentWriteRepository => throw new NotImplementedException();

        public ICategoryReadRepository categoryReads => throw new NotImplementedException();

        public ICategoryWriteRepository categoryWrites => throw new NotImplementedException();

        public IOrderItemReadRepository orderItemReads => throw new NotImplementedException();

        public IOrderItemWriteRepository orderItemWrites => throw new NotImplementedException();

        public IOrderWriteRepository orderWriteRepository => throw new NotImplementedException();

        public IOrderReadRepository orderReadRepository => throw new NotImplementedException();

        public IAddressReadRepository AddressReadRepository => throw new NotImplementedException();

        public IAddressWriteRepository AddressWriteRepository => throw new NotImplementedException();

        public IAddressReadRepository AddressReads => throw new NotImplementedException();

        public IAddressWriteRepository AddressWrites => throw new NotImplementedException();

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
