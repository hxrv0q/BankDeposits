using BankDeposits.Domain.Services;
using BankDeposits.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BankDeposits.Blazor.Components;

public sealed class ModelList<T> : ComponentBase where T : class
{
    [Parameter]
    public RenderFragment? TableHeader { get; set; }

    [Parameter]
    public RenderFragment<T>? TableBody { get; set; }

    [Parameter]
    public IEnumerable<T>? Items { get; set; }

    protected override void OnInitialized() => Items = new List<T>();

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        base.BuildRenderTree(builder);

        if (Items is not null && Items.Any())
        {
            builder.OpenElement(0, "table");
            builder.AddAttribute(1, "class", "table table-striped table-hover");

            builder.OpenElement(2, "thead");
            builder.AddAttribute(3, "class", "thead-dark");
            builder.AddContent(4, TableHeader);
            builder.CloseElement();

            builder.OpenElement(5, "tbody");
            foreach (var item in Items)
            {
                builder.OpenElement(6, "tr");
                builder.AddContent(7, TableBody?.Invoke(item));
                builder.CloseElement();
            }

            builder.CloseElement();

            builder.CloseElement();
        }
        else
        {
            builder.OpenElement(0, "div");
            builder.AddAttribute(1, "class", "alert alert-info");
            builder.AddContent(2, "No data");
            builder.CloseElement();
        }
    }
}