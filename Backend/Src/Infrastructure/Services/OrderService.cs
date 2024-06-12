namespace Infrastructure.Services;

public class OrderService(
    IHttpContextAccessor httpContextAccessor,
    IOrderRepository orderRepository,
    IBookRepository bookRepository)
    : IOrderService
{
    public async Task<Result<int>> GetOrdersCountAsync()
    {
        var ordersCount = await orderRepository.GetCountAsync();
        return Result<int>.Success(ordersCount, "Кол-во заказов успешно получены.");
    }

    public async Task<Result<PaginatedData<OrderResponse>>> GetPaginatedOrdersAsync(int pageNumber, int pageSize)
    {
        var (ordersEntities, totalCount) = await orderRepository
            .GetPaginatedOrdersAsync(pageNumber, pageSize);
        var ordersResponse = ordersEntities.Select(orderEntity => 
            new OrderResponse
            {
                Id = orderEntity.Id,
                Username = orderEntity.User.Username,
                BookTitle = orderEntity.Book.Title,
                Status = orderEntity.Status.Name,
                StatusId = orderEntity.StatusId,
                TakenFrom = orderEntity.TakenFrom,
                TakenTo = orderEntity.TakenTo,
                Created = orderEntity.Created
            }).ToList();
        return Result<PaginatedData<OrderResponse>>
            .Success(new PaginatedData<OrderResponse>(
                List: ordersResponse, TotalCount: totalCount));
    }

    public async Task<Result<PaginatedData<OrderResponse>>> GetPaginatedOrdersByUserIdAsync(Guid id, int pageNumber, int pageSize)
    {
        var (ordersEntities, totalCount) = await orderRepository
            .GetPaginatedOrdersByUserIdAsync(id,pageNumber, pageSize);
        var ordersResponse = ordersEntities.Select(orderEntity => 
            new OrderResponse
            {
                Id = orderEntity.Id,
                Username = orderEntity.User.Username,
                BookTitle = orderEntity.Book.Title,
                Status = orderEntity.Status.Name,
                StatusId = orderEntity.StatusId,
                TakenFrom = orderEntity.TakenFrom,
                TakenTo = orderEntity.TakenTo,
                Created = orderEntity.Created
            }).ToList();
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
            new OrderResponse
            {
                Id = orderEntity.Id,
                Username = orderEntity.User.Username,
                BookTitle = orderEntity.Book.Title,
                Status = orderEntity.Status.Name,
                StatusId = orderEntity.StatusId,
                TakenFrom = orderEntity.TakenFrom,
                TakenTo = orderEntity.TakenTo,
                Created = orderEntity.Created
            }).ToList();
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
    
    public async Task<Result> DeleteAsync(Guid id)
    {
        var orderEntity = await orderRepository.GetByIdAsync(id);
        if (orderEntity == null)
            return Result<string>.Fail("Заказ с данным идентификатором не найден!");

        await orderRepository.DeleteAsync(orderEntity);
        return Result<string>.Success("Заказ успешно удалён.");
    }

    public async Task<Result> ChangeOrderStatusRequest(Guid id, ChangeOrderStatusRequest request)
    {
        var orderEntity = await orderRepository.GetByIdAsync(id);
        if (orderEntity == null)
            return Result<string>.Fail("Заказ с данным идентификатором не найден!");

        orderEntity.StatusId = request.StatusId;
        orderEntity.Updated = DateTime.UtcNow;
        await orderRepository.UpdateAsync(orderEntity);
        return Result<string>.Success("Статус успешно сменён.");
    }

    public async Task<Result> ExtendOrderAsync(Guid id, ExtendOrderRequest request)
    {
        var orderEntity = await orderRepository.GetByIdAsync(id);
        if (orderEntity == null)
            return Result<string>.Fail("Заказ с данным идентификатором не найден!");

        orderEntity.TakenTo = orderEntity.TakenTo.AddDays(request.DaysCount);
        orderEntity.StatusId = (int)Status.ExtendWaiting;
        orderEntity.Updated = DateTime.UtcNow;
        await orderRepository.UpdateAsync(orderEntity);
        return Result<string>.Success("Заявка на продление книги успешно отправлена!");
    }

 
}