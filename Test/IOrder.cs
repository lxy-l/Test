using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public interface IOrder
    {
        DateTime Purchased { get; }
        decimal Cost { get; }
    }
}
