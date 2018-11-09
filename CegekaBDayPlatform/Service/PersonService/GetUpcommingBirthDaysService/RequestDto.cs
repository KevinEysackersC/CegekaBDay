
namespace CegekaBDayPlatform.Service.PersonService.GetUpcommingBirthDaysService
{
    public class RequestDto
    {
        public int NumberOfPersons { get; set; }

        public static bool IsValid(RequestDto dto)
        {
            if (dto == null)
            {
                return false;
            }

            return true;
        }
    }
}
