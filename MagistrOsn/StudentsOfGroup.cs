//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MagistrOsn
{
    using System;
    using System.Collections.Generic;
    
    public partial class StudentsOfGroup
    {
        public int IDGroup { get; set; }
        public int IDStudent { get; set; }
    
        public virtual GradesOfStudent GradesOfStudent { get; set; }
        public virtual Group Group { get; set; }
        public virtual Student Student { get; set; }
    }
}
