public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        if (value == Data)
    {
        // Value already exists, do not insert
        return;
    }

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
       if (value == Data)
    {
        return true; // Found the value
    }
    else if (value < Data)
    {
        return Left?.Contains(value) ?? false; // Recursively search left subtree
    }
    else
    {
        return Right?.Contains(value) ?? false; // Recursively search right subtree
    }
        
    }
    public IEnumerable<int> TraverseBackward()
{
    if (Right != null)
    {
        foreach (var value in Right.TraverseBackward())
        {
            yield return value;
        }
    }
    yield return Data;
    if (Left != null)
    {
        foreach (var value in Left.TraverseBackward())
        {
            yield return value;
        }
    }
}


    public int GetHeight()
    {
        int leftHeight = Left?.GetHeight() ?? 0;
    int rightHeight = Right?.GetHeight() ?? 0;
    return 1 + Math.Max(leftHeight, rightHeight);
        
    }
}