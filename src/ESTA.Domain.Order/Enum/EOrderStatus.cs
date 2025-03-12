namespace ESTA.Domain.Order.Enum;

public enum EOrderStatus
{
    Created = 0,
    Approved = 1,
    Dispatched = 2,
    OutForDelivery = 3,
    Delivered = 4,
    Canceled = 5
}
