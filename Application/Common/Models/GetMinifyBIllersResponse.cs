using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Models
{
   public class GetMinifyBIllersResponse: ResponseModel
    {
        public string RequestId { get; set; }
        public List<Biller> Billers { get; set; }
    }
    public class Biller
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
