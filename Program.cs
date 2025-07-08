using System;
using System.Linq;

class Mastermind
{   //variables for the secreat codes and attempts 
    static string secretCode;
    static int attempts = 10;

    static void Main(string[] args)
    {
        //prosses commands and arguments 
        for (int i = 0; i < args.Length; i++)
        {   //if the user specifies -c take the next arguemnt code
            if (args[i] == "-c" && i + 1 < args.Length)
                secretCode = args[i + 1];
          // If user specifies -t try to parse the next argument as attempt count
            if (args[i] == "-t" && i + 1 < args.Length && int.TryParse(args[i + 1], out int t))
                attempts = t;
        }

        // no secret code provided, generate a random one
        if (string.IsNullOrEmpty(secretCode))
            secretCode = GenerateRandomCode();
        //welcome message
        Console.WriteLine("Can you break the code? Enter a valid guess.");
        //Main game loop
        for (int round = 0; round < attempts; round++)
        {
            Console.WriteLine($"Round {round}");
            Console.Write("> ");
            string guess = Console.ReadLine();//user's guess

            // Break loop if input is null Ctrl+D
            if (guess == null)
                break;
             // guess is invalid
            if (!IsValidGuess(guess))
            {
                Console.WriteLine("Wrong input!");
                round--;  // Dosent't count
                continue; // Restart
            }
              // If guess matches the secret code
            if (guess == secretCode)
            {
                Console.WriteLine("Congratz! You did it!");
                return;// End game
            }
            // Calculate well-placed and misplaced pieces
            int wellPlaced = GetWellPlaced(guess);
            int misplaced = GetMisplaced(guess);
             // Display results
            Console.WriteLine($"Well placed pieces: {wellPlaced}");
            Console.WriteLine($"Misplaced pieces: {misplaced}");
        }
          // Game over message if all attempts used
        Console.WriteLine("Out of attempts! The code was: " + secretCode);
    }
    // Generate a random 4-digit secret code
    static string GenerateRandomCode()
    {
        Random rnd = new Random();
        return string.Join("", Enumerable.Range(0, 9).OrderBy(x => rnd.Next()).Take(4));
    }
     // Validate the user's guess
    static bool IsValidGuess(string guess)
    {
        return guess.Length == 4 && // Must be 4 characters
               guess.All(char.IsDigit) && // All characters must be digits
               guess.All(c => c >= '0' && c <= '8') && // Digits between 0 and 8
               guess.Distinct().Count() == 4; // No repeated digits
    }
     // Count digits that are correct and in the correct position
    static int GetWellPlaced(string guess)
    {
        int count = 0;
        for (int i = 0; i < 4; i++)
            if (guess[i] == secretCode[i])
                count++;
        return count;
    }
     // Count digits that are in the secret code but in the wrong position
    static int GetMisplaced(string guess)
    {
        int count = 0;
        for (int i = 0; i < 4; i++)
        {
            if (guess[i] != secretCode[i] && secretCode.Contains(guess[i]))
                count++;
        }
        return count;
    }
}
