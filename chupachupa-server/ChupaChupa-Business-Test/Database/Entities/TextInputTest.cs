using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChupaChupa.Entities;
using NUnit.Framework;

namespace ChupaChupa.Business.Test.Database.Entities
{
    [TestFixture]
    class TextInputTest
    {
        [Test]
        public void Update()
        {
            var textInput1 = new TextInput()
            {
                Description = "un text input super",
                Name = "mytextipnut2",
                Link = "www.textINput.com",
                Title = "MY TEXT INPUT" 
            };

            var textInput2 = new TextInput();
            textInput2.update(textInput1);

            Assert.IsNotNull(textInput2);
            Assert.AreNotSame(textInput1, textInput2);
            Assert.AreEqual(textInput1.Description, textInput2.Description);
            Assert.AreEqual(textInput1.Name, textInput2.Name);
            Assert.AreEqual(textInput1.Link, textInput2.Link);
            Assert.AreEqual(textInput1.Title, textInput2.Title);
        }
    }
}
