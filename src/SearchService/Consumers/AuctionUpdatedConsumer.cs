namespace SearchService.Consumers
{
    using AutoMapper;
    using Contracts;
    using MassTransit;
    using MongoDB.Entities;
    using SearchService.Models;

    /// <summary>
    /// Defines the <see cref="AuctionUpdatedConsumer" />
    /// </summary>
    public class AuctionUpdatedConsumer : IConsumer<AuctionUpdated>
    {
        /// <summary>
        /// Defines the _mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuctionUpdatedConsumer"/> class.
        /// </summary>
        /// <param name="mapper">The mapper<see cref="IMapper"/></param>
        public AuctionUpdatedConsumer(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// The Consume
        /// </summary>
        /// <param name="context">The context<see cref="ConsumeContext{AuctionUpdated}"/></param>
        /// <returns>The <see cref="Task"/></returns>
        public async Task Consume(ConsumeContext<AuctionUpdated> context)
        {
            Console.WriteLine("--> Consuming auction updated: " + context.Message.Id);

            var item = _mapper.Map<Item>(context.Message);

            var result = await DB.Update<Item>()
                .MatchID(item.ID)
                .ModifyOnly(i => new { i.Make, i.Model, i.Color, i.Mileage, i.Year }, item)
                .ExecuteAsync();

            if (!result.IsAcknowledged)
            {
                throw new MessageException(typeof(AuctionUpdated), "Problem updating mongodb");
            }
        }
    }
}
