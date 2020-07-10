using MRecon.Database;
using MRecon.AbstractFactory;
using MRecon.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRecon.SQLConnectionFactory
{
    class LoggerBAL : ILogger
    {
         DbModel db;
         public LoggerBAL()
         {
             db = new DbModel();
         }
        long ILogger.PageLogger(long UserID, long PageID)
        {
            PageLogMaster log = new PageLogMaster();
            log.CreatedBy = UserID;
            log.CreatedDtTm = DateTime.Now;
            log.IsActive = true;
            log.PageEnteredDtTm = DateTime.Now;
            log.PageID = PageID;
            log.UserID = UserID;
            db.PageLogMasters.Add(log);
            db.SaveChanges();
            return log.LogID;
        }

        void ILogger.UpdatePageLogger(long PageLogID)
        {
            var Log = db.PageLogMasters.Where(w => w.LogID == PageLogID).ToList();
            foreach (var item in Log)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        void ILogger.PageEventLogger(long PageLogID, string MethodName, long UserID, string Remarks, string RemarkType)
        {
            PageActionLogMaster logAction = new PageActionLogMaster();
            logAction.CreatedBy = UserID;
            logAction.CreatedDtTm = DateTime.Now;
            logAction.IsActive = true;
            logAction.ActivityStartDtTm = DateTime.Now;
            logAction.LogID = PageLogID;
            logAction.MethodName = MethodName;
            logAction.Remarks = Remarks;
            logAction.RemarkType = RemarkType;
            db.PageActionLogMasters.Add(logAction);
            db.SaveChanges();
        }
    }
}
