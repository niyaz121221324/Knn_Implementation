using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kNN
{
    class Normalize
    {
        public float age;
        public float incoming;
        public float numCard;

        public Normalize(Customer customer, int maxAge, int maxIncome, int maxNumCard)
        {
            age = (float) customer.Age / (float)maxAge;
            incoming = (float) customer.Incoming / (float)maxIncome;
            numCard = (float) customer.NumCard / (float)maxNumCard;
        }
    }
}
