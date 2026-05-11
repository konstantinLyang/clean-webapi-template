namespace CleanWebApiTemplate.Domain.Enums;

public enum Permissions
{
    /// <summary>
    /// Получать список всех пользователей или конкретного по Id
    /// </summary>
    CanGetUsers = 1,
    
    /// <summary>
    /// Изменять созданных или добавлять новых пользователей
    /// </summary>
    CanEditUsers = 2,
    
    /// <summary>
    /// Получать список всех ролей или конкретного по Id
    /// </summary>
    CanGetRoles = 10,
    
    /// <summary>
    /// Изменять созданные или добавлять новые роли
    /// </summary>
    CanEditRoles = 20,
}