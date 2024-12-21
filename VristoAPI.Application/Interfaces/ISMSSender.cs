using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio.Rest.Api.V2010.Account;

namespace VristoAPI.Application.Interfaces
{
    public interface ISMSSender
    {
        MessageResource Send(string PhoneNumber, string Body);

    }
}
