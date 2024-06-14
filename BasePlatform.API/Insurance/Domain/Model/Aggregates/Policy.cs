using BasePlatform.API.Insurance.Domain.Model.ValueObjects;

namespace BasePlatform.API.Insurance.Domain.Model.Aggregates;

public partial class Policy
{
    public Policy(string costumer, Eproduct productId, string address, string dni, int age)
    {
        this.Costumer = costumer;
        this.ProductId = productId;
        this.Address = address;
        this.Dni = dni;
        this.Age = age;
    }

    public int Id { get; }
    public string Costumer { get; private set; }
    
    public Eproduct ProductId { get; private set; }
    
    public string Address { get; private set; }
    
    public string Dni { get; private set; }
    
    public int Age { get; private set; }
}