using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Timetable.Base.Entities;

namespace Timetable.Host.Interfaces
{
    public class OperationResult
    {
        public Status Status { get; set; }

        public BaseEntity Object { get; set; }
    }

    public enum Status
    {
        Success,
        Fail
    }
}