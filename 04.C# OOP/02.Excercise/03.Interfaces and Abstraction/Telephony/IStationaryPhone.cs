using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    interface IStationaryPhone
    {

        public string PhoneNumber { get; set; }

        void Dialing();
        
    }
}
