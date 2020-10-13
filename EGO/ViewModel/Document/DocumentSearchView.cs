using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGO.ViewModel.Document
{
    class DocumentSearchView
    {
        public DocumentSearchView(DOCUMENT document)
        {
            this.DOCUMENTYEAR = document.DOCUMENTYEAR;
            this.DOCUMENTNAME = document.DOCUMENTTYPE.DOCUMENTNAME;
            this.MADATORY = document.DOCUMENTTYPE.MADATORY;
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

        public int DOCUMENTYEAR { get; set; }
        public string DOCUMENTNAME { get; set; }
        public short MADATORY { get; set; }
        public List<DocumentSearchView> DocumentSearchViews { get; set; }
    }
}
