using System.Diagnostics;
using MVC101.Models;

namespace MVC101.Services.SmsService;

public class SonicSmsService : ISmsService
{
    public SmsStates Send(SmsModel model)
    {
        Debug.Write($"Sonic : {model.TelefonNo} - {model.Mesaj}");
        return SmsStates.Sent;
    }
}