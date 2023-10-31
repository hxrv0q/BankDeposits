using Microsoft.AspNetCore.Components;

namespace BankDeposits.Blazor.Components;

public partial class ListBase<T> : ComponentBase where T : class
{
    [Parameter]
    public IEnumerable<T>? Items { get; set; }

    [Parameter]
    public RenderFragment<ListModelContext<T>> RowContent { get; set; } = default!;

    [Parameter]
    public RenderFragment? TableHeader { get; set; }

    private IEnumerable<ListModelContext<T>>? IndexedItems => Items?.Select((item, index) => new ListModelContext<T>(item, index));
}

public record ListModelContext<T>(T Model, int Index);