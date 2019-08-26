using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using XMLFeed.Models.Interfaces;

namespace XMLFeed.Controllers
{
    public class XmlFeedController : Controller
    {
        IXmlParser<XElement> xmlParser;
        IItemBuilder<XElement> itemBuilder;

        public XmlFeedController(IXmlParser<XElement> xmlParser, IItemBuilder<XElement> itemBuilder)
        {
            this.xmlParser = xmlParser;
            this.itemBuilder = itemBuilder;
        }

        public ActionResult Index()
        {
            
            
            return View();
        }

        [HttpGet]
        public JsonResult Items()
        {
            var res = xmlParser.ParseXml().ToList();
            var itemModels = itemBuilder.BuildItems(res);
            var json = JsonConvert.SerializeObject(itemModels);
            return Json(json, JsonRequestBehavior.AllowGet);
        }
    }
}