using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;

namespace AccessSchedule.Component
{
    public partial class Minute
    {
        private MudTheme Theme = new MudTheme();
        [Parameter]
        public string Position { get; set; } = string.Empty;
        [Parameter]
        public string Idx { get; set; } = string.Empty;
        [Parameter]
        public int? Number { get; set; } = null;

        [Parameter]
        public bool IsSelected { get; set; }

        [Parameter]
        public EventCallback<string> OnMouseDown { get; set; }

        [Parameter]
        public EventCallback<string> OnMouseEnter { get; set; }

        [Parameter]
        public EventCallback OnMouseUp { get; set; }

        private string GetClass()
        {
            string large = Number is not null ? " large large-position" : " small-position";
            return $"tick{large}";
        }
        private string GetStyle()
        {
            string selected = IsSelected ? $" background-color:{Theme.Palette.SuccessLighten};" : "";
            string border = Number == 0 ? " border-top:solid;border-left:solid;border-bottom:solid;" : Number == 24 ? " border-top:solid;border-right:solid;border-bottom:solid;" : " border-top:solid;border-bottom:solid;";

            return $"width:8px; {selected}{border}";
        }

        private async Task HandleMouseDown(MouseEventArgs e)
        {
            if (e.CtrlKey && e.Button == 0)
            {
                await OnMouseDown.InvokeAsync(Idx);
            }
        }

        private async Task HandleMouseEnter(MouseEventArgs e)
        {
            if (e.CtrlKey && e.Button == 0)
            {
                await OnMouseEnter.InvokeAsync(Idx);
            }
        }

        private async Task HandleMouseUp()
        {
            await OnMouseUp.InvokeAsync();
        }
    }
}