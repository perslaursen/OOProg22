
/// <summary>
/// This class represents a dice cup that can hold
/// any set of dice, each die being specified by the
/// list provided to the constructor.
/// NB: This class is only used for steps 5 and 6
/// </summary>
public class DiceCupGeneral
{
    #region Instance fields
    private List<DieNSides> _dice;
    #endregion

    #region Constructor
    public DiceCupGeneral(List<int> dieSides)
    {
        _dice = new List<DieNSides>();

        foreach (int noOfSides in dieSides)
        {
            _dice.Add(new DieNSides(noOfSides));
        }
    }
    #endregion

    #region Properties
    public int TotalValue
    {
        get { return _dice.Sum(die => die.FaceValue); }
    }
    #endregion

    #region Methods
    public void Shake()
    {
        foreach (DieNSides die in _dice)
        {
            die.Roll();
        }
    }

    public override string ToString()
    {
        return string.Join(", ", _dice);
    }
    #endregion
}
