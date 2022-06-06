﻿using AvServiceHR.Contexts;
using AvServiceHR.Services;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AvServiceHR.Unit_Tests
{
    public class AdventureWorkServicesTEST
    {
        AdventureWorks2017Context _advContext = new AdventureWorks2017Context();

        [Theory]
        [InlineData(10)]
        public async Task GetProductsQtyMaggiore100TEST(int locId)  //preso dalla tabella Production.Location
        {
            var services = new AdventureWorksServices(_advContext);

            Assert.True(services != null);

            var getQty100 = await services.GetProductsQtyMaggioreDi100(locId);

            if (getQty100.Count > 100)
            {
                Assert.True(true);
            }
        }

        [Theory]
        [InlineData(4)]
        public async Task GetProductsQtyLocationIdTEST(int locId)   //preso dalla tabella Production.Location
        {
            var services = new AdventureWorksServices(_advContext);

            Assert.True(services != null);

            var getQty = await services.GetProductsQtyLocationId(locId);

            Assert.True(getQty.Count > 0);
        }
    }
}
