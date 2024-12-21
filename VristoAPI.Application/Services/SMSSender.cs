using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using VristoAPI.Application.Interfaces;
using VristoAPI.Domain.Models;

namespace VristoAPI.Application.Services
{
    public class SMSSender : ISMSSender
    {
        private readonly TwillioSettings twillio;

        public SMSSender(IOptions<TwillioSettings> Twillio)
        {
            twillio = Twillio.Value;
        }
        public MessageResource Send(string PhoneNumber, string Body)
        {
            TwilioClient.Init(twillio.AccountSID, twillio.AuthToken);
            var result = MessageResource.Create(
                body: Body,
                from: new Twilio.Types.PhoneNumber(twillio.PhoneNumber),
                to: PhoneNumber);

            return result;
        }
    }
}
