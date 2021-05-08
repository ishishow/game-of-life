using Lifegame;

namespace Lifegame.Rules
{
    public interface IRule
    {
        bool NextAlive(Cell cell);
    }
}