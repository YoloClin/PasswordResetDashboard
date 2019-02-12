// ReviewMe
using System;
using System.Web.Mvc;
using System.DirectoryServices.AccountManagement;
using PasswordResetDashboard.Models;

namespace PasswordResetDashboard.Controllers
{
    [Authorize]
    public class PasswordResetController: Controller
    {

        [HttpGet]
        public ActionResult PasswordReset()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PasswordReset(PaswordResetViewModel viewModel)
        {
            var prefixedUser = viewModel.Username;
            if (!prefixedUser.ToLower().StartsWith("u"))
                prefixedUser = "u" + prefixedUser;

            var context = new PrincipalContext(ContextType.Machine);
            using (var user = UserPrincipal.FindByIdentity(context, prefixedUser))
            {
                if (user == null)
                {
                    ViewBag.Message = String.Format("Unable to find user '{0}'", prefixedUser);
                    return View();
                }
                else
                {
                    // user.SetPassword(viewModel.Password);
                    ViewBag.Message = String.Format("User '{0}' would be reset if resets were actually enabled.", user.Name);
                    if (!user.Name.ToLower().StartsWith("u"))
                    {
                        ViewBag.Message += " You have successfully bypassed input validation!";
                    }
                }
            }
            return View();
        }
    }
}