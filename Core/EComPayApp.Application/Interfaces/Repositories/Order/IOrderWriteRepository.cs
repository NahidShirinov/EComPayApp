﻿using EComPayApp.Application.Interfaces.Repositories;
using EComPayApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Interfaces.Repositories
{

    public interface IOrderWriteRepository : IWriteRepository<Order>
    {
    }
}
