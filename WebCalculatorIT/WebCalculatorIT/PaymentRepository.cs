using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCalculatorIT
{
    public class PaymentRepository
    {
        public PaymentRepository(ApplicationDbContext context)
        {
        }

        public Boolean CreatePayment(string namePayment)
        {
            return true;
        }
    }
}