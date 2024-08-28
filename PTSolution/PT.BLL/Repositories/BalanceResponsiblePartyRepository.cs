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

        public BalanceResponsiblePartyDto Get(string country, string Code)
        {
            var entity = _context.BalanceResponsibleParties.FirstOrDefault(e => e.Country == country && e.Code == Code);

            return Mapper.ToDto(entity);
        }

        public bool Exists(string country, string Code)
        {
            return _context.BalanceResponsibleParties.Any(e => e.Country == country && e.Code == Code);
        }

        public bool IsEmpty()
        {
            return _context.BalanceResponsibleParties.Count() == 0;
        }

        public void Load(List<BalanceResponsiblePartyDto> data)
        {
            foreach (var item in data)
            {
                var entity = Mapper.ToEntity(item);

                _context.BalanceResponsibleParties.Add(entity);
            }

            _context.SaveChanges();
        }
    }
}
