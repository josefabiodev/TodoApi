using System.ComponentModel;

namespace TodoApi.Enums
{
    public enum StatusTask
    {
        [Description("A fazer")]
        Todo = 1,
        [Description("Em andamento")]
        InProgress = 2,
        [Description("Concluído")]
        Done = 3
    }
}
