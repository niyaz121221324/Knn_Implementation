using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kNN
{
    class MaximumValue
    {
        private int maxAge = 0;
        private int maxIncome = 0;
        private int maxNumCard = 0;

        private List<Customer> _customers = new List<Customer>();

        public MaximumValue(List <Customer> customers)
        {
            this._customers = customers;
        }

        public void findAllMax()
        {
            for (int i = 0; i < this._customers.Count; i++)
            {
                if (this._customers[i].Age > maxAge)
                    maxAge = this._customers[i].Age;
                if (this._customers[i].Incoming > maxIncome)
                    maxIncome = this._customers[i].Incoming;
                if (this._customers[i].NumCard > maxNumCard)
                    maxNumCard = this._customers[i].NumCard;
            }
        }


        public int getMaxAge()
        {
            return this.maxAge;
        }

        public int getMaxIncome()
        {
            return this.maxIncome;
        }

        public int getMaxNumCard()
        {
            return this.maxNumCard;
        }
    }
}
