using MediatR;

namespace CarWorkshop.Application.CarWorkshop.Queries.GetAllCarWorkshops
{
    public class GetAllCarWorkshopsQuery: IRequest<IEnumerable<CarWorkshopDto>>//jakiego typu bedzie odp kwerendy, jaki typ chcemy zwrocic
    {
    }
}
