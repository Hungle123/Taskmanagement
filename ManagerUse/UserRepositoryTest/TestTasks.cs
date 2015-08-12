using ManagerUse;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UserRepositoryTest
{
    [TestClass]
    public class TestTasks
    {
        [TestMethod]
        public void CheckInfoTests()
        {
            TaskRepository taskRepository = new TaskRepository();
            string[] infoTasks = new string[]
            {
                "Name: Task name goes here\n",
                "Description: Description goes here\n",
                "Type: (Either Bug or Feature)\n",
                "User: Tran Thien Khiem (look up in user repository for this user)\n",
                "State: (Either ToDo - Doing - Done - or Tested)\n",
                "CompletedPercent: 50%"
            };
            string expected = null;
            foreach (var infoTask in infoTasks)
            {
                expected += infoTask;
            }
            var result = taskRepository.ReadText();
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }
    }
}
