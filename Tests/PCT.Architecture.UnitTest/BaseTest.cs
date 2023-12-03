using System.Reflection;
using PCT.Shared.Data;

namespace PCT.Architecture.UnitTest;

public abstract class BaseTest
{
    protected static readonly Assembly DomainAssembly = typeof(Entity).Assembly;
}
