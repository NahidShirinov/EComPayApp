using EComPayApp.Application.Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.DTOs.OrderItems
{
    public class UpdateOrderItemDto:IDto
    {
        public int Quantity { get; set; }
    }
}
