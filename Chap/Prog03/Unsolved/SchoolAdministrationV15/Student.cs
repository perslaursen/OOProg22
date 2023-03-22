﻿
/// <summary>
/// This class represents a student, 
/// with an id, name and a set of test scores
/// </summary>
public class Student
{
    #region Instance fields
    private Dictionary<string, int> _testScores;
    #endregion

    #region Constructor
    public Student(int id, String name)
    {
        ID = id;
        Name = name;
        _testScores = new Dictionary<string, int>();
    }
    #endregion

    #region Properties
    public int ID { get; }
    public string Name { get; }

    /// <summary>
    /// Returns the average of the test scores for the student.
    /// If no scores are present, an average of -1 is returned.
    /// </summary>
    public double ScoreAverage
    {
        get
        {
            if (_testScores.Count == 0)
            {
                return -1;
            }
            else
            {
                return (from t in _testScores 
                        select t.Value).Average();
                
            }
        }
    }
    #endregion

    #region Methods
    /// <summary>
    /// Insert a single test result
    /// </summary>
    public void AddTestResult(String courseName, int score)
    {
        _testScores.Add(courseName, score);
    }

    public override string ToString()
    {
        return $"{Name} (id: {ID})";
    }
    #endregion
}
