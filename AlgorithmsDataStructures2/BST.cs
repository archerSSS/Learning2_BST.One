using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class BSTNode<T>
    {
        public int NodeKey; // ключ узла
        public T NodeValue; // значение в узле
        public BSTNode<T> Parent; // родитель или null для корня
        public BSTNode<T> LeftChild; // левый потомок
        public BSTNode<T> RightChild; // правый потомок	

        public BSTNode(int key, T val, BSTNode<T> parent)
        {
            NodeKey = key;
            NodeValue = val;
            Parent = parent;
            LeftChild = null;
            RightChild = null;
        }
    }



    // 1. node
    // 2. true или false если родительский
    // 3. true если родительский 
    // промежуточный результат поиска
    public class BSTFind<T>
    {
        // null если не найден узел, и в дереве только один корень
        public BSTNode<T> Node;

        // true если узел найден
        public bool NodeHasKey;

        // true, если родительскому узлу надо добавить новый левым
        public bool ToLeft;

        public BSTFind() { Node = null; }
    }

    public class BST<T>
    {
        BSTNode<T> Root; // корень дерева, или null

        public BST(BSTNode<T> node)
        {
            Root = node;
        }

        public BSTFind<T> FindNodeByKey(int key)
        {
            if (Root != null)
            {
                BSTFind<T> bst_find = new BSTFind<T>();
                if (Root.NodeKey == key)
                {
                    bst_find.ToLeft = Root.LeftChild == null;
                    if (Root.LeftChild != null || Root.RightChild != null)
                    {
                        if (Root.LeftChild != null && Root.RightChild != null) bst_find.NodeHasKey = true;
                        bst_find.Node = Root;   
                    }
                }

                else if (Root.NodeKey > key)
                    if (Root.LeftChild != null) bst_find = FindNodeByKey(key, Root.LeftChild, bst_find);
                    else bst_find.ToLeft = true;

                else if (Root.RightChild != null)
                    bst_find = FindNodeByKey(key, Root.RightChild, bst_find);

                return bst_find;
            }
            // ищем в дереве узел и сопутствующую информацию по ключу
            return null;
        }

        public bool AddKeyValue(int key, T val)
        {
            if (Root != null)
            {
                BSTNode<T> node = Root;

                BSTFind<T> bst_find = FindNodeByKey(key);
                if (!bst_find.NodeHasKey)
                {
                    if (bst_find.Node != null)
                    {
                        if (!bst_find.NodeHasKey && bst_find.ToLeft)
                        {
                            bst_find.Node.LeftChild = new BSTNode<T>(key, val, bst_find.Node);
                            return true;
                        }
                        else if (bst_find.NodeHasKey && !bst_find.ToLeft)
                        {
                            bst_find.Node.RightChild = new BSTNode<T>(key, val, bst_find.Node);
                            return true;
                        }
                    }
                }
            }
            // добавляем ключ-значение в дерево
            return false; // если ключ уже есть
        }

        public BSTNode<T> FinMinMax(BSTNode<T> FromNode, bool FindMax)
        {
            // ищем максимальное/минимальное в поддереве
            return null;
        }

        public bool DeleteNodeByKey(int key)
        {
            // удаляем узел по ключу
            return false; // если узел не найден
        }

        public int Count()
        {
            return 0; // количество узлов в дереве
        }

        private bool KeyBiggerThen(int nodeKey, int key)
        {
            if (nodeKey > key) return true;
            return false;
        }

        private BSTFind<T> FindNodeByKey(int key, BSTNode<T> node, BSTFind<T> bst_find)
        {
            bst_find.Node = node;
            
            if (node.NodeKey == key)
            {
                bst_find.NodeHasKey = node.LeftChild != null && node.RightChild != null;
                return bst_find;
            }
            else if (node.NodeKey > key)
            {
                if (node.LeftChild != null) return FindNodeByKey(key, node, bst_find);
                bst_find.ToLeft = true;
            }
            return bst_find;
            return null;
        }
    }
}