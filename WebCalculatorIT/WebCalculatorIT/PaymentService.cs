using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCalculatorIT
{
    public class PaymentService
    {
        public PaymentRepository PaymentRepository { get; set; }

        public PaymentService(PaymentRepository repo)
        {
            PaymentRepository = repo;
        }

        public Boolean CreatePayment(string namePayment)
        {
            return PaymentRepository.CreatePayment(namePayment);
        }
    }
}