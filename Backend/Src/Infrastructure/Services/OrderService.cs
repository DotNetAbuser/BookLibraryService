namespace Infrastructure.Services;

public class OrderService(
    IHttpContextAccessor httpContextAccessor,
    IOrderRepository orderRepository,
    IBookRepository bookRepository)
    : IOrderService
{
    public async Task<Result<PaginatedData<OrderResponse>>> GetPaginatedOrdersAsync(int pageNumber, int pageSize)
    {
        var (ordersEntities, totalCount) = await orderRepository
            .GetPaginatedOrdersAsync(pageNumber, pageSize);
        var ordersResponse = ordersEntities.Select(orderEntity => 
            new OrderResponse(
                Id: orderEntity.Id,
                Username: orderEntity.User.Username,
                BookTitle: orderEntity.Book.Title,
                Status: orderEntity.Status.Name,
                TakenFrom: orderEntity.TakenFrom,
                TakenTo: orderEntity.TakenTo,
                Created: orderEntity.Created)).ToList();
        return Result<PaginatedData<OrderResponse>>
            .Success(new PaginatedData<OrderResponse>(
                List: ordersResponse, TotalCount: totalCount));
    }

    public async Task<Result<PaginatedData<OrderResponse>>> GetPaginatedOrdersByUserIdAsync(Guid id, int pageNumber, int pageSize)
    {
        var (ordersEntities, totalCount) = await orderRepository
            .GetPaginatedOrdersByUserIdAsync(id,pageNumber, pageSize);
        var ordersResponse = ordersEntities.Select(orderEntity => 
            new OrderResponse(
                Id: orderEntity.Id,
                Username: orderEntity.User.Username,
                BookTitle: orderEntity.Book.Title,
                Status: orderEntity.Status.Name,
                TakenFrom: orderEntity.TakenFrom,
                TakenTo: orderEntity.TakenTo,
                Created: orderEntity.Created)).ToList();
        return Result<PaginatedData<OrderResponse>>
            .Success(new PaginatedData<OrderResponse>(
                List: ordersResponse, TotalCount: totalCount));
    }

    public async Task<Result<PaginatedData<OrderResponse>>> GetPaginatedMyOrdersAsync(int pageNumber, int pageSize)
    {
        var claims = httpContextAccessor.HttpContext!.User;
        var currentUserId = Guid.Parse(claims.GetLoggedInUserId<string>());
        var (ordersEntities, totalCount) = await orderRepository
            .GetPaginatedOrdersByUserIdAsync(currentUserId,pageNumber, pageSize);
        var ordersResponse = ordersEntities.Select(orderEntity => 
            new OrderResponse(
                Id: orderEntity.Id,
                Username: orderEntity.User.Username,
                BookTitle: orderEntity.Book.Title,
                Status: orderEntity.Status.Name,
                TakenFrom: orderEntity.TakenFrom,
                TakenTo: orderEntity.TakenTo,
                Created: orderEntity.Created)).ToList();
        return Result<PaginatedData<OrderResponse>>
            .Success(new PaginatedData<OrderResponse>(
                List: ordersResponse, TotalCount: totalCount));
    }

    public async Task<Result> CreateAsync(CreateOrderRequest request)
    {
        var claims = httpContextAccessor.HttpContext!.User;
        var currentUserId = Guid.Parse(claims.GetLoggedInUserId<string>());
        
        var bookEntity = await bookRepository.GetByIdAsync(request.BookId);
        if (bookEntity == null)
            return Result<string>.Fail("Книга с данным идентификатором не найдена!");

        if (bookEntity.Quantity == 0)
            return Result<string>.Fail("В данный момент эта книга недоступна!");

        var orderEntity = new OrderEntity {
            UserId = currentUserId,
            BookId = request.BookId,
            StatusId = (int)Status.WaitingTaking,
            TakenFrom = request.TakenFrom.ToUniversalTime(),
            TakenTo = request.TakenTo.ToUniversalTime()
        };

        bookEntity.Quantity -= 1;
        bookEntity.Updated = DateTime.UtcNow;
        await bookRepository.UpdateAsync(bookEntity);
        await orderRepository.CreateAsync(orderEntity);
        return Result<string>.Success("Книга успешно взята в использование!");
    }
}