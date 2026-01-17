namespace DTOLayer.DTOs.AppUserDTOs;

public class AppUserRegisterDTOs
{
    public string Name { get; set; }   
    public string SurName { get; set; }   
    public string UserName { get; set; }  
    public string Mail { get; set; }  
    public string Password { get; set; }  
    public string ConfirmPassword { get; set; }
    public string? Gender { get; set; }
    public string? ImageUrl { get; set; }
}