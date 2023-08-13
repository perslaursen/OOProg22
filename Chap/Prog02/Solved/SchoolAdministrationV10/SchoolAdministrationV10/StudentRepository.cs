
/// <summary>
/// This class represents a collection of students,
/// for instance students attending a school
/// </summary>
public class StudentRepository
{
    #region Instance fields
    private Dictionary<int, Student> _students;
    #endregion

    #region Constructor
    public StudentRepository()
    {
        _students = new Dictionary<int, Student>();
    }
    #endregion

    #region Properties
    /// <summary>
    /// Return the number of students in the catalog.
    /// </summary>
    public int Count
    {
        get { return _students.Count; }
    }
    #endregion

    #region Methods
    /// <summary>
    /// Add a single student to the catalog.
    /// </summary>
    public void AddStudent(Student aStudent)
    {
        if (!_students.ContainsKey(aStudent.ID))
        {
            _students.Add(aStudent.ID, aStudent);
        }
    }

    /// <summary>
    /// Given an id, return the student with that id.
    /// If no student exists with the given id, return null.
    /// </summary>
    public Student? GetStudent(int id)
    {
        return _students.ContainsKey(id) ? _students[id] : null;
    }

    /// <summary>
    /// Given an id, return the score average for the student with that id.
    /// If no student exists with the given id, return null.
    /// </summary>
    public int? GetAverageForStudent(int id)
    {
        return _students.ContainsKey(id) ? _students[id].ScoreAverage : null;
    }

    /// <summary>
    /// Returns the total test score average for ALL students in the catalog.
    /// Note that only students with an actual score average (i.e. NOT null) 
    /// should be included in the calculation of the average.
    /// If there are no students with actual score averages, return null.
    /// </summary>
    public int? GetTotalAverage()
    {
        int sumOfAverages = 0;
        int studentCount = 0;

        foreach (Student aStudent in _students.Values)
        {
            if (aStudent.ScoreAverage != null)
            {
                sumOfAverages = sumOfAverages + aStudent.ScoreAverage.Value;
                studentCount++;
            }
        }

        return studentCount > 0 ? sumOfAverages / studentCount : null;
    }
    #endregion
}
