using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XMLFeed;
using XMLFeed.Controllers;
using XMLFeed.Services;

namespace XMLFeed.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        const string testFileName = "ForTest.xml";

        [TestInitialize]
        public void Init()
        {
            if (File.Exists(testFileName))
            {
                File.Delete(testFileName);
            }
        }

        [TestMethod]
        public void TestXmlParse()
        {
            
            var xmlParserSevice = new XmlParserService();
            File.WriteAllText(testFileName, @"<item>
<title>
<![CDATA[
Keeping Up with Country and Tax Compliance - June 2019
]]>
</title>
<guid isPermaLink='false'>test
</guid>
<pubDate>Wed, 26 Jun 2019 12:51:23 GMT </pubDate>
<creator>![CDATA[Ruud van Hilten]] </creator>
<category>Friction</category>
<description>
<![CDATA[The latest news for the last month ]]>
</description>
<enclosure url='https://www.tungsten-network.com/media/16604570/1511-progress-and-lack.jpg' />
</item>
");
            var elements = xmlParserSevice.ParseXml(testFileName).ToList();
            Assert.AreEqual(1, elements.Count);

            string heading = elements[0].Descendants("title").ToList()[0].Value;
            Assert.AreEqual("\nKeeping Up with Country and Tax Compliance - June 2019\n", heading);
            DateTime date = Convert.ToDateTime(elements[0].Descendants("pubDate").ToList()[0].Value);
            DateTime expected = Convert.ToDateTime("Wed, 26 Jun 2019 12:51:23 GMT");
            Assert.AreEqual(expected, date);
            string imgUrl = elements[0].Descendants("enclosure").ToList()[0].Attribute("url").Value;
            Assert.AreEqual("https://www.tungsten-network.com/media/16604570/1511-progress-and-lack.jpg", imgUrl);
        }
    }
}
