using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Travel.Application.Common.Exceptions;
using Travel.Application.TourLists.Commands.CreateTourList;
using Travel.Application.TourPackages.Commands.CreateTourPackage;
using Travel.Application.TourPackages.Commands.DeleteTourPackage;
using Travel.Domain.Entities;
using Xunit;

namespace Application.IntegrationTests.TourPackages.Commands
{
    using static DatabaseFixture;
    [Collection("DatabaseCollection")]
    public class DeleteTourPackageTests
    {
        public DeleteTourPackageTests()
        {
            ResetState().GetAwaiter().GetResult();
        }

        [Fact]
        public void ShouldRequireValidTourPackageId()
        {
            var command = new DeleteTourPackageCommand
            {
                Id = 69
            };
            FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
        }
        ///TODO: page.410

    }
}
