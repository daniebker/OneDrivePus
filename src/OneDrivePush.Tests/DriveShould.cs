using OneDrivePush.App;
using Shouldly;
using Xunit;

namespace OneDrivePush.Tests
{
    public class DriveShould
    {
        private readonly Drive _drive;

        public DriveShould()
        {
            _drive = new Drive()
            {
                Id = "1234",
                DriveType = "anything",
                Owner = new DriveUser()
                {
                    Id = "321",
                    DisplayName = "Dave Thomas"
                }
            };
        }

        [Fact]
        public void be_equal_when_other_id_is_equal()
        {
            var other = new Drive()
            {
                Id = "1234",
                DriveType = "nothing",
                Owner = new DriveUser()
                {
                    Id = "33",
                    DisplayName = "Dave Matthews"
                }
            };
            _drive.Equals(other).ShouldBe(true);
        }

        [Theory]
        [MemberData(nameof(UnequalOthers))]
        public void not_be_equal_when_others_id_is_different(object other)
        {
            _drive.Equals(other).ShouldBe(false);
        }

        public static TheoryData<object> UnequalOthers = new TheoryData<object> {

            new Drive()
            {
                Id = "231",
                DriveType = "business",
                Owner = new DriveUser()
                {
                    Id = "4345",
                    DisplayName = "Davey Savage"
                }
            },
            "not a Drive",
            null
        };
    }
}
