using MultiDictionary.Interfaces;
using MultiDictionary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultiDictionary.Services
{
    public class MultiDictionaryService : IDictionaryBasic, IDictionaryAdvance 
    {
        //private readonly Dictionary<string, List<string>> dicData = new Dictionary<string, List<string>>();

        private IList<MultiDictionaryModel> entries = null;
        public string message = null;

        public MultiDictionaryService()
        {
            this.entries = new List<MultiDictionaryModel>();
        }

        #region Basic Methods

        //
        // Summary:
        //     Adds an object to the end of the Dictionary collection.
        //
        // Parameters:
        //   key:
        //     key to be added
        //   values:
        //     values for the given key
        public void Add(string key, IList<string> values)
        {
            message = null;
            
            if (!IsKey(key))
            {
               entries.Add(new MultiDictionaryModel { key = key, value = values });
               message = "Key and Member added";

            }
            else
            {
                var members = AllMembersForKey(key);
                foreach (var item in values)
                {
                    if (members.Contains(item))
                    {
                        message = "member already exists for this key";
                    }
                    else
                    {
                        members.Add(item);
                        message = "member added to Existing key";

                    }
                }
               
            }
        }

        //
        // Summary:
        //     Return All Items in Dictionary.        
        public IList<MultiDictionaryModel> AllItems()
        {
            message = null;
            if (!IsEmpty())
            {
                return entries;
            }
            message = "Dictionary Empty";
            return null;
        }

        //
        // Summary:
        //     Return All Keys in Dictionary.  
        public IList<string> AllKeys()
        {
            message = null;

            if (!IsEmpty())
            {
                var keys = new List<string>();
                foreach (var entry in entries)
                {
                    keys.Add(entry.key);
                }
                return keys;
            }
            message = "No Key";
            return null;

        }

        //
        // Summary:
        //     Return All Members in Dictionary.        
        public IList<string> AllMembers()
        {
            message = null;

            if (!IsEmpty())
            {
                var members = new List<string>();
                foreach (var entry in entries)
                {
                    foreach (var member in entry.value)
                    {
                        members.Add(member);                        
                    }
                }
                return members;
            }
            message = "No Key";
            return null;

        }

        //
        // Summary:
        //     Return All Members for given Key in Dictionary.  
        // Parameters:
        //   key:
        //     key to be searched
        public IList<string> AllMembersForKey(string key)
        {
            message = null;

            if (!IsEmpty())
            {
                foreach (var entry in entries)
                {
                    if (entry.key.ToLower() == key.ToLower())
                    {
                        return entry.value;
                    }
                }

            }
            message = "key does not exist";
            return null;
        }

        //
        // Summary:
        //     Clears Dictionary  
        public void Clear()
        {
            message = null;

            if (!IsEmpty())
            {
                entries = new List<MultiDictionaryModel>();
                message = "Dictionary Cleared";
            }
        }

        //
        // Summary:
        //     Return true if key exists.  
        // Parameters:
        //   key:
        //     key to be searched
        public bool IsKey(string key)
        {
            message = null;

            if (!IsEmpty())
            {
                foreach (var entry in entries)
                {
                    if (entry.key.ToLower() == key.ToLower())
                        return true;
                }
            }
            return false;
        }

        //
        // Summary:
        //     Return true if key and member exists.  
        // Parameters:
        //   key:
        //     key to be searched
        //   member:
        //     member to be searched
        public bool IsMemberForKey(string key, string member)
        {
            message = null;

            if (IsKey(key))
            {
                //add new mwmber
                foreach (var item in AllMembersForKey(key))
                {
                    if (item.ToLower() == member.ToLower())
                        return true;
                }
                message = "Member not present for Key";
                return false;

            }
            else
            {
                message = "key does not exist";
                return false;

            }
        }

        //
        // Summary:
        //     Remove all members for a key.  
        // Parameters:
        //   key:
        //     key to be searched by
        public void RemoveAllForKey(string key)
        {
            message = null;

            if (!IsEmpty())
            {
                if (IsKey(key))
                {
                    var entry = entries.Where(x => x.key == key).ToList();
                    entries.Remove(entry[0]);
                    message = "Removed Key from Dictionary";
                }
                else
                {
                    message = "Key not present";

                }
            }
            else
            {
                message = "Empty Dictionary";
            }
        }

        //
        // Summary:
        //     Remove member form a given key.  
        // Parameters:
        //   key:
        //     key to be searched
        //   member:
        //     member to be removed
        public void RemoveMemberFor(string key, string member)
        {
            message = null;

            if (IsKey(key) && !IsEmpty())
            {
                var members = AllMembersForKey(key);

                if (members.Contains(member))
                {
                    if (members.Count > 1)
                    {
                        members.Remove(member);
                        message = "member removed from Key";
                    }
                    else
                    {
                        RemoveAllForKey(key);
                    }
                }
                else
                {
                    message = "member not present";

                }

            }
            else
            {
                message = "Key not present";

            }
        }

        #endregion



        #region Advance Methods 
        
        //
        // Summary:
        //     Returns key in which member is present.
        // Parameters:       
        //   member:
        //     member to be searched
        public string MemberOf(string member)
        {
            message = null;
            if (!IsEmpty())
            {
                var key = entries.Where(x => x.value.Contains(member)).Select(x=>x.key).FirstOrDefault();
                if (key !=null)
                {
                    return key;
                }
                else
                {
                    message = "No such member in any Key";
                }
            }
            else
            {
                message = "Dictionary Empty";
            }
            return null;

        }


        //
        // Summary:
        //     Returns total numbers of records in Dictionary
        public int Count()
        {
            message = null;
            if (!IsEmpty())
            {
                return entries.Count();
            }
            else
            {
                message = "Dictionary empty";
                return 0;
            }
        }

        //
        // Summary:
        //     Returns total numbers of members in Dictionary for that given key
        // Parameters:       
        //   key:
        //     key to be searched
        public int MemberCount(string key)
        {
            message = null;
            if (!IsEmpty())
            {
                var values = AllMembersForKey(key);
                return values.Count();
            }
            else
            {
                message = "Dictionary empty";
                return 0;
            }
        }
        #endregion

        #region Private Methods

        //
        // Summary:
        //     Returns true if Dictionary is null
        private bool IsEmpty()
        {
            return entries.Count == 0;
        }
        #endregion
    }
}
