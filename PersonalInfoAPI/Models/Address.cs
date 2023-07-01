namespace PersonalInfoAPI.Models;

public class Address 
{
    public int Id {get; set;}
    public int PersonId {get; set;}
    public string? Longitude {get; set;}
    public string? Latitude {get; set;}
    public string? LandMark {get; set;}
    public string? PinCode {get; set;}
}