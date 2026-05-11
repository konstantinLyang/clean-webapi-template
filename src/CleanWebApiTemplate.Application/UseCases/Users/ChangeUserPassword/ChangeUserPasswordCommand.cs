using Mediator;

namespace CleanWebApiTemplate.Application.UseCases.Users.ChangeUserPassword;

public sealed record ChangeUserPasswordCommand(
    long UserId,
    string CurrentPassword,
    string NewPassword
) : ICommand;
