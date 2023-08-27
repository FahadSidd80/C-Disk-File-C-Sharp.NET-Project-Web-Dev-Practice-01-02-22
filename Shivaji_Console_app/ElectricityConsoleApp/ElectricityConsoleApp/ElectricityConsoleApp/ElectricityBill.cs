using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityConsoleApp
{
    public class ElectricityBill
    {
        //Implement the fields and properties as per description
        private String consumerNumber;
        private String consumerName;
        private int unitsConsumed;
        private double billAmount;

        public string ConsumerNumber
        {
            get { return this.consumerNumber; }
            set
            {
                if (value.Substring(0, 2).Equals("EB"))
                {
                    this.consumerNumber = value;
                }
                else
                    throw new FormatException("Invalid Consumer Number");
            }
        }
        //public string ConsumerNumber { get; set; }
        public string ConsumerName { get; set; }
        public int UnitsConsumed { get; set; }
        public double BillAmount { get; set; }

         public override string ToString()
         {
         return String.Format("EB Bill for "+ ConsumerName+" is "+BillAmount);
         }

    }
}
