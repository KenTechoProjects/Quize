using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Models
{
    public class GetProductFormItemsResponseModel: ResponseModel
    {
        // public string RequestId { get; set; }
        public List<ProductFormItem> productFormItems { get; set; }
    }
    public class ProductFormItem
    {
        public int Id { get; set; }
        public string ProductId { get; set; }
        public string ItemName { get; set; }
        public string ItemDefaultValue { get; set; }
        public string ItemDescription { get; set; }
        public string DisplaySequenceNo { get; set; }
        public bool IsRequired { get; set; }
        public string DataType { get; set; }
        public string FieldType { get; set; }
    }
}
