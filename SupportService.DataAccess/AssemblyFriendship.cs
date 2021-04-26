using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SupportService.Tests")] // для того что бы тесты могли видеть internal method, class в тестах.
namespace SupportService.DataAccess
{
    class AssemblyFriendship
    {
    }
}
