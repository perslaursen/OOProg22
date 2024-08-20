namespace RolePlayDemoAug24.Models.Base;

/// <summary>
/// A very simple repository-like storage class, which can hold a sset of
/// elements of a specific type. A selection of a subset of the stored elements 
/// can also be maintained.
/// </summary>
/// <typeparam name="T">Type of elements stored in a repository instance.</typeparam>
public class Repository<T> where T : HasIdAndName
{
	protected List<T> _elements;
	protected List<bool> _selection;

	public Repository()
	{
		_elements = new List<T>();
		_selection = new List<bool>();
	}

	/// <summary>
	/// Returns all elements stored in the repository.
	/// </summary>
	public List<T> GetAll()
	{
		return _elements;
	}

	/// <summary>
	/// Returns the element matching the given id, otherwise null.
	/// </summary>
	public T? Get(int id)
	{
		return _elements.FirstOrDefault(e => e.Id == id);
	}

	/// <summary>
	/// Returns the current selection. Note that a copy of the selection is
	/// returned, so a client should use SetSelection to update the selection.
	/// </summary>
	public List<bool> GetSelection()
	{
		return new List<bool>(_selection);
	}

	/// <summary>
	/// Updates the current selection.
	/// </summary>
	public void SetSelection(List<bool> selected)
	{
		_selection.Clear();
		_selection.AddRange(selected);
	}
}
