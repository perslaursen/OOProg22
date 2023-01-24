
/// <summary>
/// The TicketFactory class is just a convenience class, making it easier to
/// produce many tickets for the same flight.
/// </summary>
public class TicketFactory
{
    #region Instance field and Constructor
    private CommonInfo _commonInfo;

    public TicketFactory(string flightNo, string fromWAC, string toWAC, DateTime timeOfDeparture)
    {
        _commonInfo = new CommonInfo("(empty)", flightNo, fromWAC, toWAC, timeOfDeparture);
    }
    #endregion

    #region Methods
    /// <summary>
    /// Creates a ticket for an individual passenger.
    /// </summary>
    public Ticket Create(string passengerName, Company? company = null)
    {
        return new Ticket(passengerName, company, _commonInfo.FlightNo, _commonInfo.FromWAC, _commonInfo.ToWAC, _commonInfo.TimeOfDeparture);
    }
    #endregion
}
