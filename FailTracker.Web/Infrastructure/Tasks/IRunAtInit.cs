﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FailTracker.Web.Infrastructure.Tasks
{
    interface IRunAtInit
    {
        void Execute();
    }
}
