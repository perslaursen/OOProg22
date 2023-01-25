
Console.WriteLine("Testing fair strategy...");
NowFight(FightType.Fair);

Console.WriteLine("Testing biased strategy...");
NowFight(FightType.BiasedA);


void NowFight(FightType type, int noOfFights = 100000)
{
    // Feel free to try out a different pair of Players...
    Player playerA = new Player("Adolf", 100, 30);
    Player playerB = new Player("Josef", 120, 25);

    IFight1v1Manager fightManager = Fight1v1ManagerFactory.Create(type, playerA, playerB, noOfFights);
    fightManager.Fight();
}
