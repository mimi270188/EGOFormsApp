using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace EGOFormsApp.ViewModel
{
    class DocumentSearchView
    {
        public DocumentSearchView(DOCUMENT document)
        {
            this.DOCUMENTID = document.DOCUMENTID;
            this.DOCUMENTTYPENAME = document.DOCUMENTTYPE.DOCUMENTNAME;
            this.DOCUMENTYEAR = document.DOCUMENTYEAR;
        }

        public DocumentSearchView(List<DOCUMENT> documents)
        {
            this.DocumentSearchViews = new List<DocumentSearchView>();
            foreach (var document in documents)
            {
                DocumentSearchView documentSearchView = new DocumentSearchView(document);
                this.DocumentSearchViews.Add(documentSearchView);
            }
        }
        public int DOCUMENTID { get; set; }
        public string DOCUMENTTYPENAME { get; set; }
        public int DOCUMENTYEAR { get; set; }
        public List<DocumentSearchView> DocumentSearchViews { get; set; }

    }
}
