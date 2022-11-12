using System;

class Fsihing_interaction{

	static void Main(){
		
		string[] fishes = {"Sardine", "Carp", "Northern pike", "Salmon", "Swordfish"};																								
		var r = new Random();
		int bucket_cap = 10, success, fish;  //bucket of fishes capacity, success of catching a fish and which one (fish)
		string[] bucket = new string[bucket_cap];
		
		for (int i = 0; i < bucket_cap; i++){	//Let's start fishing!!!
			success = r.Next(0,2);
			if(success == 0){} //No fish mate :(
			else{
				fish = r.Next(1,101);
				if(fish <= 50) bucket[i] = fishes[0];
				if(fish <= 75 && fish > 50) bucket[i] = fishes[1];
				if(fish <= 87 && fish > 75) bucket[i] = fishes[2];
				if(fish <= 95 && fish > 87) bucket[i] = fishes[3];
				if(fish > 95) bucket[i] = fishes[4];
			}
		}
		foreach(string fished in bucket){
			if(fished == null){}
			else Console.WriteLine(fished);
		}
	}	
}
