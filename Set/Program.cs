using System;
using System.Reflection.Metadata.Ecma335;
using Node;
using NUnit.Framework.Constraints;

namespace Set{

	public class Set<Type> where Type : IComparable{
		private List<Type> set;

		// Instantianes a new Set<Type> data type.
		public Set(){
			set = new List<Type>();
			Console.WriteLine("Set Created! []");
		}

		// Instantiates a new Set<Type> data type, accepting a previously defined List<Type> object. Ensures the predefined List follows the properties of this Set.
		public Set(List<Type> set){
			this.set = set;
			EnsureSetProperties();
			Console.WriteLine("Set Created! " + this);
		}

		/*	Cleans up the internal List in order to preserve the properties of a Set as
		* 	defined in the Homework 1 instructions
		*/
		private void EnsureSetProperties()
		{
			
			if(set.Count != 1){
				set.Sort();
				int index = 1;
				while(index < set.Count){
                    if (set[index] != null && set[index].Equals(set[index-1]))
						set.RemoveAt(index);
					else
						index++;
                }
			}
		}

		// Returns the size of the Set
		public int Size()
		{
			return set.Count;
		}

		// Converts the Set into an array of elements
		public Type[] ToArray()
		{
			return set.ToArray();
		}

        public override string ToString()
        {
			String ret = "[";
            foreach(Type item in set)
			{
				ret += " " + item;
			}
			return ret + " ]";
        }

        

        // Adds a new element into its correctly sorted place in the Set, as long as it does not exist within the Set.
        public Set<Type> Add(Type element)
		{
			if (!set.Contains(element))
			{
				set.Add(element);
				set.Sort();
			}
			Console.WriteLine("Added " + element);
			Console.WriteLine(this);
			return this;
        }

		// Takes the union of this Set and another previously defined Set and returns it. 
		// Union meaning if at least one of the two sets has it, it will appear in the output Set
		public Set<Type> Union(Set<Type> other){
			int index = 0;
			Set<Type> newSet = new Set<Type>();

			//iterates through both Sets at the same time and adds each element into the new Set (Set.add() ensures there is no repitition)
			while(index < set.Count || index < other.Size()){
				if(index < set.Count)
					newSet.Add(set[index]);
				if(index < other.Size())
					newSet.Add(other[index]);
				index++;
			}
	
			Console.Write(this + " union " + other + " = " + newSet);
			set = newSet.ToArray().ToList();

			return this;
		}

		/*	Takes the intersection of this Set and another previously defined Set, then returns the result. 
		*	Intersection meaning the output set contains only the elements that both sets have in common.
		*/	
		public Set<Type> Intersection(Set<Type> other)
		{
			Set<Type> newSet = new Set<Type>();
			int ptr1 = 0, ptr2 = 0;

			// Due to the properties of this Set datatype, we can use a two pointer solution, where each pointer iterates through the list, and
			// the one that is found to have a lesser value increases by 1. In this example, if they are the same, the element is added to the new Set.
			while(ptr1 < set.Count && ptr2 < other.Size())
			{
				int comparison = set[ptr1].CompareTo(other[ptr2]);
				if(comparison == 0)
				{
					newSet.Add(set[ptr1]);
					ptr1++;
					ptr2++;
				} else if(comparison > 0)
				{
					ptr2++;
				} else {
					ptr1++;
				}
			}
			Console.Write(this + " intersection " + other + " = " + newSet);
			set = newSet.ToArray().ToList();
			return newSet;
		}

		/*	Subtracts the previously definted Set with this Set and then returns the result. 
		*	Subtracting meaning all of the elements appearing in both Sets are removed from this set.
		*/	
		public Set<Type> Subtract(Set<Type> other)
		{
			Set<Type> newSet = new Set<Type>();
			int ptr1 = 0, ptr2 = 0;

			// Due to the properties of this Set datatype, we can use a two pointer solution, where each pointer iterates through the list, and
			// the one that is found to have a lesser value increases by 1. In this example, if they are the same, the element is skipped while the other elements are added.
			while(ptr1 < set.Count && ptr2 < other.Size())
			{
				int comparison = set[ptr1].CompareTo(other[ptr2]);
				if(comparison > 0)
				{
					ptr2++;
				} else if(comparison < 0)
				{
					newSet.Add(set[ptr1]);
					ptr1++;
				} else {
					ptr1++;
					ptr2++;
				}
			}
			for(int i = ptr1; i < set.Count; i++)
			{
				newSet.Add(set[ptr1]);
			}
			Console.Write(this + " - " + other + " = " + newSet);
			set = newSet.ToArray().ToList();
			return newSet;
		}


		// Allows the Set to be accessed by the indexer operator.
		public Type this[int index]
		{
			get => set[index];
			set => set[index] = value;
		}

		// The operators defined below allow the public methods to be called by using their corresponding operator.
		public static Set<Type> operator &(Set<Type> set1, Set<Type> set2)
		{	
			return set1.Intersection(set2);
		}

		public static Set<Type> operator |(Set<Type> set1, Set<Type> set2)
		{
			return set1.Union(set2);
		}

		public static Set<Type> operator +(Set<Type> set, Type newElement)
		{
			return set.Add(newElement);
		}

		public static Set<Type> operator -(Set<Type> set1, Set<Type> set2)
		{
			return set1.Subtract(set2);
		}

		// Logic for true/false is the Set is "true" if it contains elements, and false if it is empty.
		public static bool operator true(Set<Type> set)
		{
			return set.Size() != 0;
		}

        public static bool operator false(Set<Type> set)
        {
			return set.Size() == 0;
        }

		// The below operators define when two sets are equal. If both sets have the same size and element values, they are equivalent. And vice versa.
		public static bool operator ==(Set<Type> set1, Set<Type> set2)
		{
			for(int i = 0; i < set1.Size(); i++)
			{
				if(i >= set2.Size() || !set1[i].Equals(set2[i]))
					return false;
			}
			return true;
		}

		public static bool operator !=(Set<Type> set1, Set<Type> set2)
		{
			for(int i = 0; i < set1.Size(); i++)
			{
				if(i >= set2.Size() || !set1[i].Equals(set2[i]))
					return true;
			}
			return false;
		}
    }
}
