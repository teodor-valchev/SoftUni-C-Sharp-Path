using System;

namespace Telephony
{
    public class Program
    {
        public static void Main(string[] args)
        {

            string[] phoneNumbers = Console.ReadLine().Split();
            string[] url = Console.ReadLine().Split();
            int count = 0;

            foreach (var phone in phoneNumbers)
            {
                if (phone.Length == 10)
                {
                    ISmartPhone smartPhone = new SmartPhone(phone, url[count]);
                    smartPhone.Calling();
                    count++;      
                }
                else
                {
                    IStationaryPhone stationary = new StationaryPhone(phone);
                    stationary.Dialing();
               }

            }

        }
    }
}
