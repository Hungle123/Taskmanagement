using System;
using ManagerUse;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UserRepositoryTest
{
    [TestClass]
    public class TestSearch
    {
        [TestMethod]
        public void SearchUserTest()
        {
            SearchUsers user = new SearchUsers();
            string ecpected = "Le Hung";
            var name = "le hung";
            var result = user.Search(name);
            Assert.AreEqual(ecpected, result);
        }
    }
}
