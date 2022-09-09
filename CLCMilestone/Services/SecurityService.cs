using CLCMilestone.Models;

namespace CLCMilestone.Services
{
    public class SecurityService
    {
        SecurityDAO securityDAO = new SecurityDAO();
        public bool isValid(Login User)
        {
            return securityDAO.FindUserByNameAndPassword(User);
        }
    }
}
