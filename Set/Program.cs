using System;
using Node;

namespace Set{
	public class Set<Element>{
		private Element[] set;

		public Set(){
			set = [];
		}

		public Set(Element[] set){
			this.set = set;
		}
	}
}
