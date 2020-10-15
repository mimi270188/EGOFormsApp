using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace EGOFormsApp.Common
{
    static class Translation
    {
        static public string GetByKey(string key)
        {
            EGOEntities egoEntities = new EGOEntities();
            if (egoEntities.TRANSLATION.Any(x=>x.TRANSLATIONKEY == key))
            {
                return egoEntities.TRANSLATION.First(x => x.TRANSLATIONKEY == key).WORDS;
            }
            else
            {
                return key;
            }
        }
    }
}
