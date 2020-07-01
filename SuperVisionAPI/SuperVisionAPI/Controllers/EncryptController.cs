using SuperVisionAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntegrationLib.Common;
using System.Threading.Tasks;

namespace SuperVisionAPI.Controllers
{
    public class EncryptController : Controller
    {
        // GET: Encrypt
        public ActionResult Encrypt()
        {
            return View("Encrypt");
        }

        public ActionResult Decrypt()
        {
            return View("Decrypt");
        }


        [HttpPost]
        public ActionResult Encrypt(EncryptModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //model.EncryptedText = EncryptionHelper.Encrypt(model.DecryptedText, model.Key);
                    return View("Encrypt", model);
                }
                else
                {
                    ModelState.AddModelError("Key", "Please enter valid input string/ Key.");
                    return View("Encrypt", model);
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Key", "Please enter valid input string/ Key.");
                return View("Encrypt", model);
            }
        }

        [HttpPost]
        public async Task<string> GetEncryptedString(EncryptModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.EncryptedText = EncryptionHelper.Encrypt(model.DecryptedText, model.Key, model.Salt);
                    return model.EncryptedText;
                }
                else
                {
                    return model.EncryptedText;
                }
            }
            catch (Exception ex)
            {
                return model.EncryptedText;
            }
        }


        [HttpPost]
        public ActionResult Decrypt(DecryptModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //model.DecryptedText = EncryptionHelper.Decrypt(model.EncryptedText, model.Key, model.Salt);
                    return View("Decrypt", model);
                }
                else
                {
                    ModelState.AddModelError("Key", "Please enter valid input string/ Key.");
                    return View("Decrypt", model);
                }
            }
            catch
            {
                ModelState.AddModelError("Key", "Please enter valid input string/ Key.");
                return View("Decrypt", model);
            }
        }

        [HttpPost]
        public async Task<string> GetDecryptedString(DecryptModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.DecryptedText = EncryptionHelper.Decrypt(model.EncryptedText, model.Key, model.Salt);
                    return model.DecryptedText;
                }
                else
                {
                    return model.DecryptedText;
                }
            }
            catch (Exception ex)
            {
                return model.DecryptedText;
            }
        }

    }
}
