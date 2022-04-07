using MVC101.Models;

namespace MVC101.Services.SmsService;

public interface ISmsService
{
    SmsStates Send(SmsModel model);

}