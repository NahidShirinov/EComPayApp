using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Interfaces.Repositories.IUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IAddressReadRepository AddressReadRepository { get; }
        IAddressWriteRepository AddressWriteRepository { get; }
        IProductReadRepository ProductReads { get; }
        IProductWriteRepository ProductWrites { get; }
        ICustomerReadRepository CustomerReads { get; }
        ICustomerWriteRepository CustomerWrites { get; }
        IAddressReadRepository AddressReads { get; }
        IAddressWriteRepository AddressWrites { get; }
        IBranchReadRepository BranchReads { get; }
        IBranchWriteRepository BranchWrites { get; }
        IPaymentReadRepository paymentReadRepository { get; }
        IPaymentWriteRepository paymentWriteRepository { get; }
        ICategoryReadRepository categoryReads { get; }
        ICategoryWriteRepository categoryWrites { get; }    
        IOrderItemReadRepository orderItemReads { get; }
        IOrderItemWriteRepository orderItemWrites { get; }
        IOrderWriteRepository orderWriteRepository { get; }
        IOrderReadRepository orderReadRepository { get; }

        Task<int> CompleteAsync();
    }
    

    
}
