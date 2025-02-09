﻿
/// <summary>
/// This class represents a single N-sided die
/// The creator of Die objects specify the value of N
/// NB: This class is only used for steps 5 and 6
/// </summary>
class DieNSides
{
    #region Instance fields
    private int _faceValue;
    private int _noOfSides;
    #endregion

    #region Constructor
    public DieNSides(int noOfSides)
    {
        _noOfSides = noOfSides;
        Roll(); // This puts the die in a well-defined state
    }
    #endregion

    #region Properties
    public int FaceValue
    {
        get { return _faceValue; }
    }
    #endregion

    #region Methods
    /// <summary>
    /// Roll the die: the value will be set to a random number
    /// between 1 and _noOfSides (both included).
    /// </summary>
    public void Roll()
    {
        _faceValue = RandomNumberGenerator.Generate(1, _noOfSides);
    }

    public override string ToString()
    {
        return _faceValue.ToString();
    }
    #endregion
}
