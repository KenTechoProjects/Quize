using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Models
{
    public class CommitBillerRequestResponse:ResponseModel
    {
        public string Pin { get; set; }
        public string TransactionReference { get; set; }
    }
}
