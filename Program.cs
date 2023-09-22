Console.WriteLine("Hello GameMaster! Please choose a number below.");
int lives = 10;
string currentGuess = "";
string[] listWords = File.ReadAllLines("../../../data.txt");
string? input = string.Empty;
int selected;
Console.WriteLine();

for (int i = 0; i < listWords.Length - 1; i++)
{
    Console.Write(i + 1 + ". ");
    Console.WriteLine(listWords[i]);
}
Console.WriteLine();

while (!int.TryParse(input, out selected))
{
    input = Console.ReadLine();
    if (input == "0")
    {
        input = listWords[0];
        Console.WriteLine("du skrev in 0. Du är en sopa.");
    }
}
Console.Clear();
Console.WriteLine();
string word = listWords[selected - 1];

while (currentGuess.Length < word.Length)
{
    currentGuess = currentGuess + "_";
}

bool won = false;
Console.WriteLine("The word contains " + word.Length + " letters. You start with " + lives + " lives.");
Console.WriteLine();

while (lives > 0 && !won)
{
    Console.WriteLine(currentGuess);
    Console.WriteLine();
    Console.WriteLine("Guess a letter or a word.");
    Console.WriteLine();

    string? guess = Console.ReadLine().ToLower();
    bool guessCorrect = false;
    if (guess.Length > 1)
    {
        if (guess == word)
        {
            won = true;
        }
        else if (guess != word)
        {
            lives--;
            Console.WriteLine("You guess was wrong, you lose a life and have " + lives + " left!!.");
            Console.WriteLine();
        }
    }
    if (guess.Length == 0)
    {
        Console.WriteLine(currentGuess);
        Console.WriteLine("Sorry, you have to choose a letter that exists. Try again!");
        Console.WriteLine();
    }
    if (guess.Length == 1)
    {
        foreach (var letter in word)
        {
            if (letter.ToString() == guess)
            {
                guessCorrect = true;
            }
        }
        if (guessCorrect)
        {
            for (int i = 0; i < word.Length; i++)
            {
                var letter = word[i];
                if (guess == word[i].ToString())
                {
                    currentGuess = currentGuess.Remove(i, 1).Insert(i, guess);
                    Console.Clear();
                    Console.WriteLine("Correct! The letter " + guess + " was in the word.");
                    Console.WriteLine();
                }
                if (currentGuess == word)
                {
                    won = true;
                }
            }
        }
        if (!guessCorrect)
        {
            lives--;
            Console.Clear();
            Console.WriteLine("You guess was wrong, you lose a life and have " + lives + " left.");
            Console.WriteLine();
        }
    }
}
if (won == true)
{
    Console.Clear();
    Console.WriteLine();
    Console.WriteLine("VICTORY! You are the best ;)");
    Console.WriteLine("The correct word you guessed was: " + word);
}
if (lives == 0)
{
    Console.Clear();
    Console.WriteLine();
    Console.WriteLine("† --- GAME OVER --- †");
    Console.WriteLine("The correct word was: " + word);
}


