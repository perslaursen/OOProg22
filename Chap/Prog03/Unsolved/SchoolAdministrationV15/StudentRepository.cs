
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
        get
        {
            return _students.Count;
        }
    }

    /// <summary>
    /// Returns the total test score average for all students in the catalog.
    /// Note that if a student does not have any recorded scores yet, the
    /// student is not included in the average.
    /// If no students have an actual average, null is returned.
    /// </summary>
    public double? TotalAverage
    {
        get
        {
            if (_students.Count > 0)
            {
                double? sum = 0;
                int countRealScores = 0;

                foreach (var student in _students.Values)
                {
                    if (student.ScoreAverage != null)
                    {
                        sum = sum + student.ScoreAverage;
                        countRealScores++;
                    }
                }

                return (sum / countRealScores);
            }
            else
            {
                return null;
            }
        }
    }
    #endregion

    #region Methods
    /// <summary>
    /// Add a single student to the catalog.
    /// </summary>
    public void AddStudent(Student aStudent)
    {
        _students.Add(aStudent.ID, aStudent);
    }

    /// <summary>
    /// Given an id, return the student with that id.
    /// If no student exists with the given id, return null.
    /// </summary>
    public Student? GetStudent(int id)
    {
        if (_students.ContainsKey(id))
        {
            return _students[id];
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// Given an id, return the score average for the student with that id.
    /// If no student exists with the given id, return null.
    /// </summary>
    public double? GetAverageForStudent(int id)
    {
        if (_students.ContainsKey(id))
        {
            return _students[id].ScoreAverage;
        }
        else
        {
            return null;
        }
    }
    #endregion
}
