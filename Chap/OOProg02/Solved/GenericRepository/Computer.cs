
public class Computer
{
    public string SerialNo { get; set; }
    public string NetworkName { get; set; }

    public Computer(string serialNo, string networkName)
    {
        SerialNo = serialNo;
        NetworkName = networkName;
    }

    public override string ToString()
    {
        return $"{SerialNo}, called {NetworkName} on network";
    }
}
