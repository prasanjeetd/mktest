using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace mktest.tests
{
    [TestClass]
    public class OrderTests
    {
        string file = Path.Combine(Environment.CurrentDirectory, "Logs.txt");

        [TestCleanup]
        public void TearDown()
        {
            File.WriteAllText(file,"");
        }

        [TestMethod]
        public void Test_Physical()
        {
            OrderItem orderItem = new OrderItem();
            orderItem.product = new Products { ID = 1, Name = "Physical Item", Mrp = 10 };
            orderItem.Qty = 1;

            Order order = new Order(new List<OrderItem> { orderItem });

            order.Process();

            string[] lines = File.ReadAllLines(file);

            Assert.AreEqual(lines.Length, 2);
            Assert.AreEqual(lines[0], "generate a packing slip for shipping.");
            Assert.AreEqual(lines[1], "generate a commission payment to the agent.");

        }

        [TestMethod]
        public void Test_Book()
        {
            OrderItem orderItem = new OrderItem();
            orderItem.product = new Book { ID = 1, Name = "Book", Mrp = 10 };
            orderItem.Qty = 1;

            Order order = new Order(new List<OrderItem> { orderItem });

            order.Process();

            string[] lines = File.ReadAllLines(file);

            Assert.AreEqual(lines.Length, 2);
            Assert.AreEqual(lines[0], "create a duplicate packing slip for the royalty department.");
            Assert.AreEqual(lines[1], "generate a commission payment to the agent.");

        }

        [TestMethod]
        public void Test_Membership_Active()
        {
            OrderItem orderItem = new OrderItem();
            orderItem.product = new Membership (true) { ID = 1, Name = "Active Membership", Mrp = 10 };
            orderItem.Qty = 1;

            Order order = new Order(new List<OrderItem> { orderItem });

            order.Process();

            string[] lines = File.ReadAllLines(file);

            Assert.AreEqual(lines.Length, 2);
            Assert.AreEqual(lines[0], "activate that membership.");
            Assert.AreEqual(lines[1], "e-mail the owner and inform them of the activation/upgrade.");

        }

        [TestMethod]
        public void Test_Membership_Upgrade()
        {
            OrderItem orderItem = new OrderItem();
            orderItem.product = new Membership(false) { ID = 1, Name = "Active Membership", Mrp = 10 };
            orderItem.Qty = 1;

            Order order = new Order(new List<OrderItem> { orderItem });

            order.Process();

            string[] lines = File.ReadAllLines(file);

            Assert.AreEqual(lines.Length, 2);
            Assert.AreEqual(lines[0], "apply the upgrade.");
            Assert.AreEqual(lines[1], "e-mail the owner and inform them of the activation/upgrade.");

        }

        [TestMethod]
        public void Test_Video()
        {
            OrderItem orderItem = new OrderItem();
            orderItem.product = new Video { ID = 1, Name = "Other videos", Mrp = 10 };
            orderItem.Qty = 1;

            Order order = new Order(new List<OrderItem> { orderItem });

            order.Process();

            string[] lines = File.ReadAllLines(file);

            Assert.AreEqual(lines.Length, 1);
            Assert.AreEqual(lines[0], "execute default delivery");

        }

        [TestMethod]
        public void Test_Video_LearningToSki()
        {
            OrderItem orderItem = new OrderItem();
            orderItem.product = new Video { ID = 1, Name = "Learning to Ski,", Mrp = 10 };
            orderItem.Qty = 1;

            Order order = new Order(new List<OrderItem> { orderItem });

            order.Process();

            string[] lines = File.ReadAllLines(file);

            Assert.AreEqual(lines.Length, 1);
            Assert.AreEqual(lines[0], "First Aid");

        }
    }
}
