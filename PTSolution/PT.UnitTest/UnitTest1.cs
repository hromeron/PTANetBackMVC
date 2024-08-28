using Microsoft.Extensions.Configuration;
using PT.BLL.Dto;
using PT.BLL.Interfaces;
using PT.BLL.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PT.UnitTest
{
    public class UnitTestRepository
    {
        private readonly IBalanceResponsibleParty _repository;

        public UnitTestRepository()
        {
            var connectionsConfig = new Dictionary<string, string>
            {
                {"ConnectionStrings:Connection", "Server=tcp:localhost,1433;Database=TestAlicundeDB; User ID=sql_guest;Password=guest@2024#pt; MultipleActiveResultSets=true; Trust Server Certificate=true;"}
            };

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(connectionsConfig)
                .Build();

            _repository = new BalanceResponsiblePartyRepository(configuration);
        }

        [Fact]
        public void ValueNotFound()
        {
            ClearLoadTestData();

            var result = _repository.Exists("0", "0");

            Assert.False(result);
        }

        [Fact]
        public void ValueFound()
        {
            ClearLoadTestData();

            var result = _repository.Exists("ES", "TEST1");

            Assert.True(result);
        }

        [Fact]
        public void Empty()
        {
            _repository.Clear();

            var result = _repository.IsEmpty();

            Assert.True(result);
        }

        [Fact]
        public void NotEmpty()
        {
            var data = new List<BalanceResponsiblePartyDto>();
            data.Add(new BalanceResponsiblePartyDto() { brpCode = "TEST1", brpName = "TEST 1", country = "ES", businessId = "916116991", codingScheme = "GS1", validityEnd = DateTime.Now, validityStart = DateTime.Now });
            data.Add(new BalanceResponsiblePartyDto() { brpCode = "TEST2", brpName = "TEST 2", country = "ES", businessId = "916116992", codingScheme = "GS2", validityEnd = DateTime.Now, validityStart = DateTime.Now });

            _repository.Load(data);

            var result = _repository.IsEmpty();

            Assert.False(result);
        }

        private void ClearLoadTestData()
        {
            _repository.Clear();

            var data = new List<BalanceResponsiblePartyDto>();
            data.Add(new BalanceResponsiblePartyDto() { brpCode = "TEST1", brpName = "TEST 1", country = "ES", businessId = "916116991", codingScheme = "GS1", validityEnd = DateTime.Now, validityStart = DateTime.Now });
            data.Add(new BalanceResponsiblePartyDto() { brpCode = "TEST2", brpName = "TEST 2", country = "ES", businessId = "916116992", codingScheme = "GS2", validityEnd = DateTime.Now, validityStart = DateTime.Now });

            _repository.Load(data);
        }
    }
}