//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class PHONE
    {
        public int PHONEID { get; set; }
        public int FAMILYID { get; set; }
        public string PHONENUMBER { get; set; }
    
        public virtual FAMILY FAMILY { get; set; }
    }
}