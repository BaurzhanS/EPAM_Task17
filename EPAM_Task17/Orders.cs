//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EPAM_Task17
{
    using System;
    using System.Collections.Generic;
    
    public partial class Orders
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Orders()
        {
            this.OrdersCartsProductsSellers = new HashSet<OrdersCartsProductsSellers>();
        }
    
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
    
        public virtual Customers Customers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdersCartsProductsSellers> OrdersCartsProductsSellers { get; set; }
        public virtual Orders Orders1 { get; set; }
        public virtual Orders Orders2 { get; set; }
    }
}
