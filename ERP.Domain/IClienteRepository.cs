﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetAllAsync();
        Task<Cliente> GetByIdAsync(int id);
        Task AddAsync(Cliente cliente);
        Task UpdateAsync(Cliente cliente);
        Task DeleteAsync(int id);
    }
}
