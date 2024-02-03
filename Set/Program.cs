using System;
using Node;

namespace Set{
	public class Set<IComparable>{
		private List<IComparable> set;

		public Set(){
			set = new List<IComparable>();
		}

		public Set(List<IComparable> set){
			this.set = set;
		}

	}
}
