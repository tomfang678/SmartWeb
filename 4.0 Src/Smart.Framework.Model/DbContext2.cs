namespace Smart.Framework.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbContext2 : DbContext
    {
        public DbContext2()
            : base("name=DbContext2")
        {
        }

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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<sd_about>()
                .Property(e => e.shortDesc)
                .IsUnicode(false);

            modelBuilder.Entity<sd_about>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<sd_about>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<sd_about>()
                .Property(e => e.fax)
                .IsUnicode(false);

            modelBuilder.Entity<sd_about>()
                .Property(e => e.other)
                .IsUnicode(false);

            modelBuilder.Entity<sd_admin>()
                .Property(e => e.admin_type)
                .IsUnicode(false);

            modelBuilder.Entity<sd_admin>()
                .Property(e => e.admin_id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<sd_admin>()
                .Property(e => e.admin_pass)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<sd_admin>()
                .Property(e => e.admin_name)
                .IsUnicode(false);

            modelBuilder.Entity<sd_admin>()
                .Property(e => e.admin_email)
                .IsUnicode(false);

            modelBuilder.Entity<sd_admin>()
                .Property(e => e.admin_modify_ip)
                .IsUnicode(false);

            modelBuilder.Entity<sd_admin>()
                .Property(e => e.cookie)
                .IsUnicode(false);

            modelBuilder.Entity<sd_admin>()
                .Property(e => e.admin_shortcut)
                .IsUnicode(false);

            modelBuilder.Entity<sd_appointmentClass>()
                .Property(e => e.ClassName)
                .IsUnicode(false);

            modelBuilder.Entity<sd_appointmentClass>()
                .Property(e => e.Position)
                .IsUnicode(false);

            modelBuilder.Entity<sd_appointmentClass>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<sd_appointmentClass>()
                .Property(e => e.Tel)
                .IsUnicode(false);

            modelBuilder.Entity<sd_appointmentClass>()
                .Property(e => e.QQ)
                .IsUnicode(false);

            modelBuilder.Entity<sd_appointmentClass>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<sd_appointmentClass>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<sd_appointmentClass>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<sd_case>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<sd_case>()
                .Property(e => e.ctitle)
                .IsUnicode(false);

            modelBuilder.Entity<sd_case>()
                .Property(e => e.keywords)
                .IsUnicode(false);

            modelBuilder.Entity<sd_case>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<sd_case>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<sd_case>()
                .Property(e => e.imgurl)
                .IsUnicode(false);

            modelBuilder.Entity<sd_case>()
                .Property(e => e.displayimg)
                .IsUnicode(false);

            modelBuilder.Entity<sd_companyevent>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<sd_curriculum>()
                .Property(e => e.imgurl)
                .IsUnicode(false);

            modelBuilder.Entity<sd_curriculum>()
                .Property(e => e.classtime)
                .IsUnicode(false);

            modelBuilder.Entity<sd_curriculum>()
                .Property(e => e.remark)
                .IsUnicode(false);

            modelBuilder.Entity<sd_curriculum>()
                .Property(e => e.contents)
                .IsUnicode(false);

            modelBuilder.Entity<sd_curriculum>()
                .Property(e => e.price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<sd_download>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<sd_download>()
                .Property(e => e.keywords)
                .IsUnicode(false);

            modelBuilder.Entity<sd_download>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<sd_download>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<sd_download>()
                .Property(e => e.downloadurl)
                .IsUnicode(false);

            modelBuilder.Entity<sd_download>()
                .Property(e => e.filesize)
                .IsUnicode(false);

            modelBuilder.Entity<sd_download>()
                .Property(e => e.filename)
                .IsUnicode(false);

            modelBuilder.Entity<sd_download>()
                .Property(e => e.filetype)
                .IsUnicode(false);

            modelBuilder.Entity<sd_flash>()
                .Property(e => e.URL)
                .IsUnicode(false);

            modelBuilder.Entity<sd_flash>()
                .Property(e => e.descript)
                .IsUnicode(false);

            modelBuilder.Entity<sd_flash>()
                .Property(e => e.imgurl)
                .IsUnicode(false);

            modelBuilder.Entity<sd_flash>()
                .Property(e => e.imgclass)
                .IsUnicode(false);

            modelBuilder.Entity<sd_job>()
                .Property(e => e.position)
                .IsUnicode(false);

            modelBuilder.Entity<sd_job>()
                .Property(e => e.place)
                .IsUnicode(false);

            modelBuilder.Entity<sd_job>()
                .Property(e => e.deal)
                .IsUnicode(false);

            modelBuilder.Entity<sd_job>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<sd_job>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<sd_job>()
                .Property(e => e.filename)
                .IsUnicode(false);

            modelBuilder.Entity<sd_job>()
                .Property(e => e.shortdescript)
                .IsUnicode(false);

            modelBuilder.Entity<sd_log>()
                .Property(e => e.ip)
                .IsUnicode(false);

            modelBuilder.Entity<sd_log>()
                .Property(e => e.operation)
                .IsUnicode(false);

            modelBuilder.Entity<sd_message>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<sd_message>()
                .Property(e => e.tel)
                .IsUnicode(false);

            modelBuilder.Entity<sd_message>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<sd_message>()
                .Property(e => e.contact)
                .IsUnicode(false);

            modelBuilder.Entity<sd_message>()
                .Property(e => e.info)
                .IsUnicode(false);

            modelBuilder.Entity<sd_message>()
                .Property(e => e.ip)
                .IsUnicode(false);

            modelBuilder.Entity<sd_message>()
                .Property(e => e.useinfo)
                .IsUnicode(false);

            modelBuilder.Entity<sd_message>()
                .Property(e => e.lang)
                .IsUnicode(false);

            modelBuilder.Entity<sd_message>()
                .Property(e => e.customerid)
                .IsUnicode(false);

            modelBuilder.Entity<sd_module>()
                .Property(e => e.url)
                .IsUnicode(false);

            modelBuilder.Entity<sd_module>()
                .Property(e => e.adminurl)
                .IsUnicode(false);

            modelBuilder.Entity<sd_module>()
                .Property(e => e.summary)
                .IsUnicode(false);

            modelBuilder.Entity<sd_news>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<sd_news>()
                .Property(e => e.keywords)
                .IsUnicode(false);

            modelBuilder.Entity<sd_news>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<sd_news>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<sd_news>()
                .Property(e => e.imgurl)
                .IsUnicode(false);

            modelBuilder.Entity<sd_news>()
                .Property(e => e.imgurls)
                .IsUnicode(false);

            modelBuilder.Entity<sd_news>()
                .Property(e => e.issue)
                .IsUnicode(false);

            modelBuilder.Entity<sd_news>()
                .Property(e => e.filename)
                .IsUnicode(false);

            modelBuilder.Entity<sd_news>()
                .Property(e => e.date)
                .IsUnicode(false);

            modelBuilder.Entity<sd_news>()
                .Property(e => e.videourl)
                .IsUnicode(false);

            modelBuilder.Entity<sd_online>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<sd_online>()
                .Property(e => e.qq)
                .IsUnicode(false);

            modelBuilder.Entity<sd_online>()
                .Property(e => e.msn)
                .IsUnicode(false);

            modelBuilder.Entity<sd_online>()
                .Property(e => e.taobao)
                .IsUnicode(false);

            modelBuilder.Entity<sd_online>()
                .Property(e => e.alibaba)
                .IsUnicode(false);

            modelBuilder.Entity<sd_online>()
                .Property(e => e.skype)
                .IsUnicode(false);

            modelBuilder.Entity<sd_product>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<sd_product>()
                .Property(e => e.ctitle)
                .IsUnicode(false);

            modelBuilder.Entity<sd_product>()
                .Property(e => e.keywords)
                .IsUnicode(false);

            modelBuilder.Entity<sd_product>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<sd_product>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<sd_product>()
                .Property(e => e.imgurl)
                .IsUnicode(false);

            modelBuilder.Entity<sd_product>()
                .Property(e => e.imgurls)
                .IsUnicode(false);

            modelBuilder.Entity<sd_product>()
                .Property(e => e.displayimg)
                .IsUnicode(false);

            modelBuilder.Entity<sd_product>()
                .Property(e => e.issue)
                .IsUnicode(false);

            modelBuilder.Entity<sd_product>()
                .Property(e => e.filename)
                .IsUnicode(false);

            modelBuilder.Entity<sd_product>()
                .Property(e => e.price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<sd_product>()
                .Property(e => e.discoutprice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<sd_resume>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<sd_resume>()
                .Property(e => e.qq)
                .IsUnicode(false);

            modelBuilder.Entity<sd_resume>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<sd_resume>()
                .Property(e => e.files)
                .IsUnicode(false);

            modelBuilder.Entity<sd_staff>()
                .Property(e => e.imgurl)
                .IsUnicode(false);

            modelBuilder.Entity<sd_staff>()
                .Property(e => e.remark)
                .IsUnicode(false);

            modelBuilder.Entity<sd_staff>()
                .Property(e => e.link)
                .IsUnicode(false);

            modelBuilder.Entity<sd_staff>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<sd_staff>()
                .Property(e => e.education)
                .IsUnicode(false);

            modelBuilder.Entity<sd_staff>()
                .Property(e => e.professional)
                .IsUnicode(false);

            modelBuilder.Entity<sd_staff>()
                .Property(e => e.position)
                .IsUnicode(false);

            modelBuilder.Entity<sd_staff>()
                .Property(e => e.state)
                .IsUnicode(false);

            modelBuilder.Entity<sd_staff>()
                .Property(e => e.idcard)
                .IsUnicode(false);

            modelBuilder.Entity<sd_staff>()
                .Property(e => e.department)
                .IsUnicode(false);

            modelBuilder.Entity<sd_staffstar>()
                .Property(e => e.staffid)
                .IsUnicode(false);

            modelBuilder.Entity<sd_staffstar>()
                .Property(e => e.imgurl)
                .IsUnicode(false);

            modelBuilder.Entity<sd_studentshare>()
                .Property(e => e.vediourl)
                .IsUnicode(false);

            modelBuilder.Entity<sd_visits>()
                .Property(e => e.ip)
                .IsUnicode(false);

            modelBuilder.Entity<sd_visits>()
                .Property(e => e.remark)
                .IsUnicode(false);
        }
    }
}
