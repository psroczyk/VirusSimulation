namespace VirusSimulation.Abstract
{
    public interface IIterator
    {
        bool HasNext();
        CellComponent Next();
        CellComponent First();
        CellComponent Current();
    }
}
