using System;
using System.Collections.Generic;
using System.Text;

namespace MultiDictionary.Interfaces
{
    interface IDictionaryAdvance
    {
        public string MemberOf(string member);

        public int Count();

        public int MemberCount(string key);

       
    }
}
