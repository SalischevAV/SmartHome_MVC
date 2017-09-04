using SmartHomeMVC.Model.DeviceClasses;
using SmartHomeMVC.Model.Interfaces;
using SmartHomeMVC.Model.ServiceClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartHomeMVC.Controllers
{
    public class SmartHomeController : Controller
    {
        // GET: SmartHome
        public ActionResult Index()
        {
            Dictionary<string, Device> smartHoseDevicesDictionary = new Dictionary<string, Device>();
            DeviceCreator myDCreator = new DeviceCreator();

            smartHoseDevicesDictionary.Add("Nord", myDCreator.CreateDevice("fridge"));

            smartHoseDevicesDictionary.Add("Mitsubishi", myDCreator.CreateDevice("conditioner"));

            smartHoseDevicesDictionary.Add("Spidola", myDCreator.CreateDevice("radio"));

            smartHoseDevicesDictionary.Add("Indesit", myDCreator.CreateDevice("oven"));

            smartHoseDevicesDictionary.Add("Siemens", myDCreator.CreateDevice("mwoven"));

            smartHoseDevicesDictionary.Add("Seiko", myDCreator.CreateDevice("radiolamp"));


            Fridge f = new Fridge();
            if (f is IModeable)
            {
                f = null;
            }


            Session["Devices"] = smartHoseDevicesDictionary;
            return View(smartHoseDevicesDictionary);

        }
    }
}