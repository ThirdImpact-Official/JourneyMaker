using SoundBoard.Repository.Interface;

namespace SoundBoard.Repository
{
    public class SoundLibraryRepository : Repository<SoundLibrary>, ISoundLibraryRepository
    {
        public SoundLibraryRepository(DataContext context) : base(context)
        {
        }
    }
}
