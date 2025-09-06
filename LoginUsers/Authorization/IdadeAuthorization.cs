
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace LoginUsers.Authorization
{
    public class IdadeAuthorization : AuthorizationHandler<IdadeMinima>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IdadeMinima requirement)
        {
            var dataNascimento = context.User.FindFirst(c => c.Type == ClaimTypes.DateOfBirth);
            if (dataNascimento == null)
            {
                context.Fail();
                return Task.CompletedTask;
            }
            var idade = Convert.ToDateTime(dataNascimento.Value);


            var idadeAtual = DateTime.Today.Year - idade.Year;

            if (idade > DateTime.Today.AddYears(-idadeAtual)) idadeAtual--;

            if (idadeAtual >= requirement.Idade)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
