using System;
using System.Timers;

class FishingWithTimer{
	
	static int ticks = 0;
	static int ticks2 = 0;
	static int getLoot = 10;
	static bool getFish = false, noRepeat = true;
	static Random random = new Random();
	static Timer fishingTimer = new Timer(4000);
	
	static void Main(){
		Fishing();
		string[] fishes = {"Sardine", "Carp", "Northern pike", "Salmon", "Swordfish"};	
		string[] bucket = new string[10];
		byte fishCounter = 0;
		ConsoleKeyInfo button;
		while(fishCounter < 10){
			ticks = 0;	//ticks for waiting method
			ticks2 = 0;	//ticks for control the time to get out the fishing rod
			getLoot = 10; //need it to enter the first if statment in the timer event and modify the odds of getting the fish
			getFish = false;
			noRepeat = true;
			//Throwing the fishing rod
			do{
			Console.WriteLine("");
			Console.WriteLine("Press Up Arrow to throw the fishing rod: ");
			button = Console.ReadKey(true);
			}
			while(button.Key != ConsoleKey.UpArrow);
			fishingTimer.Start();
			
			//Wating step
			Console.WriteLine("");
			Console.Write("Waiting ");
			while(ticks < 3 && getLoot != 20){Console.ReadKey(true);}
			fishingTimer.Stop();
			Console.WriteLine("");
			if(getFish){
				Loot(bucket, ref fishCounter, fishes);
				Console.WriteLine("");
			}
		}
		for(int i = 0; i < fishCounter; i++){
			Console.WriteLine("");
			Console.WriteLine((i + 1) + ") " + bucket[i]);
		}
		Console.ReadKey(true);
	}
	static void Fishing(){
		fishingTimer.Elapsed += Waiting;
		fishingTimer.AutoReset = true;
	}
	
	static void Waiting(Object source, ElapsedEventArgs e){
		if(ticks2 == 1)
			ticks2++;
		if(getLoot != 20 && ticks < 3){
			if(getLoot >= 3 && ticks < 3)
				getLoot = random.Next(1, 11);
			if(getLoot < 2){
				getFish = true;
				Console.WriteLine("Something has bitten, press any key to take out the fishing rod");
				getLoot = 20;
				ticks2++; // need it to enter the next if statement and lose the fish looted
			}
		}
		if(((getLoot == 20) && (ticks2 != 1)) && (noRepeat == true)){
			Console.WriteLine("");
			Console.WriteLine("The fish has gone..., press any key to start again.");
			getFish = false;
			noRepeat = false; //don't want to repeat the WriteLine() if the player doesn't press any key
			ticks = 0;
		}
			
		if(ticks == 3 && (getLoot >= 2 && getLoot != 20)){
			Console.WriteLine("You got nothing..., press any key to try again");
			ticks2 = 0;
		}
		if(ticks < 3 && getLoot >= 2 && getLoot != 20)
			Console.Write(". ");
		ticks++;
	}
	
	static void Loot(string[] bucket, ref byte fishCounter, string[] fishes){
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
		fishCounter++;
	}
}


