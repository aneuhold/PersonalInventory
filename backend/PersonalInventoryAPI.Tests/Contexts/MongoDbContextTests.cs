using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonalInventoryAPI.Contexts;

namespace PersonalInventoryAPI.Tests.Contexts
{
    [TestClass]
    public class MongoDbContextTests
    {
        [TestMethod]
        public void MongoDbContext_ConnectionStringSet_NoExceptions()
        {
            new MongoDbContext();
        }
    }
}
