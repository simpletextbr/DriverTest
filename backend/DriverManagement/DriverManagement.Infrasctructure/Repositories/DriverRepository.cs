using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DriverManagement.Domain.interfaces;
using DriverManagement.Domain.Models;
using DriverManagement.Infrastructure.Context;

namespace DriverManagement.Infrasctructure.Repositories
{

    public class DriverRepository : BaseRepository<DriverModel>, IDriverRepository
    {
        protected readonly ApplicationContext _context;

        public DriverRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }
    }
}