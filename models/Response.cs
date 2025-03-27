using IPS_survey.ENUMS;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IPS_survey.models
{
    /// <summary>
    /// Response used for returning a result object
    /// </summary>
    /// <typeparam name="T">The result object to return</typeparam>
    public class Response<T> : Response
        where T : class
    {
        /// <summary>
        /// Indicates if the response contains a result
        /// </summary>
        public override bool HasResult
        {
            get
            {
                return this.Result != null;
            }
        }

        /// <summary>
        /// The result of the response
        /// </summary>
        public new T? Result
        {
            get
            {
                return base.Result as T;
            }

            set
            {
                base.Result = value;
            }
        }

        /// <summary>
        /// Creates a successful response with a given result object
        /// </summary>
        /// <param name="result">The result object to return with the response</param>
        /// <returns>The response object</returns>
        public static Response<T> Success(T result)
        {
            var response = new Response<T> { ResultType = ResultTypeEnum.Success, Result = result, ResponseTime = DateTime.UtcNow.AddHours(1) };

            return response;
        }

        /// <summary>
        /// Creates a failed result. It takes no result object
        /// </summary>
        /// <param name="errorMessage">The error message returned with the response</param>
        /// <param name="errors">The errors returned with the response</param>
        /// <returns>The created response object</returns>
        public new static Response<T> Failed(string errorMessage, List<Error> errors)
        {
            var response = new Response<T> { ResultType = ResultTypeEnum.Error, Message = errorMessage, ErrorMessages = errors, ResponseTime = DateTime.UtcNow.AddHours(1) };

            return response;
        }



        /// <summary>
        /// Creates a validation error response, indicating the input was invalid
        /// </summary>
        /// <param name="validationMessages">The validation message</param>
        /// <returns>The Response object</returns>
        public new static Response<T> ValidationError(List<Error> validationMessages)
        {
            var response = new Response<T> { ResultType = ResultTypeEnum.ValidationError, Message = "Response has validation errors", ErrorMessages = validationMessages, ResponseTime = DateTime.UtcNow.AddHours(1) };

            return response;
        }

        /// <summary>
        /// Creates a warning result. The warning result is successful, but might have issues that should be addressed or logged
        /// </summary>
        /// <param name="warningMessage">The warning returned with the response</param>
        /// <param name="result">The result object</param>
        /// <returns>The created response object</returns>
        public static Response<T> Warning(string warningMessage, T result)
        {
            var response = new Response<T>
            {
                ResultType = ResultTypeEnum.Warning,
                Message = warningMessage,
                Result = result,
                ResponseTime = DateTime.UtcNow.AddHours(1)
            };

            return response;
        }

        /// <summary>
        /// Creates an empty result. The empty result is successful, but might have issues that should be addressed or logged
        /// </summary>
        /// <returns>The created response object</returns>
        public static new Response<T> Empty()
        {
            var response = new Response<T> { ResultType = ResultTypeEnum.Empty, ResponseTime = DateTime.UtcNow.AddHours(1) };

            return response;
        }

    }

    /// <summary>
    /// A simple response object with no returned object. Just indicates successful or failed requests
    /// </summary>
    public class Response
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Response"/> class. 
        /// </summary>
        public Response()
        {
            this.ResultType = ResultTypeEnum.Success;
        }

        /// <summary>
        /// Indicates if the response contains a result
        /// </summary>
        public virtual bool HasResult
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// The result of the response
        /// </summary>
        public object Result { get; protected set; }

        /// <summary>
        /// Indicates if the response is successful or not. Warning or success result type indicate success
        /// </summary>
        public bool Successful
        {
            get
            {
                return this.ResultType == ResultTypeEnum.Success || this.ResultType == ResultTypeEnum.Warning;
            }
        }

        /// <summary>
        /// The result type
        /// </summary>
        public ResultTypeEnum ResultType { get; set; }

        /// <summary>
        /// The message returned with the response
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The validation error messages returned with the response
        /// </summary>
        public List<Error> ErrorMessages { get; set; }
        /// <summary>
        /// The time the request came in
        /// </summary>
        public DateTime RequestTime { get; set; } = DateTime.UtcNow;
        /// <summary>
        /// The time response was shared
        /// </summary>
        public DateTime ResponseTime { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Creates a successful response with a given result object
        /// </summary>
        /// <returns>The response object</returns>
        public static Response Success()
        {
            var response = new Response { ResultType = ResultTypeEnum.Success };

            return response;
        }

        /// <summary>
        /// Creates a failed result. It takes no result object
        /// </summary>
        /// <param name="errorMessage">The error message returned with the response</param>
        /// <param name="errors">The list of errors that occurred</param>
        /// <returns>The created response object</returns>
        public static Response Failed(string errorMessage, List<Error> errors)
        {
            var response = new Response { ResultType = ResultTypeEnum.Error, Message = errorMessage, ErrorMessages = errors };

            return response;
        }

        /// <summary>
        /// Creates a validation error response, indicating the input was invalid
        /// </summary>
        /// <param name="validationMessages">The validation message</param>
        /// <returns>The Response object</returns>
        public static Response ValidationError(List<Error> validationMessages)
        {
            var response = new Response { ResultType = ResultTypeEnum.ValidationError, ErrorMessages = validationMessages };

            return response;
        }

        /// <summary>
        /// Creates a warning result. The warning result is successful, but might have issues that should be addressed or logged
        /// </summary>
        /// <param name="warningMessage">The warning returned with the response</param>
        /// <returns>The created response object</returns>
        public static Response Warning(string warningMessage)
        {
            var response = new Response { ResultType = ResultTypeEnum.Warning, Message = warningMessage };

            return response;
        }

        /// <summary>
        /// Creates a validation error response, indicating the input was invalid
        /// </summary>
        /// <param name="customerInformationMessage">The validation message</param>
        /// <returns>The Response object</returns>
        public static Response CustomerInformation(string customerInformationMessage)
        {
            var response = new Response
            {
                ResultType = ResultTypeEnum.CustomerInformation,
                Message = customerInformationMessage
            };

            return response;
        }

        /// <summary>
        /// Creates an empty result. The empty result is successful, but might have issues that should be addressed or logged
        /// </summary>
        /// <returns>The created response object</returns>
        public static Response Empty()
        {
            var response = new Response { ResultType = ResultTypeEnum.Empty };

            return response;
        }
    }
}
