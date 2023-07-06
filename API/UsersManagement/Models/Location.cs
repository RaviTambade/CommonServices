namespace UsersManagement.Models;

public class Location 
{
    public int Id {get; set;}
    public int UserId {get; set;}
    public string? Longitude {get; set;}
    public string? Latitude {get; set;}
    public string? LandMark {get; set;}
    public string? PinCode {get; set;}
}