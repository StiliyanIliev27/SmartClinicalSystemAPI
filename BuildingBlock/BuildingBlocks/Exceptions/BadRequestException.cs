namespace BuildingBlock.BuildingBlocks.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message) { }

        public BadRequestException(string message, string details) : base(details)
        {
            Details = details;
        }

        public string? Details { get; set; }
    }
}
