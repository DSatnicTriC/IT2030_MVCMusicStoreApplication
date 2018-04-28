﻿using System.Collections.Generic;

namespace MVCMusicStoreApplication.Models
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}