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

        [Test]
        public void TestFrancMultiplication()
        {
            Money five = Money.franc(5);
            Assert.AreEqual(Money.franc(10), five.Times(2));
            Assert.AreEqual(Money.franc(15), five.Times(3));
        }

        [Test]
        public void testEquality()
        {
            Assert.True(Money.dollar(5).Equals(Money.dollar(5)));
            Assert.False(Money.dollar(5).Equals(Money.dollar(6)));
            Assert.True(Money.franc(5).Equals(Money.franc(5)));
            Assert.False(Money.franc(5).Equals(Money.franc(6)));
            Assert.True(Money.dollar(5).Equals(Money.dollar(5)));
            Assert.True(Money.dollar(5).Equals(Money.dollar(5)));
            Assert.True(Money.franc(5).Equals(Money.franc(5)));
            Assert.False(Money.franc(5).Equals(Money.franc(6)));
            Assert.False(Money.franc(5).Equals(Money.dollar(5)));

        }

        [Test]
        public void testDifferentClassEquality()
        {
            Bank bank = new Bank();
            bank.AddRate("CHF", "USD", 2);
            Money money = new Money(10, "CHF");
            Expression franc = new Franc(10, "CHF");
            Assert.IsFalse(money.Equals(bank.Reduce(franc, "USD")));
        }

        [Test]
        public void testSimpleAddition()
        {
            Money five = Money.dollar(5);
            Expression result = five.plus(five);
            Bank bank = new Bank();
            bank.SetRate("USD", "USD", 1);
            bank.SetRate("USD", "CHF", 2);

            Money reduced = bank.Reduce(result, "USD");
            Assert.AreEqual(Money.dollar(10), reduced);
        }

        [Test]
        public void testReduceSum()
        {
            Expression sum = new Sum(Money.dollar(3), Money.dollar(4));
            Bank bank = new Bank();
            Money result = bank.Reduce(sum, "USD");
            Assert.AreEqual(Money.dollar(7), result);
        }

        [Test]
        public void testReduceMoneyDifferentCurrency()
        {
            Bank bank = new Bank();
            bank.AddRate("CHF", "USD", 2);
            Money result = bank.Reduce(Money.franc(2), "USD");
            Assert.AreEqual(Money.dollar(1), result);
        }

        [Test]
        public void testArrayEquals()
        {
            Assert.AreEqual(new Object[] { "abc" }, new Object[] { "abc" });
        }
    }
}