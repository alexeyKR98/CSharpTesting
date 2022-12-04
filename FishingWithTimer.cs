using System;
using System.Timers;

class FishingWithTimer{
	
	static int ticks = 0;
	static int getLoot = 10;
	static Random random = new Random();
	
	static void Main(){
		string[] fishes = {"Sardine", "Carp", "Northern pike", "Salmon", "Swordfish"};	
		string[] bucket = new string[10];
		Timer getFish = new Timer (2000);
		byte fishCounter = 0;
		while(fishCounter < 10){
			Timer fishingTimer = new Timer(4000);
			ticks = 0;
			getLoot = 10;
			
			//Throwing the fishing rod
			do{
			Console.WriteLine("");
			Console.WriteLine("Press enter to throw the fishing rod: ");
			}
			while(Console.ReadKey(true).Key	!= ConsoleKey.Enter);
			
			//Wating step
			Console.WriteLine("");
			Console.Write("Waiting ");
			Fishing(fishingTimer);
			while(ticks < 4 && getLoot >= 3){}
			fishingTimer.Stop();
			Console.WriteLine("");
			Console.WriteLine("");
			
			//Taking out the fishing rod with loot
			if(getLoot < 3){
				ticks = 0;
				Console.Write("Something has bittne, press enter to take out the fishing rod: ");
				Timer takingOutTimer = new Timer(2000);
				TakeOutTheFishingRod(takingOutTimer);
				while(Console.ReadKey(true).Key	!= ConsoleKey.Enter);
				takingOutTimer.Stop();
				if(ticks < 2)
					Loot(bucket, fishCounter, fishes);
				else{
					Console.WriteLine("You got nothing...");
					Console.WriteLine("");
				}
			}
			else{
				Console.WriteLine("You got nothing...");
				Console.WriteLine("");
			}	
		}
		for(int i = 0; i < fishCounter; i++){
			Console.WriteLine("");
			Console.WriteLine((i + 1) + ") " + bucket[i]);
		}
	}
	static void Fishing(Timer fishingTimer){
		fishingTimer.Elapsed += Waiting;
		fishingTimer.AutoReset = true;
		fishingTimer.Enabled = true;
	}
	
	static void Waiting(Object source, ElapsedEventArgs e){
		
		ticks++;
		if(ticks < 4)
			Console.Write(". ");
		getLoot = random.Next(1, 11);
	}
	
	static void TakeOutTheFishingRod(Timer takingOutTimer){
		takingOutTimer.Elapsed += Action;
		takingOutTimer.AutoReset = true;
		takingOutTimer.Enabled = true;
	}
	
	static void Action(Object source, ElapsedEventArgs e){
		ticks++;
	}
	
	static void Loot(string[] bucket, byte fishCounter, string[] fishes){
		fishCounter++;
		int fish = random.Next(1, 101);
		
		if(fish <= 50){
			Console.WriteLine("You got a " + fishes[0]);
			bucket[fishCounter] = fishes[0];
		}
		if(fish <= 75 && fish > 50){
			Console.WriteLine("You got a " + fishes[1]);
			bucket[fishCounter] = fishes[1];
		}
		if(fish <= 87 && fish > 75){
			Console.WriteLine("You got a " + fishes[2]);
			bucket[fishCounter] = fishes[2];
		}
		if(fish <= 95 && fish > 87){
			Console.WriteLine("You got a " + fishes[3] + "!");
			bucket[fishCounter] = fishes[3];
		}
		if(fish > 95){
			Console.WriteLine("Congrats, you got a " + fishes[4] + "!!!");
			bucket[fishCounter] = fishes[4];
		}
	}
}


