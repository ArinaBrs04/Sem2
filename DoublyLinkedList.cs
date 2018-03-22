using System;
using System.IO;

namespace Structure
{
    class DoublyLinkedList
    {
        private Node First;
        private Node Current;
        private Node Last;
        private uint size;
        public DoublyLinkedList()
        {
            size = 0;
            First = Current = Last = null;
        }
        public DoublyLinkedList(uint SIZE)
        {
            size = SIZE;
            First = Current = Last = null;
        }
        public void InsertIndex(object newElement, uint index)
        {
            if (index < 1 || index > size) throw new InvalidOperationException();
            else if (index == 1) Push_Front(newElement);
            else if (index == size)
            {
                Push_Back(newElement);
            }
            else
            {
                uint count = 1;
                Current = First;
                while (Current != null && count != index)
                {
                    Current = Current.Next;
                    count++;
                }
                Node newNode = new Node(newElement);
                Current.Prev.Next = newNode;
                newNode.Prev = Current.Prev;
                Current.Prev = newNode;
                newNode.Next = Current;
            }
        }
        //новый элемент в начало списка
        public void Push_Front(object newElement)
        {
            Node newNode = new Node(newElement);
            if (First == null) First = Last = newNode;
            else
            {
                newNode.Next = First;
                //First и newNode указывают на один и тот же объект
                First = newNode;
                newNode.Next.Prev = First;
            }
            Count++;
        }
        //элемент из начала списка
        public Node Pop_Front()
        {
            if (First == null) throw new InvalidOperationException();
            else
            {
                //Создаем объект где будет храниться первый
                Node temp = First;
                if (First.Next != null)
                {
                    // То очищаем ссылки для первого
                    First.Next.Prev = null;
                }
                First = First.Next;
                Count--;
                return temp;
            }
        }
        public void Push_Back(object newElement)
        {
            //Новый объект типа узла
            Node newNode = new Node(newElement);
            if (First == null) First = Last = newNode;
            else
            {
                Last.Next = newNode;
                newNode.Prev = Last;
                Last = newNode;
            }
            Count++;
        }
        //элемент из конца списка
        public Node Pop_Back()
        {
            if (Last == null) throw new InvalidOperationException();
            else
            {
                // Во временный объект заносим последний
                Node temp = Last;
                if (Last.Prev != null) Last.Prev.Next = null;
                Last = Last.Prev;
                Count--;
                return temp;
            }
        }
        //size
        public uint Count
        {
            get { return size; }
            set { size = value; }
        }
        public double[] BubbleSort(double[] A)
        {
            for (int i = 0; i < A.Length; i++)
            {
                for (int j = 0; j < A.Length - i - 1; j++)
                {
                    if (A[j] > A[j + 1])
                    {
                        double temp = A[j];
                        A[j] = A[j + 1];
                        A[j + 1] = temp;
                    }
                }
            }
            return A;
        }
        public void Sort()
        {
            if (First == null)
            {
                Console.WriteLine("Список пуст");
                return;
            }
            Current = First;
            uint count = 1;
            while (Current != null)
            {
                count++;
                Current = Current.Next;
            }
            double[] array = new double[count];
            count = 1;
            Current = First;
            while (Current != null)
            {
                array[count] = LengthValue(Current);
                count++;
                Current = Current.Next;
            }
            //массив отсортирован
            array = BubbleSort(array);
            count = 1;
            Current = First;
            for (uint i = 0; i < array.Length; i++)
            {
                while (Current != null)
                {
                    if (array[i] == LengthValue(Current)) Console.WriteLine(Current.Value.ToString());
                    Current = Current.Next;
                }
                Current = First;
            }
        }
        public double LengthValue(Node elem)
        {
            double length = 0;
            //разбиваем на массив строк 
            string[] s_2 = elem.Value.ToString().Split(';');
            length = Math.Sqrt(Math.Pow((Convert.ToDouble(s_2[2]) - Convert.ToDouble(s_2[0])), 2) +
                Math.Pow((Convert.ToDouble(s_2[3]) - Convert.ToDouble(s_2[1])), 2));
            return length;
        }
        public void LengthList(double o, double t)
        {
            DoublyLinkedList linkedList2 = new DoublyLinkedList();
            if (First == null)
            {
                Console.WriteLine("Список пуст");
                return;
            }
            Current = First;
            while (Current != null)
            {
                // Записываем узел в переменную
                string s = Current.Value.ToString();
                // Разбиваем ее на массив строк
                string[] s_2 = s.Split(';');
                double len = Math.Sqrt(Math.Pow((Convert.ToDouble(s_2[2]) -
                    Convert.ToDouble(s_2[0])), 2) + Math.Pow((Convert.ToDouble(s_2[3]) - Convert.ToDouble(s_2[1])), 2));
                if ((len > o) && (len < t))
                {
                    linkedList2.Push_Back(s);
                }
                Current = Current.Next;
            }
            linkedList2.Show();
        }
        public void AngleList()
        {
            DoublyLinkedList linkedList2 = new DoublyLinkedList();
            if (First == null)
            {
                Console.WriteLine("Список пуст");
                return;
            }
            Current = First;
            while (Current != null)
            {
                string s = Current.Value.ToString();
                string[] s_2 = s.Split(';');
                double len = Math.Atan((Convert.ToDouble(s_2[3]) -
                    Convert.ToDouble(s_2[1])) / (Convert.ToDouble(s_2[2]) - Convert.ToDouble(s_2[0])));
                if ((len == 30) || (len == 45))
                {
                    linkedList2.Push_Back(s);
                }
                Current = Current.Next;
            }
            linkedList2.Show();
        }
        public void Show()
        {
            if (First == null)
            {
                Console.WriteLine("Список пуст");
                return;
            }
            Current = First;
            uint count = 1;
            while (Current != null)
            {
                Console.WriteLine("Элемент " + count.ToString() + " : " + Current.Value.ToString());
                count++;
                Current = Current.Next;
            }
        }
    }
}