/// <summary>
///  Simple barometer, measuring pressure in hPa (hectopascal)
/// </summary>
public class Barometer
{
    #region Properties
    public double Pressure { get; set; }

    public string WeatherDescription
    {
        get { return "All weather is nice!"; }
    }
    #endregion

    #region Constructor
    public Barometer()
    {
        Pressure = 1000.0;
    }
    #endregion
}
