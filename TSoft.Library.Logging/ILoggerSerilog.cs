using Serilog.Core;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using TSoft.Library.Core.Logging;

namespace TSoft.Library.Logging
{
	/// <summary> Interface for logger. </summary>
	/// <seealso cref="T:ILoggerFacade"/>
	public interface ISeriLogger : ILogger, Serilog.ILogger
	{
		#region [Methods Implementation]
		///// <summary> For context. </summary>
		///// <param name="propertyName"> Name of the property. </param>
		///// <param name="value"> The value. </param>
		///// <param name="destructureObjects"> true to destructure objects. </param>
		///// <returns> A Serilog.ILogger. </returns>
		///// <seealso cref="M:TSoft.Library.Logging.ILogger.ForContext(string,object,bool)"/>
		//Serilog.ILogger ForContext(string propertyName, object value, bool destructureObjects = false);

		///// <summary> For context. </summary>
		///// <param name="source"> Source for the. </param>
		///// <returns> A Serilog.ILogger. </returns>
		///// <seealso cref="M:TSoft.Library.Logging.ILogger.ForContext(Type)"/>
		//Serilog.ILogger ForContext(Type source);

		///// <summary> For context. </summary>
		///// <param name="enrichers"> The enrichers. </param>
		///// <returns> A Serilog.ILogger. </returns>
		///// <seealso cref="M:TSoft.Library.Logging.ILogger.ForContext(IEnumerable{ILogEventEnricher})"/>
		//Serilog.ILogger ForContext(IEnumerable<ILogEventEnricher> enrichers);

		///// <summary> For context. </summary>
		///// <typeparam name="TSource"> Type of the source. </typeparam>
		///// <returns> A Serilog.ILogger. </returns>
		///// <seealso cref="M:TSoft.Library.Logging.ILogger.ForContext{TSource}()"/>
		//Serilog.ILogger ForContext<TSource>();

		///// <summary> Writes. </summary>
		///// <param name="logEvent"> The log event to write. </param>
		///// <seealso cref="M:TSoft.Library.Logging.ILogger.Write(LogEvent)"/>
		//void Write(LogEvent logEvent);
		#endregion
	}
}
