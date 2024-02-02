using System;
using Node;

namespace Set{
	public class Set<Element>{
		private Element[] set;

		public Set(){

		}

		public Set(Element[] set){

		}

		public static bool operator true(Set<Element> set){
			return true;
		}

		public static bool operator false(Set<Element> set){
			return true;
		}
	}
}
