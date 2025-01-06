using SoundBoard.Repository;
using SoundBoard.Repository.Interface;

namespace SoundBoard.Repository
{
    public class SoundFileRepository : Repository<SoundFile>, ISoundFileRepository
    {
        public SoundFileRepository(DataContext context) : base(context)
        {
        }
    }
}
