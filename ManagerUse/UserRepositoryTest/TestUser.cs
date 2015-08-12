using ManagerUse;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UserRepositoryTest
{
    [TestClass]
    public class TestUser
    {
        [TestMethod]
        public void ChekInfoUsers()
        {
            UserRepository userRepository =  new UserRepository();
            
            string[] infoUsers = new string[]{
                                                 "Name: Tran Thien Khiem\n",
                                                 "Email: daniel@clearpathdevelopment.com\n",
                                                 "Name: Le Hung\n",
                                                 "Email: nick@clearpathdevelopement.com"
                                              };
            string expected = null;
            foreach (var infoUser in infoUsers)
            {
                expected += infoUser;
            }
            var result = userRepository.ReadText();
            Assert.IsNotNull(result);
            Assert.AreEqual(expected,result);
        }
    }
}

