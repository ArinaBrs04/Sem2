namespace Structure
{
    public class Node
    {
        private object _Data;
        private Node _Next;
        private Node _Prev;
        public object Value
        {
            get { return _Data; }
            set { _Data = value; }
        }
        public Node(object Data)
        {
            _Data = Data;
        }
        public Node Next
        {
            get { return _Next; }
            set { _Next = value; }
        }
        public Node Prev
        {
            get { return _Prev; }
            set { _Prev = value; }
        }
    }
}