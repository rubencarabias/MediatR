using BuildingBlocks.Common;

namespace Domain
{
    internal class Example : BaseEntity
    {
        protected Example()
        {
        }

        public string Description { get; protected set; } = default!;
    }
}