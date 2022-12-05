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
		Fishing(fishingTimer);
		string[] fishes = {"Sardine", "Carp", "Northern pike", "Salmon", "Swordfish"};	
		string[] bucket = new string[10];
		byte fishCounter = 0;
		ConsoleKeyInfo button;
		while(fishCounter < 10){
			ticks = 0;
			ticks2 = 0;
			getLoot = 10;
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
			if(getFish)
				Loot(bucket, ref fishCounter, fishes);
		}
		for(int i = 0; i < fishCounter; i++){
			Console.WriteLine("");
			Console.WriteLine((i + 1) + ") " + bucket[i]);
		}
	}
	static void Fishing(Timer fishingTimer){
		fishingTimer.Elapsed += Waiting;
		fishingTimer.AutoReset = true;
	}
	
	static void Waiting(Object source, ElapsedEventArgs e){
		if(ticks2 == 1)
			ticks2++;
		if(getLoot != 20 && ticks < 3){
			if(getLoot >= 3 && ticks < 3)
				getLoot = random.Next(1, 11);
			if(getLoot < 3){
				getFish = true;
				Console.WriteLine("Something has bitten, press any key to take out the fishing rod");
				getLoot = 20;
				ticks2++;
			}
		}
		if(((getLoot == 20) && (ticks2 != 1)) && (noRepeat == true)){
			Console.WriteLine("The fish has gone..., press any key to start again.");
			getFish = false;
			noRepeat = false;
			ticks = 0;
		}
			
		if(ticks == 3 && (getLoot >= 3 && getLoot != 20)){
			Console.WriteLine("You got nothing..., press any key to try again");
			ticks2 = 0;
		}
		if(ticks < 3 && getLoot >= 3 && getLoot != 20)
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


