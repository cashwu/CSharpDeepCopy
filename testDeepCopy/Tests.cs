using System;
using NUnit.Framework;

namespace testDeepCopy
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var poco = new Poco
            {
                Name = "123"
            };
            
            var original = new[] { poco, poco };

            var copyOriginal = DeepCopy.DeepCopier.Copy(original);
            
            Assert.AreNotSame(original, copyOriginal);
            Assert.AreSame(copyOriginal[0], copyOriginal[1]);
            Assert.AreNotSame(original[0], copyOriginal[1]);
            
            Assert.AreNotEqual(original, copyOriginal);
            Assert.AreEqual(copyOriginal[0], copyOriginal[1]);
            Assert.AreNotEqual(original[0], copyOriginal[1]);
            

            copyOriginal[0].Name = "cash";
            
            Assert.AreNotSame(copyOriginal[0], original[0]);
            
            Assert.AreNotEqual(copyOriginal[0], original[0]);
        }
    }

    public class Poco
    {
        public string Name { get; set; }
    }
}