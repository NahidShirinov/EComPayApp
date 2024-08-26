using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Commands.Payments.DeletePayment
{
    public class DeletePaymentResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
