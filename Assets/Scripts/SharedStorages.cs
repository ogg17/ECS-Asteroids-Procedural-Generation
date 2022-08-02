public class SharedStorages
{
    public CoreStorage CoreStorage { get; set; }

    public SharedStorages(CoreStorage coreStorage)
    {
        CoreStorage = coreStorage;
    }
}