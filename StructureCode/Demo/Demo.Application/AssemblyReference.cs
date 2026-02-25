using System.Reflection;

namespace Demo.Application
{
    public static class AssemblyReference
    {
        // Dùng để tham chiếu đến assembly này
        public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
    }
}
