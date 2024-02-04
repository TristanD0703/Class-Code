using System.Runtime.CompilerServices;

namespace Node{

	public class Node : IComparable{
		private int val;
		public int Val{
			get => val;
		}

		public Node next;
		public Node previous;

		public Node(){
			val = -1;
			next = null;
			previous = null;
		}

		public Node(int val){
			this.val = val;
			next = null;
			previous = null;
		}

		public static bool operator ==(Node node1, Node node2){
			return node1.Val == node2.Val;
		}

		public static bool operator !=(Node node1, Node node2){
			return node1.Val != node2.Val;
		}

		public override bool Equals(Object obj){
			Node n = (Node)obj;
			return n.Val == this.Val;
		}

        public int CompareTo(Object obj)
        {
			Node n = (Node)obj;
            if (n.Val == this.Val){
				return 0;
			}
			else if(n.Val <= this.Val){
				return 1;
			}
			return -1;
        }
    }
}

public class NodeTester{
	public static void Main(){}
}