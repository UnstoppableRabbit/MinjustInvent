﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MinjustInvent
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class minjustDBEntities : DbContext
    {
        public minjustDBEntities()
            : base("name=minjustDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ARMOrder> ARMOrder { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<KartochkiOrder> KartochkiOrder { get; set; }
        public virtual DbSet<PrinterOrder> PrinterOrder { get; set; }
        public virtual DbSet<TelephonyOrder> TelephonyOrder { get; set; }
        public virtual DbSet<USBOrder> USBOrder { get; set; }
    }
}
