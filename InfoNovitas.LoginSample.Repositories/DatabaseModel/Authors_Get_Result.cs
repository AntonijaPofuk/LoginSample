//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InfoNovitas.LoginSample.Repositories.DatabaseModel
{
    using System;
    
    public partial class Authors_Get_Result
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public System.DateTimeOffset DateCreated { get; set; }
        public Nullable<int> UserCreated { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public Nullable<System.DateTimeOffset> LastModified { get; set; }
        public Nullable<int> UserLastModified { get; set; }
    }
}
