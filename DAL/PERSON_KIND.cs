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
    
    public partial class PERSON_KIND
    {
        public int PERSON_KIND_ID { get; set; }
        public int PERSONID { get; set; }
        public int KINDID { get; set; }
    
        public virtual KIND KIND { get; set; }
        public virtual PERSON PERSON { get; set; }
    }
}
