﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarbucksClone.Application.DTO
{
    public class AddCartLineDto
    {
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public IEnumerable<AddInForCartDto> AddIns { get; set; }
    }

    public class AddInForCartDto
    {
        public int Id { get; set; }
        public int? Pump { get; set; }
    }

    public class CartLineDto
    {
        public int CartLineId { get; set; }
        public string ProductImage { get; set; }
        public string ProductName { get; set; } 
        public string ProductSize { get; set; }
    }

    public class ModifyCartLineDto
    {
        public int CartLineId { get; set; }
        public int SizeId { get; set; }

        public IEnumerable<AddInForCartDto> AddIns { get; set; }

    }

    public class DeleteCartLineDto
    {
        public int CartLineId { get; set; }
    }
}
