using System;
using System.Collections.Generic;
using Xunit;

namespace web.test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.NotEmpty(new List<string> { "test" });
            Assert.IsType<string>(5);
        }
    }
}
