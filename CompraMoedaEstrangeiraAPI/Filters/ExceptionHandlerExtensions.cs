using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Filters;

namespace CompraMoedaEstrangeiraAPI.Filters
{
	public static class ExceptionHandlerExtensions
	{
		public static void UseGlobalExceptionHandler(this IApplicationBuilder app)
		{
			app.UseExceptionHandler(builder =>
			{
				builder.Run(async context =>
				{
					var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();

					if (exceptionHandlerFeature != null)
					{						

						context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
						context.Response.ContentType = "application/json";

						var json = new
						{
							context.Response.StatusCode,
							Message = exceptionHandlerFeature.Error.Message
						};

						await context.Response.WriteAsync(JsonConvert.SerializeObject(json));
					}
				});
			});
		}
	}
}
