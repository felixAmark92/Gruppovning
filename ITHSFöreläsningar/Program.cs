


Console.Write("Please enter the amount of players: ");

string input = Console.ReadLine();
int amountOfPlayers = 0;

while (!int.TryParse(input, out amountOfPlayers))
{
    Console.Write("Please enter a valid iput: ");
    input = Console.ReadLine();
}

string[] players = new string[amountOfPlayers];
int[] playersScores = new int[amountOfPlayers];
int[] playersRolls;

for (int i = 0; i < amountOfPlayers; i++)
{
    Console.WriteLine("Enter player " + (i + 1) + " name:");
    players[i] = Console.ReadLine();
}

//Start of game
for (int k = 0; k < 6; k++)
{
    playersRolls = MakeDiceRolls(amountOfPlayers);
    Console.WriteLine("Rolls:");
    for (int i = 0; i < amountOfPlayers; i++)
    {
        Console.WriteLine(players[i] + ": " + playersRolls[i]);
    }
    Console.WriteLine();

    DeclarePoints();

    Console.WriteLine("Points:");
    for (int i = 0; i < amountOfPlayers; i++)
    {
        Console.WriteLine(players[i] + ": " + playersScores[i]);
    }
    Console.WriteLine();
    Console.ReadKey();
}

DeclareWinner();



int[] MakeDiceRolls(int amount)
{
    int[] rolls = new int[amount];
    var random = new Random();

    for (int i = 0; i < amount; i++)
    {
        rolls[i] = random.Next(1, 7);
    }
    return rolls;
}


void DeclarePoints()
{
    int highestRoll = 0;
    int winnerIndex = -1;

    int point = 5;

    for (int i = 0; i < 3; i++)
    {
        highestRoll = 0;
        for (int j = 0; j < playersRolls.Length; j++)
        {
            if (playersRolls[j] > highestRoll)
            {
                highestRoll = playersRolls[j];
                winnerIndex = j;
            }
        }
        playersScores[winnerIndex] += point;
        playersRolls[winnerIndex] = 0;

        for (int j = 0; j < playersRolls.Length; j++)
        {
            if (playersRolls[j] == highestRoll)
            {
                playersScores[j] += point;
                playersRolls[j] = 0;
            }
        }
        point -= 2;
    }
}

void DeclareWinner()
{
    int highestScore = 0;
    int winnerIndex = -1;

    for (int i = 0; i < amountOfPlayers; i++)
    {
        if ((playersScores[i] > highestScore))
        {
            winnerIndex = i;
            highestScore = playersScores[i];
        }
    }
    Console.WriteLine("Winner: " + players[winnerIndex]);
}
