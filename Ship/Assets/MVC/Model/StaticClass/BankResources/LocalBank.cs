public static class LocalBank
{
    public static int Score { get; private set; }
    public static int Coin { get; private set; }

    public static void AddScore(int countScore)
    {
        Score += countScore;
    }    
    
    public static void AddCoin(int countCoin)
    {
        Coin += countCoin;
    }

    public static void TryChangeScore()
    {
        if(Score > BankResource.Score)
        {
            BankResource.ChangeScore(Score);
            Score = 0;
        }
        else
        {
            Score = 0;
        }
    }

    public static void SumUpCoin()
    {
        BankResource.AddCoin(Coin);
        Coin = 0;   
    }
}
