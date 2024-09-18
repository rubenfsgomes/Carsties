namespace SearchService.Consumers
{
    using AutoMapper;
    using Contracts;
    using MassTransit;
    using MongoDB.Entities;
    using SearchService.Models;

    /// <summary>
    /// Defines the <see cref="AuctionDeletedConsumer" />
    /// </summary>
    public class AuctionDeletedConsumer : IConsumer<AuctionDeleted>
    {
        /// <summary>
        /// Defines the _mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuctionDeletedConsumer"/> class.
        /// </summary>
        /// <param name="mapper">The mapper<see cref="IMapper"/></param>
        public AuctionDeletedConsumer(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// The Consume
        /// </summary>
        /// <param name="context">The context<see cref="ConsumeContext{AuctionDeleted}"/></param>
        /// <returns>The <see cref="Task"/></returns>
        public async Task Consume(ConsumeContext<AuctionDeleted> context)
        {
            Console.WriteLine("--> Consuming AuctionDeleted: " + context.Message.Id);

            var result = await DB.DeleteAsync<Item>(context.Message.Id);

            if (!result.IsAcknowledged)
            {
                throw new MessageException(typeof(AuctionDeleted), "Problem deleting auction");
            }
        }
    }
}
