using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiDictionary.Services;
using System;
using System.Collections.Generic;

namespace MultiDictionary.UnitTests
{
    [TestClass]
    public class MultiDictionaryServicesTests
    {
        [TestMethod]
        // naming conventions
        // [MethodName]_[Scenrio]_[ExpectedBehaviour]
        public void Add_NewItem()
        {
            // Arrange
            MultiDictionaryService dictionary = new MultiDictionaryService();

            // Act
            string key = "A";
            var values = new List<string>() { "Apple", "All" };
            dictionary.Add(key, values);

            // Assert            
            Assert.AreEqual(values, dictionary.AllMembersForKey(key));
        }

        [TestMethod]
        // naming conventions
        // [MethodName]_[Scenrio]_[ExpectedBehaviour]
        public void Remove_ExistingKey()
        {
            // Arrange
            MultiDictionaryService dictionary = new MultiDictionaryService();

            // Act
            string key = "A";
            var values = new List<string>() { "Apple", "All" };
            dictionary.Add(key, values);
            dictionary.RemoveAllForKey(key);

            // Assert            
            Assert.IsFalse(dictionary.IsKey(key));
        }

        [TestMethod]
        // naming conventions
        // [MethodName]_[Scenrio]_[ExpectedBehaviour]
        public void Keys_keysPresent_ReturnsKeysList()
        {
            // Arrange
            MultiDictionaryService dictionary = new MultiDictionaryService();

            // Act
            string key = "A";
            var values = new List<string>() { "Apple", "All" };
            string key1 = "B";
            var values1 = new List<string>() { "Bat", "Ball" };
            dictionary.Add(key, values);
            dictionary.Add(key1, values1);
            var keysInserted = new List<string>() { "A", "B" };

            // Assert      
            CollectionAssert.AreEqual(keysInserted, (System.Collections.ICollection)dictionary.AllKeys());
        }

        [TestMethod]
        // naming conventions
        // [MethodName]_[Scenrio]_[ExpectedBehaviour]
        public void Count_NonEmptyDic_ReturnsCount()
        {
            // Arrange
            MultiDictionaryService dictionary = new MultiDictionaryService();

            // Act
            string key = "A";
            var values = new List<string>() { "Apple", "All" };
            dictionary.Add(key, values);

            // Assert            
            Assert.AreEqual(dictionary.Count(),1);
        }
    }
}
