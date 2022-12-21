namespace MicroFIN.Models;

public class LoginViewModel
{
    public LoginViewModel()
    {
        Username = "";
        Password = "";
        Remember = true;
    }
    public string Username { get; set; }
    public string Password { get; set; }
    public bool Remember { get; set; }
}