using BankDeposits.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BankDeposits.Blazor.Components;

public sealed class ModelList<T> : ComponentBase where T : class
{
    [Inject]
    public IService<T> Service { get; set; }

    [Parameter]
    public RenderFragment TableHeader { get; set; }

    [Parameter]
    public RenderFragment<T> TableBody { get; set; }

    [Parameter]
    public IReadOnlyList<T> Items { get; set; }

    protected override async Task OnInitializedAsync() => Items = (IReadOnlyList<T>)await Service.GetAllAsync();

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        base.BuildRenderTree(builder);

        if (Items.Any())
        {
            builder.OpenElement(0, "table");
            builder.AddAttribute(1, "class", "table table-striped table-hover");

            builder.OpenElement(2, "thead");
            builder.AddContent(3, TableHeader);
            builder.CloseElement();

            builder.OpenElement(4, "tbody");
            foreach (var item in Items)
            {
                builder.OpenElement(5, "tr");
                builder.AddContent(6, TableBody(item));
                builder.CloseElement();
            }

            builder.CloseElement();

            builder.CloseElement();
        }
        else
        {
            builder.OpenElement(0, "div");
            builder.AddAttribute(1, "class", "alert alert-info");
            builder.AddContent(2, "No data to display");
            builder.CloseElement();
        }
    }
}