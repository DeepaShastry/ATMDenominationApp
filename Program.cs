/*

ATM machine program to despense thhe give user amount in denominations of 10, 50 and 100 euros
For example, for 100 EUR the available payout denominations would be:
•	10 x 10 EUR
•	1 x 50 EUR + 5 x 10 EUR
•	2 x 50 EUR
•	1 x 100 EUR

*/

using System;

public class ATMDenomination
{

    static class Global
    {
        public static int maxTensNotes = 0;
    }

    // Recursive function to find all the possible denominations
    public static void denominations(int maxHundred, int maxFifty, int maxTens)
    {
        Console.WriteLine("100 x {0}, 50 x {1}, 10 x {2}", maxHundred, maxFifty, maxTens);

        //Stop condition for reursive call. End if both maxHundred and maxFifty both are zero
        if (maxHundred == 0 && maxFifty == 0)
        {
            return;
        }
        else
        {
            if (maxFifty != 0)
            {
                //If Fifties notes are not 0 then keep decrementing 50 by 1 incremeting 10 notes by 5. as 50 = 5* 10 Euros

                maxFifty -= 1;
                maxTens += 5;
            }
            else
            {
                /*
                 If fiftes notes are zero 
                    - Decrement 100 notes by 1
                    - Assign 50 notes to a value calulated based on no of 10´s in the current iteration 
                    - Assign no to 10´s to the value passed at start of function call
                */
                maxHundred -= 1;
                maxFifty = (10 * (maxTens - Global.maxTensNotes) + 100) / 50;
                maxTens = Global.maxTensNotes;
            }
            denominations(maxHundred, maxFifty, maxTens);

        }

    }
    public static void Main(string[] args)
    {
        int userInput = 0;
        int maxHundred = 0;
        int remainderHundred = 0;
        int maxFifty = 0;
        int remainderFifty = 0;
        int maxTens = 0;
        int depth = 0;
        int denominationCount = 0;

        Console.WriteLine("Enter the amount for denominations:");
        userInput = Convert.ToInt32(Console.ReadLine());

        //Validating user input 
        if (userInput % 10 != 0)
        {
            Console.WriteLine("The Amount entered in not in multipe of 10´s");
            return;
        }
        else
        {
            maxHundred = userInput / 100;
            remainderHundred = userInput % 100;
            maxFifty = remainderHundred / 50;
            remainderFifty = remainderHundred % 50;
            maxTens = remainderFifty / 10;
            Global.maxTensNotes = maxTens;
            depth = maxHundred + 1;

            //Calculating no of possible combinations for given user amount
            if (maxFifty == 1)
            {
                denominationCount = depth * (depth + 1);
            }
            else
            {
                denominationCount = depth * depth;
            }
            Console.WriteLine("Number of denominations: " + denominationCount);

            // Calling denominations recursive function
            denominations(maxHundred, maxFifty, maxTens);
        }
    }
}
