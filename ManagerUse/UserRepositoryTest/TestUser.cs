using System.Collections.Generic;
using ManagerUse;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UserRepositoryTest
{
    [TestClass]
    public class TestUser
    {
        /// <summary>
        ///   This is test method read file user.txt in UserRepository class
        /// </summary>
        [TestMethod]
        public void TestUserRepository()
        {
            var userRepository = UserRepository.GetInstance();
            var users = userRepository.ReadText();
            var userEmail = "";
            var userName = "";
            foreach (var user in users)
            {
                userName += user.Name;
                userEmail += user.Email;
            }
            Assert.AreEqual("Tran Thien Khiem" + "Le Hung", userName);
            Assert.AreEqual("daniel@clearpathdevelopment.com" + "nick@clearpathdevelopement.com", userEmail);
            Assert.IsNotNull(users);
        }

        /// <summary>
        ///  This is test method read file user.txt in TaskRepository class
        /// </summary>
        [TestMethod]
        public void TestTaskRepository()
        {
            var taskRepository = TaskRepository.GetIntance();
            var tasks = taskRepository.ReadText();
            var taskName = "";
            var taskDescription = "";
            var taskType = "";
            var taskState = "";
            var taskUser = "";
            var taskComplate = "";
            foreach (var task in tasks)
            {
                taskName += task.Name;
                taskDescription += task.Description;
                taskType += task.Type;
                // ReSharper disable once LoopCanBeConvertedToQuery
                foreach (var user in task.Users)
                {
                    taskUser += user.Name;
                }
                taskState += task.State;
                taskComplate += task.CompletedPercent;
            }
            Assert.AreEqual("Task 1" + "Task 2", taskName);
            Assert.AreEqual("Description goes here" + "Description goes here", taskDescription);
            Assert.AreEqual("Bug" + "Feature", taskType);
            Assert.AreEqual("ToDo" + "Done", taskState);
            Assert.AreEqual("Tran Khiem" + "Hung", taskUser);
            Assert.AreEqual("50" + "100", taskComplate);
            Assert.IsNotNull(tasks);
        }

        /// <summary>
        ///  Test function search user in list users
        /// </summary>
        [TestMethod]
        public void TestSearchFound()
        {
            var userRepository = UserRepository.GetInstance();
            userRepository.Users = new List<User>
            {
                new User()
                {
                   
                    Name = "Khiem",
                    Email = "thienkhiem88@gmail.com"

                },
                new User()
                {
                    Name = "ABC",
                    Email = "abc.xz@gmail.com"
                }
            };

            var user = userRepository.Search("Khiem");
            Assert.IsNotNull(user);
            Assert.AreEqual("Khiem", user.Name);
            Assert.AreEqual("thienkhiem88@gmail.com", user.Email);
        }
        /// <summary>
        ///  Test case not return result with method search.
        /// </summary>
        [TestMethod]
        public void TestNotFound()
        {
            var userRepository = UserRepository.GetInstance();
            userRepository.Users = new List<User>
            {  new User()
                {
                   
                    Name = "Khiem",
                    Email = "thienkhiem88@gmail.com"

                },
                new User()
                {
                    Name = "ABC",
                    Email = "abc.xz@gmail.com"
                }
            };
            var user = userRepository.Search("XYZ");
            Assert.IsNull(user);
        }

        /// <summary>
        ///  Test method ContainUser search one user on list tasks
        /// </summary>
        [TestMethod]
        public void TestContainUser()
        {
            var user = new User()
            {
                Name = "Hung"
            };
            // ReSharper disable once UseObjectOrCollectionInitializer
            var tasks = new Task();
            tasks.Users = new List<User> { new User()
            {
                Name = ""
            } };
            var result = tasks.ContainUser(user);
            Assert.AreEqual(true, result);
            Assert.IsNotNull(user);
        }

        /// <summary>
        /// Test method list of tasks of a selected user 
        /// and selected state in TaskRepository class
        /// </summary>
        [TestMethod]
        public void TestGetUserTasks()
        {
            var taskRepository = TaskRepository.GetIntance();

            taskRepository.Tasks = new List<Task>
            {
              //  new Task("Task 3", "Do something",TaskType.Bug, new List<User> {new User(){}}, TaskState.Doing, 90)
            };

            var tasks = taskRepository.GetUserTasks(new User()
            {
                Name = "Nick"
            }, TaskState.Doing);
            var complate = 0;
            foreach (var task in tasks)
            {
                complate = task.CompletedPercent;
            }
            Assert.AreEqual(90, complate);
            Assert.IsNotNull(tasks);
        }
    }
}

