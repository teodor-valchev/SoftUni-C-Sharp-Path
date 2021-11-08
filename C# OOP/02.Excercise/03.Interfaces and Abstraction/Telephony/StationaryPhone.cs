using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : IStationaryPhone
    {
        private string phoneNumber;

        public StationaryPhone(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }

        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }

            set
            {
                foreach (var c in value)
                {
                    if (char.IsLetter(c))
                    {
                        throw new Exception("Invalid number!");
                        
                    }
                }
                phoneNumber = value;
            }
        }

        public void Dialing()
        {
            Console.WriteLine($"Dialing... {PhoneNumber}");
        }
    }
}
