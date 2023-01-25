
/// <summary>
/// Simple factory for generation of randomised PNCs.
/// </summary>
public class NPCFactory : INPCFactory
{
    /// <summary>
    /// Returns an NPC with a randomly generated type.
    /// </summary>
    public INPC Create()
    {
        return new NPC(NPCGeneratorHelper.GenerateRandomNPCType());
    }
}
