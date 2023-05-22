# ATMDenominationApp

ReadMe file:
Program to calculate the all the possible denominations combinations which ATM can pay out for an user input.
ATM has three different cartridges for different denominations
These denominations are stored in the an list.
If user wants to change the ATM cartidges denominations, the list can be altered.

Program Alogrithm:
1. Ask user to input the amount in the multiples of 10 Euros to find all the possible denominations combinations (Default: 10 , 50 and 100 Euros)
2. If the user inputs is not in multiples of 10 euros then display wrong input message and exit the program
3. If the user input is correct then calculate the maximum number of 100 euro note the ATM machine can despense for the given input.
4. Calculate maximum number of 50 and 10 euro notes for the remaining amount.
	e.g: userInput 360 
	maxHundred = 360/100 = 3 , remaining amount = 360%100 = 60
	maxFifty   = 60/50   = 1 , remaining amount = 60%50   = 10
	maxTens    = 10/10   = 1
	
	For 360 euros , maxHundred notes a machine despense are 3.
	For any user input maxHundred notes = userInput/360
	For any user input maxFifty notes for the remaining amount =  0 for 0 < remaining amount < 50 and 1 for 50 < remaining amount < 100
	So there are only 2 possible combinations of Fifty notes at the start of the program either 0 or 1
	For any user input at the start of the program maxTen notes = remaining amount  0 < maxTens < 4
	
	The goal of the program is to start from the max number of 100 euros and calculate possible combinations of 50 and 10 euros
	Then decrement the number of  100 euros by 1 and then calcualting maximum no of 50 and 100 euros notes which can add up to user amount
	Program will stop when the maxHundred and maxFifty both reches to zero.

6.  If fiftes notes are zero 
    - Decrement 100 notes by 1
	- Assign 50 notes to a value calulated based on no of 10´s in the current iteration 
    - Assign no to 10´s to the value passed at start of function call
	
5. For a given 100´s, the possible comibination of 50´s and 10´s are calulated from stating the maximum no of fifty notes and miminum no of 10´s to reach the calulated sum
	- Then amount of 50´s is decremented and 5 ten´s notes are added to the previous Tens notes as 50 euros = 5 x 10 euros
	- This tens are added 5 times for each iteration till the 50´s are decremented to 0
	- Once the 50´s are decrement to 0 then 10´s are assinged back to the value from where it was stated.
	- Now the 100´s are decremented by 1 and to the last 50´s value 2 notes are added as. 100 euros = 2 x 50 euros.
	
6. A recursive function is used to pass maxHundred, maxFifies and maxTens for each function call.
7. Stop condition for recusion is when maxHundred and maxFifies both are zero.
8. Recursive calls increases when the user inputs higher amount
	
	Case1: When the max fifty for the first calculation is 1 (odd) e.g 360 euros. Here the maxHunderd = 3 , maxFifty = 1 and maxTens = 1
			- In this case the possible combinations of fifty notes and Tens notes for maxHunderd will be always be 2
			- In the next iteration the when the maxHunderd notes is decrement by 1 then maximum possible comibination of 50´s and 10´s will be doubled i.e 4
			- The maximum possible combinations of the 50´s and 10´s will be doubled than the previous iteration till the the maxHunderd notes are decremented to 0
			- Collectivley Even combinations : 2->4->6->8->10->12
			
			- Recursive call calculation and Time Complexity
				maxHundredNotes = maximum amout of 100 notes a machine can despense for a give amount e.g : 930 euros , maxHunderdNotes = 9 , 570 euors: maxHundredNotes = 5
				Depth = maxHunderdNotes + 1
				
				Recursivecalls = Depth(Depth + 1)
		
				TimeComplexity = Big(O) = No of Recursivecalls
			
			
	Case2: When the max fifty for the first calculation is 0 (even) e.g 340 euros. Here the maxHunderd = 3 , maxFifty = 0 and maxTens = 4
			- In this case the possible combinations of fifty notes and Tens notes for maxHunderd will be always be 1
			- In the next iteration the when the maxHunderd notes is decrement by 1 then maximum possible comibination of 50´s and 10´s will be doubled i.e 4
			- The maximum possible combinations of the 50´s and 10´s will be doubled than the previous iteration till the the maxHunderd notes are decremented to 0
			- Collectivley Even combinations : 1->3->5->7->9->11
			
			- Recursive call calculation and Time Complexity
				maxHundredNotes = maximum amout of 100 notes a machine can despense for a give amount e.g : 930 euros , maxHunderdNotes = 9 , 570 euors: maxHundredNotes = 5
				Depth = maxHunderdNotes + 1
				
				Recursivecalls = Depth x Depth
		
				TimeComplexity = Big(O) = No of Recursivecalls


e.g : 
userInput = 360 Euros
- maxHunderd = 3 , remaing amount = 60 , maxFifty for the remaing amount = 60/50 = 1 , remaining amount = 10, maxHunderd for the remaining amount = 10/10= 1
- Passing these there vallues to the funtion and printing the denominations

100 x 3 , 50 x 1 , 10 x 1   - First arguments for the functtion
100 x 3 , 50 x 0 , 10 x 6   - Decrement 50´s by 1 till it becomes and adding 5 notes to 10 to keep the total same
100 x 2 , 50 x 3 , 10 x 1   - As 50´s are zero , decrement 100´s , assign 10´s to the original value and increment fify by 2 then previous value i.e 50´s= 1+2=3
100 x 2 , 50 x 2 , 10 x 6   - Decrement 50´s and add 5 in 10´s
100 x 2 , 500x 1 , 10 x 11  - Decrement 50´s till 0 and add 5 notes in 10´s
.
.
100 x 0 , 50 x 0 , 10 x 36  - End the program when both 100´s and 50´s are zero 

