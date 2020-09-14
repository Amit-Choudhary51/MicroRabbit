using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Banking.Application.DTO
{
    public class AccountTransferDTO
    {
        public int FromAccount { get; set; }
        public int ToAccount { get; set; }
        public decimal Amount { get; set; }

    }
}
