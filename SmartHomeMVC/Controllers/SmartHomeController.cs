﻿using SmartHomeMVC.Model.DeviceClasses;
using SmartHomeMVC.Model.DeviceInterfaces;
using SmartHomeMVC.Model.Interfaces;
using SmartHomeMVC.Model.ServiceClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace SmartHomeMVC.Controllers
{
    public class SmartHomeController : Controller
    {
        Dictionary<string, Device> smartHoseDevicesDictionary;
        // GET: SmartHome
        public ActionResult Index()
        {
            smartHoseDevicesDictionary = new Dictionary<string, Device>();
            DeviceCreator myDCreator = new DeviceCreator();

            smartHoseDevicesDictionary.Add("Nord", myDCreator.CreateDevice("fridge"));

            smartHoseDevicesDictionary.Add("Mitsubishi", myDCreator.CreateDevice("conditioner"));

            smartHoseDevicesDictionary.Add("Spidola", myDCreator.CreateDevice("radio"));

            smartHoseDevicesDictionary.Add("Indesit", myDCreator.CreateDevice("oven"));

            smartHoseDevicesDictionary.Add("Siemens", myDCreator.CreateDevice("mwoven"));

            smartHoseDevicesDictionary.Add("Seiko", myDCreator.CreateDevice("radiolamp"));

            Session["Devices"] = smartHoseDevicesDictionary;
            return View(smartHoseDevicesDictionary);

        }

        public ActionResult AddDevice(string nameOfDevice, string typeOfDevice)
        {
            smartHoseDevicesDictionary = (Dictionary<string, Device>)Session["Devices"];
            DeviceCreator dc = new DeviceCreator();
            try
            {
                switch (typeOfDevice)
                {

                    case "fridge":
                        smartHoseDevicesDictionary.Add(nameOfDevice, dc.CreateDevice("fridge"));
                        break;
                    case "mwoven":
                        smartHoseDevicesDictionary.Add(nameOfDevice, dc.CreateDevice("mwoven"));
                        break;
                    case "oven":
                        smartHoseDevicesDictionary.Add(nameOfDevice, dc.CreateDevice("oven"));
                        break;
                    case "radio":
                        smartHoseDevicesDictionary.Add(nameOfDevice, dc.CreateDevice("radio"));
                        break;
                    case "radiolamp":
                        smartHoseDevicesDictionary.Add(nameOfDevice, dc.CreateDevice("radiolamp"));
                        break;
                    case "conditioner":
                    default:
                        smartHoseDevicesDictionary.Add(nameOfDevice, dc.CreateDevice("conditioner"));
                        break;
                }
            }

            catch { }

            Session["Devices"] = smartHoseDevicesDictionary;
            return View("Index", smartHoseDevicesDictionary);

        }


        public ActionResult SetMode(string deviceName, string mode)
        {
            smartHoseDevicesDictionary = (Dictionary<string, Device>)Session["Devices"];

            ((IModeable)smartHoseDevicesDictionary[deviceName]).SetMode(mode);
            Session["Devices"] = smartHoseDevicesDictionary;
            return View("Index", smartHoseDevicesDictionary);
        }

        public ActionResult Light(string deviceName, string settingBrightness)
        {
            smartHoseDevicesDictionary = (Dictionary<string, Device>)Session["Devices"];

            ((ILightable)smartHoseDevicesDictionary[deviceName]).SetBrightnes(settingBrightness);
            Session["Devices"] = smartHoseDevicesDictionary;
            return View("Index", smartHoseDevicesDictionary);
        }

        public ActionResult Power(string deviceName)
        {
            smartHoseDevicesDictionary = (Dictionary<string, Device>)Session["Devices"];
            smartHoseDevicesDictionary[deviceName].Power();
            Session["Devices"] = smartHoseDevicesDictionary;
            return View("Index", smartHoseDevicesDictionary);
        }

        public ActionResult Door(string deviceName)
        {
            smartHoseDevicesDictionary = (Dictionary<string, Device>)Session["Devices"];
            ((IDoorable)smartHoseDevicesDictionary[deviceName]).DoorManipulation();
            Session["Devices"] = smartHoseDevicesDictionary;
            return View("Index", smartHoseDevicesDictionary);
        }

        public ActionResult Channel(string deviceName, string action, int channel)
        {
            smartHoseDevicesDictionary = (Dictionary<string, Device>)Session["Devices"];

            if (action == "-")
            {
                ((IChannelable)smartHoseDevicesDictionary[deviceName]).AdjustChannel(false);
            }
            else if (action == "+")
            {
                ((IChannelable)smartHoseDevicesDictionary[deviceName]).AdjustChannel(true);
            }
            else if (action == "set")
            {
                ((IChannelable)smartHoseDevicesDictionary[deviceName]).SetChannel(channel);
            }

            Session["Devices"] = smartHoseDevicesDictionary;
            return View("Index", smartHoseDevicesDictionary);
        }


        public ActionResult Temperature(string deviceName, string action, int temp)
        {
            smartHoseDevicesDictionary = (Dictionary<string, Device>)Session["Devices"];

            if (action == "-")
            {
                ((IFridgeable)smartHoseDevicesDictionary[deviceName]).DecrTemp();
            }
            else if (action == "+")
            {
                ((IFridgeable)smartHoseDevicesDictionary[deviceName]).IncrTemp();
            }
            else if (action == "set")
            {
                ((IFridgeable)smartHoseDevicesDictionary[deviceName]).SetTemp(temp);
            }

            Session["Devices"] = smartHoseDevicesDictionary;
            return View("Index", smartHoseDevicesDictionary);
        }

        public ActionResult Volume(string deviceName, string action)
        {
            smartHoseDevicesDictionary = (Dictionary<string, Device>)Session["Devices"];

            if (action == "-")
            {
                ((IVolumeable)smartHoseDevicesDictionary[deviceName]).SetVolume(false);
            }
            else if (action == "+")
            {
                ((IVolumeable)smartHoseDevicesDictionary[deviceName]).SetVolume(true);
            }

            Session["Devices"] = smartHoseDevicesDictionary;
            return View("Index", smartHoseDevicesDictionary);
        }

        public ActionResult Delete(string deviceName)
        {
            smartHoseDevicesDictionary = (Dictionary<string, Device>)Session["Devices"];
            smartHoseDevicesDictionary.Remove(deviceName);
            Session["Devices"] = smartHoseDevicesDictionary;
            return View("Index", smartHoseDevicesDictionary);
        }

    }
}