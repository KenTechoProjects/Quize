﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Models
{
    public class GetMobileMoneyOperatorsResponse :ResponseModel
    {
        public List<BaseResponseModel> Billers { get; set; }
    }
}
