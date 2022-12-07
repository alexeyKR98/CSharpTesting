using System;
using System.Timers;

class AutomaticFishing{

	static Timer timer = new Timer(4000);
	static Random random = new Random();
	static byte sardineCounter, carpCounter, northernPikeCounter, salmonCounter, swordFishCounter;
	static string[] fishes = {"Sardine", "Carp", "Northern pike", "Salmon", "Swordfish"};
	static int [,] fishingLoot = new int[5,100];
	static sbyte ticks = 0;
	static int getLoot;
	static byte fishingCheck = 0;
	
	static void Main(){
		
		sardineCounter = carpCounter = northernPikeCounter = salmonCounter = swordFishCounter = 0;
		do{
			Console.WriteLine("");
			Console.WriteLine("Press enter to start Fishing");
		}
		while(Console.ReadKey(true).Key != ConsoleKey.Enter);
		Console.Clear();
		Console.WriteLine(fishes[0] + ": " + sardineCounter);
		Console.WriteLine(fishes[1] + ": " + carpCounter);
		Console.WriteLine(fishes[2] + ": " + northernPikeCounter);
		Console.WriteLine(fishes[3] + ": " + salmonCounter);
		Console.WriteLine(fishes[4] + ": " + swordFishCounter);
		FishingTimerSet();
		Console.WriteLine("");
		Console.WriteLine("Fishing");
		Console.WriteLine("");
		Console.WriteLine("Press Enter to finish");		
		while(Console.ReadKey(true).Key != ConsoleKey.Enter){}
		timer.Stop();
	}
	
	static void FishingTimerSet(){
	
		timer.Elapsed += FishingEvent;
		timer.AutoReset = true;
		timer.Enabled = true;
	}
	
	static void FishingEvent(Object source, ElapsedEventArgs e){
		getLoot = random.Next(1, 101);
		if(getLoot < 6)
			Loot();
		ticks++;
		Console.Clear();
		Console.WriteLine(fishes[0] + ": " + sardineCounter);
		Console.WriteLine(fishes[1] + ": " + carpCounter);
		Console.WriteLine(fishes[2] + ": " + northernPikeCounter);
		Console.WriteLine(fishes[3] + ": " + salmonCounter);
		Console.WriteLine(fishes[4] + ": " + swordFishCounter);
		Console.WriteLine("");
		
		switch(ticks){
			case 1: Console.Write("Fishing . "); break;
			case 2: Console.Write("Fishing . . "); break;
			case 3: 
				Console.Write("Fishing . . . ");
				ticks = 0; break;
			default: break;
		}
		switch(fishingCheck){
			case 1: Console.Write("You got " + fishes[0]); fishingCheck = 0; break;
			case 2: Console.Write("You got " + fishes[1]); fishingCheck = 0; break;
			case 3: Console.Write("You got " + fishes[2]); fishingCheck = 0; break;
			case 4: Console.Write("You got " + fishes[3] + "!"); fishingCheck = 0; break;
			case 5: Console.Write("Congrats, you got " + fishes[4] + "!!!"); fishingCheck = 0; break;
			default: break;
		}
		Console.WriteLine("");
		Console.WriteLine("");
		Console.WriteLine("Press Enter to finish");
	}

	static void Loot(){
		int getLoot = random.Next(1, 101);
		
		if(getLoot <= 50){
			sardineCounter++;
			fishingCheck = 1;
		}
		if(getLoot <= 75 && getLoot > 50){
			carpCounter++;
			fishingCheck = 2;
		}
		if(getLoot <= 87 && getLoot > 75){
			northernPikeCounter++;
			fishingCheck = 3;
		}
		if(getLoot <= 95 && getLoot > 87){
			salmonCounter++;
			fishingCheck = 4;
		}
		if(getLoot > 95){
			swordFishCounter++;
			fishingCheck = 5;
		}
	}
}
