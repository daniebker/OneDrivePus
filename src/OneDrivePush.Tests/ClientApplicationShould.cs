using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace OneDrivePush.Tests
{
    public class ClientApplicationShould
    {
        [Fact]
        public void Default_with_ReadWriteAll_scopes()
        {
            var clientApplication = new ClientApplication("some_app_id");

            clientApplication.Scopes.Length.ShouldBe(1);
            clientApplication.Scopes.ShouldBe(new string[] { "Files.ReadWrite.All" });
        }
    }
}
