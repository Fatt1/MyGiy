using System.Reflection;

namespace Demo.Domain
{
    public static class AssemblyReference
    {
        // Dùng để tham chiếu đến assembly này
        public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
    }
}
