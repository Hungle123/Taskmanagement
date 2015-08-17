using ManagerUse;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UserRepositoryTest
{
    [TestClass]
    public class TestUser
    {
        [TestMethod]
        public void TestSearchFound()
        {
            var userRepository = new UserRepository();
            userRepository.Users.Add(new User("Khiem", "thienkhiem88@gmail.com"));
            userRepository.Users.Add(new User("ABC", "abc@def.com"));

            var user = userRepository.Search("Khiem");

            Assert.IsNotNull(user);
            Assert.AreEqual("Khiem", user.Name);
           // Assert.AreEqual("thienkhiem88@gmail.com", user.Email);
        }


        [TestMethod]
        public void TestNotFound()
        {
            var userRepository = new UserRepository();
            userRepository.Users.Add(new User("Khiem", "thienkhiem88@gmail.com"));
            userRepository.Users.Add(new User("ABC", "abc@def.com"));

            var user = userRepository.Search("XYZ");

            Assert.IsNull(user);
        }
    }
}

