﻿using System.Collections.Generic;
using ManagerUse;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UserRepositoryTest
{
    [TestClass]
    public class TestUser
    {
        /// <summary>
        /// 
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
        /// 
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
            var taskComplate = "";
            foreach (var task in tasks)
            {
                taskName += task.Name;
                taskDescription += task.Description;
                taskType += task.Type;
                taskState += task.State;
                taskComplate += task.ComplateedPercent;
            }
            Assert.AreEqual("Task 1" + "Task 2", taskName);
            Assert.AreEqual("Description goes here" + "Description goes here", taskDescription);
            Assert.AreEqual("Bug" + "Feature", taskType);
            Assert.AreEqual("ToDo" + "Done", taskState);
            Assert.AreEqual("50%" + "100%", taskComplate);
            Assert.IsNotNull(tasks);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void TestSearchFound()
        {
            var userRepository = UserRepository.GetInstance();
            userRepository.Users = new List<User>
            {
                new User("Khiem", "thienkhiem88@gmail.com"),
                new User("ABC", "abc@def.com")
            };

            var user = userRepository.Search("Khiem");

            Assert.IsNotNull(user);
            Assert.AreEqual("Khiem", user.Name);
            Assert.AreEqual("thienkhiem88@gmail.com", user.Email);
        }
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void TestNotFound()
        {
            var userRepository = UserRepository.GetInstance();
            userRepository.Users = new List<User>
            {
                new User("Khiem", "thienkhiem88@gmail.com"),
                new User("ABC", "abc@def.com")
            };

            var user = userRepository.Search("XYZ");
            Assert.IsNull(user);
        }
    }
}

