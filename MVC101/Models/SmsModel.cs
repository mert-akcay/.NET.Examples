namespace MVC101.Models;

public class SmsModel
{
    public string TelefonNo { get; set; }
    public string Mesaj { get; set; }
}

public enum SmsStates
{
    Pending,
    Sent,
    Failed
}