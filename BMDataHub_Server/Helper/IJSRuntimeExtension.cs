using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;


namespace BMDataHub_Server.Helper
{

    public static class IJSRuntimeExtension
    {
        private const string Identifier = "ShowToastr";

        public static async ValueTask ToastrSuccess(this IJSRuntime JSRuntime, string message)
        {
            await JSRuntime.InvokeVoidAsync(Identifier, "success", "Success");

        }
        public static async ValueTask ToastrError(this IJSRuntime JSRuntime, string message)

        {
            await JSRuntime.InvokeVoidAsync(Identifier, "error","Error Message");
    }
}
}
