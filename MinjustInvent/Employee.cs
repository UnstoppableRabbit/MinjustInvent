//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            this.Computers = new HashSet<Computers>();
        }
    
        public string Name { get; set; }
        public string Card { get; set; }
        public string СityPhone { get; set; }
        public string InternalPhone { get; set; }
        public int Id { get; set; }
        public string Office { get; set; }
        public string Post { get; set; }
        public string NameDepartament { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Computers> Computers { get; set; }
        public virtual USB USB { get; set; }
        public virtual Printers1 Printers1 { get; set; }
    }
}