using Smart.Framework.DAL;
using Smart.Framework.Model;
using Smart.Framework.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Smart.Framework.DAL.SqlServer
{
    /// <summary>
    /// DAL基类，实现Repository通用泛型数据访问模式
    /// </summary>
    public class SqlRepository : DbContextBase
    {
        private static readonly string connstr = !string.IsNullOrEmpty(ConfigurationManager.ConnectionStrings["DbContext"].ConnectionString) ? Encrypt.Decode(ConfigurationManager.ConnectionStrings["DbContext"].ConnectionString) : "DbContext";
        public SqlRepository()
            : base(connstr)
        {
        }

        #region Table DbSet
        public virtual DbSet<sd_about> sd_about { get; set; }
        public virtual DbSet<sd_admin> sd_admin { get; set; }
        public virtual DbSet<sd_appointmentClass> sd_appointmentClass { get; set; }
        public virtual DbSet<sd_case> sd_case { get; set; }
        public virtual DbSet<sd_category> sd_category { get; set; }
        public virtual DbSet<sd_commondata> sd_commondata { get; set; }
        public virtual DbSet<sd_companyevent> sd_companyevent { get; set; }
        public virtual DbSet<sd_curriculum> sd_curriculum { get; set; }
        public virtual DbSet<sd_download> sd_download { get; set; }
        public virtual DbSet<sd_flash> sd_flash { get; set; }
        public virtual DbSet<sd_job> sd_job { get; set; }
        public virtual DbSet<sd_log> sd_log { get; set; }
        public virtual DbSet<sd_message> sd_message { get; set; }
        public virtual DbSet<sd_module> sd_module { get; set; }
        public virtual DbSet<sd_news> sd_news { get; set; }
        public virtual DbSet<sd_newstype> sd_newstype { get; set; }
        public virtual DbSet<sd_online> sd_online { get; set; }
        public virtual DbSet<sd_product> sd_product { get; set; }
        public virtual DbSet<sd_resume> sd_resume { get; set; }
        public virtual DbSet<sd_staff> sd_staff { get; set; }
        public virtual DbSet<sd_staffstar> sd_staffstar { get; set; }
        public virtual DbSet<sd_studentshare> sd_studentshare { get; set; }
        public virtual DbSet<sd_visits> sd_visits { get; set; }
        #endregion
    }
}

