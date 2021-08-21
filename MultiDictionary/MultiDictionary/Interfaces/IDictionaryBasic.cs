using MultiDictionary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiDictionary.Interfaces
{
    interface IDictionaryBasic
    {
        public void Add(string key, IList<string> value);

        public void RemoveMemberFor(string key, string member);

        public void RemoveAllForKey(string key);

        public IList<string> AllMembersForKey(string key);

        public bool IsKey(string key);

        public bool IsMemberForKey(string key, string member);

        public IList<string> AllMembers();

        public void Clear();
        public IList<string> AllKeys();
        public IList<MultiDictionaryModel> AllItems();

    }
}
