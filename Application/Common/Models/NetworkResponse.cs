using System.Collections.Generic;


namespace Application.Common.Models
{
    //public class NetworkResponse : ResponseModel
   public class NetworkResponse
    {
      //  public string RequestId { get; set; }
        public List<BaseResponseModel> Billers { get; set; }
    }
  //  public class CategoryResponse : ResponseModel
   public class CategoryResponse 
    {
        //[JsonIgnore]
        //public string RequestId { get; set; }
        public List<BaseResponseModel> Categories { get; set; }
    }
}
