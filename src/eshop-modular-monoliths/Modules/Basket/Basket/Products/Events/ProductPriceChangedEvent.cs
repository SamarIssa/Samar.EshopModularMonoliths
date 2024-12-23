namespace Basket.Products.Events;

public record ProductPriceChangedEvent(Product Product):IDomainEvent;

