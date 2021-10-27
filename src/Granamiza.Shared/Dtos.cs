using System;

namespace Granamiza.Shared
{
    public abstract class Dtos
    {
        public abstract class Requests
        {
            public record AddIncomeRequest (string Title, decimal Value);

        }

        public abstract class Responses
        {
            public record AddIncomeResponse (string Id, string Title, decimal Value, DateTime CreatedAt);
            public record IncomeResponse (string Id, string Title, decimal Value, DateTime CreatedAt);

        }
    }
}
