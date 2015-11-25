using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using Smart.Framework.Model;

namespace Smart.Framework.DAL.SqlServer
{
    [Table("AuditLog")]
    public class AuditLog : ModelBase
    {
        public int Modelid { get; set; }
        public string UserName { get; set; }
        public string ModuleName { get; set; }
        public string TableName { get; set; }
        public string EventType { get; set; }
        public string NewValues { get; set; }
    }

    public class LogDbContext : SqlRepository//, IAuditable
    {
        public LogDbContext()
            : base()
        {
            Database.SetInitializer<LogDbContext>(null);
        }

        public DbSet<AuditLog> AuditLogs { get; set; }

        public void WriteLog(int modelid, string userName, string moduleName, string tableName, string eventType, ModelBase newValues)
        {
            this.AuditLogs.Add(new AuditLog()
            {
                Modelid = modelid,
                UserName = userName,
                ModuleName = moduleName,
                TableName = tableName,
                EventType = eventType,
                //  NewValues = JsonConvert.SerializeObject(newValues, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })
            });

            this.SaveChanges();
            this.Dispose();
        }
    }
}
