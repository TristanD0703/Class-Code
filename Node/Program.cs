namespace Node{

	public class Node<Value>{
		private Value? val;
		public Value? Val{
			get => val;
		}

		public Node<Value>? next;
		public Node<Value>? previous;

		public Node(){
			val = default(Value);
			next = null;
			previous = null;
		}

		public Node(Value val){
			this.val = val;
			next = null;
			previous = null;
		}

	}
}

public class NodeTester{
	public static void Main(){}
}