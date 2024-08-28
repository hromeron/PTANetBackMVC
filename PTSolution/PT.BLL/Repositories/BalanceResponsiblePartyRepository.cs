using PT.DAL.Context;
using PT.BLL.Dto;
using PT.BLL.Interfaces;
using PT.BLL.CustomMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace PT.BLL.Repositories
{
    public class BalanceResponsiblePartyRepository : IBalanceResponsibleParty
    {
        private readonly MarketPartiesContext _context;

        public BalanceResponsiblePartyRepository(IConfiguration configuration)
        {
            if (string.IsNullOrWhiteSpace(configuration.GetConnectionString("Connection"))) throw new ArgumentNullException();

            string connectionString = configuration.GetConnectionString("Connection");
            var options = SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder<MarketPartiesContext>(), connectionString).Options;

            _context = new MarketPartiesContext(options);
        }

        public List<BalanceResponsiblePartyDto> Get()
        {
            var entities = _context.BalanceResponsibleParties.ToList();

            return entities.Select(e => Mapper.ToDto(e)).ToList();
        }

        public BalanceResponsiblePartyDto Get(string Code)
        {
            var entity = _context.BalanceResponsibleParties.FirstOrDefault(e => e.Code == Code);

            return Mapper.ToDto(entity);
        }

        public bool Exists(string Code)
        {
            return _context.BalanceResponsibleParties.Any(e => e.Code == Code);
        }

        public bool Load(List<BalanceResponsiblePartyDto> data)
        {
            throw new NotImplementedException();
        }
    }
}
