using System;

public class List{
	public int[] list;
	private int size;

	public List(){
		list = [];
		size = 0;
	}

	public List(int[] arr){
		list = arr;
		size = arr.Length;
	}

	public static List operator +(List l, int elem){
		int return_size = 1+l.size;
		int[] return_list = new int[return_size];

		for(int i = 0; i < l.size; i++){
			return_list[i] = l.list[i];
		}
		return_list[return_size-1] = elem;
		return new List(return_list);
	}

	public static List operator +(List l1, List l2){
		foreach(int val in l2.list){
			l1 += val;
		}
		return l1;
	}



    public override string ToString()
    {
		string return_string = "[";
		foreach(int val in list){
			return_string += $"{val},";
		}

		return_string += "]";

        return return_string;
    }



}

public class ListTest{
	public static void Main(){
		int[] arr = {0,1,2,3};
		int elem = 5;

		List l = new List(arr);
		Console.WriteLine(l);

		l = l + elem;
		Console.WriteLine(l);

		l = l + l;
		Console.WriteLine(l);

	}
}