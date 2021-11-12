using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public interface ISmartPhone
    {
        public string PhoneNumber { get; set; }

        public string URL { get; set; }

        void Calling();
    }
}
