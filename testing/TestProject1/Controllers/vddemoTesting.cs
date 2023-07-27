using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.Controllers
{
    public class vddemoTesting
    {

        [Fact]
        public void get()
        {
            var ob = new TESTING.Controllers.VDEMOController();
            var data = ob.Get();
            Assert.Equal("data", data);
        }

        [Fact]
        public void post()
        {
            var ob = new TESTING.Controllers.VDEMOController();

            var data = ob.post("newData");

            Assert.Equal("newData", data);
        }

        [Fact]
        public void newGet()
        {
            var ob = new TESTING.Controllers.VDEMOController();
            var data = ob.newGet();
            var expectedName = "value";
            var okResult = Assert.IsType<OkObjectResult>(data);
            Assert.Equal(expectedName, okResult.Value);
        }

    }
}
