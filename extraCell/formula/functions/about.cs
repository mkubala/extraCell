﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace extraCell.formula.functions
{
    class about : IFunction
    {
        public Object run(Object[] args)
        {
            return "by: Marcin Kubala, Michał Urbańczyk, Paweł Ochalik";
        }
    }
}
