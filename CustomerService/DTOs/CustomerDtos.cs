namespace CustomerService.DTOs
{
    public class CustomerDtos
    {
        public record CreateCustomerRequest(
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber);

        public record UpdateCustomerRequest(
            string FirstName,
            string LastName,
            string Email,
            string PhoneNumber);
    }
}
