using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TPLOCAL1_MHN.Models;

//Subject is find at the root of the project and the logo in the wwwroot/ressources folders of the solution
//--------------------------------------------------------------------------------------
//Careful, the MVC model is a so-called convention model instead of configuration,
//The controller must imperatively be name with "Controller" at the end !!!
namespace TPLOCAL1_MHN.Controllers
{
    public class HomeController : Controller
    {
        //methode "naturally" call by router
        public ActionResult Index(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                //return to the Index view (see routing in Program.cs)
                return View();
            else
            {
                //Call different pages, according to the id pass as parameter
                switch (id)
                {
                    case "OpinionList":
                        //TODO : code reading of the xml files provide
                        var opinionList = new OpinionList();
                        string xmlFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "resources", "DataAvis.xml");
                        List<Opinion> opinions = opinionList.GetAvis(xmlFilePath);
                        return View("OpinionList", opinions);
                    case "Form":
                        //TODO : call the Form view with data model empty
                        return View("Form", new FeedbackForm());
                    default:
                        //return to the Index view (see routing in Program.cs)
                        return View();
                }
            }
        }


        //methode to send datas from form to validation page
        [HttpPost]
        public ActionResult ValidationFormulaire(FeedbackForm model)
        {
            //TODO : test if model's fields are set
            //if not, display an error message and stay on the form page
            //else, call ValidationForm with the datas set by the user
            if (ModelState.IsValid)
            {
                // All controls are OK
                return View("Validation", model);
            }
            else
            {
                // At least one control is KO
                return View("Form", model);
            }

        }
    }
}
