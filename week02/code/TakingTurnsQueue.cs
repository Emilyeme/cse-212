/// <summary>
/// This queue is circular.  When people are added via AddPerson, then they are added to the 
/// back of the queue (per FIFO rules).  When GetNextPerson is called, the next person
/// in the queue is saved to be returned and then they are placed back into the back of the queue.  Thus,
/// each person stays in the queue and is given turns.  When a person is added to the queue, 
/// a turns parameter is provided to identify how many turns they will be given.  If the turns is 0 or
/// less than they will stay in the queue forever.  If a person is out of turns then they will 
/// not be added back into the queue.
/// </summary>

public class TakingTurnsQueue
{
    private Queue<Person> queue = new Queue<Person>();

    // Adds a person with a specific number of turns
    public void AddPerson(Person person)
    {
        queue.Enqueue(person);
    }

    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        AddPerson(person);
    }

    // Returns the next person in the queue and handles turn management
    public Person GetNextPerson()
    {
        if (queue.Count == 0)
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        Person person = queue.Dequeue();

        // If the person has finite turns, decrement them and re-enqueue if there are still turns left
        if (person.Turns > 0)
        {
            person.Turns--;
            if (person.Turns > 0)
            {
                queue.Enqueue(person);
            }
        }
        else
        {
            // If the person has infinite turns (Turns <= 0), just re-enqueue them
            queue.Enqueue(person);
        }

        return person;
    }

    public int Length => queue.Count;
}

