using System;

class SumaRestaR{
	
	static void Main(){
		
		Random r = new Random();
		int n=2, selector=0, solution=0, attempt=0;		//needed selector which chooses the operators, make a solution and attempts to solve the operations
		string operators="+-";							//string/array of operators "+" and "-" from which the program chooses randomly
		int[] numbers = new int[n]; 					//array of 2 random numbers
		bool control;									//for try-catch/while loop
	
		for(int counter = 1; counter < 11; counter++){	//I want to do the operations 10 times
			control = true;								//reset of control for try-catch/while loop
			for(int i=0; i < n; i++){ 					//fill the array with random numbers
				numbers[i] = r.Next(1,10);
			}
			selector = r.Next(0,2);
			
			if(operators[selector] == '+'){
				solution = numbers[0] + numbers[1];
				while (control){
					try{
						Console.Write(numbers[0] + " + " + numbers[1] + " = ");
						attempt = Convert.ToInt32(Console.ReadLine());
						Console.WriteLine();
						if(solution == attempt)
							control=false;
					}
					catch(Exception errorFound){
						Console.WriteLine("Error detected: " + errorFound.Message);
						Console.WriteLine();
					}
				}
			}
			else{
				solution = numbers[0] - numbers[1];
				while (control){
					try{
						Console.Write(numbers[0] + " - " + numbers[1] + " = ");
						attempt = Convert.ToInt32(Console.ReadLine());
						Console.WriteLine();
						if(solution == attempt)
							control=false;
					}
					catch(Exception errorFound){
						Console.WriteLine("Error detected: " + errorFound.Message);
						Console.WriteLine();
					}
				}
			}
		}
	}
}
