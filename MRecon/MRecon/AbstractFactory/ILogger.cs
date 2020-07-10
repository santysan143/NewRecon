using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRecon.AbstractFactory
{
    public interface ILogger
    {
        Int64 PageLogger(Int64 UserID, Int64 PageID);
        void UpdatePageLogger(Int64 PageLogID);
        void PageEventLogger(Int64 PageLogID, string MethodName, Int64 UserID, string Remarks, string RemarkType);
    }
}
