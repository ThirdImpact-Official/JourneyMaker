using SoundBoard.Repository;
using SoundBoard.Repository.Interface;

namespace SoundBoard.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {
        }
    }
}
