namespace TestProject2
{
    [TestFixture]
    public class Tests
    {
      
        [Test]
        public void TestMultiplication()
        {
            Money five = Money.dollar(5);
            Assert.AreEqual(Money.dollar(10), five.Times(2));
            Assert.AreEqual(Money.dollar(15), five.Times(3));
        }
    }
}