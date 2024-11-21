using System.ComponentModel;

namespace Plurish.Auth.Domain.Enums;

public enum Role
{
    [Description("Usuário Comum")]
    COMMON,

    [Description("Desenvolvedor")]
    DEVELOPER,

    [Description("Administrador")]
    ADMIN
}
