using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermExample
{
    class BinarySourceTree<T> where T:IComparable
    {
          /*                                   BİNARY SOURCE TREE 
                                              ___ ___________ ____
                                             |   |           |    | 
                                             |   |           |    |
                                             |   |           |    |
                                             |   |           |    |
                                             |   |   ROOT    |    |
                                             |   |           |    |
                                             |   |           |    |
                                             |___|___________|____|
                                             LEFT    VALUE    RIGHT  
                      IF ROOT>NEWNODE        /                    \    IF NEWNODE>ROOT
                        ADD LEFT            /                      \      ADD RIGHT
                      END                  /                        \  END
                      ___ ___________ ____/                          \___ ___________ ____  
                     |   |           |    |                          |   |           |    |
                     |   |           |    |                          |   |           |    | 
                     |   |           |    |                          |   |           |    |
                     |   |           |    |                          |   |           |    |
                     |   |  BSTNODE  |    |                          |   |  BSTNODE  |    |
                     |   |           |    |                          |   |           |    |
                     |   |           |    |                          |   |           |    |
                     |___|___________|____|                          |___|___________|____|
                     LEFT    VALUE    RIGHT                          LEFT    VALUE    RIGHT
         */

        BSTNODE<T> root;
        //İlk adımda sol alt ağaç sondan başlayarak dolaşılır. İkinci adımda sağ alt ağaç sondan başlayarak dolaşılır.Sonra köke uğranır.
        public void inOrder()
        {
            inOrder(root);
        }
        private void inOrder(BSTNODE<T> temp)
        {
            if (temp != null)
            {
                inOrder(temp.Left);
                Console.WriteLine(temp.Value);
                inOrder(temp.Right);
            }
        }
        //İlk adımda köke uğranır. Sol alt ağaç kökten başlayarak dolaşılır. Son adımda sol alt ağaç kökten başlayarak dolaşılır.
        public void preOrder()
        {
            preOrder(root);
        }
        private void preOrder(BSTNODE<T> temp)
        {
            if (temp != null)
            {
                Console.WriteLine(temp.Value);
                preOrder(temp.Left);
                preOrder(temp.Right);
            }
        }
        //İlk adımda sol alt ağaç sondan başlayarak dolaşılır. İkinci adımda sağ alt ağaç sondan başlayarak dolaşılır . Son adımda ise köke uğranır.
        public void postOrder()
        {
            postOrder(root);
        }
        private void postOrder(BSTNODE<T> temp)
        {
            if (temp != null)
            {
                postOrder(temp.Left);
                postOrder(temp.Right);
                Console.WriteLine(temp.Value);
            }
        }
        //Binary source tree yapısına eleman eklemeyi sağlar. Önce parentini bulur daha sonra bu değer büyükse sağ küçükse sol tarafa eklenmesini sağlar.
        public void Add(T val)
        {

            if (root == null)
                root = new BSTNODE<T>(val);
            else
            {
                BSTNODE<T> iterator = root, parent = root;

                while (iterator != null)
                {
                    parent = iterator;
                    iterator = iterator.Value.CompareTo(val) == 1 ? iterator.Left : iterator.Right;
                }
                if (parent.Value.CompareTo(val) == 1)
                    parent.Left = new BSTNODE<T>(val);
                else
                    parent.Right = new BSTNODE<T>(val);
            }
        }
        //Binary Source Tree içerisinde arama methodu
        public bool Search(T val)
        {
            BSTNODE<T> iterator = root;
            while (iterator != null)
            {
                if (iterator.Value.CompareTo(val) == 0)
                    return true;
                iterator = iterator.Value.CompareTo(val) == 1 ? iterator.Left : iterator.Right;
            }
            return false;
        }
        public BSTNODE<T> findParent(T val)
        {
            if (!Search(val) || root.Value.CompareTo(val) == 0)
                return null;
            BSTNODE<T> iterator = root, parent = root;
            while (iterator.Value.CompareTo(val) != 0)
            {
                parent = iterator;
                iterator = iterator.Value.CompareTo(val) == 1 ? iterator.Left : iterator.Right;
            }
            return parent;
        }
        //En küçük node bulma 
        public BSTNODE<T> findMinNode(BSTNODE<T> tempRoot)
        {
            if (tempRoot == null)
                return default(BSTNODE<T>);
            BSTNODE<T> iterator = tempRoot;
            while (iterator.Left != null)
                iterator = iterator.Left;
            return iterator;
        }
        //En küçük nodun değerini bulma
        public T findMin()
        {
            if (root == null)
                return default(T);
            BSTNODE<T> iterator = root;
            while (iterator.Left != null)
                iterator = iterator.Left;
            return iterator.Value;
        }
        //En büyük nodenin değerni bulma
        public T findMax()
        {
            if (root == null)
                return default(T);
            BSTNODE<T> iterator = root;
            while (iterator.Right != null)
                iterator = iterator.Right;
            return iterator.Value;
        }
        //Aranan değerin nodunu getirme
        public BSTNODE<T> FindNode(T val)
        {
            if (root == null)
                return null;
            BSTNODE<T> iterator = root;
            while (iterator != null)
            {
                if (iterator.Value.CompareTo(val) == 0)
                    return iterator;
                else if (iterator.Value.CompareTo(val) == 1)
                    iterator = iterator.Left;
                else
                    iterator = iterator.Right;
            }
            return null;
        }
        //Toplam Node sayısı
        public int NodeCount()
        {
            return NodeCount(root);
        }
        private int NodeCount(BSTNODE<T> tempRoot)
        {
            if (tempRoot == null)
                return 0;
            return NodeCount(tempRoot.Left) + 1 + NodeCount(tempRoot.Right);
        }
        //verilen değerin parentinin nodesini getirme
        //Successor bode bulma methodu
        public BSTNODE<T> findSuccessor(BSTNODE<T> treeNode)
        {
            if (treeNode == null)
                return null;
            if (treeNode.Right != null)//node'un saginda eleman varsa
            {
                return findMinNode(treeNode.Right);
            }
            //sag child yoksa
            BSTNODE<T> parent = findParent(treeNode.Value);
            BSTNODE<T> rIterator = treeNode;
            while (parent != null && parent.Right == rIterator)
            {
                rIterator = parent;
                parent = findParent(rIterator.Value);
            }
            return parent;
        }
        //Yaprakmı?
        public bool isLeaf(BSTNODE<T> treeNode)
        {
            return treeNode.Left == null && treeNode.Right == null;
        }
        //Tek çocuklumu?
        public bool hasOneChild(BSTNODE<T> treeNode)
        {
            return (treeNode.Left == null && treeNode.Right != null)
                || (treeNode.Left != null && treeNode.Right == null);
        }
        //Silme methodu
        public void Delete(T val)
        {
            if (!Search(val))
                Console.WriteLine("Deger yok");
            else
            {
                BSTNODE<T> deleteNode = FindNode(val);
                BSTNODE<T> parent = findParent(val);
                if (isLeaf(deleteNode))//silinecek yapraksa
                {
                    if (deleteNode == root)
                        root = null;
                    else if (parent.Left == deleteNode)
                        parent.Left = null;
                    else
                        parent.Right = null;
                }
                else if (hasOneChild(deleteNode))//tek cocuklu ise
                {
                    if (deleteNode == root)
                        root = root.Left != null ? root.Left : root.Right;
                    else if (parent.Left == deleteNode)
                        parent.Left = deleteNode.Left != null ? deleteNode.Left : deleteNode.Right;
                    else
                        parent.Right = deleteNode.Left != null ? deleteNode.Left : deleteNode.Right;
                }
                else//iki cocugu varsa
                {
                    BSTNODE<T> successor = findSuccessor(deleteNode);
                    Delete(successor.Value);
                    deleteNode.Value = successor.Value;
                }

            }
        }
       }
}
