using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreSociety;

namespace CoreSocietyTests
{
    [TestClass]
    public class IndexerTest
    {
        [TestMethod]
        public void Clamp1D()
        {
            List<int> data = new List<int>() { 0, 1, 2, 3 };
            Indexer<int> idx = new Indexer<int>(data, ClampMode.Clamp);
            Assert.AreEqual(0, idx[-1]);
            Assert.AreEqual(1, idx[1]);
            Assert.AreEqual(3, idx[5]);
        }

        [TestMethod]
        public void Repeat1D()
        {
            List<int> data = new List<int>() { 0, 1, 2, 3 };
            Indexer<int> idx = new Indexer<int>(data, ClampMode.Repeat);
            Assert.AreEqual(3, idx[-1]);
            Assert.AreEqual(2, idx[-2]);
            Assert.AreEqual(1, idx[1]);
            Assert.AreEqual(1, idx[5]);
            Assert.AreEqual(0, idx[8]);
        }

        [TestMethod]
        public void Clamp2D()
        {
            List<int> data = new List<int>() { 
                00, 01, 02, 
                10, 11, 12, 
                20, 21, 22 };
            Indexer<int> idx = new Indexer<int>(data, 3, ClampMode.Clamp);
            Assert.AreEqual(0,idx[-1, 0]);
            Assert.AreEqual(0,idx[0, -1]);
            Assert.AreEqual(0,idx[0, 0]);
            Assert.AreEqual(12,idx[1, 2]);
            Assert.AreEqual(12,idx[1, 3]);
            Assert.AreEqual(22,idx[3, 3]);
        }

        [TestMethod]
        public void Repeat2D()
        {
            List<int> data = new List<int>() { 
                00, 01, 02, 
                10, 11, 12, 
                20, 21, 22 };
            Indexer<int> idx = new Indexer<int>(data, 3, ClampMode.Repeat);
            Assert.AreEqual(20,idx[-1, 0]);
            Assert.AreEqual(2,idx[0, -1]);
            Assert.AreEqual(0,idx[0, 0]);
            Assert.AreEqual(12,idx[1, 2]);
            Assert.AreEqual(10,idx[1, 3]);
            Assert.AreEqual(0,idx[3, 3]);
        }

        [TestMethod]
        public void Wrap2D()
        {
            List<int> data = new List<int>() { 
                00, 01, 02, 
                10, 11, 12, 
                20, 21, 22 };
            Indexer<int> idx = new Indexer<int>(data, 3);
            Assert.AreEqual(20, idx[-1, 0]);
            Assert.AreEqual(2, idx[0, -1]);
            Assert.AreEqual(0, idx[0, 0]);
            Assert.AreEqual(12, idx[1, 2]);
            Assert.AreEqual(20, idx[1, 3]);
            Assert.AreEqual(10, idx[3, 3]);
        }
    }
}
