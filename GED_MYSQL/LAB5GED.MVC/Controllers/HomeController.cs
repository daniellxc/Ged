﻿using LAB5GED.DOMAIN.AppContext;
using LAB5GED.DOMAIN.DAO.Business;
using LAB5GED.DOMAIN.Entidades;
using LAB5GED.MVC.Acessorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace LAB5GED.MVC.Controllers
{
    [Authorize]
    public class HomeController : CustomController
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {

            
            return View();
        }

    }
}
