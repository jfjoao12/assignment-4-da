using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using Assignment_4;

namespace TestLibrary
{
    [TestFixture]
    public class StringKeyTest
    {
        /// <summary>
        /// Tests the StringKey constructor.
        /// </summary>
        [Test]
        public static void StringKeyConstructorTest()
        {
            string name = "Name";
            StringKey stringKey = new StringKey(name);

            ClassicAssert.AreEqual(stringKey.KeyName, name);
        }

        /// <summary>
        /// Test CompareTo using the same object. Ensures StringKey impliments IComparable<StringKey>
        /// </summary>
        [Test]
        public static void CompareToSameObjectTest()
        {
            int expectedResult = 0;
            StringKey stringKey = new StringKey("Name");
            IComparable<StringKey> comparableStringKey = stringKey;

            ClassicAssert.AreEqual(expectedResult, comparableStringKey.CompareTo(stringKey));
        }

        /// <summary>
        /// Test CompareTo on two StringKeys with the same name.
        /// </summary>
        [Test]
        public static void CompareToSameNameTest()
        {
            int expectedResult = 0;
            StringKey stringKey1 = new StringKey("A");
            StringKey stringKey2 = new StringKey("A");

            ClassicAssert.AreEqual(expectedResult, stringKey1.CompareTo(stringKey2));

        }

        /// <summary>
        /// Test CompareTo with a stringKey with a name that comes aphabetically before the instance.
        /// </summary>
        [Test]
        public static void CompareToAphabeticallyBeforeNameTest()
        {
            StringKey stringKey1 = new StringKey("B");
            StringKey stringKey2 = new StringKey("A");

            ClassicAssert.IsTrue(stringKey1.CompareTo(stringKey2) > 0);
        }

        /// <summary>
        /// Test CompareTo with a StringKey with a name that comes aphabetically after the instance.
        /// </summary>
        [Test]
        public static void CompareToAphabeticallyAfterNameTest()
        {
            StringKey stringKey1 = new StringKey("A");
            StringKey stringKey2 = new StringKey("B");

            ClassicAssert.IsTrue(stringKey1.CompareTo(stringKey2) < 0);
        }


        /// <summary>
        /// Test that the GetHashCode method returns differnt values for words with 
        /// same letters in different orders. Ensures overwrite of Object's HashCode method.
        /// </summary>
        [Test]
        public static void GetHashCodeVarietyTest()
        {
            StringKey stringKey1 = new StringKey("stop");
            StringKey stringKey2 = new StringKey("pots");
            object objStrKey1 = stringKey1;
            object objStrKey2 = stringKey2;

            ClassicAssert.AreNotEqual(objStrKey1.GetHashCode(), objStrKey2.GetHashCode());
        }


        /// <summary>
        /// Test that the GetHashCode method returns positive values for large words.
        /// </summary>
        [Test]
        public static void GetHashCode_is_not_negative_Test()
        {
            StringKey stringKey1 = new StringKey("1234567"); // ints should overflow int to negative when hashed using this value

            object objStrKey1 = stringKey1;
            ClassicAssert.GreaterOrEqual(objStrKey1.GetHashCode(), 0);
        }

        /// <summary>
        /// Test that GetHashCode returns 0 on an empty name.
        /// </summary>
        [Test]
        public static void GetHashCodeEmptyNameTest()
        {
            int expectedResult = 0;
            StringKey stringKey = new StringKey("");
            object objStrKey1 = stringKey;
            ClassicAssert.AreEqual(expectedResult, objStrKey1.GetHashCode());
        }

        /// <summary>
        /// Test that Equals returns true when the same object is checked against itself.
        /// </summary>
        [Test]
        public static void EqualsSameObjectTest()
        {
            StringKey stringKey = new StringKey("A");
            object objStrKey1 = stringKey;

            ClassicAssert.IsTrue(objStrKey1.Equals(objStrKey1));
        }

        /// <summary>
        /// Test that Equals returns false when a null object is passed in.
        /// </summary>
        [Test]
        public static void EqualsNullObjectTest()
        {
            StringKey stringKey = new StringKey("A");
            object objStrKey1 = stringKey;

            ClassicAssert.IsFalse(objStrKey1.Equals(null));
        }

        /// <summary>
        /// Test that Equals returns false when a non StringKey object is passed in.
        /// </summary>
        [Test]
        public static void EqualsNonStringKeyObjectTest()
        {
            StringKey stringKey = new StringKey("A");
            object objStrKey1 = stringKey;

            ClassicAssert.IsFalse(objStrKey1.Equals("Not a string key"));
        }

        /// <summary>
        /// Test that Equals returns true when a StringKey with a matching name is compared.
        /// </summary>
        [Test]
        public static void EqualsDifferentObjectsWithMatchingNameTest()
        {
            StringKey stringKey1 = new StringKey("A");
            StringKey stringKey2 = new StringKey("A");
            object objStrKey1 = stringKey1;
            object objStrKey2 = stringKey2;

            ClassicAssert.IsTrue(objStrKey1.Equals(objStrKey2));
        }

        /// <summary>
        /// Test that Equals returns false when a StringKey with a mismatching name is compared.
        /// </summary>
        [Test]
        public static void EqualsMisMatchedObjectsTest()
        {
            StringKey stringKey1 = new StringKey("A");
            StringKey stringKey2 = new StringKey("B");
            object objStrKey1 = stringKey1;
            object objStrKey2 = stringKey2;

            ClassicAssert.IsFalse(objStrKey1.Equals(objStrKey2));
        }

        /// <summary>
        /// Test GetHashCode to ensure it returns expected result.
        /// </summary>
        [Test]
        public static void GetHashCodeTest()
        {
            int expectedResult = 3446974;
            StringKey stringKey = new StringKey("stop");
            object objStrKey1 = stringKey;
            ClassicAssert.AreEqual(expectedResult, objStrKey1.GetHashCode());
        }

        /// <summary>
        /// Test GetHashCode to ensure it returns expected result.
        /// </summary>
        [Test]
        public static void GetHashCode_should_be_using_integer_power_method_Test()
        {
            StringKey stringKey = new StringKey("123456789a");
            object objStrKey1 = stringKey;

            StringKey stringKey2 = new StringKey("123456789aaa"); // larger key 
            object objStrKey2 = stringKey2;

            ClassicAssert.AreNotEqual(objStrKey1.GetHashCode(), objStrKey2.GetHashCode()); // hashes to the same value if you're using Math.Pow() 
        }

        /// <summary>
        /// Test that ToString returns the expected string.
        /// </summary>
        [Test]
        public static void ToStringTest()
        {
            string expectedString = "KeyName: stop HashCode: 3446974";
            StringKey stringKey = new StringKey("stop");
            object objStrKey1 = stringKey;
            ClassicAssert.AreEqual(expectedString, objStrKey1.ToString());
        }

    }
}