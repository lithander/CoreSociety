using System;
using CoreSociety;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreSocietyTests
{
    [TestClass]
    public class SerializationTests
    {
        [TestMethod]
        public void Base64CoreEncoding()
        {
            Core core = new Core();
            string s = core.Encode();
            core.Decode(s);
        }
    }
}
