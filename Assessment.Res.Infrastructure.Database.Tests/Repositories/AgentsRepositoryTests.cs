using Assessment.Res.Infrastructure.Database.Entities;
using Assessment.Res.Infrastructure.Database.Repositories;
using FakeItEasy;
using MockQueryable.FakeItEasy;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment.Res.Infrastructure.Database.Tests.Repositories
{
    [TestFixture]
    public class AgentsRepositoryTests
    {
        private RealEstateScraperDbContext _dbContext;
        private AgentsRepository _agentsRepository;

        [SetUp]
        public void SetUp()
        {
            _dbContext = A.Fake<RealEstateScraperDbContext>();

            _agentsRepository = new AgentsRepository(_dbContext);
        }

        [Test]
        public async Task GetByVendorIdAsync_Agents_Success()
        {
            var data = new List<AgentEntity>
            {
                new AgentEntity{ Id = 1, Name = "name", VendorId = "vendorId"}
            };

            var mock = data.AsQueryable().BuildMockDbSet(); 
            A.CallTo(() => _dbContext.Agents).Returns(mock);

            var result = await _agentsRepository.GetByVendorIdAsync("vendorId");

            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("name", result.Name);
            Assert.AreEqual("vendorId", result.VendorId);
        }
    }
}
