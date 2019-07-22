﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsDataStructures2;

namespace AlgoTest_1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_A_Methods_1()
        {
            BST<int> btree = new BST<int>(new BSTNode<int>(11, 100, null));
            btree.AddKeyValue(1, 2);
            btree.AddKeyValue(9, 3);
            btree.AddKeyValue(42, 4);
            btree.AddKeyValue(32, 5);
            btree.AddKeyValue(35, 6);
        }
        
        [TestMethod]
        public void Test_A_Methods_2()
        {
            BST<int> btree = new BST<int>(new BSTNode<int>(16, 100, null));
            btree.AddKeyValue(8, 100);
            btree.AddKeyValue(4, 100);
            btree.AddKeyValue(2, 100);
            btree.AddKeyValue(1, 100);
            btree.AddKeyValue(0, 100);
            btree.AddKeyValue(-1, 100);
            btree.AddKeyValue(3, 100);
            btree.AddKeyValue(6, 100);
            btree.AddKeyValue(18, 100);
            btree.AddKeyValue(17, 100);
            btree.AddKeyValue(22, 100);
            btree.AddKeyValue(23, 100);
            btree.AddKeyValue(20, 100);

            Assert.AreEqual(14, btree.Count());
        }

        [TestMethod]
        public void TestFind_1()
        {
            BST<int> tree = new BST<int>(null);
            tree.AddKeyValue(16, 100);

            Assert.AreEqual(null, tree.FindNodeByKey(16).Node);
            Assert.AreEqual(true, tree.FindNodeByKey(16).NodeHasKey);
            Assert.AreEqual(false, tree.FindNodeByKey(16).ToLeft);
        }

        [TestMethod]
        public void TestFind_2()
        {
            BST<int> tree = new BST<int>(null);
            tree.AddKeyValue(16, 100);

            Assert.AreEqual(null, tree.FindNodeByKey(16).Node);
        }

        [TestMethod]
        public void TestFind_3()
        {
            BST<int> btree = GetTree();

            Assert.AreEqual(true, btree.FindNodeByKey(6).NodeHasKey);
            Assert.AreEqual(true, btree.FindNodeByKey(-1).NodeHasKey);
            Assert.AreEqual(true, btree.FindNodeByKey(0).NodeHasKey);
            Assert.AreEqual(true, btree.FindNodeByKey(18).NodeHasKey);
            Assert.AreEqual(false, btree.FindNodeByKey(19).NodeHasKey);
            Assert.AreEqual(false, btree.FindNodeByKey(28).NodeHasKey);
        }

        [TestMethod]
        public void TestFind_4()
        {
            BST<int> btree = GetTree();

            Assert.AreEqual(false, btree.FindNodeByKey(6).ToLeft);
            Assert.AreEqual(false, btree.FindNodeByKey(-1).ToLeft);
            Assert.AreEqual(false, btree.FindNodeByKey(0).ToLeft);
            Assert.AreEqual(false, btree.FindNodeByKey(18).ToLeft);
            Assert.AreEqual(true, btree.FindNodeByKey(19).ToLeft);
        }

        [TestMethod]
        public void TestFind_5()
        {
            BST<int> btree = GetTree();

            Assert.AreEqual(false, btree.FindNodeByKey(6).ToLeft);
            Assert.AreEqual(false, btree.FindNodeByKey(-1).ToLeft);
            Assert.AreEqual(false, btree.FindNodeByKey(0).ToLeft);
            Assert.AreEqual(false, btree.FindNodeByKey(18).ToLeft);
            Assert.AreEqual(true, btree.FindNodeByKey(19).ToLeft);

            btree.AddKeyValue(19, 200);

            Assert.AreEqual(true, btree.FindNodeByKey(19).Node != null);
            Assert.AreEqual(true, btree.FindNodeByKey(19).NodeHasKey);
            Assert.AreEqual(false, btree.FindNodeByKey(19).ToLeft);
        }

        [TestMethod]
        public void TestFind_6()
        {
            BST<int> btree = GetTree();

            Assert.AreEqual(true, btree.FindNodeByKey(-2).ToLeft);
            Assert.AreEqual(true, btree.FindNodeByKey(5).ToLeft);
            Assert.AreEqual(false, btree.FindNodeByKey(30).ToLeft);

            btree.AddKeyValue(30, 200);

            Assert.AreEqual(true, btree.FindNodeByKey(28).ToLeft && !btree.FindNodeByKey(28).NodeHasKey);
            Assert.AreEqual(true, !btree.FindNodeByKey(31).ToLeft && !btree.FindNodeByKey(31).NodeHasKey);
        }

        [TestMethod]
        public void TestFinMinMax_1()
        {
            BST<int> btree = GetTree();

            Assert.AreEqual(-1, btree.FinMinMax(btree.FindNodeByKey(16).Node, false).NodeKey);
            Assert.AreEqual(23, btree.FinMinMax(btree.FindNodeByKey(16).Node, true).NodeKey);
        }

        [TestMethod]
        public void TestFinMinMax_2()
        {
            BST<int> btree = GetTree();

            Assert.AreEqual(6, btree.FinMinMax(btree.FindNodeByKey(4).Node, true).NodeKey);
        }

        [TestMethod]
        public void TestFinMinMax_3()
        {
            BST<int> btree = GetTree();

            Assert.AreEqual(17, btree.FinMinMax(btree.FindNodeByKey(18).Node, false).NodeKey);
            Assert.AreEqual(23, btree.FinMinMax(btree.FindNodeByKey(18).Node, true).NodeKey);
        }

        [TestMethod]
        public void TestFinMinMax_4()
        {
            BST<int> btree = GetTree();

            Assert.AreEqual(23, btree.FinMinMax(btree.FindNodeByKey(23).Node, false).NodeKey);
            Assert.AreEqual(23, btree.FinMinMax(btree.FindNodeByKey(23).Node, true).NodeKey);
        }

        [TestMethod]
        public void TestDelete_1()
        {
            BST<int> btree = GetTree();

            btree.DeleteNodeByKey(4);
            Assert.AreEqual(false, btree.FindNodeByKey(4).NodeHasKey);
            Assert.AreEqual(true, btree.FindNodeByKey(6).NodeHasKey);
            Assert.AreEqual(true, btree.FindNodeByKey(6).Node.LeftChild != null);
            Assert.AreEqual(true, btree.FindNodeByKey(6).Node.RightChild == null);
        }

        [TestMethod]
        public void TestDelete_2()
        {
            BST<int> btree = GetTree();

            btree.DeleteNodeByKey(2);
            Assert.AreEqual(false, btree.FindNodeByKey(2).NodeHasKey);
            Assert.AreEqual(true, btree.FindNodeByKey(4).NodeHasKey);
            Assert.AreEqual(true, btree.FindNodeByKey(3).NodeHasKey);
            Assert.AreEqual(true, btree.FindNodeByKey(0).NodeHasKey);
            Assert.AreEqual(true, btree.FindNodeByKey(3).Node.LeftChild != null);
            Assert.AreEqual(true, btree.FindNodeByKey(3).Node.RightChild == null);
            Assert.AreEqual(true, btree.FindNodeByKey(3).Node.Parent != null);
            Assert.AreEqual(true, btree.FindNodeByKey(3).Node.LeftChild.Parent != null);
        }

        [TestMethod]
        public void TestDelete_3()
        {
            BST<int> btree = GetTree();

            btree.DeleteNodeByKey(18);
            Assert.AreEqual(false, btree.FindNodeByKey(18).NodeHasKey);
            Assert.AreEqual(true, btree.FindNodeByKey(22).NodeHasKey);
            Assert.AreEqual(true, btree.FindNodeByKey(16).NodeHasKey);

            Assert.AreEqual(17, btree.FindNodeByKey(20).Node.LeftChild.NodeKey);
            Assert.AreEqual(22, btree.FindNodeByKey(20).Node.RightChild.NodeKey);
            Assert.AreEqual(16, btree.FindNodeByKey(20).Node.Parent.NodeKey);

            Assert.AreEqual(20, btree.FindNodeByKey(16).Node.RightChild.NodeKey);
            Assert.AreEqual(20, btree.FindNodeByKey(17).Node.Parent.NodeKey);
            Assert.AreEqual(20, btree.FindNodeByKey(22).Node.Parent.NodeKey);
            Assert.AreEqual(23, btree.FindNodeByKey(22).Node.RightChild.NodeKey);
            Assert.AreEqual(null, btree.FindNodeByKey(22).Node.LeftChild);
        }
        
        [TestMethod]
        public void TestDelete_4()
        {
            BST<int> btree = GetTree();

            btree.DeleteNodeByKey(22);
            Assert.AreEqual(false, btree.FindNodeByKey(22).NodeHasKey);
            Assert.AreEqual(true, btree.FindNodeByKey(23).NodeHasKey);
            Assert.AreEqual(20, btree.FindNodeByKey(23).Node.LeftChild.NodeKey);
            Assert.AreEqual(null, btree.FindNodeByKey(23).Node.RightChild);
        }

        [TestMethod]
        public void TestDelete_5()
        {
            BST<int> btree = GetTree();

            btree.DeleteNodeByKey(17);
            Assert.AreEqual(false, btree.FindNodeByKey(17));
        }

        [TestMethod]
        public void TestDelete_6()
        {
            BST<int> btree = GetTree();

            btree.DeleteNodeByKey(23);
            Assert.AreEqual(false, btree.FindNodeByKey(23).NodeHasKey);
        }

        [TestMethod]
        public void TestDelete_7()
        {
            BST<int> btree = GetTree();

            btree.DeleteNodeByKey(-1);
            Assert.AreEqual(false, btree.FindNodeByKey(-1).NodeHasKey);
        }

        [TestMethod]
        public void TestDelete_8()
        {
            BST<int> btree = GetTree();

            btree.DeleteNodeByKey(3);
            Assert.AreEqual(false, btree.FindNodeByKey(3).NodeHasKey);
        }

        [TestMethod]
        public void TestDelete_9()
        {
            BST<int> btree = GetTree();

            btree.DeleteNodeByKey(20);
            Assert.AreEqual(false, btree.FindNodeByKey(20).NodeHasKey);
        }

        [TestMethod]
        public void TestBit_1()
        {
            int y1 = 7 << 2;
            int y2 = y1 ^ 5;
            int y3 = y2 & 8;
            int u = 25 & 8;
        }

        // Tree scheme:
        /*
         *                16
         *             8     18
         *           4     17   22
         *         2   6       20  23
         *        1 3     
         *       0  
         *     -1   
         */
        private BST<int> GetTree()
        {
            BST<int> btree = new BST<int>(new BSTNode<int>(16, 100, null));
            btree.AddKeyValue(8, 100);
            btree.AddKeyValue(4, 100);
            btree.AddKeyValue(2, 100);
            btree.AddKeyValue(1, 100);
            btree.AddKeyValue(0, 100);
            btree.AddKeyValue(-1, 100);
            btree.AddKeyValue(3, 100);
            btree.AddKeyValue(6, 100);
            btree.AddKeyValue(18, 100);
            btree.AddKeyValue(17, 100);
            btree.AddKeyValue(22, 100);
            btree.AddKeyValue(23, 100);
            btree.AddKeyValue(20, 100);
            return btree;
        }
    }
}
