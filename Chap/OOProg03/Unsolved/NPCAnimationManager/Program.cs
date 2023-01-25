
int noOfNPCs = 5000;

TestOriginal();

/// <summary>
/// Test original NPC generation.
/// NB: Will use about 0,1 MB per NPC.
/// </summary>
void TestOriginal()
{
    INPCFactory npcFac = new NPCFactory();
    List<INPC> allNPCs = CreateNPCs(npcFac);
    AnimateAll(allNPCs);
    DoneWithTest("(original)");
}

List<INPC> CreateNPCs(INPCFactory npcFac)
{
    List<INPC> all = new List<INPC>();
    for (int i = 0; i < noOfNPCs; i++)
    {
        all.Add(npcFac.Create());
    }
    return all;
}

void AnimateAll(List<INPC> all)
{
    foreach (INPC npc in all)
    {
        npc.Animate();
    }
}

void DoneWithTest(string testDesc)
{
    Console.WriteLine();
    Console.WriteLine($"Using {testDesc} creation strategy");
    Console.WriteLine($"Created and Animated {noOfNPCs} NPCs");
    Console.WriteLine();
}
