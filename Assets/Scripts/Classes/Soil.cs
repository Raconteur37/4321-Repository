using System.Diagnostics.CodeAnalysis;

[SuppressMessage("ReSharper", "InconsistentNaming")]

class Soil
{
    private string type, status; // The type of soil, Sandy, Loam, or Clay as well as the status of the soil, Dry or Moist.
    
    public Soil(string type)
    {
        this.type = type;
    }

    public string getType()
    {
        return type;
    }
    
    
}
