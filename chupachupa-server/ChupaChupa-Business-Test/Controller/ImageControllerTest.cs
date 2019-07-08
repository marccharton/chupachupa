using ChupaChupa.Business.Controller;
using ChupaChupa.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChupaChupa.Business.Test.Controller
{
    [TestFixture]
    class ImageControllerTest
    {
        [Test]
        public void controlImageControllerTest()
        {
            ImageController controller = new ImageController();
            Image validImage = new Image();
            Image wrongImage = new Image();

            validImage.Url = "http://fakedomain.com";
            validImage.Title = "This is a valid title";
            validImage.Link = "This is a valid link";
            validImage.Description = "This is a valid description";
            validImage.Width = 22;
            validImage.Height = 44;

            Assert.IsTrue(controller.controlData(validImage));

            wrongImage.Url = "http://fakedomain.com";
            wrongImage.Title = "This is a valid title";
            wrongImage.Link = "This is a valid link";
            wrongImage.Description = "This is a valid description";
            wrongImage.Width = 22;
            wrongImage.Height = 44;

            #region wrong url test

            wrongImage.Url = "http://fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.euhttp://fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.euhttp://fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.euhttp://fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.euhttp://fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.euhttp://fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.euhttp://fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.euhttp://fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.euhttp://fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.euhttp://fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.euhttp://fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.euhttp://fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.euhttp://fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.euhttp://fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu";
            Assert.IsFalse(controller.controlData(wrongImage));

            wrongImage.Url = "";
            Assert.IsFalse(controller.controlData(wrongImage));

            wrongImage.Url = null;
            Assert.IsFalse(controller.controlData(wrongImage));

            wrongImage.Url = "http://fakedomain.com";

            #endregion

            #region wrong title test

            wrongImage.Title = "This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title ";
            Assert.IsFalse(controller.controlData(wrongImage));

            wrongImage.Title = "";
            Assert.IsFalse(controller.controlData(wrongImage));

            wrongImage.Title = null;
            Assert.IsFalse(controller.controlData(wrongImage));

            wrongImage.Title = "This is a valid title";

            #endregion

            #region wrong link test

            wrongImage.Link = "This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link This is an invalind link ";
            Assert.IsFalse(controller.controlData(wrongImage));

            wrongImage.Link = "";
            Assert.IsFalse(controller.controlData(wrongImage));

            wrongImage.Link = null;
            Assert.IsFalse(controller.controlData(wrongImage));

            wrongImage.Link = "This is a valid link";

            #endregion

            #region wrong description test

            wrongImage.Description = "This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description ";
            Assert.IsFalse(controller.controlData(wrongImage));

            wrongImage.Description = "This is a valid description";

            #endregion

            #region wrong width test

            wrongImage.Width = -50;
            Assert.IsFalse(controller.controlData(wrongImage));

            wrongImage.Width = 22;

            #endregion

            #region wrong height test

            wrongImage.Height = -44;
            Assert.IsFalse(controller.controlData(wrongImage));

            #endregion
        }
    }
}
