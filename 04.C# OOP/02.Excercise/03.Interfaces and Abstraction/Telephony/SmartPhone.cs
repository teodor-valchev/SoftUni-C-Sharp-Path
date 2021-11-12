using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class SmartPhone : ISmartPhone
    {
        private string phoneNumber;
        private string url;

        public SmartPhone(string phoneNumber,string url)
        {
            PhoneNumber = phoneNumber;
            URL = url;
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

        public string URL
        {
            get
            {
                return url;
            }
            set
            {
                foreach (var c in value)
                {
                    if (char.IsDigit(c))
                    {
                        Console.WriteLine("Invalid URL!");
                    }
                    else
                    {
                        Console.WriteLine($"Browsing: {value}!");
                    }
                }
                url = value;


            }
        }

        public void Calling()
        {
            Console.WriteLine($"Calling... {PhoneNumber}");
        }
    }
}

      
    

