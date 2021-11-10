using Microsoft.AspNetCore.Mvc;
using Multi_Language_Support.Models.Json;
using System;
using System.Collections.Generic;
using System.Xml;

namespace Multi_Language_Support.Controllers
{
    [Route("ajax/[controller]")]
    [ApiController]
    public class HomeAjaxController : ControllerBase
    {
        [HttpGet("{action}")]
        public IActionResult GetResources(string localize = "en")
        {
            localize = localize.ToLower();

            List<LocalizeJson> result = new();

            string path = $".\\Resources\\Views\\Home\\Index.{localize}.resx";
            //FileStream fstream = new FileStream($"{path}", FileMode.Open);

            XmlDocument xDoc = new();
            xDoc.Load(path);

            XmlElement xRoot = xDoc.DocumentElement;

            foreach (XmlNode xnode in xRoot)
            {
                if (xnode.Name == "data")
                {
                    XmlNode attr = xnode.Attributes.GetNamedItem("name");

                    // обходим все дочерние узлы элемента
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        // если узел = value
                        if (childnode.Name == "value")
                        {
                            //Console.WriteLine($"{attr.Value}: {childnode.InnerText}");
                            result.Add(new LocalizeJson
                            {
                                Name = attr.Value,
                                Value = childnode.InnerText
                            });
                        }
                    }
                }
            }

            return Ok(result);
        }
    }
}
