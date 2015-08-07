using System;
using System.Threading.Tasks;
using ManagerUse;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UserRepositoryTest
{
    [TestClass]
    public class TestUser
    {
        [TestMethod]
        public void CheckingUserEmpty()
        {
            UserRepository userRepository =  new UserRepository();
            // do something
        }
    }
}

