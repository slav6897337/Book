using System;
using NUnit.Framework;
using BookTask;

namespace NUnitTestBook
{
    public class Tests
    {

        [TestCase("Joseph Albahari and Ben Albahari", "C# 7.0, in a Nutshell", "Oreily", ExpectedResult = "C# 7.0, in a Nutshell by Joseph Albahari and Ben Albahari")]
        [TestCase("Джеффри Рихтер", "CLR via C#", "Питер", ExpectedResult = "CLR via C# by Джеффри Рихтер")]
        [TestCase("Jennifer Greene, Andrew Stellman", "Head First c#", "O'Reilly Media", ExpectedResult = "Head First c# by Jennifer Greene, Andrew Stellman")]
        [TestCase("Стив МакКоннелл", "Совершенный код. Мастер-класс.", "Второе издание", ExpectedResult = "Совершенный код. Мастер-класс. by Стив МакКоннелл")]

        public string FirstConstructorTest_ResultInformBook(string author, string title, string publsher)
        {
            Book bk = new Book(author, title, publsher);
            return bk.ToString();
        }

        [TestCase("Joseph Albahari and Ben Albahari", "C# 7.0, in a Nutshell", "O'Reilly Media", "978-1491987650", ExpectedResult = "C# 7.0, in a Nutshell by Joseph Albahari and Ben Albahari")]
        [TestCase("Джеффри Рихтер", "CLR via C#", "Питер", "978-5-4461-1102-2", ExpectedResult = "CLR via C# by Джеффри Рихтер")]
        [TestCase("Jennifer Greene, Andrew Stellman", "Head First c#", "O'Reilly Media", "978-1-449-34350-7", ExpectedResult = "Head First c# by Jennifer Greene, Andrew Stellman")]
        [TestCase("Стив МакКоннелл", "Совершенный код. Мастер-класс.", "Второе издание", "978-5-9909805-1-8", ExpectedResult = "Совершенный код. Мастер-класс. by Стив МакКоннелл")]

        public string SecondConstructorTest_ResultInformBook(string author, string title, string publsher, string isbn)
        {
            Book bk = new Book(author, title, publsher);
            return bk.ToString();
        }

        [Test]
        public void Pages_PagesLessZero_ThrowArgumentOutOfRangeException() =>
           Assert.Throws<ArgumentOutOfRangeException>(() =>
           {
               Book bk = new Book("Joseph Albahari and Ben Albahari", "C# 7.0, in a Nutshell", "O'Reilly Media");
               {
                   bk.Pages = -2;
               };
           },
               "Pages can not be less than zero.");

        [Test]
        public void PublishAndGetPublicationDate_TrueDate_ResultTrue()
        {
            Book bk = new Book("Joseph Albahari and Ben Albahari", "C# 7.0, in a Nutshell", "O'Reilly Media");
            DateTime date = new DateTime(2017, 01, 01);
            bk.Publish(date);

            Assert.AreEqual(date.ToString(), bk.GetPublicationDate());

        }

        [Test]
        public void GetPublicationDate_NotinstaledDate_ResultNYP()
        {
            Book bk = new Book("Joseph Albahari and Ben Albahari", "C# 7.0, in a Nutshell", "O'Reilly Media");      

            Assert.AreEqual("NYP", bk.GetPublicationDate());
        }

        [Test]
        public void SetPrice_Prise_TruePrise()
        {
            Book bk = new Book("Joseph Albahari and Ben Albahari", "C# 7.0, in a Nutshell", "O'Reilly Media");
            bk.SetPrice(1000, "BYN");
            Assert.AreEqual(1000, bk.Price);

        }

        [Test]
        public void SetPrice_Prise_TrueISO()
        {
            Book bk = new Book("Joseph Albahari and Ben Albahari", "C# 7.0, in a Nutshell", "O'Reilly Media");
            bk.SetPrice(1000, "BYN");        
            Assert.AreEqual("BYN", bk.ISO);
        }
    }
}