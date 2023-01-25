
/// <summary>
/// Base class for all Support Center classes.
/// </summary>
public abstract class SupportCenterBase : ISupportCenter
{
    #region Properties
    public List<ErrorTicket> OpenTickets { get; }
    public List<ErrorTicket> ClosedTickets { get; }
    public List<ErrorTicket> UnhandledTickets { get; }

    public int OpenTicketCount { get { return OpenTickets.Count; } }
    public int ClosedTicketCount { get { return ClosedTickets.Count; } }
    public int UnhandledTicketCount { get { return UnhandledTickets.Count; } }
    #endregion

    #region Constructor
    protected SupportCenterBase()
    {
        OpenTickets = new List<ErrorTicket>();
        ClosedTickets = new List<ErrorTicket>();
        UnhandledTickets = new List<ErrorTicket>();
    }
    #endregion

    #region Methods
    /// <summary>
    /// Clear all tickets from all lists.
    /// </summary>
    public void Reset()
    {
        OpenTickets.Clear();
        ClosedTickets.Clear();
        UnhandledTickets.Clear();
    }

    /// <summary>
    /// Submit a single error ticket, which will be placed 
    /// in the list of Open tickets.
    /// </summary>
    public void SubmitTicket(ErrorTicket ticket)
    {
        OpenTickets.Add(ticket);
    }

    /// <summary>
    /// Try to handle all open tickets. After calling this method, it should hold that:
    /// 1) No tickets are in the Open list
    /// 2) Tickets successfully handled are in the Closed list
    /// 3) Tickets unsuccessfully handled are in the Unhandled list
    /// </summary>
    public void HandleOpenTickets()
    {
        while (OpenTicketCount > 0)
        {
            // Take a ticket from the list
            ErrorTicket ticket = OpenTickets[OpenTicketCount - 1];
            OpenTickets.RemoveAt(OpenTicketCount - 1);

            // Try to handle it
            TryHandleTicket(ticket);
        }
    }

    /// <summary>
    /// Specific Support Center classes need to define a specific
    /// algorithm for how to handle an error ticket.
    /// </summary>
    public abstract void TryHandleTicket(ErrorTicket ticket);
    #endregion
}
