public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
public static double[] MultiplesOf(double number, int length)
{
    // Create an empty array of doubles with the specified length
    double[] result = new double[length];

    // Loop through the array and fill it with multiples of the number
    for (int i = 0; i < length; i++)
    {
        result[i] = number * (i + 1); // Multiply the base number by (i+1) to get the correct multiple
    }

    // Return the populated array of multiples
    return result;
}

   
    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
public static void RotateListRight(List<int> data, int amount)
{
    // Ensure that the rotation amount is within the list's bounds
    amount = amount % data.Count;

    // If the amount is 0, no rotation is needed
    if (amount == 0) return;

    // Slice the list into two parts: the last 'amount' elements and the rest
    var rightPart = data.GetRange(data.Count - amount, amount); // Last 'amount' elements
    var leftPart = data.GetRange(0, data.Count - amount); // Remaining elements

    // Clear the original list and add the right part followed by the left part
    data.Clear();
    data.AddRange(rightPart);
    data.AddRange(leftPart);
}

    
}
