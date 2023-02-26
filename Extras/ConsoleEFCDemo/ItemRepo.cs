using DBCxt = ConsoleEFCDemoDBContext;

public class ItemRepo
{
    public List<Item> GetAll()
    {
        using DBCxt dbContext = new();

        return dbContext.Items.ToList();
    }

    public void Clear()
    {
        using DBCxt dbContext = new();

        dbContext.Items.RemoveRange(dbContext.Items);
        dbContext.SaveChanges();
    }

    public void Create(Item item)
    {
        using DBCxt dbContext = new();

        item.ID = NextId();
        dbContext.Items.Add(item);
        dbContext.SaveChanges();
    }

    public Item? Read(int id)
    {
        using DBCxt dbContext = new();

        return dbContext.Items.FirstOrDefault(e => e.ID == id);
    }

    public void Delete(int id)
    {
        using DBCxt dbContext = new();

        Item? item = dbContext.Items.Find(id);
        if (item != null)
            dbContext.Items.Remove(item);

        dbContext.SaveChanges();
    }

    private int NextId()
    {
        return GetAll().Select(e => e.ID).DefaultIfEmpty(0).Max() + 1;
    }
}

