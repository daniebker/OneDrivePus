using Moq;
using OneDrivePush.App;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OneDrivePush.Tests
{
    public class OneDriveRepositoryShould
    {
        [Fact]
        public void return_a_list_of_drives_for_a_user()
        {
            var httpHandler = new Mock<IHttpHandler>(MockBehavior.Strict);
            httpHandler
                .Setup(m => m.GetAsync("/me/drives"))
                .Returns(Task.FromResult<string>(Properties.Resources.get_drives_response_200));

            var oneDriveRepository = new OneDriveRepository(httpHandler.Object);

            IEnumerable<Drive> drives = oneDriveRepository.GetDrives().Result;

            var expectedDrive = new Drive()
            {
                Id = "0123456789abc",
                DriveType = "personal",
                Owner = new DriveUser()
                    {
                        Id = "12391913bac",
                        DisplayName = "Ryan Gregg"
                    }
            };

            drives.ShouldNotBeEmpty();
            drives.Count().ShouldBe(1);
            drives.ShouldContain(expectedDrive);
        }
    }
}
