[Serializable]
public struct Unit
{
    public string type;
    public int weight;

    public Unit(string type, int weight)
    {
        this.type = type;
        this.weight = weight;
    }
}

[Serializable]
public struct Person
{
    public string name;
    public Unit[] baggage;
}

