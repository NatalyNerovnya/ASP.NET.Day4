using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomQueue;

namespace CustomQueue.Tests
{
    [TestClass]
    public class CustomQueueTests
    {
        [TestMethod]
        public void Enqueue_ObjectArrayAddString_ObjectArrayWithString()
        {
            CustomQueue<object> actual = new CustomQueue<object>("Queue", 123);
            CustomQueue<object> expected = new CustomQueue<object>("Queue", 123, "Hello, world!");

            actual.Enqueue("Hello, world!");

            CollectionAssert.AreEquivalent(actual.ToArray(), expected.ToArray());
        }

        [TestMethod]
        public void Dequeue_ObjectArrayWithFirstString_ObjectArrayWithoutFirstString()
        {
            CustomQueue<object> actual = new CustomQueue<object>("Queue", 123, "Hello, world!");
            CustomQueue<object> expected = new CustomQueue<object>(123, "Hello, world!");

            actual.Dequeue();

            CollectionAssert.AreEquivalent(actual.ToArray(), expected.ToArray());
        }

        [TestMethod]
        public void Peek_ObjectArrayWithFirstString_ObjectArrayWithoutFirstString()
        {
            CustomQueue<object> queue = new CustomQueue<object>("Queue", 123, "Hello, world!");
            string expected = "Queue";

            object result = queue.Peek();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Contain_ObjectArrayWithSummer_True()
        {
            CustomQueue<object> queue = new CustomQueue<object>("Queue", 123, "Summer");
            bool expected = true;

            bool result = queue.Contain("Summer");

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Contain_ObjectArrayWithoutSummer_False()
        {
            CustomQueue<object> queue = new CustomQueue<object>("Queue", 123, "Summmmmmmer");
            bool expected = false;

            bool result = queue.Contain("Summer");

            Assert.AreEqual(expected, result);
        }

    }
}
