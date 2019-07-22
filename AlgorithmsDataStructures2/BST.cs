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
                if (Root.LeftChild != null || Root.RightChild != null)
                    return FindNodeByKey(key, Root, bst_find);
                bst_find.NodeHasKey = Root.NodeKey == key;
                bst_find.ToLeft = Root.NodeKey > key;
                return bst_find;
            }
            // ищем в дереве узел и сопутствующую информацию по ключу
            return null;
        }

        public bool AddKeyValue(int key, T val)
        {
            if (Root == null)
            {
                Root = new BSTNode<T>(key, val, null);
                return true;
            }
            BSTFind<T> bst_find = FindNodeByKey(key);
            if (bst_find.Node != null && !bst_find.NodeHasKey)
            {
                if (bst_find.ToLeft) bst_find.Node.LeftChild = new BSTNode<T>(key, val, bst_find.Node);
                else bst_find.Node.RightChild = new BSTNode<T>(key, val, bst_find.Node);
                return true;
            }
            else if (bst_find.Node == null)
            {
                if (bst_find.ToLeft) Root.LeftChild = new BSTNode<T>(key, val, Root);
                else Root.RightChild = new BSTNode<T>(key, val, Root);
                return true;
            }
            // добавляем ключ-значение в дерево
            return false; // если ключ уже есть
        }

        public BSTNode<T> FinMinMax(BSTNode<T> FromNode, bool FindMax)
        {
            BSTNode<T> MinMax = FromNode;

            if (MinMax != null)
            {
                if (FindMax)
                    while (MinMax.RightChild != null)
                        MinMax = MinMax.RightChild;
                else
                    while (MinMax.LeftChild != null)
                        MinMax = MinMax.LeftChild;

                return MinMax;
            }
            // ищем максимальное/минимальное в поддереве
            return null;
        }

        public bool DeleteNodeByKey(int key)
        {
            BSTFind<T> bst_find = FindNodeByKey(key);
            if (bst_find.NodeHasKey)
            {
                BSTNode<T> node = bst_find.Node;
                BSTNode<T> successor;
                if (node.RightChild != null)
                {
                    successor = FindSuccessor(node.RightChild);
                    successor.Parent = node.Parent;

                    successor.LeftChild = node.LeftChild;
                    successor.RightChild = node.RightChild;

                    ReplaceChildWith(node, successor);
                }
                else if (node.LeftChild != null)
                {
                    node.LeftChild.Parent = node.Parent;

                    ReplaceChildWith(node, node.LeftChild);
                }
                
                return true;
            }
            // удаляем узел по ключу
            return false; // если узел не найден
        }

        public int Count()
        {
            if (Root != null)
                return CountNodes(Root.RightChild) + CountNodes(Root.LeftChild) + 1;
            return 0; // количество узлов в дереве
        }

        private BSTFind<T> FindNodeByKey(int key, BSTNode<T> node, BSTFind<T> bst_find)
        {
            bst_find.Node = node;
            if (node.NodeKey > key)
            {
                if (node.LeftChild != null) return FindNodeByKey(key, node.LeftChild, bst_find);
                bst_find.ToLeft = true;
                return bst_find;
            }
            else
            {
                if (node.NodeKey == key) bst_find.NodeHasKey = true;
                else if (node.RightChild != null) return FindNodeByKey(key, node.RightChild, bst_find);
                return bst_find;
            }
        }
        
        private BSTNode<T> FindSuccessor(BSTNode<T> node)
        {
            while (node.LeftChild != null || node.RightChild != null)
            {
                if (node.LeftChild != null) node = node.LeftChild;
                else if (node.RightChild != null)
                {
                    //node.Parent.LeftChild = node.RightChild;
                    node.RightChild.Parent = node.Parent;
                    return node;
                }
            }
            return node;
        }

        private void ReplaceChildWith(BSTNode<T> child, BSTNode<T> new_child)
        {
            if (child.NodeKey < child.Parent.NodeKey) child.Parent.LeftChild = new_child;
            else child.Parent.RightChild = new_child;
        }

        private void MoveInsteadOf(BSTNode<T> successor, BSTNode<T> node)
        {
            if (node.RightChild != null) successor.RightChild = node.RightChild;
            if (node.LeftChild != null) successor.LeftChild = node.LeftChild;

            if (node.Parent != null)
            {
                if (node.Parent.LeftChild != null && node.Parent.LeftChild.NodeKey == node.NodeKey) node.Parent.LeftChild = successor;
                else if (node.Parent.RightChild != null && node.Parent.RightChild.NodeKey == node.NodeKey) node.Parent.RightChild = successor; 
            }
        }

        private int CountNodes(BSTNode<T> node)
        {
            if (node != null)
                return CountNodes(node.LeftChild) + CountNodes(node.RightChild) + 1;
            return 0;
        }
    }
}