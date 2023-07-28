using ErrorOr;

namespace DDD.Domain.Common.DomainErrors;

public static partial class Errors
{
    public static class Menu
    {
        public static Error InvalidMenuId => Error.Validation(
            code: "Menu.InvalidId",
            description: "The provided menu id is invalid."
        );

        public static Error NotFound => Error.Validation(
            code: "Menu.NotFound",
            description: "Menu with given ID does not exist."
        );
    }
}