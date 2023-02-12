
PersonRepository personRepository = new PersonRepository();
PersonService personService = new PersonService(personRepository);

try
{
    Console.WriteLine("Trying something...");

    // Try out some calls to Person/PersonRepository/PersonService here

    Console.WriteLine("Done, all is well...");
}
catch (ArgumentException arguEx)
{
    Console.WriteLine($"Got an argument Exception!  ->  {arguEx.Message}");
}
catch (RepositoryException repoEx)
{
    Console.WriteLine($"Got a repository Exception!  ->  {repoEx.Message}");
}
catch (Exception ex)
{
    // When the exercise is solved, we should - in theory -  never end up in this case...
    Console.WriteLine($"Got a general Exception!  ->  {ex.Message}");
}
