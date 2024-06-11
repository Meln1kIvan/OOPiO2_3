using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLib;
using System.Linq;

namespace MyLib.Tests
{
    [TestClass]
    public class MyCollectionTests
    {
        [TestMethod]
        public void Add_ItemToCollection_CollectionContainsItem()
        {
            // Arrange
            var collection = new MyCollection<int>();

            // Act
            collection.Add(1);

            // Assert
            Assert.IsTrue(collection.Contains(1));
        }

        [TestMethod]
        public void Remove_ItemFromCollection_CollectionDoesNotContainItem()
        {
            // Arrange
            var collection = new MyCollection<int>();
            collection.Add(1);

            // Act
            collection.Remove(1);

            // Assert
            Assert.IsFalse(collection.Contains(1));
        }

        [TestMethod]
        public void Count_EmptyCollection_ReturnsZero()
        {
            // Arrange
            var collection = new MyCollection<int>();

            // Act
            int count = collection.Count;

            // Assert
            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void Count_NonEmptyCollection_ReturnsCorrectCount()
        {
            // Arrange
            var collection = new MyCollection<int>();
            collection.Add(1);
            collection.Add(2);
            collection.Add(3);

            // Act
            int count = collection.Count;

            // Assert
            Assert.AreEqual(3, count);
        }

        [TestMethod]
        public void Clear_CollectionIsEmpty()
        {
            // Arrange
            var collection = new MyCollection<int>();
            collection.Add(1);
            collection.Add(2);
            collection.Add(3);

            // Act
            collection.Clear();

            // Assert
            Assert.AreEqual(0, collection.Count);
        }

        [TestMethod]
        public void CopyTo_CopyCollectionToArray_ArrayContainsCollectionItems()
        {
            // Arrange
            var collection = new MyCollection<int>();
            collection.Add(1);
            collection.Add(2);
            collection.Add(3);
            var array = new int[3];

            // Act
            collection.CopyTo(array, 0);

            // Assert
            CollectionAssert.AreEqual(collection.ToList(), array);
        }
    }
}