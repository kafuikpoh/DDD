using DDD.Application.Common.Interfaces.Persistence;
using DDD.Application.Menus.Commands.CreateMenu;
using DDD.Application.UnitTests.Menus.Commands.TestUtils;
using DDD.Application.UnitTests.TestUtils.Menus.Extensions;
using FluentAssertions;
using Moq;

namespace DDD.Application.UnitTests.Menus.Commands.CreateMenu;

public class CreateMenuCommandHandlerTests
{
    private readonly CreateMenuCommandHandler _handler;
    private readonly Mock<IMenuRepository> _mockMenuRepository;

    public CreateMenuCommandHandlerTests()
    {
        _mockMenuRepository = new Mock<IMenuRepository>();
        _handler = new CreateMenuCommandHandler(_mockMenuRepository.Object);
    }

    // System-Under-Test :- logical component under test
    // Scenario :- What is the scenario under test
    // Expected-Result :- What is the expected result of the scenario
    [Theory]
    [MemberData(nameof(ValidCreateMenuCommands))]
    public async void HandleCreateMenuCommand_WhenMenuIsValid_ShouldCreateAndReturnMenu(CreateMenuCommand createMenuCommand)
    {
        // Arrange
        // Get hold of a valid menu
        //var createMenuCommand = CreateMenuCommandUtils.CreateCommand();

        // Act
        // Invoke the handler
        var result = await _handler.Handle(createMenuCommand, default);

        // Assert
        result.IsError.Should().BeFalse();
        result.Value.ValidateCreatedFrom(createMenuCommand);
        _mockMenuRepository.Verify(mock => mock.Add(result.Value), Times.Once);
        // 1. Validate correct menu created based on command
        // 2. Menu added to repository
    }

    public static IEnumerable<object[]> ValidCreateMenuCommands()
    {
        yield return new[] { CreateMenuCommandUtils.CreateCommand() };
        yield return new[]
        {
             CreateMenuCommandUtils.CreateCommand(
                sections: CreateMenuCommandUtils.CreateSectionsCommand(sectionCount: 3)),
        };

        yield return new[]
        {
             CreateMenuCommandUtils.CreateCommand(
                sections: CreateMenuCommandUtils.CreateSectionsCommand(
                    sectionCount: 3,
                    items: CreateMenuCommandUtils.CreateItemsCommand(itemCount: 3))),
        };
    }
}